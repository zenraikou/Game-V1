using Game.Domain.Entities;
using MediatR;

namespace Game.Core.Items.Commands.Post;

public record PostItemCommand(Item Item) : IRequest<Item>;
