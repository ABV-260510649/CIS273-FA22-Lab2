namespace Lab2;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(IsBalanced("]"));
    }

    public static bool IsBalanced(string s)
    {
        Stack<char> stack = new Stack<char>();

        // iterate over all chars in string
        foreach(var c in s)
        {
            // if char is an open thing, push it
            if ( c=='<' || c=='(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }

            // if char is a close thing,
            // compare it to top of stack;
            else if (c == '>' || c == ')' || c == '}' || c == ']')
            {
                // handle result == false
                if (stack.Count > 0)
                {
                    char top = stack.Peek();
                    // if they match, pop()
                    if (Matches(c, top))
                    {
                        stack.Pop();
                    }
                    // else, return false
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            
        }

        // if stack is empty, return true
        if( stack.Count ==0)
        {
            return true;
        }

        return false;

    }

    private static bool Matches(char closing, char opening)
    {
        if (opening == '<' && closing == '>')
        {
            return true;
        }
        else if (opening == '{' && closing == '}')
        {
            return true;
        }
        else if (opening == '[' && closing == ']')
        {
            return true;
        }
        else if (opening == '('  && closing == ')')
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static double? Evaluate(string s)
    {
        Stack<string> stack = new Stack<string>();
        // parse string into tokens
        string[] tokens = s.Split();

        // foreach token
        // if it's a number, push to stack
        foreach (string token in tokens)
        {
            int number;
            bool isNumber = int.TryParse(token, out number);
            if (isNumber == true)
            {
                stack.Push(token);
            }
            else
            {
                var num1 = Convert.ToDouble(stack.Pop());
                var num2 = Convert.ToDouble(stack.Pop());
                double result = computeResult(num2, num1, token);
                stack.Push(result.ToString());
            }
        }

        // if it's a math operator, pop twice;
        // compute result;
        // push result onto stack

        // return top of stack (if the stack has 1 element)
        if (stack.Count == 1)
        {
            return Convert.ToDouble(stack.Peek());
        }

        return null;
    }

    private static double computeResult(double num1, double num2, string oper)
    {
        if (oper == "+")
        {
            return num1 + num2;
        }
        else if (oper == "-")
        {
            return num1 - num2;
        }
        else if (oper == "*")
        {
            return num1 * num2;
        }
        else if (oper == "/")
        {
            return num1 / num2;
        }
        return 0;
    }

}

