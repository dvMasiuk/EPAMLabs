﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace RailTransport
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class PassengerCar : Car, IComparable<PassengerCar>
    {
        private IList<Passenger> _passengers;

        #region properties
        public virtual int CountBaggage
        {
            get { return this._passengers.Count(x => x.HasBaggage); }
        }

        public virtual int CountFreeSeats
        {
            get { return CountSeats - CountPassengers; }
        }

        public virtual int CountPassengers
        {
            get { return this._passengers.Count; }
        }

        public virtual int CountSeats
        {
            get;
            protected set;
        }

        public virtual int CountTakenSeats
        {
            get { return CountPassengers; }
        }
        public virtual TypeCar Type
        {
            get;
            protected set;
        }
        #endregion

        public PassengerCar(int number, TypeCar type)
        {
            this._passengers = new List<Passenger>();
            Number = number;
            Type = type;
            switch (type)
            {
                case TypeCar.Platskartny:
                    CountSeats = 54;
                    break;
                case TypeCar.Kupe:
                    CountSeats = 36;
                    break;
                case TypeCar.SpalnyVagon:
                    CountSeats = 18;
                    break;
            }
        }

        public virtual void AddPassenger(Passenger pass)
        {
            this._passengers.Add(pass);
        }

        public virtual void RemovePassenger(Passenger pass)
        {
            this._passengers.Remove(pass);
        }

        public virtual void RemoveAllPassengers()
        {
            this._passengers.Clear();
        }

        public int CompareTo(PassengerCar other)
        {
            return Type.CompareTo(other.Type);
        }

        public override string ToString()
        {
            return string.Format("Car №{0}\n Type: {1}\n CountPassengers: {2}\n CountBaggage: {3}\n CountFreeSeats: {4}\n CountSeats: {5}",
                this.Number, this.Type, this.CountPassengers, this.CountBaggage,this.CountFreeSeats, this.CountSeats);
        }
	}
}

