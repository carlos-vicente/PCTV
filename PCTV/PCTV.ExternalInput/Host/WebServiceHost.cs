﻿using System;
using System.ServiceModel;
using Microsoft.ApplicationServer.Http;
using Ninject.Extensions.Logging;
using PCTV.ExternalInput.Service;

namespace PCTV.ExternalInput.Host
{
    public class WebServiceHost<T> : IDisposable
    {
        private ILogger _logger;
        private T _service;
        private HttpServiceHost _host;
        private String _baseUrl;
        private bool _useTestClient;

        public WebServiceHost(T service, ILogger logger, String baseUrl) : this(service, logger, baseUrl, false) { }

        public WebServiceHost(T service, ILogger logger, String baseUrl, bool useTestClient)
        {
            _logger = logger;
            _service = service;
            _baseUrl = baseUrl;
            _useTestClient = useTestClient;
        }

        public void Open()
        {
            HttpConfiguration conf = new HttpConfiguration();
            conf.EnableTestClient = _useTestClient;
            conf.IncludeExceptionDetail = true;
            conf.EnableHelpPage = true;

            _host = new HttpServiceHost(_service, conf, new Uri(_baseUrl));
            _host.Open();

            _logger.Info("Host is opened with the following endpoints:");
            foreach (var ep in _host.Description.Endpoints)
            {
                _logger.Info("\tEndpoint: address = {0}; binding = {1}", ep.Address, ep.Binding);
            }
        }
    
        public void Dispose()
        {
            if (_host != null && _host.State == CommunicationState.Opened)
                _host.Close();
        }
    }
}
