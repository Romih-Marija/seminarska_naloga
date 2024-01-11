using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models

{
    public class ObjavaNudimOa
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public required string Ime { get; set; }
        [Required]
        [StringLength(50)]
        public required string Priimek { get; set; }
        [Required]
        [StringLength(50)]
        public required string Lokacija { get; set; }
        [StringLength(250)]
        public string? Opis { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum")]
        public DateTime? DatumObjave { get; set; }
        [Display(Name = "Avtor")]
        public string? AvtorObjave { get; set; }
    }

}