using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Models
{
    public class MoviesStore
    {
        public long Id { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}
