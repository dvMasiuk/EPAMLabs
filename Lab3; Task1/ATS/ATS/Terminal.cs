using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ATS
{
    public class Terminal
    {
        private Port _port;

        public int Id { get; set; }

        public void Display(string message)
        {
            Console.WriteLine(message);
        }

        public void Call(string number)
        {
            //if (PortState == PortState.Connected)
            //    PortState = PortState.Calling;
        }

        public void End()
        {
            //if (PortState == PortState.Calling)
            //    PortState = PortState.Connected;
        }

        public void Connect(Port port)
        {
            if (port != null)
            {
                this._port = port;
                this._port.PortState = PortState.Connected;
            }
        }

        public void Disconnect()
        {
            if (this._port != null)
            {
                this._port.PortState = PortState.Disconnected;
                this._port = null;
            }
        }
    }
}
