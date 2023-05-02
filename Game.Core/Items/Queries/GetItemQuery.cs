using Game.Contracts.Items;
using MediatR;

namespace Game.Core.Items.Queries;

public record GetItemQuery(Guid Id) : IRequest<ItemResponse>;
