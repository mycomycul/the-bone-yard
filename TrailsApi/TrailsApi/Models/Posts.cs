using System;
using System.Collections.Generic;

namespace TrailsApi.Models
{
    public partial class Posts
    {
        public Posts()
        {
            PostTrails = new HashSet<PostTrails>();
        }

        public string Id { get; set; }

        public virtual ICollection<PostTrails> PostTrails { get; set; }
    }
}
