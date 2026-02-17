Features/Users/Handlers/GetUserByIdHandler.cs
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserDirectory.Api.Data;
using UserDirectory.Api.Features.Users.Queries;
using UserDirectory.Api.Models;

namespace UserDirectory.Api.Features.Users.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User?>
{
    private readonly AppDbContext _db;
    private readonly ILogger<GetUserByIdHandler> _logger;

    public GetUserByIdHandler(AppDbContext db, ILogger<GetUserByIdHandler> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching user with id {UserId}", request.Id);
            throw;
        }
    }
}