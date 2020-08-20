using System;

namespace DomainLayer
{
    public class Entity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
