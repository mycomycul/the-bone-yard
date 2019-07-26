using System;
using System.Collections.Generic;

namespace TrailsApi.Models
{
    public partial class TrailSections
    {
        public string Id { get; set; }
        public string ShortDescription { get; set; }
        public string Status { get; set; }
        public string TrailId { get; set; }

        public virtual Trails Trail { get; set; }
    }
}
