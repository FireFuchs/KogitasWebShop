namespace KognitasShopApp
{
    partial class Form2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ShopUsers = new System.Windows.Forms.Button();
            this.Product = new System.Windows.Forms.Button();
            this.user_orders = new System.Windows.Forms.Button();
            this.order_products = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(587, 312);
            this.dataGridView1.TabIndex = 0;
            // 
            // ShopUsers
            // 
            this.ShopUsers.Location = new System.Drawing.Point(654, 55);
            this.ShopUsers.Name = "ShopUsers";
            this.ShopUsers.Size = new System.Drawing.Size(75, 23);
            this.ShopUsers.TabIndex = 1;
            this.ShopUsers.Text = "ShopUsers";
            this.ShopUsers.UseVisualStyleBackColor = true;
            this.ShopUsers.Click += new System.EventHandler(this.ShopUsers_Click);
            // 
            // Product
            // 
            this.Product.Location = new System.Drawing.Point(654, 99);
            this.Product.Name = "Product";
            this.Product.Size = new System.Drawing.Size(75, 23);
            this.Product.TabIndex = 2;
            this.Product.Text = "Product";
            this.Product.UseVisualStyleBackColor = true;
            this.Product.Click += new System.EventHandler(this.Product_Click);
            // 
            // user_orders
            // 
            this.user_orders.Location = new System.Drawing.Point(654, 144);
            this.user_orders.Name = "user_orders";
            this.user_orders.Size = new System.Drawing.Size(75, 23);
            this.user_orders.TabIndex = 2;
            this.user_orders.Text = "user_orders";
            this.user_orders.UseVisualStyleBackColor = true;
            this.user_orders.Click += new System.EventHandler(this.user_orders_Click);
            // 
            // order_products
            // 
            this.order_products.Location = new System.Drawing.Point(654, 194);
            this.order_products.Name = "order_products";
            this.order_products.Size = new System.Drawing.Size(75, 23);
            this.order_products.TabIndex = 2;
            this.order_products.Text = "order_products";
            this.order_products.UseVisualStyleBackColor = true;
            this.order_products.Click += new System.EventHandler(this.order_products_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.order_products);
            this.Controls.Add(this.user_orders);
            this.Controls.Add(this.Product);
            this.Controls.Add(this.ShopUsers);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ShopUsers;
        private System.Windows.Forms.Button Product;
        private System.Windows.Forms.Button user_orders;
        private System.Windows.Forms.Button order_products;
    }
}