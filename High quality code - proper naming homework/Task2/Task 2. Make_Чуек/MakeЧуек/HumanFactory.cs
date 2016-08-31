public class HumanFactory
{
    public void CreateHuman(int id)
    {
        Human human = new Human();
        human.Age = id;
        if (id % 2 == 0)
        {
            human.Name = "Батката";
            human.Gender = Gender.Male;
        }
        else
        {
            human.Name = "Мацето";
            human.Gender = Gender.Female;
        }
    }
}