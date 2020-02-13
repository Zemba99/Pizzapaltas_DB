namespace Admin_Login_Application
{
    partial class frmProducts
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
            this.btnPizza = new System.Windows.Forms.Button();
            this.btnPastas = new System.Windows.Forms.Button();
            this.btnSallads = new System.Windows.Forms.Button();
            this.btnBeverages = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPizza
            // 
            this.btnPizza.Location = new System.Drawing.Point(12, 12);
            this.btnPizza.Name = "btnPizza";
            this.btnPizza.Size = new System.Drawing.Size(184, 50);
            this.btnPizza.TabIndex = 0;
            this.btnPizza.Text = "Pizzas";
            this.btnPizza.UseVisualStyleBackColor = true;
            this.btnPizza.Click += new System.EventHandler(this.btnPizza_Click);
            // 
            // btnPastas
            // 
            this.btnPastas.Location = new System.Drawing.Point(12, 68);
            this.btnPastas.Name = "btnPastas";
            this.btnPastas.Size = new System.Drawing.Size(184, 50);
            this.btnPastas.TabIndex = 1;
            this.btnPastas.Text = "Pastas";
            this.btnPastas.UseVisualStyleBackColor = true;
            this.btnPastas.Click += new System.EventHandler(this.btnPastas_Click);
            // 
            // btnSallads
            // 
            this.btnSallads.Location = new System.Drawing.Point(12, 124);
            this.btnSallads.Name = "btnSallads";
            this.btnSallads.Size = new System.Drawing.Size(184, 50);
            this.btnSallads.TabIndex = 2;
            this.btnSallads.Text = "Sallads";
            this.btnSallads.UseVisualStyleBackColor = true;
            this.btnSallads.Click += new System.EventHandler(this.btnSallads_Click);
            // 
            // btnBeverages
            // 
            this.btnBeverages.Location = new System.Drawing.Point(12, 180);
            this.btnBeverages.Name = "btnBeverages";
            this.btnBeverages.Size = new System.Drawing.Size(184, 50);
            this.btnBeverages.TabIndex = 3;
            this.btnBeverages.Text = "Beverages";
            this.btnBeverages.UseVisualStyleBackColor = true;
            this.btnBeverages.Click += new System.EventHandler(this.btnBeverages_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 236);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(184, 50);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 298);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnBeverages);
            this.Controls.Add(this.btnSallads);
            this.Controls.Add(this.btnPastas);
            this.Controls.Add(this.btnPizza);
            this.Name = "frmProducts";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Products";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPizza;
        private System.Windows.Forms.Button btnPastas;
        private System.Windows.Forms.Button btnSallads;
        private System.Windows.Forms.Button btnBeverages;
        private System.Windows.Forms.Button btnBack;
    }
}