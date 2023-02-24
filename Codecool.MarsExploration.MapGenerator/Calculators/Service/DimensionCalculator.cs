namespace Codecool.MarsExploration.MapGenerator.Calculators.Service;

public class DimensionCalculator : IDimensionCalculator
{
    public int CalculateDimension(int size, int dimensionGrowth)
    {
        int dimension = 0;
        int numberOfAvailableBoxes = 0;
        while (numberOfAvailableBoxes < size)
        {
            dimension++;
            numberOfAvailableBoxes = dimension * dimension;
        }

        return dimension + dimensionGrowth;
    }
}
