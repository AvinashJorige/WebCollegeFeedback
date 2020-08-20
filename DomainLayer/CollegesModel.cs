using System;

namespace DomainLayer
{
    public class CollegesModel : Entity
    {
        public string CollgId { get; set; }
        public string CollegeName { get; set; }
        public string Link { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string AboutCollege { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
