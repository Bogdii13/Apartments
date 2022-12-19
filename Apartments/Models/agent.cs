namespace Apartments.Models
{
    public class Agent
    {
        public int ID { get; set; }
        public string AgentName { get; set; }
        public ICollection<Apartment>? Apartments { get; set; }
    }
}
