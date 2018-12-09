namespace Travel.Entities.Factories
{
	using Contracts;
	using Items;
	using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
            var itemTypes = Assembly.GetCallingAssembly().GetTypes()
                .Where(t => typeof(IItem).IsAssignableFrom(t) && !t.IsAbstract)
                .ToArray();

            var itemType = itemTypes.FirstOrDefault(t => t.Name == type);

            var item = (IItem)Activator.CreateInstance(itemType);

            return item;
		}
	}
}
