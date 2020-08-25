using System;
using System.Collections.Generic;
using System.Text;

namespace medExpert.Models
{
    public class ViolationImage
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFavorite { get; set; }
    }
}
