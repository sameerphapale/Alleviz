using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VisitorManagementSystemWebApi.App_Code;
using VisitorManagementSystemWebApi.App_Code.DAL.Master;
using VisitorManagementSystemWebApi.Model.Master;
using static VisitorManagementSystemWebApi.Model.Master.Branch;

namespace VisitorManagementSystemWebApi.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/{Action}")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        BranchDal branchdal;

        public BranchController(IConfiguration Configuration)
        {
            SqlHelper helper = new SqlHelper(Configuration);
            branchdal = new BranchDal();
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult InsertBranchEntry([FromBody] Branch branchInsert)
        {
            Int32 Result = 0;
            try
            {
                Result = branchdal.InsertBranchData(branchInsert);

                return Ok(Result);
            }
            catch (Exception) { return Ok(-1); }
        }
        [HttpGet]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetBranchDeatils()
        {
            try
            {
                return Ok(branchdal.GetBranchDeatils());
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetBranchDeatilsById(long BranchID)
        {
            try
            {
                return Ok(branchdal.GetBranchDeatilsById(BranchID));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult UpdateBranchDetails([FromForm] Branch branchUpdate)
        {
            try
            {
                return Ok(branchdal.UpdateBranchDetails(branchUpdate));
            }

            catch (Exception) { return null; }
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult RemoveBranch(Int64 BranchID)
        {
            try
              {
                return Ok(branchdal.RemoveBranch(BranchID));
            }

            catch (Exception) { return null; }
        }
    }
}
