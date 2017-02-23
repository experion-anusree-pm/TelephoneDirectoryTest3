using Experion.Marina.Data.Contracts;

namespace Experion.Marina.Data.Services
{
    public class SampleEntity : ISampleEntity, IEntity<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}