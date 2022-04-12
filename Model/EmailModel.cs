using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorManagementSystemWebApi.Model
{
    public class EmailModel
    {
        public class MailSettings
        {
            public string Email { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }
            public string Host { get; set; }
            public int Port { get; set; }
        }


        public class EmailRequest
        {

            public Int64 EID { get; set; }
            public string EFrom { get; set; }
            public string ECc { get; set; }
            public string ESubject { get; set; }
            public string EMessage { get; set; }
            public DateTime ECreatedOn { get; set; }
            public DateTime ESendOn { get; set; }
            public Int64 AppID { get; set; }
            public Int64 VisiCatID { get; set; }
            public Int64 AppTypeID { get; set; }
            public string EmployeeList { get; set; }
            public Int64 HostID { get; set; }
            public Int64 TotalLevels { get; set; }
            public Int64 Level { get; set; }
            public string Command { get; set; }
            public string Remark { get; set; }

        }

    }
}
