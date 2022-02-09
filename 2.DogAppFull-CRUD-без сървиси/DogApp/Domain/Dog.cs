using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DogApp.Domain
{
    public class Dog
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(1,30)]
        public int Age { get; set; }

        [Required]
        [MaxLength(50)]
        public string Breed { get; set; }

        public string Picture { get; set; }
    }
}
