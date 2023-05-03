using Game.Core.Common.Interfaces.Persistence;
using Game.Domain.Entities;
using MediatR;

namespace Game.Core.Items.Commands.Post;

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
