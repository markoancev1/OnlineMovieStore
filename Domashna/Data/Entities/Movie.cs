using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Domashna.Data.Entities
{
    public class Movie
    {
        [key]
        public int Id { get; set; }

        [StringLength(250)]
        public string Title { get; set; }
        public DateTime YearOfRelease { get; set; }
        public Director Director {get; set;}
        public int DirectorID { get; set; }
        public string DirectorName { get; set; }
        public Genre Genre { get; set; }
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public double IMBDScore { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        [StringLength(50)]
        public string Language { get; set; }

        public int UserId { get; set; }

        [StringLength(50)]
        public string Country { get; set; }
        public string PhotoURL { get; set; }
        public int SoldItems { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}
