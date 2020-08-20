using System;

namespace DomainLayer
{
    public class PlacementModel : Entity
    {
        public string PlmtCode { get; set; }
        public string Collegecode { get; set; }
        public string CompanyName { get; set; }
        public string About { get; set; }
        public string ConcernPersonName { get; set; }
        public string ConcernPersonNo { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
