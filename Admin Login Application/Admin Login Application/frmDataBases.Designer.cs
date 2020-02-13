namespace Admin_Login_Application
{
    partial class frmDataBases
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
            this.btnMsSql = new System.Windows.Forms.Button();
            this.btnPostgres = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMsSql
            // 
            this.btnMsSql.Location = new System.Drawing.Point(12, 12);
            this.btnMsSql.Name = "btnMsSql";
            this.btnMsSql.Size = new System.Drawing.Size(204, 51);
            this.btnMsSql.TabIndex = 0;
            this.btnMsSql.Text = "MsSql";
            this.btnMsSql.UseVisualStyleBackColor = true;
            this.btnMsSql.Click += new System.EventHandler(this.btnMsSql_Click);
            // 
            // btnPostgres
            // 
            this.btnPostgres.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnPostgres.Location = new System.Drawing.Point(12, 69);
            this.btnPostgres.Name = "btnPostgres";
            this.btnPostgres.Size = new System.Drawing.Size(204, 51);
            this.btnPostgres.TabIndex = 1;
            this.btnPostgres.Text = "Postgresql";
            this.btnPostgres.UseVisualStyleBackColor = true;
            this.btnPostgres.Click += new System.EventHandler(this.btnPostgres_Click);
            // 
            // btnExit
            // 
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnExit.Location = new System.Drawing.Point(12, 126);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(204, 51);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmDataBases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 190);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPostgres);
            this.Controls.Add(this.btnMsSql);
            this.Name = "frmDataBases";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Databases";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMsSql;
        private System.Windows.Forms.Button btnPostgres;
        private System.Windows.Forms.Button btnExit;
    }
}