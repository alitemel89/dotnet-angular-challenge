using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Post
    {
        public Guid PostId { get; set; }
        public string Caption { get; set; }
        public virtual User User { get; set; }
    }
}