using Game.Core.Common.Interfaces.Persistence;
using Game.Core.Services.Commands;
using Game.Domain.Entities;
using MediatR;

namespace Game.Core.Services.Handlers;

public class PostItemCommandHandler : IRequestHandler<PostItemCommand, Item>
{
    private readonly IUnitOfwork _unitOfWork;

    public PostItemCommandHandler(IUnitOfwork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Item> Handle(PostItemCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Items.PostAsync(request.Item);
        await _unitOfWork.SaveAsync();
        
        var response = request.Item;
        return response;
    }
}
