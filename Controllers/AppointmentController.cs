using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VisitorManagementSystemWebApi.App_Code;
using VisitorManagementSystemWebApi.App_Code.DAL.Visitor;
using static VisitorManagementSystemWebApi.Model.Visitor.Appointment;

namespace VisitorManagementSystemWebApi.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/{Action}")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        AppointmentDal Appdal;

        public AppointmentController(IConfiguration Configuration)
        {
            SqlHelper helper = new SqlHelper(Configuration);
            Appdal = new AppointmentDal();
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult InsertAppointmentEntry([FromBody] AppointmentInsert AppointmentInsert)
        {
            Int32 Result = 0;
            try
            {
                Result = Appdal.InsertAppointmenntData(AppointmentInsert);

                return Ok(Result);
            }
            catch (Exception) { return Ok(-1); }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetAppointmentDeatils()
        {
            try
            {
                return Ok(Appdal.GetAppointmentDeatils());
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetAppointmentDeatilsByID(long Visiid)
        {
            try
            {
                return Ok(Appdal.GetAppointmentDeatilsByID(Visiid));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetAppointmentDeatilsByEmpID(long Empid)
        {
            try
            {
                return Ok(Appdal.GetAppointmentDeatilsByEmpID(Empid));
            }

            catch (Exception) { return null; }
        }


        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetAppointmentDeatilsByDept(string DeptName)
        {
            try
            {
                return Ok(Appdal.GetAppointmentDeatilsByDept(DeptName));
            }

            catch (Exception) { return null; }
        }


        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetPassDeatilsByVisiId(long Visiid)
        {
            try
            {
                return Ok(Appdal.GetPassDeatilsByVisiId(Visiid));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetAppointmentDeatilsByBranch(string BranchName)
        {
            try
            {
                return Ok(Appdal.GetAppointmentDeatilsByBranch(BranchName));
            }

            catch (Exception) { return null; }
        }


        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetAppointmentDeatilsByDate(string AppDatefrom)
        {
            try
            {
                return Ok(Appdal.GetAppointmentDeatilsByDate(AppDatefrom));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetAppointmentStartEndTime(string AppDatefrom)
        {
            try
            {
                return Ok(Appdal.GetAppointmentStartEndTime(AppDatefrom));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]

        public ActionResult GetPersonaltimelineStartEndTime(string AppDatefrom,long Empid)
        {
            try
            {
                return Ok(Appdal.GetPersonaltimelineStartEndTime(AppDatefrom, Empid));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetAppointmentbasicreport(string DeptName, string AppDatefrom)
        {
            try
            {
                return Ok(Appdal.GetAppointmentbasicreport(DeptName,AppDatefrom));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult GetVisitorCount(string SearchDate)
        {
            try
            {
                return Ok(Appdal.GetVisitorCount(SearchDate));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult RemoveAppointment(Int64 Visiid)
        {
            try
            {
                return Ok(Appdal.RemoveAppointment(Visiid));
            }

            catch (Exception) { return null; }
        }
    }
}
