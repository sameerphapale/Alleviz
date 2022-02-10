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
using VisitorManagementSystemWebApi.Model.Visitor;
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

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult InsertVisitorAppointmenntData([FromBody] Appointment AppointmentInsert)
        {
            Int32 Result = 0;
            try
            {
                Result = Appdal.InsertVisitorAppointmenntData(AppointmentInsert);

                return Ok(Result);
            }
            catch (Exception) { return Ok(-1); }
        }

        [HttpPost]
        public ActionResult InsertCoVisitorEntry([FromBody] Appointment AppointmentInsert)
        {
            Int32 Result = 0;
            try
            {
                Result = Appdal.InsertCoVisitorData(AppointmentInsert);

                return Ok(Result);
            }
            catch (Exception) { return Ok(-1); }
        }

        [HttpPost]

        public ActionResult InsertVisitorImg([FromForm] VisiImageUpload visiImageUpload)
        {

            try
            {
                // Saving Image on Server
                if (visiImageUpload.FileData.Length > 0)
                {
                    return Ok(CommonFunctionLogic.SaveImageInDatabase(visiImageUpload.FileData, visiImageUpload.AppID));
                }
                else
                {
                    return Ok("0");
                }
            }
            catch (Exception ex)
            {
                return Ok("-1");
            }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult UpdateSheduledVisitorDetails([FromForm] Appointment AppointmentInsert)
        {
            try
            {
                return Ok(Appdal.UpdateSheduledVisitorDetails(AppointmentInsert));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]

        public ActionResult GetTodaySheduledAppDetails()
        {
            try
            {
                return Ok(Appdal.GetTodaySheduledAppDetails());
            }

            catch (Exception) { return null; }
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

        [HttpGet]

        public ActionResult GetPeriodicPassDetails()
        {
            try
            {
                return Ok(Appdal.GetPeriodicPassDetails());
            }

            catch (Exception) { return null; }
        }

        [HttpGet]

        public ActionResult GetDailyOutPassDetails()
        {
            try
            {
                return Ok(Appdal.GetDailyOutPassDetails());
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetAppointmentDeatilsByID(long AppID)
        {
            try
            {
                return Ok(Appdal.GetAppointmentDeatilsByID(AppID));
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

        public ActionResult GetPassDeatilsByVisiId(long AppID)
        {
            try
            {
                return Ok(Appdal.GetPassDeatilsByVisiId(AppID));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]

        public ActionResult GetRePrintPassDetails()
        {
            try
            {
                return Ok(Appdal.GetRePrintPassDetails());
            }

            catch (Exception) { return null; }
        }

        [HttpGet]

        public ActionResult GetVisitorDetailsForBlack()
        {
            try
            {
                return Ok(Appdal.GetVisitorDetailsForBlack());
            }

            catch (Exception) { return null; }
        }

        [HttpGet]

        public ActionResult GetBlackVisitorDetails()
        {
            try
            {
                return Ok(Appdal.GetBlackVisitorDetails());
            }

            catch (Exception) { return null; }
        }


        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult BlackVisitor(long AppID)
        {
            try
            {
                return Ok(Appdal.BlackVisitor(AppID));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult ExitVisitor(long AppID)
        {
            try
            {
                return Ok(Appdal.ExitVisitor(AppID));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult DailyInVisitor(long AppID)
        {
            try
            {
                return Ok(Appdal.DailyInVisitor(AppID));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]
        public ActionResult GetPurposeDeatils()
         {
            try
            {
                return Ok(Appdal.GetPurposeDeatils());
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


        //[HttpPost]
        ////[Authorize(Roles = "Admin")]

        //public ActionResult GetAppointmentDeatilsByDate(string AppDatefrom)
        //{
        //    try
        //    {
        //        return Ok(Appdal.GetAppointmentDeatilsByDate(AppDatefrom));
        //    }

        //    catch (Exception) { return null; }
        //}

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
