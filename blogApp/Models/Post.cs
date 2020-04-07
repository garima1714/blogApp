using System;
using System.Collections.Generic;

namespace blogApp.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        public string PostData { get; set; }
        public string PostUrl { get; set; }
        public string PostHeading { get; set; }
    }
}
