using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorManagementSystemWebApi.Model.Master
{
    public class Company
    {
        public class InsertCompany
        {
            public string Command { get; set; }
            public string CompName { get; set; }
        }

        public class CompanyModel
        {
         
            public long CompID { get; set; }
            public string CompName { get; set; }
            public Byte[] CompanyLogo { get; set; }
        }
        public class ImageUploadModel
        {

            public string CompName { get; set; }
            public IFormFile FileData { get; set; }
        }

    }
}
