namespace Client
{
    partial class Form_YeuCauDichVu
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
			this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.btn_CallServices = new System.Windows.Forms.Button();
			this.btn_Clear = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// flowLayoutPanel
			// 
			this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel.AutoScroll = true;
			this.flowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.flowLayoutPanel.Location = new System.Drawing.Point(12, 118);
			this.flowLayoutPanel.Name = "flowLayoutPanel";
			this.flowLayoutPanel.Size = new System.Drawing.Size(888, 413);
			this.flowLayoutPanel.TabIndex = 0;
			// 
			// btn_CallServices
			// 
			this.btn_CallServices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(154)))), ((int)(((byte)(246)))));
			this.btn_CallServices.FlatAppearance.BorderSize = 0;
			this.btn_CallServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_CallServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_CallServices.ForeColor = System.Drawing.Color.White;
			this.btn_CallServices.Location = new System.Drawing.Point(706, 24);
			this.btn_CallServices.Name = "btn_CallServices";
			this.btn_CallServices.Size = new System.Drawing.Size(111, 32);
			this.btn_CallServices.TabIndex = 7;
			this.btn_CallServices.Text = "Gọi dịch vụ";
			this.btn_CallServices.UseVisualStyleBackColor = false;
			this.btn_CallServices.Click += new System.EventHandler(this.btn_CallServices_Click);
			// 
			// btn_Clear
			// 
			this.btn_Clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btn_Clear.FlatAppearance.BorderSize = 0;
			this.btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_Clear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btn_Clear.Location = new System.Drawing.Point(706, 63);
			this.btn_Clear.Name = "btn_Clear";
			this.btn_Clear.Size = new System.Drawing.Size(111, 32);
			this.btn_Clear.TabIndex = 9;
			this.btn_Clear.Text = "Clear";
			this.btn_Clear.UseVisualStyleBackColor = false;
			this.btn_Clear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(154)))), ((int)(((byte)(246)))));
			this.label1.Location = new System.Drawing.Point(119, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(384, 48);
			this.label1.TabIndex = 10;
			this.label1.Text = "Dịch vụ tiệm internet";
			// 
			// Form_YeuCauDichVu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(912, 531);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_Clear);
			this.Controls.Add(this.btn_CallServices);
			this.Controls.Add(this.flowLayoutPanel);
			this.Name = "Form_YeuCauDichVu";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Yêu cầu dịch vụ";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button btn_CallServices;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Label label1;
    }
}