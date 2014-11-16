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

        public void Call(string number)
        {
            if (this._port != null)
            {
                this._port.StartCall(number);
            }
        }

        public void EndCall()
        {
            if (this._port != null)
            {
                this._port.FinishCall();
            }
        }

        public void Connect(Port port)
        {
            if (port != null)
            {
                this._port = port;
                this._port.Plug(this);
            }
        }

        public void Disconnect()
        {
            if (this._port != null)
            {
                this._port.UnPlug();
                this._port = null;
            }
        }
    }
}
