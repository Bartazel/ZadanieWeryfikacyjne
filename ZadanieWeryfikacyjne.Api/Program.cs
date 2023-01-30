using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZadanieWeryfikacyjne;
using ZadanieWeryfikacyjne.Commands;
using ZadanieWeryfikacyjne.Commands.Validators;
using ZadanieWeryfikacyjne.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails(configure => ProblemDetailsConfiguration.ConfigureProblemDetails(configure));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "corsPolicy",
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
builder.Services.AddDbContext<DbContext>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<DbContext>();
builder.Services.AddMediatR(typeof(ZadanieWeryfikacyjne.Commands.AddItemHandler));
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssemblyContaining<ZadanieWeryfikacyjne.Commands.Validators.AddItemValidator>();
builder.Services.AddScoped<IValidator<AddItem>, AddItemValidator>();
builder.Services.AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsPolicy");
app.UseRouting();
app.UseProblemDetails();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
