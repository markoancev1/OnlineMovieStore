using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domashna.Data.Entities
{
    public class RentingMovie
    {
        [key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public double Price { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
