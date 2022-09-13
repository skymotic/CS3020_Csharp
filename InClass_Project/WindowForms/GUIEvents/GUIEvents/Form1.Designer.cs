
namespace GUIEvents
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Yes_Button = new System.Windows.Forms.Button();
            this.No_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Yes_Button
            // 
            this.Yes_Button.Location = new System.Drawing.Point(635, 51);
            this.Yes_Button.Name = "Yes_Button";
            this.Yes_Button.Size = new System.Drawing.Size(380, 136);
            this.Yes_Button.TabIndex = 0;
            this.Yes_Button.Text = "Yeppers";
            this.Yes_Button.UseVisualStyleBackColor = true;
            this.Yes_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // No_Button
            // 
            this.No_Button.Location = new System.Drawing.Point(80, 51);
            this.No_Button.Name = "No_Button";
            this.No_Button.Size = new System.Drawing.Size(380, 136);
            this.No_Button.TabIndex = 1;
            this.No_Button.Text = "Absolutly Not!";
            this.No_Button.UseVisualStyleBackColor = true;
            this.No_Button.Click += new System.EventHandler(this.No_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 239);
            this.Controls.Add(this.No_Button);
            this.Controls.Add(this.Yes_Button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Yes_Button;
        private System.Windows.Forms.Button No_Button;
    }
}

