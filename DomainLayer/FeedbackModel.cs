namespace DomainLayer
{
    public class FeedbackModel : Entity
    {
        public string FbCode { get; set; }
        public string CollegeCode { get; set; }
        public int Studies { get; set; }
        public int Sports { get; set; }
        public int Placements { get; set; }
        public string Comments { get; set; }        
    }
}
