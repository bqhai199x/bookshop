using BusinessLogic.BaseServices;
using DataAccess.Infrastructure;
using DataAccess.Repositories;
using Entities;

namespace BusinessLogic.Services
{
    public class FeedbackServices : BaseServices<Feedback>, IFeedbackServices
    {
        public FeedbackServices(IUnitOfWork unitOfWork, IGenericRepository<Feedback> genericRepository) : base(unitOfWork, genericRepository) { }
    }
}
