using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SimpleAPI
{
    public class TripMailVM
    {
        [Required(ErrorMessage = "TripId is required.")]
        public int TripId { get; set; }
        [Required(ErrorMessage = "Mail is required.")]
        public string Mail { get; set; }

    }
}
