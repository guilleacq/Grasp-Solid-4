//-------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace Full_GRASP_And_SOLID
{
    public class Program
    {
        private static List<CatalogItem> productCatalog = new List<CatalogItem>();
        private static List<CatalogItem> equipmentCatalog = new List<CatalogItem>();

        private static CatalogCreator productCreator = new ProductCreator();
        private static CatalogCreator equipmentCreator = new EquipmentCreator();

        public static void Main(string[] args)
        {
            PopulateCatalogs();

            Recipe recipe = new Recipe();
            recipe.FinalProduct = GetProduct("Café con leche");
            recipe.AddStep(new Step(GetProduct("Café"), 100, GetEquipment("Cafetera"), 120));
            recipe.AddStep(new Step(GetProduct("Leche"), 200, GetEquipment("Hervidor"), 60));

            IPrinter printer;
            printer = new ConsolePrinter();
            printer.PrintRecipe(recipe);
            printer = new FilePrinter();
            printer.PrintRecipe(recipe);
        }

        private static void PopulateCatalogs()
        {
            AddCatalogItemToCatalog(productCreator, "Café", 100);
            AddCatalogItemToCatalog(productCreator, "Leche", 200);
            AddCatalogItemToCatalog(productCreator, "Café con leche", 300);

            AddCatalogItemToCatalog(equipmentCreator, "Cafetera", 1000);
            AddCatalogItemToCatalog(equipmentCreator, "Hervidor", 2000);
        }

        private static void AddCatalogItemToCatalog(CatalogCreator creator, string description, double cost)
        {
            var item = creator.CreateCatalogItem(description, cost);

            if (item != null)
            {
                if (item is Product)
                    productCatalog.Add(item);
                else if (item is Equipment)
                    equipmentCatalog.Add(item);
            }
        }

        // private static void AddProductToCatalog(string description, double unitCost)
        // {
        //     productCatalog.Add(new Product(description, unitCost));
        // }

        // private static void AddEquipmentToCatalog(string description, double hourlyCost)
        // {
        //     equipmentCatalog.Add(new Equipment(description, hourlyCost));
        // }

        private static Product ProductAt(int index)
        {
            return productCatalog[index] as Product;
        }

        private static Equipment EquipmentAt(int index)
        {
            return equipmentCatalog[index] as Equipment;
        }

        private static Product GetProduct(string description)
        {
            var query = from Product product in productCatalog where product.Description == description select product;
            return query.FirstOrDefault();
        }

        private static Equipment GetEquipment(string description)
        {
            var query = from Equipment equipment in equipmentCatalog where equipment.Description == description select equipment;
            return query.FirstOrDefault();
        }
    }
}
