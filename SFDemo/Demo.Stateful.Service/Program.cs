using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.ServiceFabric.Services.Runtime;

namespace Demo.Stateful.Service
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                ServiceRuntime.RegisterServiceAsync("MyServiceType", context => new MyService(context)).GetAwaiter().GetResult();
                ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(MyService).Name);
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
