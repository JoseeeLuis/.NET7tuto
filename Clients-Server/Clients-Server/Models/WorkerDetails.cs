using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clients_Server.Models
{
    public class WorkerDetails
    {
    
        public int WorkerDetailsId { get; set; }
        public DateTime JoiningDate { get; set; } = DateTime.Now;
        public decimal Salary { get; set; }
        public string DepartamentTypeCode { get; set; }
        public DepartamentType DepartamentType { get; set; }
        public string SeniorityTypeCode { get; set; } = string.Empty;
        public SeniorityType SeniorityType { get; set; }
    }
}


