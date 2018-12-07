namespace Travel.Entities.Airplanes
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.Immutable;
	using System.Linq;
	using Entities.Contracts;
    using Travel.Entities.Airplanes.Contracts;

    // migrated from java. please do the needful kind sir
    public abstract class Airplane : IAirplane {
		private IList<IBag> luggage;
		private IList<IPassenger> passengers;
		public Airplane(int seats, int bags)
        {
			this.passengers = new List<IPassenger>();
			this.Seats = seats;
			this.BaggageCompartments = bags;
			this.luggage = new List<IBag>();
		}
		public int Seats { get; }
		public int BaggageCompartments { get; }
        public IReadOnlyCollection<IBag> BaggageCompartment => this.luggage as IReadOnlyList<IBag>;
		public IReadOnlyCollection<IPassenger> Passengers => this.passengers as IReadOnlyList<IPassenger>;
		public bool IsOverbooked => this.Passengers.Count > this.Seats;
        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
		}
		public IPassenger RemovePassenger(int seatIndex) {
            // mdrchd
            var passenger = this.passengers[seatIndex];
            this.passengers.RemoveAt(seatIndex);            		

			return passenger;
		}

		public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
			var passengerBags = this.luggage
				.Where(b => b.Owner == passenger)
				.ToArray();

            foreach (var bag in passengerBags)
            {
                this.luggage.Remove(bag);
            }

			return passengerBags;
		}

		public void LoadBag(IBag bag)
        {
			bool isBaggageCompartmentFull = this.BaggageCompartment.Count > this.BaggageCompartments;
            if (isBaggageCompartmentFull)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().ToString()}!");
            }

			this.luggage.Add(bag);
		}
	}
}