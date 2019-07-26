using System;
using System.Collections.Generic;

namespace TrailsApi.Models
{
    public partial class Conditions
    {
        public string Id { get; set; }
        public int PercentSnowCover { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public string TrailId { get; set; }

        public virtual Trails Trail { get; set; }
    }
}
