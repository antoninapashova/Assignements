using Application.Logger;
using Application.Repositories;
using HobbyProject.Application.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.User.Command.ForgetPassword
{
    public class ForgetPasswordCommandHandler : IRequestHandler<ForgetPasswordCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly EmailSettings _emailSettings;
        private readonly IEmailService _emailService;
        private readonly ILog _log;

        public ForgetPasswordCommandHandler(IUnitOfWork unitOfWork, IOptions<EmailSettings> emailSettings, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _emailSettings = emailSettings.Value;
            _emailService = emailService;
            _log = SingletonLogger.Instance; ;
        }

        public EmailSettings Get() => _emailSettings;

        public async Task<string> Handle(ForgetPasswordCommand command, CancellationToken cancellationToken)
        {
            try
            {
              var user = await _unitOfWork.UserRepository.FindByEmail(command.Email);

              if (user == null) throw new NullReferenceException("User with that email does not exists!");

              var tokenBytes = RandomNumberGenerator.GetBytes(64);
              var emailToken = Convert.ToBase64String(tokenBytes);
              user.ResetPasswordToken = emailToken;
              user.ResetPasswordExpiry = DateTime.Now.AddMinutes(15);
              string from = _emailSettings.From;
              var emailModel = new EmailModel(command.Email, "Reset password!", EmailBody.EmailStringBody(command.Email, emailToken));
              _emailService.SendEmail(emailModel);
              await _unitOfWork.UserRepository.Update(user);
              await _unitOfWork.Save();
              return await Task.FromResult(user.Email);
            }catch(Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
