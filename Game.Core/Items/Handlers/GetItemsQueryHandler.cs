using Game.Contracts.Items;
using Game.Core.Common.Interfaces.Persistence;
using Game.Core.Items.Queries;
using Mapster;
using MediatR;

namespace Game.Core.Items.Handlers;

public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, List<ItemResponse>>
{
    private readonly IUnitOfwork _unitOfWork;

    public GetItemsQueryHandler(IUnitOfwork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ItemResponse>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await _unitOfWork.Items.GetAllAsync();
        var response = items.Adapt<List<ItemResponse>>();
        return response;
    }
}
