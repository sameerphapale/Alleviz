using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorManagementSystemWebApi.Services;
using static VisitorManagementSystemWebApi.Model.EmailModel;

namespace VisitorManagementSystemWebApi.Controllers
{
    public class EmailController : Controller
    {
        private readonly IMailService mailService;
        public EmailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        //[HttpPost]
        //public async Task<IActionResult> Send([FromForm] EmailSendModel request)
        //{
        //    try
        //    {
        //       var res= await mailService.SendEmail(request);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}

    }
}
