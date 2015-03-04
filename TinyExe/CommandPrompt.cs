using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace TinyExe
{
    /// <summary>
    /// this class demonstrates how to access application specific features
    /// e.g. access to the console through the Context object
    /// </summary>
    class ClearFunction : Function
    {
        CommandPrompt CommandPrompt;

        public ClearFunction(CommandPrompt cp)
        {
            Name = "Clear";
            CommandPrompt = cp;
            MinParameters = 0;
            MaxParameters = 0;
        }

        public override object Eval(object[] parameters, ParseTreeEvaluator tree)
        {
            if (CommandPrompt != null)
                CommandPrompt.Text = "";
            return null;
        }
    }
        
    public class CommandPrompt : RichTextBox
    {
        private bool navigated = false; // remember if Up or Down keys were used
        private int expIndex = 0;
        private List<string> expressions = new List<string>();

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SelectionStart = Text.Length;
            Context.Default.Functions.Add("clear", new ClearFunction(this));
        }

        private void Execute(string expr)
        {
            try
            {
                expressions.Remove(expr);
                expressions.Add(expr);
                if (expressions.Count > 20)
                    expressions.RemoveAt(0); // remove first one

                if (expressions.Count > 0)
                    expIndex = expressions.Count-1;
                navigated = false;

                Expression exp = new Expression(expr);

                if (exp.Errors.Count > 0)
                {
                    WriteLine(exp.Errors[0].Message);
                    return;
                }

                object val = exp.Eval();
                if (exp.Errors.Count > 0)
                {
                    WriteLine(exp.Errors[0].Message);
                    return;
                }
                if (val == null)
                {
                    Write("\r\n>");
                    return;
                }

                WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}", val));
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }


        public void Write(string text)
        {
            Text += text;
            SelectionStart = Text.Length;
        }

        public void WriteLine(string line)
        {
            //rtCommandPrompt.Text = line +"\r"+ rtCommandPrompt.Text;
            Write("\r\n" + line + "\r\n>");
        }

        private void rtCommandPrompt_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {

            int curlineidx = GetFirstCharIndexOfCurrentLine();
            int curline = GetLineFromCharIndex(curlineidx);

            ReadOnly = (curline < Lines.Length - 1);
            if (curline < Lines.Length - 1)
                return;

            SuspendLayout();
            if (e.KeyCode == Keys.Enter)
            {
                string expr = Text.Substring(curlineidx < Text.Length ? curlineidx + 1 : Text.Length);
                Execute(expr);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Back)
            {
                if (SelectionStart <= curlineidx + 1)
                {
                    SelectedText = "";
                    e.Handled = true;
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (SelectionStart < curlineidx + 1)
                    e.Handled = true;
            }

            else if (e.KeyCode == Keys.Up)
            {
                if (expressions.Count > 0)
                {
                    if (navigated)
                    {
                        expIndex--;
                        if (expIndex < 0)
                            expIndex = expressions.Count - 1;
                    }
                    else
                        navigated = true;
                    Text = Text.Substring(0, curlineidx < Text.Length ? curlineidx + 1 : Text.Length) + expressions[expIndex];
                    SelectionStart = Text.Length;
                }
                e.Handled = true;
            }

            else if (e.KeyCode == Keys.Down)
            {
                if (expressions.Count > 0)
                {
                    if (navigated)
                    {
                        expIndex++;
                        if (expIndex >= expressions.Count)
                            expIndex = 0;
                    }
                    else
                        navigated = true;
                    Text = Text.Substring(0, curlineidx < Text.Length ? curlineidx + 1 : Text.Length) + expressions[expIndex];
                    SelectionStart = Text.Length;
                }
                e.Handled = true;
            }

            else if (e.KeyCode == Keys.Escape)
            {
                Text = Text.Substring(0, curlineidx < Text.Length ? curlineidx + 1 : Text.Length);
                SelectionStart = Text.Length;
                if (expressions.Count > 0)
                    expIndex = expressions.Count - 1;
                navigated = false; // reset

                e.Handled = true;
            }

            else if (e.KeyCode == Keys.Left)
            {
                if (SelectionStart <= curlineidx + 1)
                    e.Handled = true;
            }

            else if (e.KeyCode == Keys.Home)
            {
                if (SelectionStart <= curlineidx + 1)
                {
                }
            }
            
            base.OnKeyDown(e);
            ResumeLayout();
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            base.OnSelectionChanged(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            
            int curlineidx = GetFirstCharIndexOfCurrentLine();

            if (!ReadOnly && e.KeyCode == Keys.Home)
            {
                if (SelectionLength > 1)
                    SelectionLength--;
                SelectionStart = curlineidx + 1;
                base.OnKeyDown(e);
                e.Handled = true;
                return;
            }
            
            
            base.OnKeyUp(e);
        }
    }
}
