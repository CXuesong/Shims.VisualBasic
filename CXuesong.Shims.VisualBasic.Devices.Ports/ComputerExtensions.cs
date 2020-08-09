using System;
using System.Collections.Generic;
using System.Text;

namespace CXuesong.Shims.VisualBasic.Devices
{

    public static class ComputerExtensions
    {

        private static readonly object portsKey = new object();

        /// <summary>
        /// Gets an object that provides a property and a method for accessing the computer's serial ports.
        /// </summary>
        public static Ports Ports(this ServerComputer computer)
        {
            return computer.GetOrCreateExtensionSlot<Ports>(portsKey);
        }

    }

}
