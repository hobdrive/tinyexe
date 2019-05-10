using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyExe
{
    public class Expression
    {
        private string expression;
        private ParseTreeEvaluator tree;

        public ParseErrors Errors
        {
            get
            {
                if (tree != null)
                    return tree.Errors;
                else 
                    return null;
            }
        }

        public Expression(string exp) : this(exp, Context.Default)
        {
        }

        public Expression(string exp, Context context)
        {
            expression = exp;
            Scanner scanner = new Scanner();
            Parser parser = new Parser(scanner);
            tree = new ParseTreeEvaluator(context);
            tree = parser.Parse(expression, null, tree) as ParseTreeEvaluator;
        }

        public object Eval()
        {
            object result = tree.Eval(null);
            return result;
        }

        public object EvalOrError()
        {
            object result = Eval();
            if (result == null && tree.Errors.Count > 0)
                return tree.Errors[0].Message + " @ " + tree.Errors[0].Column;
            return result;
        }

        public string Error()
        {
            if (tree.Errors.Count > 0)
                return tree.Errors[0].Message + " @ " + tree.Errors[0].Column;
            return null;
        }

        public static object Eval(string expression, Context context)
        {
            return Expression.Eval<object>(expression, context);
        }

        public static object Eval(string expression)
        {
            return Expression.Eval<object>(expression, Context.Default);
        }

        public static T Eval<T>(string expression)
        {
            return Eval<T>(expression, Context.Default);
        }

        public static T Eval<T>(string expression, Context context) 
        {
            object result = null;
            try
            {
                Expression exp = new Expression(expression, context);
                
                if (exp.tree.Errors.Count > 0)
                    result = exp.tree.Errors[0].Message;
                else
                    result = exp.Eval();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result != null ? ((T)(result)) : default(T);
        }

    }
}
