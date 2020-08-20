using System;

namespace DomainLayer
{
    public class StudentModel : Entity
    {
        public string StdCode { get; set; }
        public string CollegeCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? DOB { get; set; }
        public string ContactNo { get; set; }
        public string Image { get; set; }
    }
}
