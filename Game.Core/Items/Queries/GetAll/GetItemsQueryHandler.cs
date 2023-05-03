using Game.Core.Common.Interfaces.Persistence;
using Game.Domain.Entities;
using MediatR;

namespace Game.Core.Items.Queries.GetAll;

public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, List<Item>>
{
    private readonly IUnitOfwork _unitOfWork;

    public GetItemsQueryHandler(IUnitOfwork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Item>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
    {
        var response = await _unitOfWork.Items.GetAllAsync();
        return response;
    }
}
