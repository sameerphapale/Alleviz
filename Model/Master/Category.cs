using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorManagementSystemWebApi.Model.Master
{
    public class Category
    {
        public class InsertCategory
        {

            public string Command { get; set; }
            public string catName { get; set; }
            public string ApprovalAuthority { get; set; }
        }

        public class InsertApprovalAuthority
        {

            public string Command { get; set; }
            public string catName { get; set; }
            public string ApprovalAuthority { get; set; }
            public Int32 VisitorType { get; set; }
            public Int32 ApprovalLevel { get; set; }
            public long Level1 { get; set; }
            public long Level2 { get; set; }
            public long Level3 { get; set; }
            public long Level4 { get; set; }
            public long Level5 { get; set; }

         
        }

        public class CategoryModel
        {
            
            public Int32 catid { get; set; }
            public string catName { get; set; }
            public string ApprovalAuthority { get; set; }
            public Int32 ApprovalLevel { get; set; }
            public long Level1 { get; set; }
            public long Level2 { get; set; }
            public long Level3 { get; set; }
            public long Level4 { get; set; }
            public long Level5 { get; set; }
        }

        public class CodeModel
        {
            public long Code { get; set; }
      
        }
    }
}
