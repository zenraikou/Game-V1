using Game.Domain.Entities;
using MediatR;

namespace Game.Core.Items.Queries.Get;

public record GetItemQuery(Guid Id) : IRequest<Item>;
