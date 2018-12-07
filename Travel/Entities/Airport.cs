namespace Travel.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;
	
	public class Airport : IAirport
	{
		private List<IBag> confiscatedBags;
		private List<IBag> checkedInBags;
		private List<ITrip> trips;
		private List<IPassenger> passengers;

        public Airport()
        {
            confiscatedBags = new List<IBag>();
            checkedInBags = new List<IBag>();
            trips = new List<ITrip>();
            passengers = new List<IPassenger>();
        }

        public IReadOnlyCollection<IBag> CheckedInBags => this.checkedInBags.AsReadOnly();

        public IReadOnlyCollection<IBag> ConfiscatedBags => this.confiscatedBags.AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

        public IReadOnlyCollection<ITrip> Trips => this.trips.AsReadOnly();

        public IPassenger GetPassenger(string username) => passengers.Find(n => n.Username == username);

		public ITrip GetTrip(string id) => trips.Find(i => i.Id == id);

		public void AddPassenger(IPassenger passenger) => passengers.Add(passenger);

		public void AddTrip(ITrip trip) => trips.Add(trip);

		public void AddCheckedBag(IBag bag) => checkedInBags.Add(bag);

		public void AddConfiscatedBag(IBag bag) => confiscatedBags.Add(bag);
	}
}