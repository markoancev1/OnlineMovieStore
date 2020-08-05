using Domashna.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domashna.Services.Services.Interfaces
{
    public interface IDirectorService
    {
        IEnumerable<Director> GetAllDirectors();
        void Add(Director director);
        void Edit(Director director);
        void Delete(int DirectorID);
        Director GetDirectorById(int id);

        Director GetDirectorByPopularity();
    }
}
