using Game.Domain.Entities;
using MediatR;

namespace Game.Core.Services.Commands;

public record PostItemCommand(Item Item) : IRequest<Item>;
