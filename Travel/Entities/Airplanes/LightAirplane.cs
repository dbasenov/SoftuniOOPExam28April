using Travel.Entities.Airplanes.Contracts;

namespace Travel.Entities.Airplanes
{
	public class LightAirplane : Airplane
	{
		public LightAirplane()
			: base(seats: 5, bags: 8)
		{
		}
	}
}