using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorManagementSystemWebApi.Model
{
    public class SMSModel
    {
        public Int64 SID { get; set; }
        public string SFrom { get; set; }
        public string STo { get; set; }
        public string SCc { get; set; }
        public string SSubject { get; set; }
        public string SMessage { get; set; }
        public DateTime SCreatedOn { get; set; }
        public DateTime SSendOn { get; set; }
        public Int64 AppID { get; set; }

        public Int64 Status { get; set; }

    }
}
