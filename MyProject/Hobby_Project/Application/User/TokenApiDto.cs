﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.User
{
    public class TokenApiDto
    {
        public string AccessToken { get; set; } = string.Empty;

        public string RefreshToken { get; set;} = string.Empty;
    }
}
