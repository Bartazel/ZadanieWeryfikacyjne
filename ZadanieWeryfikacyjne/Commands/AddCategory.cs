using MediatR;
using ZadanieWeryfikacyjne.Repository;
using ZadanieWeryfikacyjne.Repository.Entities;

namespace ZadanieWeryfikacyjne.Commands
{
    public record AddCategory(string Name, string? Description, int Code) : IRequest;
    public class AddCategoryHandler : IRequestHandler<AddCategory>
    {
        private readonly DbContext _dbContext;
        public AddCategoryHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AddCategory request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var category = new Category()
            {
                Id = id.ToString(),
                Name = request.Name,
                Description = request.Description,
                Code = request.Code,
            };

            await _dbContext.AddAsync(category, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
