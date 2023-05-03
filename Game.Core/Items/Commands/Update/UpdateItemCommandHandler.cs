using Game.Core.Common.Interfaces.Persistence;
using Game.Domain.Entities;
using MediatR;

namespace Game.Core.Items.Commands.Update;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, Item>
{
    private readonly IUnitOfwork _unitOfWork;

    public UpdateItemCommandHandler(IUnitOfwork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Item> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.Items.Update(request.Item);
        await _unitOfWork.SaveAsync();
        
        var response = request.Item;
        return response;
    }
}
