using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorManagementSystemWebApi.Model.Visitor
{

    public class Appointment
    {

        public string Command { get; set; }
        public long VisiID { get; set; }
        public long Empid { get; set; }

        public long AppID { get; set; }
        public long Visi_cat_id { get; set; }
        public long BranchID_visit { get; set; }
        public long Deptid_visit { get; set; }
        public long Purpose_id { get; set; }
        public Nullable<DateTime> AppDatefrom { get; set; }
        public Nullable<DateTime> AppDateTo { get; set; }
        public Nullable<DateTime> AppTimefrom { get; set; }
        public Nullable<DateTime> AppTimeto { get; set; }
        public string Assets { get; set; }
        public string VisiName { get; set; }
        public string VisiCompany { get; set; }
        public string VisiAdd { get; set; }
        public long VisiMobileNo { get; set; }
        public string VisiEmailID { get; set; }
        public string VisiDesigName { get; set; }
        public string VehicleNo { get; set; }
        public long ConferenceId { get; set; }
        public string VisitorType { get; set; }
        public string IDProof { get; set; }
        public string IDProofNumber { get; set; }
        public Nullable<Decimal> Temprature { get; set; }

        //  public Nullable<float>Temprature { get; set; }
        public long Host { get; set; }
        public string Badge_no { get; set; }
        public DateTime EntryDate { get; set; }
        public Nullable<DateTime> InDate { get; set; }

        public string HostName { get; set; }
        public string DeptName { get; set; }
        public string BranchName { get; set; }
        public string Purpose { get; set; }
        public string catName { get; set; }
        public string QRCode { get; set; }
        public Byte[] VisiPhoto { get; set; }

        public string CoVisiName { get; set; }
        public string mobileNo { get; set; }

        public Nullable<DateTime> OutDate { get; set; }

        public string CoInDate { get; set; }
        public string CoOutDate { get; set; }
        public Nullable<DateTime> Premises_Time { get; set; }
        public Int64 AppTypeID { get; set; }
        public string ConName { get; set; }
        public long Covisiid { get; set; }

        public string MettingTitle { get; set; }
        public Nullable<DateTime> Datefrom { get; set; }
        public Nullable<DateTime> Fromtime { get; set; }
        public Nullable<DateTime> Totime { get; set; }
        public string Depatmentid { get; set; }
        public string Employeeid { get; set; }
        public long Id { get; set; }
        public string EmpName { get; set; }
        public string EmpDept { get; set; }
        public long DeptID { get; set; }
        public long EMPSRNO { get; set; }






        public class AppointmentStartEnd
        {
            public string starttime { get; set; }
            public string endtime { get; set; }
        }

        public class PurposeDetails
        {

            public long Srno { get; set; }
            public string Purpose { get; set; }
        }

        public class VisiImageUpload
        {
            public long AppID { get; set; }
            public long Covisiid { get; set; }
            public IFormFile FileData { get; set; }
        }

        public class VisiBulkUpload
        {
            public string Command { get; set; }
            public long Empid { get; set; }
            public string VisiName { get; set; }
            public string VisiCompany { get; set; }
            public long VisiMobileNo { get; set; }
            public string catName { get; set; }
            public string Purpose { get; set; }
            public Nullable<DateTime> AppDatefrom { get; set; }
        }

        public class AppointmentCount
        {
            public long Sheduled { get; set; }
            public long Visited { get; set; }
            public long WalkIn { get; set; }
            public long InPremises { get; set; }

        }

        public class SheduledAppCount
        {
            public DateTime AppDatefrom { get; set; }
            public long VisitorCount { get; set; }
        }
    }
}


