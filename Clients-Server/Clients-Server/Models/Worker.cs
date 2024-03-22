using System.ComponentModel.DataAnnotations;

namespace Clients_Server.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        public string WorkerName { get; set; } = string.Empty;

        public WorkerDetails WorkerDetails { get; set; }

        public List<Project> Projects { get; set; }

    }
}
