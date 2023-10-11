using Full_GRASP_And_SOLID;

public class ProductCreator : CatalogCreator
{
    public override CatalogItem CreateCatalogItem(string description, double cost)
    {
        return new Product(description, cost);
    }
}