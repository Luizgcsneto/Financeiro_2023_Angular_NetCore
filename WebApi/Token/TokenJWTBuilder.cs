﻿using Microsoft.IdentityModel.Tokens;

namespace WebApi.Token
{
    public class TokenJWTBuilder
    {
        private SecurityKey securityKey = null; 
        private string subject = "";
        private string audience = "";
        private string issuer = "";
        private Dictionary<string,string> claims = new Dictionary<string,string>();
        private int ExpireInMinnutes = 5;
    }
}
