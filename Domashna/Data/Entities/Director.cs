using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Domashna.Data.Entities
{
    public class Director
    {
        [key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Country { get; set; }

        public bool Popularity { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
