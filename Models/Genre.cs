using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        public string Name { get; set; }

        public Genre(string name)
        {
            Name = name;
        }
    }
}
