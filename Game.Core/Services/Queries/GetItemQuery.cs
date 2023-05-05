using Game.Domain.Entities;
using MediatR;

namespace Game.Core.Services.Queries;

public record GetItemQuery(Guid Id) : IRequest<Item>;
