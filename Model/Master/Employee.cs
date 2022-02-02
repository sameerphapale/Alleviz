using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorManagementSystemWebApi.Model.Master
{
    public class Employee
    {
        public class InsertEmployee
        {

            public string Command { get; set; }
            public string Emp_Name { get; set; }
            public long ContactNo { get; set; }
            public string Email { get; set; }
            public long DeptID { get; set; }
            public long DesigID { get; set; }
            public long BranchID { get; set; }
            public Int32 Role_id { get; set; }
            public string User_Name { get; set; }
            public string Password { get; set; }
            //public int Status { get; set; }
        }


        public class BulkEmployee
        {

            public string Command { get; set; }
            public string Emp_Name { get; set; }
            public long ContactNo { get; set; }
            public string Email { get; set; }
            public string DeptID { get; set; }
            public string DesigID { get; set; }
            public string BranchID { get; set; }
            public string RoleID { get; set; }
            public string User_Name { get; set; }
            public string Password { get; set; }
            //public int Status { get; set; }
        }

        public class EmployeeModel
        {
            public long EMPSRNO { get; set; }
            public string Emp_Name { get; set; }
            public string User_Name { get; set; }
            public long ContactNo { get; set; }
            public string Email { get; set; }
            public long DeptID { get; set; }
            public string DeptName { get; set; }
            public long DesigID { get; set; }
            public string Designame { get; set; }
            public long BranchID { get; set; }
            public string BranchName { get; set; }
            public int RoleID { get; set; }
            public int Status { get; set; }
        }

        public class EmployeeProfile
        {
            public long EMPSRNO { get; set; }
            public string Emp_Name { get; set; }
            public string User_Name { get; set; }
            public long ContactNo { get; set; }
            public string Email { get; set; }
            public long DeptID { get; set; }
            public long DesigID { get; set; }
            public long BranchID { get; set; }
            public int RoleID { get; set; }
        }


         public class UpdateEmployee
         {
            public long EMPSRNO { get; set; }
            public string Emp_Name { get; set; }
            public string User_Name { get; set; }
            public long ContactNo { get; set; }
            public string Email { get; set; }
            public long DeptID { get; set; }
            public long DesigID { get; set; }
            public long BranchID { get; set; }
            public Int32 Role_id { get; set; }
            public int Status { get; set; }
        }

        public class RoleModel
        {
            public int RoleID { get; set; }
            public string Role_Name { get; set; }
        }

        public class MultipleUser
        {
            public List<string> Username { get; set; } = new List<string>();

            public List<string> MobileNo { get; set; } = new List<string>();
            public List<string> MailId { get; set; } = new List<string>();

            public List<string> RoleName { get; set; } = new List<string>();
        }

        public class MultipleUserHistory
        {
            public string NameOf_array { get; set; }
            public string Users { get; set; }
            public int Status { get; set; }
        }
    }
}
