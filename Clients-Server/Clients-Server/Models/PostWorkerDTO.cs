namespace Clients_Server.Models
{
    public class PostWorkerDTO
    {
        //public int WorkerId { get; set; }
        public string WorkerName { get; set; }
        //public int WorkerDetailsId { get; set; }
        public string Street { get; set; } 
        public int StreetNumber { get; set; }
        public int PostalCode { get; set; }
        public string State { get; set; } 
        public DateTime JoiningDate { get; set; }= DateTime.Now;
        public string DepartamentTypeCode { get; set; }
        public string SeniorityTypeCode { get; set; }
    }
}
