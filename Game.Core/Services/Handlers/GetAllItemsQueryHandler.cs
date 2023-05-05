using Game.Core.Common.Interfaces.Persistence;
using Game.Core.Services.Queries;
using Game.Domain.Entities;
using MediatR;

namespace Game.Core.Services.Handlers;

public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, List<Item>>
{
    private readonly IUnitOfwork _unitOfWork;

    public GetAllItemsQueryHandler(IUnitOfwork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Item>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
    {
        var response = await _unitOfWork.Items.GetAllAsync();
        return response;
    }
}
