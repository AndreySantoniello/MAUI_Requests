﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClient.Models
{
    internal class Todo
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public required string Title { get; set; }
        public bool Completed { get; set; }
    }
}
