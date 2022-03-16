using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorManagementSystemWebApi.Model.Visitor
{
    public class Login
    {

        public class UserModel
        {    
            public string Name { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Role_Name { get; set; }
            public Login RoleList { get; set; }
        }

        public class UserDetails
        {
            public long Role_id { get; set; }
            public string Username { get; set; }

        }

        public class RoleList
        {
            public long RoleID { get; set; }
            public string Role_Name { get; set; }
            public long EMPSRNO { get; set; }
            public string User_Name { get; set; }
            public string Emp_Name { get; set; }
        }

        public class TestModel
        {
            public string title { get; set; }
            public string start { get; set; }
        }
    }
}
