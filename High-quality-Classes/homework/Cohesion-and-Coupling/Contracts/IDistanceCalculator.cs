namespace CohesionAndCoupling.Contracts
{
   public interface IDistanceCalculator
    {
        double CalcDistance2D(double x1, double y1, double x2, double y2);

        double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2);
    }
}
