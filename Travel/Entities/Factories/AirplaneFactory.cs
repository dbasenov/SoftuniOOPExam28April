namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using Travel.Entities.Airplanes;
    using System;
    using System.Reflection;

    public class AirplaneFactory : IAirplaneFactory
	{

        //case "LightAirplane":
        //	return new LightAirplane();
        //case "MediumAirplane":
        //	return new MediumAirplane();
        public IAirplane CreateAirplane(string type)
		{
            Type actualType = Type.GetType(type);

            IAirplane airplane = (IAirplane)Assembly.GetCallingAssembly().CreateInstance(type);

            return airplane;
		}
	}
}