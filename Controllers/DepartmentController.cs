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
using static VisitorManagementSystemWebApi.Model.Master.Department;

namespace VisitorManagementSystemWebApi.Controllers
{

    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/{Action}")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        DepartmentDal Deptdal;

        public DepartmentController(IConfiguration Configuration)
        {
            SqlHelper helper = new SqlHelper(Configuration);
            Deptdal = new DepartmentDal();
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult InsertDepartmentEntry([FromBody] DeptInsert deptInsert)
        {
            Int32 Result = 0;
            try
            {
                Result = Deptdal.InsertDepartmentData(deptInsert);

                return Ok(Result);
            }
            catch (Exception) { return Ok(-1); }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetDepartmentDeatils()
        {
            try
            {
                return Ok(Deptdal.GetDepartmentDeatils());
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult GetDepartmentDeatilsById(long DeptID)
        {
            try
            {
                return Ok(Deptdal.GetDepartmentDeatilsById(DeptID));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public ActionResult UpdateDepartmentDetails([FromForm] DeptModel deptModel)
        {
            try
            {
                return Ok(Deptdal.UpdateDepartmentDetails(deptModel));
            }

            catch (Exception) { return null; }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult CheckDeptName(string DeptName)
        {
            try
            {
                return Ok(Deptdal.CheckDeptName(DeptName));
            }

            catch (Exception) { return null; }
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult RemoveDepartment(Int64 DeptID)
        {
            try
            {
                return Ok(Deptdal.RemoveDepartment(DeptID));
            }

            catch (Exception) { return null; }
        }
    }
}
