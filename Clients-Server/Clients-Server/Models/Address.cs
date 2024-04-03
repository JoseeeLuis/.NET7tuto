namespace Clients_Server.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        public string Street { get; set; } 

        public int StreetNumber { get; set; }

        public int PostalCode { get; set; }

        public string State { get; set; } = string.Empty;
    }
}
