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
        public long VisiteeID { get; set; }
        public long VisiCatID { get; set; }
        public long VisiBranchID { get; set; }
        public long VisiDeptID { get; set; }
        public long PurposeID { get; set; }
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
        public long ConferenceId { get; set; }
        public string VisitorType { get; set; }
        public string IDProof { get; set; }
        public string IDProofNumber { get; set; }
        public Decimal Temprature { get; set; }
        public long Host { get; set; }
        public long Badge_no { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime InDate { get; set; }

        public string HostName { get; set; }
        public string DeptName { get; set; }
        public string BranchName { get; set; }
        public string Purpose { get; set; }
        public string catName { get; set; }
        public string QRCode { get; set; }
        public Byte[] VisiPhoto { get; set; }

        public Int64 AppTypeID { get; set; }
        

        public class AppointmentStartEnd
        {
            public string starttime { get; set; }
            public string endtime { get; set; }
        }

        public class AppointmentCount
        {
            //  public long Scheduled { get; set; }
            public long Visited { get; set; }
            public long WalkIn { get; set; }
            public long InPremises { get; set; }

        }
    }
}
