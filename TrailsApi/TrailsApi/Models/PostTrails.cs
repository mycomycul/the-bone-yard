using System;
using System.Collections.Generic;

namespace TrailsApi.Models
{
    public partial class PostTrails
    {
        public string PostId { get; set; }
        public string TrailId { get; set; }

        public virtual Posts Post { get; set; }
        public virtual Trails Trail { get; set; }
    }
}
