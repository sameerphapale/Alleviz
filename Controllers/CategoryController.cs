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
using static VisitorManagementSystemWebApi.Model.Master.Category;

namespace VisitorManagementSystemWebApi.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/{Action}")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryDal Catdal;

        public CategoryController(IConfiguration Configuration)
        {
            SqlHelper helper = new SqlHelper(Configuration);
            Catdal = new CategoryDal();
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult InsertCategoryEntry([FromBody] InsertCategory insertCategory)
        {
            Int32 Result = 0;
            try
            {
                Result = Catdal.InsertCategoryData(insertCategory);

                return Ok(Result);
            }
            catch (Exception) { return Ok(-1); }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult InsertApprovalAuthorityEntry([FromBody] InsertApprovalAuthority insertApprovalAuthority)
        {
            Int32 Result = 0;
            try
            {
                Result = Catdal.InsertApprovalAuthoritData(insertApprovalAuthority);

                return Ok(Result);
            }
            catch (Exception) { return Ok(-1); }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetCategoryDeatils()
        {
            try
            {
                return Ok(Catdal.GetCategoryDeatils());
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetQRCode(int Number)
        {
            
            try
            {
                return Ok(Catdal.GetQRCode(Number));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin , Cadet")]
        public ActionResult GetAllCategoryDetails(int catid)
        {
            try
            {
                return Ok(Catdal.GetAllCategoryDetails(catid));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult UpdateCategoryDetails([FromForm] CategoryModel categoryModel)
        {
            try
            {
                return Ok(Catdal.UpdateCategoryDetails(categoryModel));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult UpdateCategoryApprovalDetails([FromForm] CategoryModel categoryModel)
        {
            try
            {
                return Ok(Catdal.UpdateCategoryApprovalDetails(categoryModel));
            }

            catch (Exception) { return null; }
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult RemoveCategory(Int64 catid)
        {
            try
            {
                return Ok(Catdal.RemoveCategory(catid));
            }

            catch (Exception) { return null; }
        }
    }
}
