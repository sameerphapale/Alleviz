using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorManagementSystemWebApi.Model
{
    public class SuperAdminModel
    {
        public Int64 NoofGates { get; set; }
        public Int64 ID { get; set; }
        public string MacID { get; set; }
        public string SMSSending { get; set; }
        public int SMSPackage { get; set; }
        public string EmailSending { get; set; }
        public DateTime ToDate { get; set; }
        public string SenderEmail { get; set; }
        public string SMTPServer { get; set; }
        public string EmailUsername { get; set; }
        public string EmailPassword { get; set; }
        public Int64 PortNO { get; set; }




    }
    public class SuperAdminSMSCountModel
    {
        public Int64 Total { get; set; }
        public Int64 Used { get; set; }
        public Int64 Available { get; set; }
    }
}
