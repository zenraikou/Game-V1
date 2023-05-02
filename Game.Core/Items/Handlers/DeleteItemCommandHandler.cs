using Game.Contracts.Items;
using Game.Core.Common.Interfaces.Persistence;
using Game.Core.Items.Commands;
using Game.Domain.Entities;
using Mapster;
using MediatR;

namespace Game.Core.Items.Handlers;

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, ItemResponse>
{
    private readonly IUnitOfwork _unitOfWork;

    public DeleteItemCommandHandler(IUnitOfwork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ItemResponse> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        var item = request.Item.Adapt<Item>();
        _unitOfWork.Items.Delete(item);
        await _unitOfWork.SaveAsync();

        var response = item.Adapt<ItemResponse>();
        return response;
    }
}
