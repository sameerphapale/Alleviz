using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorManagementSystemWebApi.App_Code;
using VisitorManagementSystemWebApi.App_Code.DAL;
using VisitorManagementSystemWebApi.Model;

namespace VisitorManagementSystemWebApi.Controllers
{
    [Route("api/[controller]/{Action}")]
    [ApiController]
    public class SmsController : Controller
    {
        SMSDAL objsmsdal = new SMSDAL();
        public SmsController(IConfiguration Configuration)
        {
            SqlHelper helper = new SqlHelper(Configuration);
        }

        [HttpPost]
        public ActionResult SendSMSEPass([FromBody] SMSModel obj)
        {
            Int32 SID = 0;
            try
            {
                SID = objsmsdal.InsertSMSDetails(obj);
                if (SID > 0)
                {
                    objsmsdal.SendEPassSMS(obj);
                }
                return Ok(SID);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Ok(-1);
            }
        }

    }
}
