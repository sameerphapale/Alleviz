using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorManagementSystemWebApi.App_Code;
using VisitorManagementSystemWebApi.App_Code.DAL.Master;
using static VisitorManagementSystemWebApi.Model.Master.Conference;

namespace VisitorManagementSystemWebApi.Controllers
{

    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/{Action}")]
    [ApiController]
    public class ConferenceController : ControllerBase
    {
        ConferenceDAL ConDAL;


        public ConferenceController(IConfiguration Configuration)
        {
            SqlHelper helper = new SqlHelper(Configuration);
            ConDAL = new ConferenceDAL();
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult InsertConferenceEntry([FromBody] ConferenceInsert conferenceInsert)
        {
            Int32 Result = 0;
            try
            {
                Result = ConDAL.InsertConferenceData(conferenceInsert);

                return Ok(Result);
            }
            catch (Exception) { return Ok(-1); }
        }


        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult GetConferenceDeatils()
        {
            try
            {
                return Ok(ConDAL.GetConferenceDeatils());
            }

            catch (Exception) { return null; }
        }

        public ActionResult GetFreeConfDetails()
        {
            try
            {
                return Ok(ConDAL.GetFreeConfDetails());
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult GetConferenceDeatilsById(long ConferenceID)
        {
            try
            {
                return Ok(ConDAL.GetConferenceDeatilsById(ConferenceID));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult UpdateConferenceDetails([FromForm] ConferenceUpdate conferenceUpdate)
        {
            try
            {
                return Ok(ConDAL.UpdateConferenceDetails(conferenceUpdate));
            }

            catch (Exception) { return null; }
        }


        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult DeleteConference(Int64 ConferenceID)
        {
            try
            {
                return Ok(ConDAL.DeleteConference(ConferenceID));
            }

            catch (Exception) { return null; }
        }
    }
}
