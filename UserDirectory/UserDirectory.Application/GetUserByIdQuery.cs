Features/Users/Queries/GetUserByIdQuery.cs
using MediatR;
using UserDirectory.Api.Models;

namespace UserDirectory.Api.Features.Users.Queries;

public class GetUserByIdQuery : IRequest<User?>
{
    public int Id { get; }

    public GetUserByIdQuery(int id) => Id = id;
}