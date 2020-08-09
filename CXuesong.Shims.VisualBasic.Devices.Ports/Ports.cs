using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace CXuesong.Shims.VisualBasic.Devices
{

    /// <summary>
    /// Provides a property and a method for accessing the computer's serial ports.
    /// </summary>
    public class Ports
    {

        /// <summary>Gets a collection of the names of the serial ports on the computer.</summary>
        public IReadOnlyList<string> SerialPortNames => SerialPort.GetPortNames();

        /// <inheritdoc cref="OpenSerialPort(string,int,Parity,int,StopBits)"/>
        public SerialPort OpenSerialPort(string portName) => new SerialPort(portName);

        /// <inheritdoc cref="OpenSerialPort(string,int,Parity,int,StopBits)"/>
        public SerialPort OpenSerialPort(string portName, int baudRate) => new SerialPort(portName, baudRate);

        /// <inheritdoc cref="OpenSerialPort(string,int,Parity,int,StopBits)"/>
        public SerialPort OpenSerialPort(string portName, int baudRate, Parity parity) => new SerialPort(portName, baudRate, parity);

        /// <inheritdoc cref="OpenSerialPort(string,int,Parity,int,StopBits)"/>
        public SerialPort OpenSerialPort(string portName, int baudRate, Parity parity, int dataBits) => new SerialPort(portName, baudRate, parity, dataBits);

        /// <summary>Creates and opens a <see cref="SerialPort"/> object.</summary>
        /// <param name="portName">The port to use (for example, COM1).</param>
        /// <param name="baudRate">The baud rate.</param>
        /// <param name="parity">One of the <see cref="Parity" /> values.</param>
        /// <param name="dataBits">The data bits value.</param>
        /// <param name="stopBits">One of the <see cref="StopBits" /> values.</param>
        /// <exception cref="T:System.IO.IOException">The specified port could not be found or opened.</exception>
        public SerialPort OpenSerialPort(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits) => new SerialPort(portName, baudRate, parity, dataBits, stopBits);

    }

}
