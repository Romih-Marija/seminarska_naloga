using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models

{
    public class NudimNadomescanje
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Od datuma")]
        public DateTime OdDatuma { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Do datuma")]
        public DateTime DoDatuma { get; set; }
        [Display(Name = "Avtor")]
        public string? AvtorObjave { get; set; }
    }

}