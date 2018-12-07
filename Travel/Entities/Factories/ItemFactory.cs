namespace Travel.Entities.Factories
{
	using Contracts;
	using Items;
	using Items.Contracts;
    using System;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
            Type actualType = Type.GetType(type);

            IItem item = (IItem)Assembly.GetCallingAssembly().CreateInstance(type);
            
            return item;
		}
	}
}
