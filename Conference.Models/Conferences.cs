﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conference.Models
{
    public class Conferences
    {
        public int Id { get; set; }
        public int ConferenceTypeId { get; set; }
        public int LocationId { get; set; }
        public string OrganizerEmail { get; set; }
        public int CategoryId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }

    }
}
