namespace CohesionAndCoupling
{
    using CohesionAndCoupling.Contracts;

    public static class VolumeCalculator
    {
        public static double Width { get; set; }

        public static double Height { get; set; }

        public static double Depth { get; set; }         

        public static double CalcVolume()
        {
            double volume = Width * Height * Depth;
            return volume;
        }

        public static double CalcDiagonalXYZ(IDistanceCalculator distanceCalculator)
        {
            double distance = distanceCalculator.CalcDistance3D(0, 0, 0, Width, Height, Depth);
            return distance;
        }

        public static double CalcDiagonalXY(IDistanceCalculator distanceCalculator)
        {
            double distance = distanceCalculator.CalcDistance2D(0, 0, Width, Height);
            return distance;
        }

        public static double CalcDiagonalXZ(IDistanceCalculator distanceCalculator)
        {
            double distance = distanceCalculator.CalcDistance2D(0, 0, Width, Depth);
            return distance;
        }

        public static double CalcDiagonalYZ(IDistanceCalculator distanceCalculator)
        {
            double distance = distanceCalculator.CalcDistance2D(0, 0, Height, Depth);
            return distance;
        }
    }
}
