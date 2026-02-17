Features/Users/Handlers/UpdateUserHandler.cs
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserDirectory.Api.Data;
using UserDirectory.Api.Features.Users.Commands;

namespace UserDirectory.Api.Features.Users.Handlers;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly AppDbContext _db;
    private readonly ILogger<UpdateUserHandler> _logger;

    public UpdateUserHandler(AppDbContext db, ILogger<UpdateUserHandler> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
            if (user == null) return false;

            user.Name = request.Name;
            user.Age = request.Age;
            user.City = request.City;
            user.State = request.State;
            user.Pincode = request.Pincode;

            await _db.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating user with id {UserId}", request.Id);
            throw;
        }
    }
}