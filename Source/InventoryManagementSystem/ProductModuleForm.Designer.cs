
namespace InventoryManagementSystem
{
    partial class ProductModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductModuleForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPDes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboCat = new System.Windows.Forms.ComboBox();
            this.lblPid = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.pictureBoxClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 49);
            this.panel1.TabIndex = 14;
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(575, -1);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(29, 27);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxClose.TabIndex = 11;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "ÜRÜN MODELİ";
            // 
            // txtPDes
            // 
            this.txtPDes.Location = new System.Drawing.Point(152, 202);
            this.txtPDes.Name = "txtPDes";
            this.txtPDes.Size = new System.Drawing.Size(396, 22);
            this.txtPDes.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "Açıklama:";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Red;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(450, 296);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 37);
            this.btnClear.TabIndex = 25;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Olive;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(350, 296);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(94, 37);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(250, 296);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 37);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Kategori";
            // 
            // txtPPrice
            // 
            this.txtPPrice.Location = new System.Drawing.Point(152, 159);
            this.txtPPrice.Name = "txtPPrice";
            this.txtPPrice.Size = new System.Drawing.Size(396, 22);
            this.txtPPrice.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Fiyat";
            // 
            // txtPQty
            // 
            this.txtPQty.Location = new System.Drawing.Point(152, 116);
            this.txtPQty.Name = "txtPQty";
            this.txtPQty.Size = new System.Drawing.Size(396, 22);
            this.txtPQty.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Adet:";
            // 
            // txtPName
            // 
            this.txtPName.Location = new System.Drawing.Point(152, 73);
            this.txtPName.Name = "txtPName";
            this.txtPName.Size = new System.Drawing.Size(396, 22);
            this.txtPName.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Ürün Adı:";
            // 
            // comboCat
            // 
            this.comboCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCat.FormattingEnabled = true;
            this.comboCat.Location = new System.Drawing.Point(152, 248);
            this.comboCat.Name = "comboCat";
            this.comboCat.Size = new System.Drawing.Size(396, 25);
            this.comboCat.TabIndex = 28;
            // 
            // lblPid
            // 
            this.lblPid.AutoSize = true;
            this.lblPid.Location = new System.Drawing.Point(49, 306);
            this.lblPid.Name = "lblPid";
            this.lblPid.Size = new System.Drawing.Size(47, 17);
            this.lblPid.TabIndex = 29;
            this.lblPid.Text = "ürün id";
            this.lblPid.Visible = false;
            // 
            // ProductModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 350);
            this.Controls.Add(this.lblPid);
            this.Controls.Add(this.comboCat);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtPDes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPQty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPName);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProductModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductModuleForm";
            this.Load += new System.EventHandler(this.ProductModuleForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtPDes;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtPPrice;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtPQty;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtPName;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboCat;
        public System.Windows.Forms.Label lblPid;
    }
}