using Game.Contracts.Items;
using MediatR;

namespace Game.Core.Items.Commands;

public record DeleteItemCommand(ItemRequest Item) : IRequest<ItemResponse>;
