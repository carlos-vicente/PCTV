using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCTV.Input.Commands.Video
{
    /// <summary>
    /// The command to play the video at it's current position
    /// </summary>
    public class Play : Command { }


    /// <summary>
    /// The command to pause the video at it's current position
    /// </summary>
    public class Pause : Command { }

    /// <summary>
    /// The command to stop the video and reset it's position
    /// </summary>
    public class Stop : Command { }

    /// <summary>
    /// The command to increase volume by a fraction
    /// </summary>
    public class UpVolume : Command { }

    /// <summary>
    /// The command to decrease volume by a fraction
    /// </summary>
    public class DownVolume : Command 
    {
        public bool Mute { get; set; }
    }
}
