﻿using System;
using System.ServiceModel;
using Microsoft.ApplicationServer.Http;
using Ninject;
using PCTV.ExternalInput.Service;
using Microsoft.ApplicationServer.Http.Description;
using Ninject.Parameters;

namespace PCTV.ExternalInput.Host
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    IKernel kernel = new StandardKernel(new PCTV.Input.DependencyModule(), new PCTV.ExternalInput.DependencyModule());

        //    IExternalInput service = kernel.Get<IExternalInput>();

        //    HttpConfiguration conf = new HttpConfiguration();
        //    conf.EnableTestClient = true;
        //    conf.IncludeExceptionDetail = true;

        //    using (var host = new HttpServiceHost(service, conf, new Uri("http://localhost:8080/ExternalInput")))
        //    {
        //        host.Open();
        //        ShowEndpointsOf(host);
        //        WaitForKey();
        //    }
        //}

        //private static void ShowEndpointsOf(ServiceHost host)
        //{
        //    Console.WriteLine("Host is opened with the following endpoints:");
        //    foreach (var ep in host.Description.Endpoints)
        //    {
        //        Console.WriteLine("\tEndpoint: address = {0}; binding = {1}", ep.Address, ep.Binding);
        //    }
        //}

        private static void WaitForKey()
        {
            Console.WriteLine("Press any key to stop host...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            try
            {
                IKernel kernel = new StandardKernel(new PCTV.Input.Concrete.DependencyModule(), new PCTV.ExternalInput.DependencyModule());

                using (var host = kernel.Get<WebServiceHost<IExternalInput>>(new ConstructorArgument("baseUrl", "http://localhost:8080/ExternalInput")))
                {
                    host.Open();
                    WaitForKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The following error occured: {0}", ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
