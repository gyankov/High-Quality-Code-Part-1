namespace ControlFlow.Task3
{
    using System;

   public class RefactorLoop
    {
        public void Loop()
        {           
            var array = new int[10];
            var expectedValue = 0;
            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(array[i]);
                    if (array[i] == expectedValue)
                    {
                        i = 666;
                        Console.WriteLine("Value found");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(array[i]);
                    i++;
                }
            }
        }
    }
}
