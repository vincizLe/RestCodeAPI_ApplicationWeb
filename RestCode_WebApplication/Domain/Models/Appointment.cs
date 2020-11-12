using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public DateTime ScheduleDateTime { get; set; }
        public string Topic { get; set; }
        public string MeetLink { get; set; }


        //Relationships

        ////Many to One with Consultant
        //public int ConsultantId { get; set; }
        //public Consultant Consultant { get; set; }

        ////Many to One with Owner
        //public int OwnerId { get; set; }
        //public Owner Owner { get; set; }

        //One to One with Consultancy

        //public int ConsultancyId { get; set; }
        public Consultancy Consultancy { get; set; }


    }
}
