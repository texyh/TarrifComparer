namespace TarrifComparer.Core
{
    public interface ITarrifProduct
    {
        string Name { get; }

        double CalculateAnnualCost(int electricityConsumption);
    }
}