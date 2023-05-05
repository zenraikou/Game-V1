using Game.Domain.Entities;
using MediatR;

namespace Game.Core.Services.Queries;

public record GetAllItemsQuery : IRequest<List<Item>>;
