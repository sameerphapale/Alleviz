using Microsoft.AspNetCore.Authorization;
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
    public class SuperAdminController : Controller
    {
        SuperAdminDAL obj;
        public SuperAdminController(IConfiguration Configuration)
        {
            SqlHelper helper = new SqlHelper(Configuration);
            obj = new SuperAdminDAL();
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult InsertSuperAdminEntry([FromBody] SuperAdminModel objmodel)
        {
            Int32 Result = 0;
            try
            {
                Result = obj.InsertSuperAdminData(objmodel);

                return Ok(Result);
            }
            catch (Exception) { return Ok(-1); }
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult GetSuperAdminDeatils(SuperAdminModel objmodel)
        {
            try
            {
                return Ok(obj.GetSuperAdminDeatils(objmodel));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]

        public ActionResult UpdateSuperAdminDetails([FromForm] SuperAdminModel objmodel)
        {
            try
            {
                return Ok(obj.UpdateSuperAdminDetails(objmodel));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]
        //[Authorize(Roles = "SuperAdmin")]

        public ActionResult GetSMSCount([FromForm] SuperAdminSMSCountModel objsmscnt)
        {
            try
            {
                return Ok(obj.GetSMSCount(objsmscnt));
            }

            catch (Exception) { return null; }
        }
        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]



        [HttpPost]
        public ActionResult ActivateUser()
        {
            try
            {
                return Ok(obj.ActivateUser());
            }
            catch (Exception) { return null; }
        }
    }
}
