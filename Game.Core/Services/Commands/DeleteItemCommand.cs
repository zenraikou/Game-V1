using Game.Domain.Entities;
using MediatR;

namespace Game.Core.Services.Commands;

public record DeleteItemCommand(Item Item) : IRequest<Item>;
