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
        //[Authorize(Roles = "SuperAdmin")]
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
    }
}
