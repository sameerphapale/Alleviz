﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorManagementSystemWebApi.Services
{
   public interface IMailService
    {
        public void SendingEmail(Int64 VISIID);
    }
}