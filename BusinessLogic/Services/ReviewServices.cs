using BusinessLogic.BaseServices;
using DataAccess.Infrastructure;
using DataAccess.Repositories;
using Entities;

namespace BusinessLogic.Services
{
    public class ReviewServices : BaseServices<Review>, IReviewServices
    {
        public ReviewServices(IUnitOfWork unitOfWork, IGenericRepository<Review> genericRepository) : base(unitOfWork, genericRepository) { }
    }
}
