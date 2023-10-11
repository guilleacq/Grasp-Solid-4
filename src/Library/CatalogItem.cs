public abstract class CatalogItem
{
    public string Description { get; set; }
    public double Cost { get; set; }

    public CatalogItem(string description, double cost)
    {
        Description = description;
        Cost = cost;
    }
}
