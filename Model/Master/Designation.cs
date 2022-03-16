using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorManagementSystemWebApi.Model.Master
{
    public class Designation
    {
       public class InsertDesignation
        {
            public string Command { get; set; }
            public string Designame { get; set; }
        }

        public class DesignationModel
        {
            public long DesigID { get; set; }
            public string Designame { get; set; }
        }
    }

}
