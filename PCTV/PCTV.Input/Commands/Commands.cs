using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCTV.Input.Commands
{
    /// <summary>
    /// This class is the base representation of all the commands accepted by the Input Manager
    /// </summary>
    public abstract class Command { }

    /// <summary>
    /// This class represents the action of selection
    /// </summary>
    public class Enter : Command { }

    /// <summary>
    /// This class represents the action of returning to the previous place
    /// </summary>
    public class GoBack : Command { }

    /// <summary>
    /// This class represents the action of moving up
    /// </summary>
    public class Up : Command { }

    /// <summary>
    /// This class represents the action of moving down
    /// </summary>
    public class Down : Command { }

    /// <summary>
    /// This class represents the action of moving right
    /// </summary>
    public class Right : Command { }

    /// <summary>
    /// This class represents the action of moving left
    /// </summary>
    public class Left : Command { }

    /// <summary>
    /// This class represents the action of sending a string
    /// </summary>
    public class SendString : Command 
    {
        /// <summary>
        /// The string sent
        /// </summary>
        public String Value { get; set; }
    }
}
