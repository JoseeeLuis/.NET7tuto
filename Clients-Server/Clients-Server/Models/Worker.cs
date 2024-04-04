using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public WorkerDTO ToDto()
        {
            return new WorkerDTO
            {
                WorkerId = WorkerId,
                WorkerName = WorkerName,
                FullAddress = Address != null ? $"{Address.Street} {Address.StreetNumber},C.P: {Address.PostalCode}, {Address.State}" : "This worker doesn't have an address.",
                JoiningDate = WorkerDetails != null ? WorkerDetails.JoiningDate : DateTime.Now,
                Departament = WorkerDetails != null ? WorkerDetails.DepartamentType.Departament : "This worker doesn't have any department assigned",
                Seniority = WorkerDetails != null ? WorkerDetails.SeniorityTypeCode : "This worker doesn't have any seniority assigned",
                Projects = Projects
            };
        }

    }
}
