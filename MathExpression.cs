namespace ConsoleApp1
{
    internal class MathExpression
    {
        public double LeftSide { get; set; }
        public double RightSide { get; set; }
        public MathOperation Operation { get; set; }
        public static double Evaluate(MathExpression expr)
        {
            if (expr.Operation == MathOperation.Addition)
                return expr.LeftSide + expr.RightSide;
            else if (expr.Operation == MathOperation.Subtraction)
                return expr.LeftSide - expr.RightSide;
            else if (expr.Operation == MathOperation.Multiplication)
                return expr.LeftSide * expr.RightSide;
            else if (expr.Operation == MathOperation.Division)
                return expr.LeftSide / expr.RightSide;
            else if (expr.Operation == MathOperation.Modulus)
                return expr.LeftSide % expr.RightSide;
            else if (expr.Operation == MathOperation.Power)
                return Math.Pow(expr.LeftSide, expr.RightSide);
            else if (expr.Operation == MathOperation.Sin)
                return Math.Sin(expr.RightSide);
            else if (expr.Operation == MathOperation.Cos)
                return Math.Cos(expr.RightSide);
            else if (expr.Operation == MathOperation.Tan)
                return Math.Tan(expr.RightSide);
            return 0;
        }
    }
}
