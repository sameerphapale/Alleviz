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
using static VisitorManagementSystemWebApi.Model.Master.Company;

namespace VisitorManagementSystemWebApi.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/{Action}")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        CompanyDal compdal;

        public CompanyController(IConfiguration Configuration)
        {
            SqlHelper helper = new SqlHelper(Configuration);
            compdal = new CompanyDal();
        }

        //[HttpPost]
        ////[Authorize(Roles = "Admin")]

        //public ActionResult InsertCompanyEntry([FromBody] InsertCompany insertCompany)
        //{
        //    Int32 Result = 0;
        //    try
        //    {
        //        Result = compdal.InsertCompanyData(insertCompany);

        //        return Ok(Result);
        //    }
        //    catch (Exception) { return Ok(-1); }
        //}

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult InsertCompanyEntry([FromForm] ImageUploadModel imageUpload)
        {
            try
            {
                // Saving Image on Server
                if (imageUpload.FileData.Length > 0)
                {
                    return Ok(CommonFunctionLogic.SaveFileInDatabase(imageUpload.FileData, imageUpload.CompName));
                }
                else
                {
                    return Ok("0");
                }
            }
            catch (Exception ex)
            { return Ok("-1"); }

        }


        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult UpdateCompanyEntry([FromForm] ImageUploadModel imageUpload)
        {
            try
            {
                // Saving Image on Server
                if (imageUpload.FileData.Length > 0)
                {
                    return Ok(CommonFunctionLogic.UpdateFileInDatabase(imageUpload.FileData, imageUpload.CompName));
                }
                else
                {
                    return Ok("0");
                }
            }
            catch (Exception ex)
            { return Ok("-1"); }

        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetCompanyDeatils()
        {
            try
            {
                return Ok(compdal.GetCompanyDeatils());
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetCompanyDeatilsByID(long CompID)
        {
            try
            {
                return Ok(compdal.GetCompanyDeatilsByID(CompID));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult UpdateCompanyDetails([FromForm] CompanyModel companyModel)
        {
            try
            {
                return Ok(compdal.UpdatecompanyDetails(companyModel));
            }

            catch (Exception) { return null; }
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult RemoveCompany(Int64 CompID)
        {
            try
            {
                return Ok(compdal.RemoveCompany(CompID));
            }

            catch (Exception) { return null; }
        }
    }
}
