namespace Clients_Server.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> AddAddressAsync(Address address);
    }
}
