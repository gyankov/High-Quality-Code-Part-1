using System;

public class Chef
{
    public void Cook()
    {
        Potato potato = GetPotato();
        Carrot carrot = GetCarrot();
        Bowl bowl;
        Peel(potato);

        Peel(carrot);
        bowl = GetBowl();
        Cut(potato);
        Cut(carrot);
        bowl.Add(carrot);

        bowl.Add(potato);
    }

    private Bowl GetBowl()
    {
        return new Bowl();
    }

    private Carrot GetCarrot()
    {
        return new Carrot();
    }

    private Potato GetPotato()
    {
        return new Potato();
    }

    private void Cut(Vegetable potato)
    {
        throw new NotImplementedException();
    }
  
    private void Peel(Vegetable potato)
    {
        throw new NotImplementedException();
    }    
}