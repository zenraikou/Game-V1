using Game.Contracts.Items;
using Game.Core.Common.Interfaces.Persistence;
using Game.Core.Items.Queries;
using Mapster;
using MediatR;

namespace Game.Core.Items.Handlers;

public class GetItemQueryHandler : IRequestHandler<GetItemQuery, ItemResponse?>
{
    private readonly IUnitOfwork _unitOfWork;

    public GetItemQueryHandler(IUnitOfwork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ItemResponse?> Handle(GetItemQuery request, CancellationToken cancellationToken)
    {
        var item = await _unitOfWork.Items.GetAsync(i => i.Id == request.Id);
        var response = item?.Adapt<ItemResponse>();
        return response;
    }
}
