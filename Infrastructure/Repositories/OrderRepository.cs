using Entities;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Task<int> AddAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
