namespace Experion.Marina.Data.Contracts.Entities
{
    public interface IValidUser
    {
        long Id { get; set; }
        bool isValid { get; set; }
    }
}
