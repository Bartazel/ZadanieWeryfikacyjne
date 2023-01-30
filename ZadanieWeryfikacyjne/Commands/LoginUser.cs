using MediatR;
using Microsoft.AspNetCore.Identity;
using ZadanieWeryfikacyjne.Exceptions;

namespace ZadanieWeryfikacyjne.Commands
{
    public record LoginUser(string Username, string Password) : IRequest;

    public class LoginUserHandler : IRequestHandler<LoginUser>
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public LoginUserHandler(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Unit> Handle(LoginUser request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);
            if (!result.Succeeded)
            {
                throw new UserSignInFailedException(result.ToString());
            }

            return Unit.Value;
        }
    }
}
