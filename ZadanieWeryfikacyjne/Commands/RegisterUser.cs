using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ZadanieWeryfikacyjne.Commands
{
    public record RegisterUser(string Username, string Password) : IRequest;

    public class RegisterUserHandler : IRequestHandler<RegisterUser>
    {
        private readonly UserManager<IdentityUser> _userManager;
        public RegisterUserHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(RegisterUser request, CancellationToken cancellationToken)
        {
            var user = new IdentityUser(request.Username);
            user.Email = request.Username;

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.ToArray().ToString());
            }

            return Unit.Value;
        }
    }
}
