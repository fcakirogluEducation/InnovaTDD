namespace InnovaApp.API.Services
{
    public class Calculator : ICalculator
    {
        public int Add(int a, int b)
        {
            if (a < 0 || b < 0) throw new System.Exception("Invalid input");


            return a + b;
        }
    }
}