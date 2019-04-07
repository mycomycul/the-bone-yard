using System;
using System.Collections.Generic;

namespace TrailsApi.Models
{
    public partial class Trails
    {
        public Trails()
        {
            Conditions = new HashSet<Conditions>();
            PostTrails = new HashSet<PostTrails>();
            TrailSections = new HashSet<TrailSections>();
        }

        public string Id { get; set; }
        public string TrailName { get; set; }
        public string Zone { get; set; }
        public string Description { get; set; }
        public float? TotalMiles { get; set; }
        public string Status { get; set; }
        public string Agency { get; set; }
        public string InfoHtmllink { get; set; }
        public string Elevation { get; set; }
        public string ShortDescription { get; set; }

        public virtual ICollection<Conditions> Conditions { get; set; }
        public virtual ICollection<PostTrails> PostTrails { get; set; }
        public virtual ICollection<TrailSections> TrailSections { get; set; }
    }
}
