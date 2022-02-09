using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApp.Models
{
    public class DogDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }
        public string Picture { get; set; }
    }
}
