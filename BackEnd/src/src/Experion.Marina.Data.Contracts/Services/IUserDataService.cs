using Experion.Marina.Data.Contracts.Entities;

namespace Experion.Marina.Data.Contracts.Services
{
    public interface IUserDataService
    {
        IValidUser IsValidEntity(IUserCredential userCredential);
    }
}
