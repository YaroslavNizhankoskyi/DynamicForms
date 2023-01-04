﻿namespace Infrastructure.Helpers.Models
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int Expiry { get; set; }
    }
}
