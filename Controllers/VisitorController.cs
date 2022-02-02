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
using static VisitorManagementSystemWebApi.Model.Visitor.Visitor;

namespace VisitorManagementSystemWebApi.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/{Action}")]
    [ApiController]
    public class VisitorController : ControllerBase
    {

        VisitorDal visitordal;

        public VisitorController(IConfiguration Configuration)
        {
            SqlHelper helper = new SqlHelper(Configuration);
            visitordal = new VisitorDal();
        }

        [HttpGet]
        public ActionResult SendQRCode()
        {
            try
            {
                return Ok(CommonFunctionLogic.GenerateOTP());
            }
            catch (Exception ex) { return Ok("-1"); }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        //public ActionResult InsertVisitorEntry([FromBody] VisitorInsert visitorInsert)
        // {
        //    Int32 Result = 0;
        //    try
        //    {
        //        Result = visitordal.InsertVisitorData(visitorInsert);

        //        return Ok(Result);
        //    }
        //    catch (Exception) { return Ok(-1); }
        //}

        [HttpPost]
        public ActionResult InsertVisitorEntry([FromBody] VisitorInsert visitorInsert)
        {
            Int32 Result = 0;
            try
            {
                Result = visitordal.InsertVisitorData(visitorInsert);

                return Ok(Result);
            }
            catch (Exception) { return Ok(-1); }
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult UpdateVisitorDetails([FromForm] VisitorUpdate visitorUpdate)
        {
            try
            {
                return Ok(visitordal.UpdateVisitorDetails(visitorUpdate));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]

       public ActionResult UpdatePersonalTimeLine([FromForm] VisitorTimeline visitorTimeline)

        {
            try
            {
                return Ok(visitordal.UpdatePersonalTimeLine(visitorTimeline));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        public ActionResult InsertCoVisitorEntry([FromBody] CoVisitorInsert coVisitorInsert)
        {
            Int32 Result = 0;
            try
            {
                Result = visitordal.InsertCoVisitorData(coVisitorInsert);

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
                    return Ok(CommonFunctionLogic.SaveImageInDatabase(visiImageUpload.FileData, visiImageUpload.Visiid));
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

        public ActionResult InsertUnScheduleVisitorEntry([FromBody] UnScheduledVisitor unScheduledVisitor)
        {
            Int32 Result = 0;

            try
            {
                Result = visitordal.InsertUnSheduleData(unScheduledVisitor);

                return Ok(Result);
            }

            catch(Exception) { return Ok(-1); }
        }

        public ActionResult GetPurposeDeatils()
        {
            try
            {
                return Ok(visitordal.GetPurposeDeatils());
            }

            catch (Exception) { return null; }
        }

        [HttpGet]

        public ActionResult GetTodayUnSheduledAppDetails()
        {
            try
            {
                return Ok(visitordal.GetTodayUnSheduledAppDetails());
            }

            catch (Exception) { return null; }
        }

        [HttpGet]

        public ActionResult GetTodaySheduledAppDetails()
        {
            try
            {
                return Ok(visitordal.GetTodaySheduledAppDetails());
            }

            catch (Exception) { return null; }
        }

        [HttpPost]

        public ActionResult GetTodayUnSheduledAppDetailsByName(string VisiName)
        {
            try
            {
                return Ok(visitordal.GetTodayUnSheduledAppDetailsByName(VisiName));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]

        public ActionResult GetVisitorPesrsonalTimeLineDetails(long Empid,string AppDatefrom)
        {
            try
            {
                return Ok(visitordal.GetVisitorPesrsonalTimeLineDetails(Empid, AppDatefrom));
            }

            catch (Exception) { return null; }
        }


        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult CheckAppointment(long VisiMobileNo)
        {
            try
            {
                return Ok(visitordal.CheckAppointment(VisiMobileNo));
            }

            catch (Exception) { return null; }
        }


    }
}
