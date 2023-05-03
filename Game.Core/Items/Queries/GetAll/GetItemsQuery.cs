using Game.Domain.Entities;
using MediatR;

namespace Game.Core.Items.Queries.GetAll;

public record GetItemsQuery : IRequest<List<Item>>;
