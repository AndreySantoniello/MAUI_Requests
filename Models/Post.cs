using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClient.Models
{
    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Body { get; set; }
    }
}