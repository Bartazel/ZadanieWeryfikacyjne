using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ZadanieWeryfikacyjne.Commands
{
    public record LogoutUser() : IRequest;

    public class LogoutUserHandler : IRequestHandler<LogoutUser>
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LogoutUserHandler(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Unit> Handle(LogoutUser request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return Unit.Value;
        }
    }
}
