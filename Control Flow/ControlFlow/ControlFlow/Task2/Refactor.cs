namespace ControlFlow.Task2
{
    using System;

    public class Refactor
    {
        public void RefactorPotato()
        {
            Potato potato = new Potato();
            if (potato != null)
            {
                if (potato.HasBeenPeeled && !potato.IsRotten)
                {
                    this.Cook(potato);
                }
            }               
        }

        public void RefactorSomeIf()
        {
            const int MIN_X = 1;
            const int MAX_X = 1;
            const int MAX_Y = 1;
            const int MIN_Y = 1;
            var x = 0;
            var y = 0;

            var shouldVisitCell = false;
            var xIsInRange = x >= MIN_X && x <= MAX_X;
            var yIsInRange = MAX_Y >= y && MIN_Y <= y;
            if (xIsInRange && yIsInRange && shouldVisitCell)
            {
                VisitCell();
            }
        }

        private void VisitCell()
        {
            throw new NotImplementedException();
        }

        private void Cook(Potato potato)
        {
            throw new NotImplementedException();
        }
    }
}
