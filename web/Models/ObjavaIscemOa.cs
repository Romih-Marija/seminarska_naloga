using System;
using System.Collections.Generic;
namespace web.Models
{
    public class ObjavaIscemOa
    {
        public int ID { get; set; }
        public required string Ime { get; set; }
        public required string Priimek { get; set; }
        public required string Lokacija { get; set; }
        public required string DelovniCas { get; set; }
        public string? Opis { get; set; }
        public DateTime? DatumObjave { get; set; }
        public string? AvtorObjave { get; set; }
    }

}