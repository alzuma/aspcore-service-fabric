using System.Collections.Generic;
using System.Fabric;
using System.Threading.Tasks;
using Demo.Stateful.Domain.interfaces;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;

namespace Demo.Stateful.Service
{
    public class MyService: StatefulService, IMyService
    {
        public MyService(StatefulServiceContext serviceContext) : base(serviceContext)
        {
        }

        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new[]
            {
                new ServiceReplicaListener(this.CreateServiceRemotingListener)
            };
        }

        public async Task Test()
        {
            ServiceEventSource.Current.Message("Test");
            await Task.FromResult<bool>(true);
        }
    }
}