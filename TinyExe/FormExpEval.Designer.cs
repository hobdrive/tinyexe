namespace TinyExe
{
    partial class FormCalculator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtCommandPrompt = new TinyExe.CommandPrompt();
            this.SuspendLayout();
            // 
            // rtCommandPrompt
            // 
            this.rtCommandPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtCommandPrompt.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtCommandPrompt.Location = new System.Drawing.Point(0, 0);
            this.rtCommandPrompt.Name = "rtCommandPrompt";
            this.rtCommandPrompt.Size = new System.Drawing.Size(369, 182);
            this.rtCommandPrompt.TabIndex = 0;
            this.rtCommandPrompt.Text = "@TinyExe v1.0 by Herre Kuijpers \n>";
            // 
            // FormCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 182);
            this.Controls.Add(this.rtCommandPrompt);
            this.Name = "FormCalculator";
            this.Text = "@TinyExe - a Tiny Expression Evaluator";
            this.ResumeLayout(false);

        }

        #endregion

        private CommandPrompt rtCommandPrompt;

    }
}

