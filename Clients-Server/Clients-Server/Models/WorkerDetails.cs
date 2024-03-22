namespace Clients_Server.Models
{
    public class WorkerDetails
    {
        public int WorkerDetailsId { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        public DateTime JoiningDate { get; set; } = DateTime.Now;
        public decimal Salary { get; set; }
        public string DepartamentTypeCode { get; set; }
        public string SeniorityTypeCode { get; set; } = string.Empty;
    }
}


