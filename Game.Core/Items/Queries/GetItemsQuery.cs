using Game.Contracts.Items;
using MediatR;

namespace Game.Core.Items.Queries;

public record GetItemsQuery : IRequest<List<ItemResponse>>;
