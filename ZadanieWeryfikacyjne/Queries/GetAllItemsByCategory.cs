using MediatR;
using Microsoft.EntityFrameworkCore;
using ZadanieWeryfikacyjne.Repository.Entities;

namespace ZadanieWeryfikacyjne.Queries
{
    public record GetAllItemsByCategory(int category) : IRequest<List<Item>?>;
    public class GetAllItemsByCategoryHandler : IRequestHandler<GetAllItemsByCategory, List<Item>?>
    {
        private readonly Repository.DbContext _dbContext;
        public GetAllItemsByCategoryHandler(Repository.DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Item>?> Handle(GetAllItemsByCategory request, CancellationToken cancellationToken)
        {
            var items = await _dbContext.Items.Where(i => i.Category.Code == request.category).ToListAsync();

            return items;
        }
    }
}
