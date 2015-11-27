namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.btnGo = new System.Windows.Forms.Button();
            this.Url = new System.Windows.Forms.ComboBox();
            this.RichOut = new System.Windows.Forms.RichTextBox();
            this.RichIn = new System.Windows.Forms.RichTextBox();
            this.StsBar = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(653, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // Url
            // 
            this.Url.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Url.FormattingEnabled = true;
            this.Url.Location = new System.Drawing.Point(42, 14);
            this.Url.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Url.Name = "Url";
            this.Url.Size = new System.Drawing.Size(606, 21);
            this.Url.TabIndex = 2;
            // 
            // RichOut
            // 
            this.RichOut.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.RichOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichOut.Location = new System.Drawing.Point(715, 51);
            this.RichOut.Name = "RichOut";
            this.RichOut.ReadOnly = true;
            this.RichOut.Size = new System.Drawing.Size(667, 554);
            this.RichOut.TabIndex = 35;
            this.RichOut.Text = "<OUTPUT XML>";
            // 
            // RichIn
            // 
            this.RichIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichIn.Location = new System.Drawing.Point(42, 51);
            this.RichIn.Name = "RichIn";
            this.RichIn.Size = new System.Drawing.Size(667, 554);
            this.RichIn.TabIndex = 36;
            this.RichIn.Text = "";
            // 
            // StsBar
            // 
            this.StsBar.BackColor = System.Drawing.SystemColors.Control;
            this.StsBar.Location = new System.Drawing.Point(734, 14);
            this.StsBar.Name = "StsBar";
            this.StsBar.ReadOnly = true;
            this.StsBar.Size = new System.Drawing.Size(250, 20);
            this.StsBar.TabIndex = 37;
            this.StsBar.TabStop = false;
            this.StsBar.Text = "Status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 617);
            this.Controls.Add(this.StsBar);
            this.Controls.Add(this.RichIn);
            this.Controls.Add(this.RichOut);
            this.Controls.Add(this.Url);
            this.Controls.Add(this.btnGo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        public System.Windows.Forms.ComboBox Url;
        public System.Windows.Forms.RichTextBox RichOut;
        public System.Windows.Forms.RichTextBox RichIn;
        public System.Windows.Forms.TextBox StsBar;
    }
}

