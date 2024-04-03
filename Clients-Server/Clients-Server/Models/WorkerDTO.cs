namespace Clients_Server.Models
{
    public class WorkerDTO
    {
        public int WorkerId { get; set; }
        public string WorkerName { get; set; } 
        public string FullAddress { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Departament { get; set; } 
        public string Seniority { get; set; }
        public List<Project> Projects { get; set; }
    }
}
