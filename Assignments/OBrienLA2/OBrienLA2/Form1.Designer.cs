/*
 * Name: Luke O'Brien
 * Class: 3020:001
 * Due Date: 10/8/21 ->(moved to) 10/11/21
 */

namespace OBrienLA2
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
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.nutriDropDown = new System.Windows.Forms.ComboBox();
            this.minTextBox = new System.Windows.Forms.TextBox();
            this.maxTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.orderDropDown = new System.Windows.Forms.ComboBox();
            this.searchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(650, 22);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersWidth = 82;
            this.dataGrid.RowTemplate.Height = 41;
            this.dataGrid.Size = new System.Drawing.Size(1103, 764);
            this.dataGrid.TabIndex = 0;
            // 
            // nutriDropDown
            // 
            this.nutriDropDown.FormattingEnabled = true;
            this.nutriDropDown.Items.AddRange(new object[] {
            "Calories",
            "Protein",
            "Fat",
            "Sodium",
            "Fiber",
            "Carbohydrates",
            "Sugars",
            "Potassium",
            "Vitamins"});
            this.nutriDropDown.Location = new System.Drawing.Point(24, 64);
            this.nutriDropDown.Name = "nutriDropDown";
            this.nutriDropDown.Size = new System.Drawing.Size(572, 40);
            this.nutriDropDown.TabIndex = 1;
            this.nutriDropDown.Text = "Select Nutrients";
            this.nutriDropDown.SelectedIndexChanged += new System.EventHandler(this.nutriDropDown_SelectedIndexChanged);
            // 
            // minTextBox
            // 
            this.minTextBox.Location = new System.Drawing.Point(90, 59);
            this.minTextBox.Name = "minTextBox";
            this.minTextBox.Size = new System.Drawing.Size(200, 39);
            this.minTextBox.TabIndex = 2;
            this.minTextBox.TextChanged += new System.EventHandler(this.minTextBox_TextChanged);
            // 
            // maxTextBox
            // 
            this.maxTextBox.Location = new System.Drawing.Point(397, 59);
            this.maxTextBox.Name = "maxTextBox";
            this.maxTextBox.Size = new System.Drawing.Size(200, 39);
            this.maxTextBox.TabIndex = 3;
            this.maxTextBox.TextChanged += new System.EventHandler(this.maxTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Min:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Max:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nutriDropDown);
            this.groupBox1.Location = new System.Drawing.Point(21, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(612, 147);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nutrients";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.maxTextBox);
            this.groupBox2.Controls.Add(this.minTextBox);
            this.groupBox2.Location = new System.Drawing.Point(21, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(612, 147);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Min/Max Values";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.orderDropDown);
            this.groupBox3.Location = new System.Drawing.Point(21, 549);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(612, 147);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Order Displayed";
            // 
            // orderDropDown
            // 
            this.orderDropDown.FormattingEnabled = true;
            this.orderDropDown.Items.AddRange(new object[] {
            "Highest to Lowest",
            "Lowest  to Highest"});
            this.orderDropDown.Location = new System.Drawing.Point(24, 64);
            this.orderDropDown.Name = "orderDropDown";
            this.orderDropDown.Size = new System.Drawing.Size(572, 40);
            this.orderDropDown.TabIndex = 1;
            this.orderDropDown.Text = "Accending/Decending";
            this.orderDropDown.SelectedIndexChanged += new System.EventHandler(this.orderDropDown_SelectedIndexChanged);
            // 
            // searchButton
            // 
            this.searchButton.Enabled = false;
            this.searchButton.Location = new System.Drawing.Point(253, 740);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(150, 46);
            this.searchButton.TabIndex = 8;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1785, 818);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.ComboBox nutriDropDown;
        private System.Windows.Forms.TextBox minTextBox;
        private System.Windows.Forms.TextBox maxTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox orderDropDown;
        private System.Windows.Forms.Button searchButton;
    }
}

