Features/Users/Handlers/GetAllUsersHandler.cs
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserDirectory.Api.Data;
using UserDirectory.Api.Features.Users.Queries;
using UserDirectory.Api.Models;

namespace UserDirectory.Api.Features.Users.Handlers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
{
    private readonly AppDbContext _db;
    private readonly ILogger<GetAllUsersHandler> _logger;

    public GetAllUsersHandler(AppDbContext db, ILogger<GetAllUsersHandler> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _db.Users.AsNoTracking().ToListAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching all users");
            throw;
        }
    }
}