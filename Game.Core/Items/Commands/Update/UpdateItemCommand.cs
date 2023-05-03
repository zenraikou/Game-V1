using Game.Domain.Entities;
using MediatR;

namespace Game.Core.Items.Commands.Update;

public record UpdateItemCommand(Item Item) : IRequest<Item>;
