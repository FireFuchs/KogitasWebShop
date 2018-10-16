namespace KognitasShopApp
{
    partial class shopCart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(shopCart));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GPriceLabel = new System.Windows.Forms.Label();
            this.OrderNow = new System.Windows.Forms.Button();
            this.RemoveOrder = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(536, 369);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(594, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Price:";
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(653, 71);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(10, 13);
            this.PriceLabel.TabIndex = 1;
            this.PriceLabel.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(564, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gross Price:";
            // 
            // GPriceLabel
            // 
            this.GPriceLabel.AutoSize = true;
            this.GPriceLabel.Location = new System.Drawing.Point(653, 103);
            this.GPriceLabel.Name = "GPriceLabel";
            this.GPriceLabel.Size = new System.Drawing.Size(10, 13);
            this.GPriceLabel.TabIndex = 1;
            this.GPriceLabel.Text = "-";
            // 
            // OrderNow
            // 
            this.OrderNow.Location = new System.Drawing.Point(597, 131);
            this.OrderNow.Name = "OrderNow";
            this.OrderNow.Size = new System.Drawing.Size(130, 56);
            this.OrderNow.TabIndex = 2;
            this.OrderNow.Text = "Order Now";
            this.OrderNow.UseVisualStyleBackColor = true;
            this.OrderNow.Click += new System.EventHandler(this.OrderNow_Click);
            // 
            // RemoveOrder
            // 
            this.RemoveOrder.Location = new System.Drawing.Point(597, 314);
            this.RemoveOrder.Name = "RemoveOrder";
            this.RemoveOrder.Size = new System.Drawing.Size(130, 23);
            this.RemoveOrder.TabIndex = 3;
            this.RemoveOrder.Text = "Remove Order";
            this.RemoveOrder.UseVisualStyleBackColor = true;
            this.RemoveOrder.Click += new System.EventHandler(this.RemoveOrder_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KognitasShopApp.Properties.Resources.Kogitas_Logo_Blue_177x32;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(593, 368);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 50);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // shopCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.RemoveOrder);
            this.Controls.Add(this.OrderNow);
            this.Controls.Add(this.GPriceLabel);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "shopCart";
            this.Text = "Cart";
            this.Load += new System.EventHandler(this.Cart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label GPriceLabel;
        private System.Windows.Forms.Button OrderNow;
        private System.Windows.Forms.Button RemoveOrder;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}