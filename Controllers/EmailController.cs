using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorManagementSystemWebApi.App_Code;
using VisitorManagementSystemWebApi.App_Code.DAL;
using VisitorManagementSystemWebApi.Model.Visitor;
using VisitorManagementSystemWebApi.Services;
using static VisitorManagementSystemWebApi.Model.EmailModel;
using static VisitorManagementSystemWebApi.Model.Master.Employee;

namespace VisitorManagementSystemWebApi.Controllers
{
    [Route("api/[controller]/{Action}")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly IMailService objmailService;
        EmailDAL objemail = new EmailDAL();
        SMSDAL objsms = new SMSDAL();

        public EmailController(IConfiguration Configuration, IMailService mailService)
        {
            SqlHelper helper = new SqlHelper(Configuration);
            this.objmailService = mailService;
        }

        [HttpPost]
        public ActionResult SendApprovalEmailFirstLevel([FromBody] EmailRequest obj)
        {
            Int32 Result = 0;
            Int32 SID = 0;
            try
            {
                Result = objemail.InsertApprovalEmailDataFirstLevel(obj);
                if (Result > 0)
                {

                    SID = objmailService.SendEmail(Result);
                    // if (SID > 0)
                    //objsms.SendSMS(SID);
                }
                return Ok(Result);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Ok(-1);
            }
        }

        [HttpPost]
        public ActionResult SendApprovalEmailAllLevel([FromBody] EmailRequest obj)
        {
            Int32 Result = 0;
            Int32 SID = 0;
            try
            {
                Result = objemail.InsertHostEmailData(obj);
                if (Result > 0)
                {
                    Result = objemail.InsertApprovalEmailDataAllLevel(obj);
                    if (Result > 0)
                    {

                        SID = objmailService.SendEmail(Result);
                        // if (SID > 0)
                        //objsms.SendSMS(SID);
                    }
                }
                return Ok(Result);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Ok(-1);
            }
        }

        [HttpPost]
        public ActionResult SendVisitorEmailSMSConfirm([FromBody] EmailRequest obj)
        {
            Int32 Result = 0;
            Int32 SID = 0;
            try
            {

                Result = objemail.InsertVisitorSMSEmailConfirm(obj);
                if (Result > 0)
                {
                    if (obj.AppTypeID == 1)
                    {
                        SID = objmailService.SendEmail(Result);
                        if (SID > 0)
                            objsms.SendSMS(SID);
                    }
                    else
                    {
                        objsms.SendSMS(Result);
                    }
                }
                return Ok(Result);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Ok(-1);
            }
        }

        [HttpPost]
        public ActionResult SendInternalMeetingEmail([FromBody] EmailRequest obj)
        {
            Int32 EID = 0;
            try
            {
                EID = objemail.InsertMeetingEmailData(obj);
                if (EID > 0)
                {
                    objmailService.SendEmail(EID);
                }
                return Ok(EID);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Ok(-1);
            }
        }


        [HttpPost]
        public ActionResult SendEmployeeEmail([FromBody] EmailRequest obj)
        {
            Int32 EID = 0;
            string Result = "OK";
            try
            {
                EID = objemail.InsertEmployeeEmailData(obj);
                if (EID > 0)
                {
                    Result = objmailService.SendEmailReturnString(EID);
                    return Ok(Result);
                }
                return Ok(EID);
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
                return Ok(Result);
            }
        }

    }
}
