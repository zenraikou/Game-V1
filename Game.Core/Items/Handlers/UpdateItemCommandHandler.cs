using Game.Contracts.Items;
using Game.Core.Common.Interfaces.Persistence;
using Game.Core.Items.Commands;
using Game.Domain.Entities;
using Mapster;
using MediatR;

namespace Game.Core.Items.Handlers;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, ItemResponse>
{
    private readonly IUnitOfwork _unitOfWork;

    public UpdateItemCommandHandler(IUnitOfwork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ItemResponse> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var config = new TypeAdapterConfig();
        config.ForType<ItemRequest, Item>().Map(dest => dest.Id, src => src.Id);

        var item = request.Item.Adapt<Item>(config);
        _unitOfWork.Items.Update(item);
        await _unitOfWork.SaveAsync();
        
        var response = item.Adapt<ItemResponse>();
        return response;
    }
}
