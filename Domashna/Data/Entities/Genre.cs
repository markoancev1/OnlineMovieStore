using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domashna.Data.Entities
{
    public class Genre
    {
        [key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
