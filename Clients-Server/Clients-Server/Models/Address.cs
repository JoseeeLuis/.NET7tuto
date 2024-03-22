namespace Clients_Server.Models
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        public string Street { get; set; } = string.Empty;  

        public int StreetNumber { get; set; }

        public int PostalCode { get; set; }

        public string State { get; set; } = string.Empty;
    }
}
