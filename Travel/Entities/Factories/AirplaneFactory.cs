namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using Travel.Entities.Airplanes;
    using System;
    using System.Reflection;
    using System.Linq;

    public class AirplaneFactory : IAirplaneFactory
	{

        //case "LightAirplane":
        //	return new LightAirplane();
        //case "MediumAirplane":
        //	return new MediumAirplane();
        public IAirplane CreateAirplane(string type)
		{
            var airplaneTypes = Assembly.GetCallingAssembly().GetTypes()
                .Where(t => typeof(IAirplane).IsAssignableFrom(t) && !t.IsAbstract)
                .ToArray();

            var airplaneType = airplaneTypes.FirstOrDefault(t => t.Name == type);

            var airplane = (IAirplane)Activator.CreateInstance(airplaneType);

            return airplane;
        }
	}
}