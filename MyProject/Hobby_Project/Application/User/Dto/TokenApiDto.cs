﻿namespace HobbyProject.Application.User.Dto
{
    public class TokenApiDto
    {
        public int UserId { get; set; }
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
