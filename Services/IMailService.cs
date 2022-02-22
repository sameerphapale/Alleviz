using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static VisitorManagementSystemWebApi.Model.EmailModel;

namespace VisitorManagementSystemWebApi.Services
{
    public interface IMailService
    {
        public void SendEmail(Int64 EID);
    }
}
