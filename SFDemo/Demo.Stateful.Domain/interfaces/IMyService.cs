using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Demo.Stateful.Domain.interfaces
{
    public interface IMyService: IService
    {
        Task Test();
    }
}