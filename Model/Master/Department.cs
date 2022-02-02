using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorManagementSystemWebApi.Model.Master
{
    public class Department
    {
       public class DeptInsert
        {
            public string Command { get; set; }
            public string DeptName { get; set; }
        }

        public class DeptModel
        {
            //public string Command { get; set; }
            public long DeptID { get; set; }
            public string DeptName { get; set; }
        }
    }
}
