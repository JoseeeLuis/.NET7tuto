using System.ComponentModel.DataAnnotations;

namespace Clients_Server.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        public string WorkerName { get; set; } = string.Empty;

        public string SeniorityTypeCode { get; set; } = string.Empty; 

        public DateTime JoiningDate { get; set; } = DateTime.Now;

        public List<Project> Projects { get; set; }
           
    }
}
