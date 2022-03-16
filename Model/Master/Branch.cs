using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorManagementSystemWebApi.Model.Master
{
    public class Branch
    {
        public string Command { get; set; }
        public long BranchID { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
    }
}
