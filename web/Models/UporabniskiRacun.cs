using System;
using System.Collections.Generic;

namespace web.Models
{
    public class UporabniskiRacun
    {
        public int ID { get; set; }
        public required string uporabniskoIme { get; set; }
        public required string eposta { get; set; }
        public required string geslo { get; set; }
        public DateTime EnrollmentDate { get; set; }

    }
}