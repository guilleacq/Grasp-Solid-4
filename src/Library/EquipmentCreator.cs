using Full_GRASP_And_SOLID;

public class EquipmentCreator : CatalogCreator
{
    public override CatalogItem CreateCatalogItem(string description, double cost)
    {
        return new Equipment(description, cost);
    }
}