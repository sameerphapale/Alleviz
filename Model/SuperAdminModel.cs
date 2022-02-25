using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorManagementSystemWebApi.Model
{
    public class SuperAdminModel
    {
        public int NoofGates { get; set; }
        public string MacID { get; set; }
        public string SMSSending { get; set; }
        public int SMSPackage { get; set; }
        public string EmailSending { get; set; }
        public string EnableSSL { get; set; }
        public string SenderEmail { get; set; }
        public string SMTPServer { get; set; }
        public string EmailUsername { get; set; }
        public string EmailPassword { get; set; }
        public int PortNO { get; set; }
    }
}
