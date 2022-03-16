using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VisitorManagementSystemWebApi.App_Code;
using VisitorManagementSystemWebApi.App_Code.DAL;
using VisitorManagementSystemWebApi.App_Code.DAL.Visitor;
using VisitorManagementSystemWebApi.Model.Visitor;
using VisitorManagementSystemWebApi.Services;
using static VisitorManagementSystemWebApi.Model.EmailModel;
using static VisitorManagementSystemWebApi.Model.Visitor.Appointment;

namespace VisitorManagementSystemWebApi.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/{Action}")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        AppointmentDal Appdal;
        EmailDAL objemail = new EmailDAL();
        SMSDAL objsms = new SMSDAL();
        EmailRequest objemailmodel = new EmailRequest();

        private readonly IMailService objmailService;

        public AppointmentController(IConfiguration Configuration, IMailService mailService)
        {
            SqlHelper helper = new SqlHelper(Configuration);
            this.objmailService = mailService;
            Appdal = new AppointmentDal();
        }
        [HttpPost]
        public ActionResult InsertVisitorAppointmenntData([FromBody] Appointment AppointmentInsert)
        {
            Int32 EID = 0;
            Int32 SID = 0;
            Int32 Result = 0;
            try
            {
                Result = Appdal.InsertVisitorAppointmenntData(AppointmentInsert);
                if (Result > 0)
                {
                    objemailmodel.AppID = Result;
                    objemailmodel.VisiCatID = AppointmentInsert.Visi_cat_id;
                    EID = objemail.InsertVisitorSMSEmailConfirmData(objemailmodel);
                    if (EID > 0)
                    {
                        if (AppointmentInsert.AppTypeID == 1)
                        {

                            SID = objmailService.SendEmail(EID);
                            if (SID > 0)
                                objsms.SendSMS(SID);
                        }
                        else
                        {
                            objsms.SendSMS(SID);
                        }
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
        public ActionResult InsertVisitorAppointmentBulk([FromBody] VisiBulkUpload visiBulkUpload)
        {
            Int32 Result = 0;
            try
            {
                Result = Appdal.InsertVisitorAppointmentBulk(visiBulkUpload);

                return Ok(Result);
            }
            catch (Exception) { return Ok(-1); }
        }


        [HttpPost]
        public ActionResult InsertVisitorBulkUpload([FromBody] VisiBulkUpload [] visiBulkUpload)
        {
            String Result = "";
            try
            {
                Result = Appdal.InsertVisitorBulkUpload(visiBulkUpload);

                return Ok(Result);
            }
            catch (Exception) { return Ok(-1); }
        }

        [HttpPost]
        public ActionResult InsertCoVisitorEntry([FromBody] Appointment AppointmentInsert)
        {
            Int64 Result = 0;
            try
            {
                Result = Appdal.InsertCoVisitorData(AppointmentInsert);

                return Ok(Result);
            }
            catch (Exception) { return Ok(-1); }
        }

        [HttpPost]
        public ActionResult InsertMettingEntry([FromBody] Appointment AppointmentInsert)
        {
            Int64 Result = 0;
            try
            {
                Result = Appdal.InsertMettingEntry(AppointmentInsert);

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
                    return Ok(CommonFunctionLogic.SaveImageInDatabase(visiImageUpload.FileData, visiImageUpload.AppID,visiImageUpload.Covisiid));
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


        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult UpdateMettingDetails([FromForm] Appointment AppointmentInsert)
        {
            try
            {
                return Ok(Appdal.UpdateMettingDetails(AppointmentInsert));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult UpdateVisitorDetails([FromForm] Appointment AppointmentInsert)
        {
            try
            {
                return Ok(Appdal.UpdateVisitorDetails(AppointmentInsert));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]

        public ActionResult UpdatePersonalTimeLine([FromForm] Appointment AppointmentInsert)

        {
            try
            {
                return Ok(Appdal.UpdatePersonalTimeLine(AppointmentInsert));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]

        public ActionResult GetTodaySheduledAppDetails(long Empid)
        {
            try
            {
                return Ok(Appdal.GetTodaySheduledAppDetails(Empid));
            }

            catch (Exception) { return null; }
        }


        [HttpGet]

        public ActionResult SearchTodaySheduledAppDetails(string QRCode)
        {
            try
            {
                return Ok(Appdal.SearchTodaySheduledAppDetails(QRCode));
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

        public ActionResult GetPeriodicPassDetails(long Empid)
        {
            try
            {
                return Ok(Appdal.GetPeriodicPassDetails(Empid));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]

        public ActionResult GetDailyOutPassDetails(long Empid)
        {
            try
            {
                return Ok(Appdal.GetDailyOutPassDetails(Empid));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetAppointmentDeatilsByID(long AppID,long Covisiid)
         {
            try
            {
                return Ok(Appdal.GetAppointmentDeatilsByID(AppID, Covisiid));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetAppointmentDeatilsByMonth(int Month,long Empid)
        {
            try
            {
                return Ok(Appdal.GetAppointmentDeatilsByMonth(Month, Empid));
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

        [HttpGet]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetVisitorDeatilsByEmpID(long Empid)
        {
            try
            {
                return Ok(Appdal.GetVisitorDeatilsByEmpID(Empid));
            }

            catch (Exception) { return null; }
        }

        //[HttpPost]
        ////[Authorize(Roles = "Admin")]

        //public ActionResult GetAppointmentDeatilsByDept(string DeptName)
        //{
        //    try
        //    {
        //        return Ok(Appdal.GetAppointmentDeatilsByDept(DeptName));
        //    }

        //    catch (Exception) { return null; }
        //}


        [HttpGet]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetPassDeatilsByVisiId(long AppID,long Covisiid)
        {
            try
            {
                return Ok(Appdal.GetPassDeatilsByVisiId(AppID, Covisiid));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetVisitorVisitedReport(DateTime fromd, DateTime tod, string visitype, string dept, string hostname,long RoleId,long Empid)
        {
            try
            {
                return Ok(Appdal.GetVisitorVisitedReport(fromd, tod, visitype, dept, hostname, RoleId, Empid));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetHostList(string dept)
        {
            try
            {
                return Ok(Appdal.GetHostList(dept));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetHostDetails(Int64 Empid)
        {
            try
            {
                return Ok(Appdal.GetHostDetails(Empid));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetVisitorInOutPunchReport(DateTime fromd, DateTime tod, string visitype, string dept, string hostname,long RoleId, long Empid)
        {
            try
            {
                return Ok(Appdal.GetVisitorInOutPunchReport(fromd, tod, visitype, dept, hostname, RoleId,Empid));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetVisitorAppointmentReport(DateTime fromd, DateTime tod, string visitype, string dept, string hostname,long RoleId, long Empid)
        {
            try
            {
                return Ok(Appdal.GetVisitorAppointmentReport(fromd, tod, visitype, dept, hostname, RoleId, Empid));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]

        public ActionResult GetRePrintPassDetails(long Empid)
        {
            try
            {
                return Ok(Appdal.GetRePrintPassDetails(Empid));
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
        public ActionResult BlackVisitor(long AppID, long Covisiid, string Reason)
        {
            try
            {
                return Ok(Appdal.BlackVisitor(AppID, Covisiid, Reason));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult ExitVisitor(long AppID,long Covisiid)
        {
            try
            {
                return Ok(Appdal.ExitVisitor(AppID, Covisiid));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult DailyInVisitor(long AppID,long Covisiid)
        {
            try
            {
                return Ok(Appdal.DailyInVisitor(AppID, Covisiid));
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

        [HttpGet]
        public ActionResult GetMettingDeatils()
        {
            try
            {
                return Ok(Appdal.GetMettingDeatils());
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetAppointmentDeatilsByBranch(long BranchID)
        {
            try
            {
                return Ok(Appdal.GetAppointmentDeatilsByBranch(BranchID));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetPersonalAppointmentDeatilsByBranch(long BranchID,long Empid)
        {
            try
            {
                return Ok(Appdal.GetPersonalAppointmentDeatilsByBranch(BranchID, Empid));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetAppointmentDeatilsByDept(long DeptId)
        {
            try
            {
                return Ok(Appdal.GetAppointmentDeatilsByDept(DeptId));
            }

            catch (Exception) { return null; }
        }



        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetPersonalAppointmentDeatilsByDept(long DeptId,long Empid)
        {
            try
            {
                return Ok(Appdal.GetPersonalAppointmentDeatilsByDept(DeptId, Empid));
            }

            catch (Exception) { return null; }
        }



        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetMeetingDetailsById(long Id)
        {
            try
            {
                return Ok(Appdal.GetMeetingDetailsById(Id));
            }

            catch (Exception) { return null; }
        }


        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetAppointmentDeatilsByDate(string AppDatefrom ,long Empid)
        {
            try
            {
                return Ok(Appdal.GetAppointmentDeatilsByDate(AppDatefrom, Empid));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetAppointmentDeatilByDate(string AppDatefrom)
        {
            try
            {
                return Ok(Appdal.GetAppointmentDeatilByDate(AppDatefrom));
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

        public ActionResult GetPersonaltimelineStartEndTime(string AppDatefrom, long Empid)
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
                return Ok(Appdal.GetAppointmentbasicreport(DeptName, AppDatefrom));
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

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult GetVisitorCountForSecurity()
        {
            try
            {
                return Ok(Appdal.GetVisitorCountForSecurity());
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult CheckUsername(string UseName)
        {
            try
            {
                return Ok(Appdal.CheckUsername(UseName));
            }
            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult RemoveAppointment(Int64 AppID)
        {
            try
            {
                return Ok(Appdal.RemoveAppointment(AppID));
            }
            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult RemoveMetting(Int64 Id)
        {
            try
            {
                return Ok(Appdal.RemoveMetting(Id));
            }
            catch (Exception) { return null; }
        }
    }
}
