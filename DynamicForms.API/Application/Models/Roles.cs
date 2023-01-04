﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    
    public class Roles
    {
        public const string Admin = "Admin";
        public const string User = "User";

        public enum AppRole
        {
            Admin,
            User
        }
    }



}
