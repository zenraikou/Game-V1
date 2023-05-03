using Game.Contracts.Items;
using Game.Core.Common.Interfaces.Persistence;
using Game.Core.Items.Commands;
using Game.Domain.Entities;
using Mapster;
using MapsterMapper;
using MediatR;

namespace Game.Core.Items.Handlers;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, ItemResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfwork _unitOfWork;

    public UpdateItemCommandHandler(IMapper mapper, IUnitOfwork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ItemResponse> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Item>(request.Item);
        _unitOfWork.Items.Update(item);
        await _unitOfWork.SaveAsync();
        
        var response = item.Adapt<ItemResponse>();
        return response;
    }
}
