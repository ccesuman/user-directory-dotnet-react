Features/Users/Queries/GetAllUsersQuery.cs
using MediatR;
using UserDirectory.Api.Models;

namespace UserDirectory.Api.Features.Users.Queries;

public class GetAllUsersQuery : IRequest<IEnumerable<User>>
{
}