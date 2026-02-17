Features/Users/Commands/CreateUserCommand.cs
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace UserDirectory.Api.Features.Users.Commands;
        
public class CreateUserCommand : IRequest<int>
{   
    [Required, StringLength(100, MinimumLength = 2)]
    public string Name { get; init; } = string.Empty;

    [Required, Range(0, 120)]
    public int Age { get; init; }

    [Required]
    public string City { get; init; } = string.Empty;

    [Required]
    public string State { get; init; } = string.Empty;

    [Required, StringLength(10, MinimumLength = 4)]
    public string Pincode { get; init; } = string.Empty;
}