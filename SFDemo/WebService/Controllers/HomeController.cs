using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Demo.Stateful.Domain.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace WebService.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var builder = new ServiceUriBuilder("MyService");
            var url = builder.ToUri();
            var service = ServiceProxy.Create<IMyService>(url, new ServicePartitionKey(HashUtil.GetLongHashCode(new Guid().ToString())));

            service.Test();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
