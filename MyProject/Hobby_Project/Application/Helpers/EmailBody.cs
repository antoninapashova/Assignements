using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Helpers
{
    public static class EmailBody
    {
        public static string EmailStringBody(string email, string emailToken)
        {
            return $@"
                      <body>
                          <div>  
                              <h1>Reset password</h1>
                               <p>Please follow the link below to choose a new password.</p> 
                               <a href=""http://localhost:4200/reset?email={email}&code={emailToken}"">Reset password</a>
                                <p>Kind regards, Hobby blog app</p>
                          </div>
                     </body>
              ";
        }
    }
}
