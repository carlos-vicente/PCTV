using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Extensions.Logging;
using PCTV.Input.Commands;

namespace PCTV.Input
{
    public class InputManager : IInputManager
    {
        private ILogger _logger;

        public event InputReceiver InputReceived;

        public InputManager(ILogger logger)
        {
            _logger = logger;
        }

        public void EnterInput(object source, Command cmd)
        {
            try
            {
                InputReceived(source, cmd);
            }
            catch (Exception ex)
            {
                _logger.Error("There was an error in one of the InputReceiver listeners with the following message: {0}", ex.Message);
            }
        }
    }
}
