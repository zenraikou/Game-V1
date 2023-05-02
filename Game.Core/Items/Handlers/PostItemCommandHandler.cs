using Game.Contracts.Items;
using Game.Core.Common.Interfaces.Persistence;
using Game.Core.Items.Commands;
using Game.Domain.Entities;
using Mapster;
using MediatR;

namespace Game.Core.Items.Handlers;

public class PostItemCommandHandler : IRequestHandler<PostItemCommand, ItemResponse>
{
    private readonly IUnitOfwork _unitOfWork;

    public PostItemCommandHandler(IUnitOfwork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ItemResponse> Handle(PostItemCommand request, CancellationToken cancellationToken)
    {
        var item = request.Item.Adapt<Item>();
        await _unitOfWork.Items.PostAsync(item);
        await _unitOfWork.SaveAsync();
        var response = item.Adapt<ItemResponse>();
        return response;
    }
}
