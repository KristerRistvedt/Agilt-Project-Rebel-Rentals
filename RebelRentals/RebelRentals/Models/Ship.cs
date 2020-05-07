using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RebelRentals.Models
{
    public class Ship
    {
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }
        
        [Required][Range(1, 1000000)]
        [Display(Name = "Max. population")]
        public int NumberOfPopulation { get; set; }
        
        [Required]
        public string Class { get; set; }
        
        [Required][Range(1, 1000000)]
        [Display(Name = "Max speed")]
        public int MaxSpeed { get; set; }
        
        [Required][Range(1, 1000000)]
        public int Length { get; set; }
        
        [Required]
        [Range(1, 1000000)]
        public int Width { get; set; }
        
        [Required]
        [Range(1, 1000000)]
        public int Height { get; set; }

        [Required]
        public double Price { get; set; }
        public string About { get; set; }
    }
}
