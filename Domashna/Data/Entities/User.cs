using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domashna.Data.Entities
{
    public class User
    {
        [key]
        public int Id { get; set; }
        public int Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastActive { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsModerator { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }

    }
}
