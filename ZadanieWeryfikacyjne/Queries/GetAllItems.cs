using MediatR;
using Microsoft.EntityFrameworkCore;
using ZadanieWeryfikacyjne.Repository.Entities;

namespace ZadanieWeryfikacyjne.Queries
{
    public record GetAllItems : IRequest<List<Item>?>;
    public class GetAllItemsHandler : IRequestHandler<GetAllItems, List<Item>?>
    {
        private readonly Repository.DbContext _dbContext;
        public GetAllItemsHandler(Repository.DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Item>?> Handle(GetAllItems request, CancellationToken cancellationToken)
        {
            var items = await _dbContext.Items.ToListAsync();

            return items;
        }
    }
}
