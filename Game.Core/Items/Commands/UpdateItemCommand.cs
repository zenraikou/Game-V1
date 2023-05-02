using Game.Contracts.Items;
using MediatR;

namespace Game.Core.Items.Commands;

public record UpdateItemCommand(ItemRequest Item) : IRequest<ItemResponse>;
