namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            MathExpression expr = new();
            string input = "";
            while (true)
            {
                Console.Write(">> ");
                input = Console.ReadLine();
                if (String.IsNullOrEmpty(input)) continue;
                if (input == "exit") break;
                try
                {
                    expr = ExpressionParser.Parse(input);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(MathExpression.Evaluate(expr));
            }
            }
        }
}
