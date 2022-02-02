using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorManagementSystemWebApi.Model.Visitor
{
    public class Visitor
    {
        //public class VisitorInsert
        //{
        //    public string Command { get; set; }
        //    public string VisiName { get; set; }
        //    public string VisiCompany { get; set; }
        //    public string VisiAdd { get; set; }
        //    public long VisiMobileNo { get; set; }
        //    public string VisiEmailID { get; set; }
        //    public string VisiDesigName { get; set; }
        //    public string  VehicleNo { get; set; }

        //}


        public class VisitorInsert
        {
            public string Command { get; set; }
            public string VisiName { get; set; }
            public string VisiCompany { get; set; }
            public string VisiAdd { get; set; }
            public long VisiMobileNo { get; set; }
            public string VisiEmailID { get; set; }
            public string VisiDesigName { get; set; }
            public string VehicleNo { get; set; }
            public long Empid { get; set; }
            public long Visi_cat_id { get; set; }
            public long BranchID_visit { get; set; }
            public long Deptid_visit { get; set; }
            public long Purpose_id { get; set; }
            public DateTime AppDatefrom { get; set; }
            public DateTime AppDateTo { get; set; }
            public DateTime AppTimefrom { get; set; }
            public DateTime AppTimeto { get; set; }
            public string Assets { get; set; }

        }


        public class VisitorUpdate
        {
           public long Visiid { get; set; }
            public string VisiName { get; set; }
            public string VisiCompany { get; set; }
            public string VisiAdd { get; set; }
            public long VisiMobileNo { get; set; }
            public string VisiEmailID { get; set; }
            public string VisiDesigName { get; set; }
            public string VehicleNo { get; set; }
            public long Empid { get; set; }
            public long Visi_cat_id { get; set; }
            public long BranchID_visit { get; set; }
            public long Deptid_visit { get; set; }
            public long Purpose_id { get; set; }
            public DateTime AppDatefrom { get; set; }
            public DateTime AppDateTo { get; set; }
            public DateTime AppTimefrom { get; set; }
            public DateTime AppTimeto { get; set; }
            public string Assets { get; set; }

        }

        public class UnScheduledVisitor
        {
            public string Command { get; set; }
            public string VisiName { get; set; }
            public string VisiCompany { get; set; }
            public long VisiMobileNo { get; set; }
            public int Visi_cat_id { get; set; }
            public  int Purpose_id { get; set; }
            public string IDProof { get; set; }
            public string IDProofNumber { get; set; }
            public  float Temprature { get; set; }
            public long Host { get; set; }
            public long Badge_no { get; set; }
            public string Assets { get; set; }
        }

         public class TodayUnScheduledVisitor
         {
            public string VisiName { get; set; }
            public string VisiCompany { get; set; }
            public long VisiMobileNo { get; set; }
            public int Visi_cat_id { get; set; }
            public int Purpose_id { get; set; }
            public string IDProof { get; set; }
            public string IDProofNumber { get; set; }
            public Decimal Temprature { get; set; }
            public long Host { get; set; }
            public long Badge_no { get; set; }
            public string Assets { get; set; }
            public DateTime EntryDate { get; set; }
        }

        public class CoVisitorInsert
        {
            public string Command { get; set; }
            public long Visiid { get; set; }
            public string CoVisitor_Name { get; set; }
            public long mobileNo { get; set; }
        }

        public class PurposeDetails
        {
            public long Srno { get; set; }
            public string Purpose { get; set; }
        }

        public class VisiImageUpload
        {
            public long Visiid { get; set; }
            public IFormFile FileData { get; set; }
        }


        public class VisitorTimeLineDetails
        {

            public long Visiid { get; set; }
            public long Empid { get; set; }
            public string HostName { get; set; }
            public long Visi_cat_id { get; set; }

            public string catName { get; set; }
            public long BranchID_visit { get; set; }
            public long Deptid_visit { get; set; }
            public long Purpose_id { get; set; }

            public string DeptName { get; set; }
            public string BranchName { get; set; }
            public string Purpose { get; set; }
            public DateTime AppDatefrom { get; set; }
            public DateTime AppDateTo { get; set; }
            public DateTime AppTimefrom { get; set; }
            public DateTime AppTimeto { get; set; }
            public string Assets { get; set; }
            public string VisiName { get; set; }
            public string VisiCompany { get; set; }
            public string VisiAdd { get; set; }
            public long VisiMobileNo { get; set; }
            public string VisiEmailID { get; set; }
            public string VisiDesigName { get; set; }
            public string VehicleNo { get; set; }

            public string IDProof { get; set; }
            public string IDProofNumber { get; set; }
            public Decimal Temprature { get; set; }
            //public long Host { get; set; }
            public long Badge_no { get; set; }
            public DateTime EntryDate { get; set; }
            public DateTime InDate { get; set; }
        }

        public class VisitorTimeline
        {
            public long Visiid { get; set; }
            public string VisiCompany { get; set; }
            public string VisiName { get; set; }
            public long Purpose_id { get; set; }

            ////public long Empid { get; set; }

        }


        public class TodaySheduledDetails
        {
            public long Visiid { get; set; }
            public long Empid { get; set; }
            public long Visi_cat_id { get; set; }
            public long BranchID_visit { get; set; }
            public long Deptid_visit { get; set; }
            public long Purpose_id { get; set; }
            public DateTime AppDatefrom { get; set; }
            public DateTime AppDateTo { get; set; }
            public DateTime AppTimefrom { get; set; }
            public DateTime AppTimeto { get; set; }
            public string Assets { get; set; }
            public string VisiName { get; set; }
            public string VisiCompany { get; set; }
            public string VisiAdd { get; set; }
            public long VisiMobileNo { get; set; }
            public string VisiEmailID { get; set; }
            public string VisiDesigName { get; set; }
            public string VehicleNo { get; set; }

            public string IDProof { get; set; }
            public string IDProofNumber { get; set; }
            public Decimal Temprature { get; set; }
            public long Host { get; set; }
            public long Badge_no { get; set; }
            public DateTime EntryDate { get; set; }
            public DateTime InDate { get; set; }


        }

    }
}
