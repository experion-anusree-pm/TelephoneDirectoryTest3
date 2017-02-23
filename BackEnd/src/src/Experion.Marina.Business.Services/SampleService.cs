using Autofac;
using Experion.Marina.Business.Services.Contracts;
using Experion.Marina.Core;
using Experion.Marina.Data.Contracts;
using Experion.Marina.Dto;

namespace Experion.Marina.Business.Services
{
    public class SampleService : BusinessService, ISampleService
    {
        private readonly IComponentContext _iocContext;

        public SampleService(IComponentContext iocContext)
        {
            _iocContext = iocContext;
        }

        public SampleDto GetSample(long id)
        {
            var sampleDataService = _iocContext.Resolve<ISampleDataService>();

            var sampleEntity = sampleDataService.GetSampleEntity(id);

            return new SampleDto
            {
                Id = sampleEntity.Id,
                Name = sampleEntity.Name
            };
        }
    }
}
