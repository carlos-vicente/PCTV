using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCTV.Input.Commands;

namespace PCTV.Input
{
    /// <summary>
    /// This delegate defines the method signnature for all classes that want to receive notifications of input received by the application
    /// </summary>
    /// <param name="source">The object that receveid the command</param>
    /// <param name="cmd">The command received</param>
    public delegate void InputReceiver(object source, Command cmd);


    /// <summary>
    /// This interface defines the functional contract of the input manager
    /// </summary>
    public interface IInputManager
    {
        /// <summary>
        /// The event that the interested parties in receiving commands should subscribe
        /// </summary>
        event InputReceiver InputReceived;
        /// <summary>
        /// The method by which the commands are introduced in the application
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cmd"></param>
        void EnterInput(object source, Command cmd);
    }
}
