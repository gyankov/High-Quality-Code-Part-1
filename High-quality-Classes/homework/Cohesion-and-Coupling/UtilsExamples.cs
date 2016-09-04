namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
       public static void Main()
        {
            Console.WriteLine(FileData.GetFileExtension("example"));
            Console.WriteLine(FileData.GetFileExtension("example.pdf"));
            Console.WriteLine(FileData.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileData.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileData.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileData.GetFileNameWithoutExtension("example.new.pdf"));

            var distanceCalculator = new DistanceCalculator();

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                distanceCalculator.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                distanceCalculator.CalcDistance3D(5, 2, -1, 3, -6, 4));

            VolumeCalculator.Width = 3;
            VolumeCalculator.Height = 4;
            VolumeCalculator.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", VolumeCalculator.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", VolumeCalculator.CalcDiagonalXYZ(distanceCalculator));
            Console.WriteLine("Diagonal XY = {0:f2}", VolumeCalculator.CalcDiagonalXY(distanceCalculator));
            Console.WriteLine("Diagonal XZ = {0:f2}", VolumeCalculator.CalcDiagonalXZ(distanceCalculator));
            Console.WriteLine("Diagonal YZ = {0:f2}", VolumeCalculator.CalcDiagonalYZ(distanceCalculator));
        }
    }
}
