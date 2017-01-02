// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT).
// ------------------------------------------------------------

using System;
using System.Fabric;

namespace Common
{
    public class ServiceUriBuilder
    {
        public ServiceUriBuilder(string serviceInstance)
        {
            ActivationContext = FabricRuntime.GetActivationContext();
            ServiceInstance = serviceInstance;
        }

        public ServiceUriBuilder(ICodePackageActivationContext context, string serviceInstance)
        {
            ActivationContext = context;
            ServiceInstance = serviceInstance;
        }

        public ServiceUriBuilder(ICodePackageActivationContext context, string applicationInstance, string serviceInstance)
        {
            ActivationContext = context;
            ApplicationInstance = applicationInstance;
            ServiceInstance = serviceInstance;
        }

        public string ApplicationInstance { get; set; }

        public string ServiceInstance { get; set; }

        public ICodePackageActivationContext ActivationContext { get; set; }

        public Uri ToUri()
        {
            var applicationInstance = ApplicationInstance;

            if (string.IsNullOrEmpty(applicationInstance))
            {
                applicationInstance = ActivationContext.ApplicationName.Replace("fabric:/", string.Empty);
            }

            return new Uri("fabric:/" + applicationInstance + "/" + ServiceInstance);
        }
    }
}
