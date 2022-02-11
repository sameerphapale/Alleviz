using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VisitorManagementSystemWebApi.App_Code;
using VisitorManagementSystemWebApi.App_Code.DAL.Master;
using static VisitorManagementSystemWebApi.Model.Master.Employee;

namespace VisitorManagementSystemWebApi.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/{Action}")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeDal Empdal;

        public EmployeeController(IConfiguration Configuration)
        {
            SqlHelper helper = new SqlHelper(Configuration);
            Empdal = new EmployeeDal();
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

        public ActionResult InsertEmployeeBulkUpload([FromBody] BulkEmployee bulkEmployee)
        {
            Int32 Result = 0;
            try
            {
                Result = Empdal.InsertEmployeeBulkData(bulkEmployee);

                return Ok(Result);
            }
            catch (Exception) { return Ok(-1); }
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
