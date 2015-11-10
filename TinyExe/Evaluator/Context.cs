using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyExe
{
    public class Context
    {
        private static Context defaultContext;
        public static Context Default
        {
            get
            {
                if (defaultContext == null)
                    defaultContext = new Context();
                return defaultContext;
            }
        }

        // list of functions currently in scope during an evaluation
        // note that this typically is NOT thread safe.

        // contains a list of variables that is in scope. Scope is used only for DynamicFunctions (for now)
        private List<Variables> inScope;

        public Functions Functions { get; private set; }
        public Variables Globals { get; private set; }

        /// <summary>
        /// check current stacksize
        /// is used for debugging purposes and error handling
        /// to prevent stackoverflows
        /// </summary>
        public int CurrentStackSize
        {
            get
            {
                return inScope.Count;
            }
        }

        public Variables CurrentScope
        {
            get {
                if (inScope.Count <= 0)
                    return null;

                return inScope[inScope.Count-1];
            }
        }

        /// <summary>
        /// Traverse all the local scopes and searches for the specified variable
        /// </summary>
        /// <returns>The scoped variable.</returns>
        /// <param name="key">Key.</param>
        public object GetScopeVariable(string key)
        {
            foreach(var scope in inScope.Reverse<Variables>())
            {
                if (scope != null && scope.ContainsKey(key))
                    return scope[key];
            }
            return null;
        }

        public void PushScope(Variables vars)
        {
            inScope.Add(vars);
        }

        public Variables PopScope()
        {
            if (inScope.Count <= 0)
                return null;
            
            Variables vars = inScope[inScope.Count-1];
            inScope.RemoveAt(inScope.Count - 1);
            return vars;
        }

        public Context()
        {
            Reset();
        }

        /// <summary>
        /// resets the context to its defaults
        /// </summary> 
        public void Reset()
        {
            inScope = new List<Variables>();
            Functions = new Functions();
            Globals = new Variables();
            Functions.InitDefaults();
            Globals["Pi"] = 3.1415926535897932384626433832795; // Math.Pi is not very precise
            Globals["E"] = 2.7182818284590452353602874713527;  // Math.E is not very precise either
        }

        /// <summary>
        /// Thats not a Deep clone!
        /// Functions and Globals are shared!
        /// </summary>
        public Context Clone()
        {
            var c = new Context();
            c.Globals = this.Globals;
            c.Functions = this.Functions;
            return c;
        }
    }
}
