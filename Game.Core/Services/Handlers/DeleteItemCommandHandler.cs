using Game.Core.Common.Interfaces.Persistence;
using Game.Core.Services.Commands;
using Game.Domain.Entities;
using MediatR;

namespace Game.Core.Services.Handlers;

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, Item>
{
    private readonly IUnitOfwork _unitOfWork;

    public DeleteItemCommandHandler(IUnitOfwork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Item> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.Items.Delete(request.Item);
        await _unitOfWork.SaveAsync();
        
        var response = request.Item;
        return response;
    }
}
