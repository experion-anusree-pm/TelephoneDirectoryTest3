using Experion.Marina.Dto;

namespace Experion.Marina.Business.Services.Contracts
{
    public interface ISampleService
    {
        SampleDto GetSample(long id);
    }
}