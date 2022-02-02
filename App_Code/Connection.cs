using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VisitorManagementSystemWebApi.App_Code;

namespace VisitorManagementSystemWebApi.App_Code
{


    public class Connection
    {

        private IConfiguration Configuration;
        public Connection()
        {
        
        }
        public Connection(IConfiguration _configuration)
        {
            Configuration = _configuration;

        }

       

       
    }
}
