using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domashna.Data.Entities
{
    public class ListingMovie
    {
        [key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
