using MediatR;
using Microsoft.AspNetCore.Http;
using ZadanieWeryfikacyjne.Exceptions;
using ZadanieWeryfikacyjne.Repository;
using ZadanieWeryfikacyjne.Repository.Entities;

namespace ZadanieWeryfikacyjne.Commands
{
    public record AddItem(string Name, decimal Price, int CategoryCode) : IRequest;
    public class AddItemHandler : IRequestHandler<AddItem>
    {
        private readonly DbContext _dbContext;
        public AddItemHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AddItem request, CancellationToken cancellationToken)
        {
            var category = _dbContext.Categories.Where(c => c.Code == request.CategoryCode).FirstOrDefault();
            if (category == null) 
            {
                throw new AddingItemFailedException($"Category with a given code {request.CategoryCode} was not found.",
                    StatusCodes.Status404NotFound);
            }

            var id = Guid.NewGuid();
            var item = new Item()
            {
                Id = id.ToString(),
                Code = id.GetHashCode().ToString() + "-" + request.CategoryCode,
                Name = request.Name,
                Price = request.Price,
                Category = category
            };

            await _dbContext.AddAsync(item, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
