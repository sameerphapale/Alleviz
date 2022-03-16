using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static VisitorManagementSystemWebApi.Model.Visitor.Login;

namespace VisitorManagementSystemWebApi.Model
{
    public class UserInfo
    {


        //  string constr = "Server=192.168.10.223;User Id=Sa;Password=dsspl@123;Database=VisiTemp;Pooling = true;";

           string constr = "Server=103.16.222.44;User Id=sa;Password=dsspl@123;Database=VisitrackFinal;Pooling = true;";

  
        public UserModel GetLoginUser(UserModel login)
        {
            var userinfo = new UserModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
               
                string sql = string.Format(@"select a.*,b.Role_Name from EmployeeMaster as a
                                            inner join RoleMast as b on a.RoleID = b.RoleID
                                             where User_Name = '{0}' and  Password = '{1}' ", login.Username, login.Password);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                  
                    userinfo.Username = rd["User_Name"].ToString();
                    userinfo.Password = rd["Password"].ToString();
                    userinfo.Role_Name = rd["Role_Name"].ToString();
                }

                return userinfo;
            }

        }
    }
}
