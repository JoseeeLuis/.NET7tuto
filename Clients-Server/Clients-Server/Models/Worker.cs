namespace Clients_Server.Models
{
    public class Worker
    {
        public int WorkerId { get; set; }
        public string WorkerName { get; set; } = string.Empty;
        
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int WorkerDetailsId { get; set; }
        public WorkerDetails WorkerDetails { get; set; }
        public List<Project> Projects { get; set; }

        public Boolean IsDelete { get; set; } = false;

    }
}
