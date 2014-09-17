using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tesco.Com.Pipeline.Entities.NavigationEntities;
using Tesco.Com.Pipeline.Provider.Contract;

namespace Tesco.Com.Pipeline.Provider.GAPI
{
    public class GAPINavigationProvider : BaseProvider, INavigationProvider
    {
        // Anonymous request
        public Navigation GetNavigation(string type, string taxonomyId, string business)
        {
            Navigation navigation = new Navigation();

             Hierarchy hierarchy = (Hierarchy)FromApi("NavigationAnonymous", string.Empty,
                new string[] { type, taxonomyId, business });
            hierarchy.Name = "Shop Groceries";
            List<Hero> lstHero = new List<Hero>();
            lstHero.Add(new Hero { Value = "Bakery" });
            lstHero.Add(new Hero { Value = "Butcher" });
            lstHero.Add(new Hero { Value = "Cheese monger" });
            lstHero.Add(new Hero { Value = "Off Licence" });
            lstHero.Add(new Hero { Value = "Pet Shop" });
            hierarchy.Hero = lstHero;
            navigation.ShopGroceries = hierarchy;

            List<Child> childs;

            hierarchy = new Hierarchy();
            hierarchy.Name = "My Shopping";
            childs = new List<Child>();
            childs.Add(new Child{Name = "My Favourites"});
            childs.Add(new Child { Name = "My Orders" });
            childs.Add(new Child { Name = "My Usuals" });
            hierarchy.Children = childs;
            navigation.MyShopping = hierarchy;

            hierarchy = new Hierarchy();
            hierarchy.Name = "Special Offers";
            childs = new List<Child>();
            childs.Add(new Child { Name = "Offers By Department" });
            childs.Add(new Child { Name = "All Offers" });
            childs.Add(new Child { Name = "Top Offers" });
            childs.Add(new Child { Name = "Half Price" });
            childs.Add(new Child { Name = "Only £1" });
            childs.Add(new Child { Name = "Save 1/3" });
            childs.Add(new Child { Name = "Buy One Get One Free" });
            childs.Add(new Child { Name = "Multibuys" });
            childs.Add(new Child { Name = "Seasonal" });
            hierarchy.Children = childs;
            navigation.SpecialOffers = hierarchy;

            hierarchy = new Hierarchy();
            hierarchy.Name = "Meals Recipes";
            childs = new List<Child>();
            childs.Add(new Child { Name = "Cheese Recipes" });
            childs.Add(new Child { Name = "SORTED Food" });
            childs.Add(new Child { Name = "Quick and Health" });
            childs.Add(new Child { Name = "Cooking with Kids" });
            childs.Add(new Child { Name = "Picnic Recipes" });
            childs.Add(new Child { Name = "Family Favourites" });
            childs.Add(new Child { Name = "Recipe Binder" });
            childs.Add(new Child { Name = "Summer Recipes" });
            childs.Add(new Child { Name = "World Flavours" });
            hierarchy.Children = childs;
            navigation.MealsRecipes = hierarchy;

            hierarchy = new Hierarchy();
            hierarchy.Name = "In Season";
            //childs = new List<Child>();
            //hierarchy.Children = childs;
            navigation.InSeason = hierarchy;

            hierarchy = new Hierarchy();
            hierarchy.Name = "Your Benefits";
            //childs = new List<Child>();
            //hierarchy.Children = childs;
            navigation.YourBenefits = hierarchy;

            hierarchy = new Hierarchy();
            hierarchy.Name = "Delivery";
            //childs = new List<Child>();
            //hierarchy.Children = childs;
            navigation.Delivery = hierarchy;

            return navigation;
        }


        // Loggedin request
        public Navigation GetNavigation(string type, string taxonomyId, string business, string storeId)
        {
            Navigation navigation = new Navigation();

            return (Navigation)FromApi("Navigation", string.Empty,
                new string[] { type, taxonomyId, business, storeId });
        }
    }
}