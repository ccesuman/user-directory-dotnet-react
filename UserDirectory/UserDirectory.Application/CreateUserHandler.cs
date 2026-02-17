Features/Users/Handlers/CreateUserHandler.cs
using MediatR;
using Microsoft.Extensions.Logging;
using UserDirectory.Api.Data;
using UserDirectory.Api.Models;
using UserDirectory.Api.Features.Users.Commands;

namespace UserDirectory.Api.Features.Users.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly AppDbContext _db;
    private readonly ILogger<CreateUserHandler> _logger;

    public CreateUserHandler(AppDbContext db, ILogger<CreateUserHandler> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = new User
            {
                Name = request.Name,
                Age = request.Age,
                City = request.City,
                State = request.State,
                Pincode = request.Pincode
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating user");
            throw;
        }
    }
}