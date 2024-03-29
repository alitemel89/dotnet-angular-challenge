using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace API.DTOs
{
    public class PostDto
    {
        public string PostId { get; set; }
        public string Caption { get; set; }
        public string UserId { get; set; }
        public UserDto User { get; set; }
    }
}