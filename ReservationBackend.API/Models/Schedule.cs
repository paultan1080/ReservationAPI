﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationBackend.API.Models
{
    public class Schedule
    {
     

        public int ProviderId { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

       
    }
}
