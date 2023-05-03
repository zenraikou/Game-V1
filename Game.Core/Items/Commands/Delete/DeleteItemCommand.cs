using Game.Domain.Entities;
using MediatR;

namespace Game.Core.Items.Commands.Delete;

public record DeleteItemCommand(Item Item) : IRequest<Item>;
