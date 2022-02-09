using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogApp.Models
{
    public class DogAllViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
 
        [Display(Name = "Age")]
        public int Age { get; set; }

        
        [Display(Name = "Breed")]
        public string Breed { get; set; }

        [Display(Name = "Dog Picture")]
        public string Picture { get; set; }
    }
}
