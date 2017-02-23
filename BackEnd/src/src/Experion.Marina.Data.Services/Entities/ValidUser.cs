using Experion.Marina.Data.Contracts.Entities;

namespace Experion.Marina.Data.Services.Entities
{
    public class ValidUser: IValidUser
    {
        public long Id { get; set; }
        public bool isValid { get; set; }
    }
}
