using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorManagementSystemWebApi.Model.Master
{
    public class Conference
    {
        public class ConferenceInsert
        {
            public string Command { get; set; }
            public string ConferenceName { get; set; }
            public string LandlineNo { get; set; }
            public string ConferenceCapicity { get; set; }
        }
        public class ConferenceDetails
        {
            public long ConferenceID { get; set; }
            public string ConferenceName { get; set; }
            public string LandlineNo { get; set; }
            public string ConferenceCapicity { get; set; }
        }
        public class ConferenceUpdate
        {
            public long ConferenceID { get; set; }
            public string ConferenceName { get; set; }
            public string LandlineNo { get; set; }
            public string ConferenceCapicity { get; set; }
        }
    }
}
