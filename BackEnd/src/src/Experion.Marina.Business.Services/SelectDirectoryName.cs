using Autofac;
using Experion.Marina.Business.Services.Contracts;
using Experion.Marina.Core;
using Experion.Marina.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Business.Services
{
    public class SelectDirectoryName : BusinessService, ISelectDirectoryName
    {
        private readonly IComponentContext _iocContext;

        public SelectDirectoryName(IComponentContext iocContext)
        {
            _iocContext = iocContext;
        }

        public string DirectoryName(int DirectoryId)
        {
            throw new NotImplementedException();
        }

        //Select Directory Name

    }
}
