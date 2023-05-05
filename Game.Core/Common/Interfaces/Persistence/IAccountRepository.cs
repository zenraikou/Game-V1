using Game.Domain.Entities;

namespace Game.Core.Common.Interfaces.Persistence;

public interface IAccountRepository
{ 
    Task<User> Login(User user);
    Task Register(User user);
}
