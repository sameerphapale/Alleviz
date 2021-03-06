using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VisitorManagementSystemWebApi.Services;
using VisitorManagementSystemWebApi.App_Code;
using VisitorManagementSystemWebApi.App_Code.DAL;
using VisitorManagementSystemWebApi.App_Code.DAL.Master;
using static VisitorManagementSystemWebApi.Model.EmailModel;
using static VisitorManagementSystemWebApi.Model.Master.Employee;
using IMailService = VisitorManagementSystemWebApi.Services.IMailService;

namespace VisitorManagementSystemWebApi.Controllers
{

    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/{Action}")]
    [ApiController]


    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        EmployeeDal Empdal;
        EmailDAL objemail = new EmailDAL();
        SMSDAL objsms = new SMSDAL();
        EmailRequest objemailmodel = new EmailRequest();
        private readonly IMailService objmailService;

        public EmployeeController(IConfiguration Configuration, ILogger<EmployeeController> logger, IMailService mailService)
        {
            SqlHelper helper = new SqlHelper(Configuration);
            Empdal = new EmployeeDal();
            _logger = logger;
            this.objmailService = mailService;
        }


        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult InsertEmployeeEntry([FromBody] InsertEmployee insertEmployee)
        {
            Int32 Result = 0;
            try
            {
                Result = Empdal.InsertEmployeeData(insertEmployee);

                return Ok(Result);
            }
            catch (Exception) { return Ok(-1); }
        }
   
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult InsertEmployeeBulkUpload([FromBody] BulkEmployee[] bulkEmployee)
        {
            String Result = "";
            try
            {
                Result = Empdal.EmployeeBulkData(bulkEmployee);
                return Ok(Result);
            }
            catch (Exception) { return Ok(Result); }
        }

        [HttpPost]
        public ActionResult EmpDetailsChecked([FromBody] MultipleUser users)
        {
            try
            {
                return Ok(Empdal.CheckData(users));
            }
            catch (Exception) { return Ok(-1); }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetEmployeeDeatils()
        {
            try
            {
                return Ok(Empdal.GetEmployeeDeatils());
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetEmployeeDeatilsByID(long EMPSRNO)
        {
            try
            {
                return Ok(Empdal.GetEmployeeDeatilsByID(EMPSRNO));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetRoleDeatils()
        {
            try
            {
                return Ok(Empdal.GetRoleDeatils());
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult UpdateEmployeeDetails([FromForm] UpdateEmployee updateEmployee)
        {
            try
            {
                return Ok(Empdal.UpdateEmployeeDetails(updateEmployee));
            }

            catch (Exception) { return null; }
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult RemoveEmployee(Int64 EMPSRNO)
        {
            try
            {
                return Ok(Empdal.RemoveEmployee(EMPSRNO));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult CheckEmpMNo(long ContactNo)
        {
            try
            {
                return Ok(Empdal.CheckEmpMNo(ContactNo));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult CheckEmpEmail(string Email)
        {
            try
            {
                return Ok(Empdal.CheckEmpEmail(Email));
            }

            catch (Exception) { return null; }
        }


        [HttpGet]
        //[Authorize(Roles = "Admin , Cadet")]
        public ActionResult GetEmpProfileDetails(string User_Name)
        {
            try
            {
                return Ok(Empdal.GetEmpProfileDetails(User_Name));
            }

            catch (Exception) { return null; }
        }
    }
}
