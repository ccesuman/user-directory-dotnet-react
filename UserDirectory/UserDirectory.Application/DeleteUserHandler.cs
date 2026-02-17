Features/Users/Handlers/DeleteUserHandler.cs
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserDirectory.Api.Data;
using UserDirectory.Api.Features.Users.Commands;

namespace UserDirectory.Api.Features.Users.Handlers;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly AppDbContext _db;
    private readonly ILogger<DeleteUserHandler> _logger;

    public DeleteUserHandler(AppDbContext db, ILogger<DeleteUserHandler> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
            if (user == null) return false;

            _db.Users.Remove(user);
            await _db.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting user with id {UserId}", request.Id);
            throw;
        }
    }
}