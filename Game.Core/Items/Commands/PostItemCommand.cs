using Game.Contracts.Items;
using MediatR;

namespace Game.Core.Items.Commands;

public record PostItemCommand(ItemRequest Item) : IRequest<ItemResponse>;
