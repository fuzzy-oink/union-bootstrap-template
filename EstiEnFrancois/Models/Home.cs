using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstiEnFrancois.Models
{
    public class Home
    {
        public List<string> SlideshowImageUrls { get; set; }
        public RsvpModel RsvpModel { get; set; }
    }
}