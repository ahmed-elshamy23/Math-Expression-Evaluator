namespace ConsoleApp1
{
    internal static class ExpressionParser
    {
        private static readonly string MathSymbols = "+*/^%";
        public static MathExpression Parse(string input)
        {
            var expr = new MathExpression();
            bool LeftSideAssigned = false, OperationAssigned  = false;
            string token = "";
            for (int i = 0; i < input.Length; i++) 
            {
                if (char.IsLetter(input[i]))
                {
                    if (i == 0) LeftSideAssigned = true;
                    token += input[i];
                }
                else if(char.IsDigit(input[i]))
                {
                    token += input[i];
                }
                else if(char.IsWhiteSpace(input[i]))
                {
                    if(token.Length > 0)
                    {
                        if(!LeftSideAssigned)
                        {
                            LeftSideAssigned = true;
                            expr.LeftSide = double.Parse(token);
                        }
                        else
                        {
                            expr.Operation = ParseOperation(token);
                            OperationAssigned = true;
                        }
                        token = "";
                    }
                }
                else if (MathSymbols.Contains(input[i]))
                {
                    if (token.Length > 0)
                    {
                        LeftSideAssigned = true;
                        expr.LeftSide = double.Parse(token);
                        token = "";
                    }
                    expr.Operation = ParseOperation(input[i].ToString());
                    OperationAssigned = true;
                }
                else if (input[i] == '-')
                {
                    if (i == 0)
                    {
                        token += input[i];
                    }
                    else
                    {
                        if (token.Length > 0)
                        {
                            LeftSideAssigned = true;
                            expr.LeftSide = double.Parse(token);
                            token = "";
                            OperationAssigned = true;
                            expr.Operation = MathOperation.Subtraction;
                        }
                        else if(!OperationAssigned)
                        {
                            OperationAssigned = true;
                            expr.Operation = MathOperation.Subtraction;
                        }
                        else
                        {
                            token += input[i];
                        }
                    }
                }
            }
            expr.RightSide = double.Parse(token);
            token = "";
            return expr;
        }
        private static MathOperation ParseOperation(string operation)
        {
            switch (operation.ToLower())
            {
                case "+":
                    return MathOperation.Addition;
                case "*":
                    return MathOperation.Multiplication;
                case "/":
                    return MathOperation.Division;
                case "^":
                case "pow":
                    return MathOperation.Power;
                case "%":
                case "mod":
                    return MathOperation.Modulus;
                case "sin":
                    return MathOperation.Sin;
                case "cos":
                    return MathOperation.Cos;
                case "tan":
                    return MathOperation.Tan;
                default:
                    return MathOperation.None;
            }
        }
    }
}
