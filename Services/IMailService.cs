using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static VisitorManagementSystemWebApi.Model.EmailModel;

namespace VisitorManagementSystemWebApi.Services
{
    public interface IMailService
    {
        public Int32 SendEmail(Int64 EID);

        public string SendEmailReturnString(Int64 EID);

        public Int32 SendQRCodeEmail(Int64 EID, Int64 MeetID);

    }
}
