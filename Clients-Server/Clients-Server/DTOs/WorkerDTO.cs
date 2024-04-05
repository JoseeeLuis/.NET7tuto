namespace Clients_Server.DTOS
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
        public static WorkerDTO FromWorker(Worker worker)
        {
            return new ()
            {
                WorkerId = worker.WorkerId,
                WorkerName = worker.WorkerName,
                FullAddress = $"{worker.Address.Street} {worker.Address.StreetNumber}, C.P: {worker.Address.PostalCode}, {worker.Address.State}",
                JoiningDate = worker.WorkerDetails.JoiningDate,
                Departament = worker.WorkerDetails.DepartamentType.Departament,
                Seniority = worker.WorkerDetails.SeniorityTypeCode,
                Projects = worker.Projects
            };
        }
    }
}
