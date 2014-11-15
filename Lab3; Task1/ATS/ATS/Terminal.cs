using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ATS
{
    public class Terminal
    {
        public int Id { get; set; }

        [NotMapped]
        public TelephoneNumber TelephoneNumber { get; set; }

        [NotMapped]
        public Port Port { get; set; }

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
    }
}
