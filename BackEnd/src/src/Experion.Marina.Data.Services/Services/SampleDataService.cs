using Autofac;
using Experion.Marina.Data.Contracts;

namespace Experion.Marina.Data.Services.Services
{
    public class SampleDataService : DataService<MarinaContext>, ISampleDataService
    {
        private IRepository<SampleEntity, long> SampleRepository => DataContext.GetRepository<SampleEntity, long>();


        public SampleDataService(IComponentContext iocContext, IRepositoryContext context)
            : base(iocContext, context)
        {
        }

        public ISampleEntity GetSampleEntity(long id)
        {
            var entity = SampleRepository.GetById(id);
            return entity;
        }
    }
}
