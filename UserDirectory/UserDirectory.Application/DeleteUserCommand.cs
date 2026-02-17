Features/Users/Commands/DeleteUserCommand.cs
using MediatR;

namespace UserDirectory.Api.Features.Users.Commands;

public class DeleteUserCommand : IRequest<bool>
{
    public int Id { get; init; }
}