using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Ninject.Extensions.Logging;
using PCTV.Input;
using PCTV.Input.Commands;
using PCTV.Input.Commands.Video;

namespace PCTV.ExternalInput.Service
{
    [ServiceBehavior(Name="ExternalInputManager", Namespace="http://pctv.com", 
        ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class ExternalInputService : IExternalInput
    {
        private IInputManager _manager;
        private ILogger _logger;

        public ExternalInputService(IInputManager inputManager, ILogger logger)
        {
            _manager = inputManager;
            _logger = logger;
        }

        public void Up()
        {
            _logger.Info("The Up operation was invoked");
            _manager.EnterInput(this, new Up());
        }

        public void Down()
        {
            _logger.Info("The Down operation was invoked");
            _manager.EnterInput(this, new Down());
        }

        public void Right()
        {
            _logger.Info("The Right operation was invoked");
            _manager.EnterInput(this, new Right());
        }

        public void Left()
        {
            _logger.Info("The Left operation was invoked");
            _manager.EnterInput(this, new Left());
        }

        public void Enter()
        {
            _logger.Info("The Enter operation was invoked");
            _manager.EnterInput(this, new Enter());
        }

        public void EnterString(string value)
        {
            _logger.Info("The EnterString operation was invoked");
            _manager.EnterInput(this, new SendString(){ Value = value });
        }

        public void UpVolume()
        {
            _logger.Info("The UpVolume operation was invoked");
            _manager.EnterInput(this, new UpVolume());
        }

        public void DownVolume()
        {
            _logger.Info("The DownVolume operation was invoked");
            _manager.EnterInput(null, new DownVolume());
        }

        public void Mute()
        {
            _logger.Info("The Mute operation was invoked");
            _manager.EnterInput(null, new DownVolume() { Mute = true });
        }

        public void Play()
        {
            _logger.Info("The Play operation was invoked");
            _manager.EnterInput(null, new Play());
        }

        public void Pause()
        {
            _logger.Info("The Pause operation was invoked");
            _manager.EnterInput(null, new Pause());
        }

        public void Stop()
        {
            _logger.Info("The Stop operation was invoked");
            _manager.EnterInput(null, new Stop());
        }
    }
}
