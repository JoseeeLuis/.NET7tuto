using Microsoft.EntityFrameworkCore;

namespace Clients_Server.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { 
            
        }
    }
}
