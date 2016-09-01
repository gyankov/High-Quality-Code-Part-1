using System;

public class Size
{
    private double width, height;

    public Size(double w, double h)
    {
        this.width = w;
        this.height = h;
    }

    public static Size GetRotatedSize(
        Size s,
        double angleOfTheFigureThatWillBeRotaed)
    {
        var width = (Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * s.width) +
               (Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * s.height);
        var height = (Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * s.width) +
                (Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * s.height);
        var size = new Size(width, height);

        return size;
    }
}