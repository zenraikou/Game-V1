using Game.Core.Common.Interfaces.Persistence;
using Game.Core.Services.Queries;
using Game.Domain.Entities;
using MediatR;

namespace Game.Core.Services.Handlers;

public class GetItemQueryHandler : IRequestHandler<GetItemQuery, Item?>
{
    private readonly IUnitOfwork _unitOfWork;

    public GetItemQueryHandler(IUnitOfwork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Item?> Handle(GetItemQuery request, CancellationToken cancellationToken)
    {
        var response = await _unitOfWork.Items.GetAsync(i => i.Id == request.Id);
        return response;
    }
}
