using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMPMVC5
{
    public class AppointmentDiary
    {   
            public int id { get; set; }
            public string title { get; set; }
            public int someKey { get; set; }
            public string start { get; set; }
            public string end { get; set; }
            public int allDay { get; set; }

            public int AppointmentLength { get; set; }
            public List<AppointmentDiary> ShowallAppointment { get; set; }
        
    }
}