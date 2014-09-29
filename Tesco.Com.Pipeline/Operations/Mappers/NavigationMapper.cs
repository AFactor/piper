using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity = Tesco.Com.Pipeline.Entities.ResponseEntities;

namespace Tesco.Com.Pipeline.Operations.Mappers
{
    public static class NavigationMapper
    {
        public static List<Entity.Navigation> MapNavigationCMSResponse(IEnumerable<Entity.Navigation> toInput)
        {
            Entity.Hierarchy hierarchy = new Entity.Hierarchy();
            Entity.Navigation navigation = new Entity.Navigation();

            hierarchy.Name = "Shop Groceries";
            List<Entity.Hero> lstHero = new List<Entity.Hero>();
            lstHero.Add(new Entity.Hero { Value = "Bakery" });
            lstHero.Add(new Entity.Hero { Value = "Butcher" });
            lstHero.Add(new Entity.Hero { Value = "Cheese monger" });
            lstHero.Add(new Entity.Hero { Value = "Off Licence" });
            lstHero.Add(new Entity.Hero { Value = "Pet Shop" });
            hierarchy.Hero = lstHero;
            navigation.ShopGroceries = hierarchy;

            List<Entity.Child> childs;

            hierarchy = new Entity.Hierarchy();
            hierarchy.Name = "My Shopping";
            childs = new List<Entity.Child>();
            childs.Add(new Entity.Child { Name = "My Favourites" });
            childs.Add(new Entity.Child { Name = "My Orders" });
            childs.Add(new Entity.Child { Name = "My Usuals" });
            hierarchy.Children = childs;
            navigation.MyShopping = hierarchy;

            hierarchy = new Entity.Hierarchy();
            hierarchy.Name = "Special Offers";
            childs = new List<Entity.Child>();
            childs.Add(new Entity.Child { Name = "Offers By Department" });
            childs.Add(new Entity.Child { Name = "All Offers" });
            childs.Add(new Entity.Child { Name = "Top Offers" });
            childs.Add(new Entity.Child { Name = "Half Price" });
            childs.Add(new Entity.Child { Name = "Only £1" });
            childs.Add(new Entity.Child { Name = "Save 1/3" });
            childs.Add(new Entity.Child { Name = "Buy One Get One Free" });
            childs.Add(new Entity.Child { Name = "Multibuys" });
            childs.Add(new Entity.Child { Name = "Seasonal" });
            hierarchy.Children = childs;
            navigation.SpecialOffers = hierarchy;

            hierarchy = new Entity.Hierarchy();
            hierarchy.Name = "Meals Recipes";
            childs = new List<Entity.Child>();
            childs.Add(new Entity.Child { Name = "Cheese Recipes" });
            childs.Add(new Entity.Child { Name = "SORTED Food" });
            childs.Add(new Entity.Child { Name = "Quick and Health" });
            childs.Add(new Entity.Child { Name = "Cooking with Kids" });
            childs.Add(new Entity.Child { Name = "Picnic Recipes" });
            childs.Add(new Entity.Child { Name = "Family Favourites" });
            childs.Add(new Entity.Child { Name = "Recipe Binder" });
            childs.Add(new Entity.Child { Name = "Summer Recipes" });
            childs.Add(new Entity.Child { Name = "World Flavours" });
            hierarchy.Children = childs;
            navigation.MealsRecipes = hierarchy;

            hierarchy = new Entity.Hierarchy();
            hierarchy.Name = "In Season";
            //childs = new List<Child>();
            //hierarchy.Children = childs;
            navigation.InSeason = hierarchy;

            hierarchy = new Entity.Hierarchy();
            hierarchy.Name = "Your Benefits";
            //childs = new List<Child>();
            //hierarchy.Children = childs;
            navigation.YourBenefits = hierarchy;

            hierarchy = new Entity.Hierarchy();
            hierarchy.Name = "Delivery";
            //childs = new List<Child>();
            //hierarchy.Children = childs;
            navigation.Delivery = hierarchy;

            List<Entity.Navigation> lstNavigation = new List<Entity.Navigation>();
            lstNavigation.Add(navigation);
            return lstNavigation;
        }
    }
}