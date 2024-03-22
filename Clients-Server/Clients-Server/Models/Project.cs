namespace Clients_Server.Models
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }

        public List<Worker> Workers { get; set; }
    }
}
