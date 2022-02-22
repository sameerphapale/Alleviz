using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VisitorManagementSystemWebApi.App_Code;
using VisitorManagementSystemWebApi.App_Code.DAL.Visitor;
using VisitorManagementSystemWebApi.Model;
using static VisitorManagementSystemWebApi.Model.Visitor.Login;


namespace VisitorManagementSystemWebApi.Controllers
{
    // [EnableCors("CorsPolicy")]
    [Route("api/[controller]/{Action}")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        LoginDal login;
        private IConfiguration _config;

        UserInfo userinfos = new UserInfo();
        public LoginController(IConfiguration config)
        {

            _config = config;
            SqlHelper helper = new SqlHelper(config);
            login = new LoginDal();
        }

        [HttpPost]
        public ActionResult ChangePssword(string User_Name, string NewPass)
        {
            try
            {
                return Ok(login.ChangePssword(User_Name, NewPass));
            }

            catch (Exception) { return null; }
        }

        [HttpPost]
        public ActionResult CheckUsercredentials(string User_Name, string Password)
        {
            try
            {
                return Ok(login.CheckUsercredentials(User_Name, Password));
            }

            catch (Exception) { return null; }
        }

   

        [HttpGet]
        public ActionResult GetUserDetails()
        {
            try
            {
                return Ok(login.GetUserDetails());
            }

            catch (Exception) { return null; }
        }

  



        [HttpGet]
        //[Authorize(Roles = "Admin , User")]
        public ActionResult GetRoleList()
        {
            try
            {
                return Ok(login.GetRoleList());
            }

            catch (Exception) { return null; }
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult JWTToken(string Username, string Password)
        {
            UserModel login = new UserModel();
            login.Username = Username;
            login.Password = Password;
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString, Username = Username });
            }

            return response;
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Password),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,userInfo.Role_Name)
          
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(1440),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = userinfos.GetLoginUser(login);
            return user;
        }

    }
}



