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
using VisitorManagementSystemWebApi.Model.Master;
using static VisitorManagementSystemWebApi.Model.Master.Designation;

namespace VisitorManagementSystemWebApi.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/{Action}")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        DesignationDal Desigdal;

        public DesignationController(IConfiguration Configuration)
        {
            SqlHelper helper = new SqlHelper(Configuration);
            Desigdal = new DesignationDal();
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult InsertDesignationEntry([FromBody] InsertDesignation insertDesignation)
        {
            Int32 Result = 0;
            try
            {
                Result = Desigdal.InsertDesignationData(insertDesignation);

                return Ok(Result);
            }
            catch (Exception) { return Ok(-1); }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetDesignationDeatils()
        {
            try
            {
                return Ok(Desigdal.GetDesignationDeatils());
            }

            catch (Exception) { return null; }
        }


        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetDesignationDeatilsById(long DesigID)
        {
            try
            {
                return Ok(Desigdal.GetDesignationDeatilsById(DesigID));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult UpdateDesignationDetails([FromForm] DesignationModel designationModel)
        {
            try
            {
                return Ok(Desigdal.UpdateDesignationDetails(designationModel));
            }

            catch (Exception) { return null; }
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult RemoveDesignation(Int64 DesigID)
        {
            try
            {
                return Ok(Desigdal.RemoveDesignation(DesigID));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult CheckDesigName(string Designame)
        {
            try
            {
                return Ok(Desigdal.CheckDesigName(Designame));
            }

            catch (Exception) { return null; }
        }
    }
}
