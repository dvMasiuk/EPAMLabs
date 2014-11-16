using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.ComponentModel;

namespace ATS
{
    public class Port
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public PortState PortState { get; set; }

        public event EventHandler<PortStateChangedEventArgs> PortStateChanged;

        protected void OnPortStateChanged(PortStateChangedEventArgs e)
        {
            if (PortStateChanged != null)
            {
                PortStateChanged(this, e);
            }
        }

        public void Plug(Terminal terminal)
        {
            PortState = PortState.Connected;
            OnPortStateChanged(new PortStateChangedEventArgs(terminal.Id));
        }

        public void UnPlug()
        {
            PortState = PortState.Disconnected;
            OnPortStateChanged(new PortStateChangedEventArgs());
        }

        public void StartCall(string number)
        {
            PortState = PortState.Calling;
            OnPortStateChanged(new PortStateChangedEventArgs(number));
        }

        public void FinishCall()
        {
            PortState = PortState.Ending;
            OnPortStateChanged(new PortStateChangedEventArgs());
        }
    }
}
