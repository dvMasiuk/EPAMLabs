using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.ComponentModel;

namespace ATS
{
    public class Port : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public bool Assigned { get; set; }

        private PortState _portState;

        [NotMapped]
        public PortState PortState
        {
            get { return this._portState; }
            set
            {
                this._portState = value;
                OnPropertyChanged("PortState");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
