﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICurrentUserService
    {
        string GetUserEmail();
        Guid GetUserId();
        string GetRole();
    }
}
