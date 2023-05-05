using Game.Domain.Entities;
using MediatR;

namespace Game.Core.Services.Commands;

public record UpdateItemCommand(Item Item) : IRequest<Item>;
