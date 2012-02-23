using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Extensions.Logging;
using PCTV.Input.Commands;

namespace PCTV.Input.Concrete
{
    public class InputManager : IInputManager
    {
        private ILogger _logger;

        public event InputReceiver InputReceived;

        public InputManager(ILogger logger)
        {
            _logger = logger;
            InputReceived = new InputReceiver(LogInput);
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

        private void LogInput(object source, Command cmd)
        {
            _logger.Info("Received input {0} from {1}", cmd, source == null ? "null" : source.ToString());
        }
    }
}
