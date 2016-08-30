using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstiEnFrancois.Models
{
    public class RsvpModel
    {
        [Required(ErrorMessage = "Vul asseblief jou naam hier in")]
        [DisplayName("Jou naam")]
        public string Names { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Vul asseblief jou epos adres hier in")]
        [DisplayName("Epos adres")]
        public string Email { get; set; }

        [DisplayName("Kontak nommer")]
        public string TelNumber { get; set; }

        public bool Sent { get; set; }
    }
}