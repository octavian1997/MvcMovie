using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public string userName { get; set; }

        public string Comment { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movies { get; set; }
    }
}
