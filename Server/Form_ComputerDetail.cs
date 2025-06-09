using System;
using System.Windows.Forms;
using SQl_Database.Models;
using SQl_Database.Services;
using Server.Helpers;

namespace Server
{
  public partial class Form_ComputerDetail : Form
  {
    private readonly int computerId;
    private Computer computer;
    private Invoice invoice;
    private readonly ComputerService computerService;

    public Form_ComputerDetail(int computerId)
    {
      InitializeComponent();

      this.computerId = computerId;
      computerService = new ComputerService();

      LoadComputerDetails();
    }

    private void LoadComputerDetails()
    {
      try
      {
        // Get computer details
        computer = computerService.GetComputerById(computerId);

        if (computer != null)
        {
          // Display basic information
          lblComputerId.Text = $"Máy {computer.MaMay}";
          lblStatus.Text = $"Trạng thái: {computer.TrangThaiMay}";
          lblRoom.Text = $"Phòng: {computer.TenPhong}";
          lblPrice.Text = $"Giá phòng: {computer.GiaMoiPhong:N0} VNĐ/giờ";

          // If computer is in use, show session information
          if (computer.TrangThaiMay == "Đang sử dụng" && computer.MaPhien.HasValue)
          {
            // Show session panel
            panelSession.Visible = true;

            // Display session information
            lblSessionId.Text = $"Mã phiên: {computer.MaPhien}";
            lblCustomer.Text = $"Khách hàng: {computer.TenKH} (ID: {computer.MaKH})";
            lblBalance.Text = $"Số dư: {computer.SoDu:N0} VNĐ";
            lblStartTime.Text = $"Thời gian bắt đầu: {computer.ThoiGianBatDau:dd/MM/yyyy HH:mm:ss}";

            // Calculate usage time
            TimeSpan duration = DateTime.Now - computer.ThoiGianBatDau.Value;
            lblUsageTime.Text = $"Thời gian sử dụng: {duration.Hours} giờ {duration.Minutes} phút {duration.Seconds} giây";

            // Calculate current cost
            decimal hours = (decimal)duration.TotalHours;
            decimal cost = Math.Ceiling(hours) * computer.GiaMoiPhong;
            lblCurrentCost.Text = $"Phí hiện tại: {cost:N0} VNĐ";

            // Get invoice information
            invoice = computerService.GetInvoiceForComputer(computerId);

            if (invoice != null)
            {
              // Show invoice panel
              panelInvoice.Visible = true;

              // Display invoice information
              lblInvoiceId.Text = $"Mã hóa đơn: {invoice.MaHD}";
              lblInvoiceDate.Text = $"Ngày lập: {invoice.NgayLap:dd/MM/yyyy}";
              lblInvoiceTotal.Text = $"Tổng tiền: {invoice.TongTien:N0} VNĐ";

              if (invoice.MaNhanVien.HasValue)
              {
                lblEmployee.Text = $"Nhân viên: {invoice.TenNhanVien} (ID: {invoice.MaNhanVien})";
              }

              // Show payment status
              if (invoice.DaThanhToan)
              {
                lblPaymentStatus.Text = "Đã thanh toán";
                lblPaymentStatus.ForeColor = System.Drawing.Color.Green;
                btnPay.Visible = false;
              }
              else
              {
                lblPaymentStatus.Text = "Chưa thanh toán";
                lblPaymentStatus.ForeColor = System.Drawing.Color.Red;
                btnPay.Visible = true;
              }
            }
            else
            {
              // Hide invoice panel if no invoice
              panelInvoice.Visible = false;
            }
          }
          else
          {
            // Hide session and invoice panels
            panelSession.Visible = false;
            panelInvoice.Visible = false;
          }
        }
        else
        {
          MessageBox.Show($"Không tìm thấy thông tin cho máy {computerId}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Close();
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Lỗi khi tải thông tin máy: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.Close();
      }
    }

    private void btnShutdown_Click(object sender, EventArgs e)
    {
      DialogResult result = MessageBox.Show($"Bạn có chắc muốn tắt máy {computer.MaMay}?",
          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (result == DialogResult.Yes)
      {
        if (computerService.ShutdownComputer(computer.MaMay))
        {
          MessageBox.Show($"Đã tắt máy {computer.MaMay} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
          this.Close();
        }
        else
        {
          MessageBox.Show($"Không thể tắt máy {computer.MaMay}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void btnPay_Click(object sender, EventArgs e)
    {
      if (invoice != null)
      {
        Form_ThanhToan paymentForm = new Form_ThanhToan(invoice.MaHD, invoice.TongTien);
        paymentForm.ShowDialog();

        // Refresh computer details
        LoadComputerDetails();
      }
      else
      {
        MessageBox.Show("Không tìm thấy hóa đơn cho máy này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
      LoadComputerDetails();
    }

    private void InitializeComponent()
    {
      this.panelMain = new System.Windows.Forms.Panel();
      this.lblComputerId = new System.Windows.Forms.Label();
      this.lblStatus = new System.Windows.Forms.Label();
      this.lblRoom = new System.Windows.Forms.Label();
      this.lblPrice = new System.Windows.Forms.Label();
      this.panelSession = new System.Windows.Forms.Panel();
      this.lblSessionId = new System.Windows.Forms.Label();
      this.lblCustomer = new System.Windows.Forms.Label();
      this.lblBalance = new System.Windows.Forms.Label();
      this.lblStartTime = new System.Windows.Forms.Label();
      this.lblUsageTime = new System.Windows.Forms.Label();
      this.lblCurrentCost = new System.Windows.Forms.Label();
      this.panelInvoice = new System.Windows.Forms.Panel();
      this.lblInvoiceId = new System.Windows.Forms.Label();
      this.lblInvoiceDate = new System.Windows.Forms.Label();
      this.lblEmployee = new System.Windows.Forms.Label();
      this.lblInvoiceTotal = new System.Windows.Forms.Label();
      this.lblPaymentStatus = new System.Windows.Forms.Label();
      this.btnPay = new System.Windows.Forms.Button();
      this.btnShutdown = new System.Windows.Forms.Button();
      this.btnRefresh = new System.Windows.Forms.Button();
      this.btnClose = new System.Windows.Forms.Button();
      this.panelMain.SuspendLayout();
      this.panelSession.SuspendLayout();
      this.panelInvoice.SuspendLayout();
      this.SuspendLayout();
      //
      // panelMain
      //
      this.panelMain.BackColor = System.Drawing.Color.White;
      this.panelMain.Controls.Add(this.lblComputerId);
      this.panelMain.Controls.Add(this.lblStatus);
      this.panelMain.Controls.Add(this.lblRoom);
      this.panelMain.Controls.Add(this.lblPrice);
      this.panelMain.Location = new System.Drawing.Point(12, 12);
      this.panelMain.Name = "panelMain";
      this.panelMain.Size = new System.Drawing.Size(460, 120);
      this.panelMain.TabIndex = 0;
      //
      // lblComputerId
      //
      this.lblComputerId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(151)))), ((int)(((byte)(253)))));
      this.lblComputerId.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblComputerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblComputerId.ForeColor = System.Drawing.Color.White;
      this.lblComputerId.Location = new System.Drawing.Point(0, 0);
      this.lblComputerId.Name = "lblComputerId";
      this.lblComputerId.Size = new System.Drawing.Size(460, 30);
      this.lblComputerId.TabIndex = 0;
      this.lblComputerId.Text = "Máy #";
      this.lblComputerId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //
      // lblStatus
      //
      this.lblStatus.AutoSize = true;
      this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblStatus.Location = new System.Drawing.Point(10, 40);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new System.Drawing.Size(73, 15);
      this.lblStatus.TabIndex = 1;
      this.lblStatus.Text = "Trạng thái: ";
      //
      // lblRoom
      //
      this.lblRoom.AutoSize = true;
      this.lblRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblRoom.Location = new System.Drawing.Point(10, 65);
      this.lblRoom.Name = "lblRoom";
      this.lblRoom.Size = new System.Drawing.Size(49, 15);
      this.lblRoom.TabIndex = 2;
      this.lblRoom.Text = "Phòng: ";
      //
      // lblPrice
      //
      this.lblPrice.AutoSize = true;
      this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblPrice.Location = new System.Drawing.Point(10, 90);
      this.lblPrice.Name = "lblPrice";
      this.lblPrice.Size = new System.Drawing.Size(72, 15);
      this.lblPrice.TabIndex = 3;
      this.lblPrice.Text = "Giá phòng: ";
      //
      // panelSession
      //
      this.panelSession.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
      this.panelSession.Controls.Add(this.lblSessionId);
      this.panelSession.Controls.Add(this.lblCustomer);
      this.panelSession.Controls.Add(this.lblBalance);
      this.panelSession.Controls.Add(this.lblStartTime);
      this.panelSession.Controls.Add(this.lblUsageTime);
      this.panelSession.Controls.Add(this.lblCurrentCost);
      this.panelSession.Location = new System.Drawing.Point(12, 145);
      this.panelSession.Name = "panelSession";
      this.panelSession.Size = new System.Drawing.Size(460, 150);
      this.panelSession.TabIndex = 1;
      this.panelSession.Visible = false;
      //
      // lblSessionId
      //
      this.lblSessionId.AutoSize = true;
      this.lblSessionId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblSessionId.Location = new System.Drawing.Point(10, 10);
      this.lblSessionId.Name = "lblSessionId";
      this.lblSessionId.Size = new System.Drawing.Size(63, 15);
      this.lblSessionId.TabIndex = 0;
      this.lblSessionId.Text = "Mã phiên: ";
      //
      // lblCustomer
      //
      this.lblCustomer.AutoSize = true;
      this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblCustomer.Location = new System.Drawing.Point(10, 35);
      this.lblCustomer.Name = "lblCustomer";
      this.lblCustomer.Size = new System.Drawing.Size(82, 15);
      this.lblCustomer.TabIndex = 1;
      this.lblCustomer.Text = "Khách hàng: ";
      //
      // lblBalance
      //
      this.lblBalance.AutoSize = true;
      this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblBalance.Location = new System.Drawing.Point(10, 60);
      this.lblBalance.Name = "lblBalance";
      this.lblBalance.Size = new System.Drawing.Size(47, 15);
      this.lblBalance.TabIndex = 2;
      this.lblBalance.Text = "Số dư: ";
      //
      // lblStartTime
      //
      this.lblStartTime.AutoSize = true;
      this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblStartTime.Location = new System.Drawing.Point(10, 85);
      this.lblStartTime.Name = "lblStartTime";
      this.lblStartTime.Size = new System.Drawing.Size(115, 15);
      this.lblStartTime.TabIndex = 3;
      this.lblStartTime.Text = "Thời gian bắt đầu: ";
      //
      // lblUsageTime
      //
      this.lblUsageTime.AutoSize = true;
      this.lblUsageTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblUsageTime.Location = new System.Drawing.Point(10, 110);
      this.lblUsageTime.Name = "lblUsageTime";
      this.lblUsageTime.Size = new System.Drawing.Size(109, 15);
      this.lblUsageTime.TabIndex = 4;
      this.lblUsageTime.Text = "Thời gian sử dụng: ";
      //
      // lblCurrentCost
      //
      this.lblCurrentCost.AutoSize = true;
      this.lblCurrentCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblCurrentCost.Location = new System.Drawing.Point(10, 125);
      this.lblCurrentCost.Name = "lblCurrentCost";
      this.lblCurrentCost.Size = new System.Drawing.Size(89, 15);
      this.lblCurrentCost.TabIndex = 5;
      this.lblCurrentCost.Text = "Phí hiện tại: ";
      //
      // panelInvoice
      //
      this.panelInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
      this.panelInvoice.Controls.Add(this.lblInvoiceId);
      this.panelInvoice.Controls.Add(this.lblInvoiceDate);
      this.panelInvoice.Controls.Add(this.lblEmployee);
      this.panelInvoice.Controls.Add(this.lblInvoiceTotal);
      this.panelInvoice.Controls.Add(this.lblPaymentStatus);
      this.panelInvoice.Location = new System.Drawing.Point(12, 310);
      this.panelInvoice.Name = "panelInvoice";
      this.panelInvoice.Size = new System.Drawing.Size(460, 120);
      this.panelInvoice.TabIndex = 2;
      this.panelInvoice.Visible = false;
      //
      // lblInvoiceId
      //
      this.lblInvoiceId.AutoSize = true;
      this.lblInvoiceId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblInvoiceId.Location = new System.Drawing.Point(10, 10);
      this.lblInvoiceId.Name = "lblInvoiceId";
      this.lblInvoiceId.Size = new System.Drawing.Size(84, 15);
      this.lblInvoiceId.TabIndex = 0;
      this.lblInvoiceId.Text = "Mã hóa đơn: ";
      //
      // lblInvoiceDate
      //
      this.lblInvoiceDate.AutoSize = true;
      this.lblInvoiceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblInvoiceDate.Location = new System.Drawing.Point(10, 35);
      this.lblInvoiceDate.Name = "lblInvoiceDate";
      this.lblInvoiceDate.Size = new System.Drawing.Size(62, 15);
      this.lblInvoiceDate.TabIndex = 1;
      this.lblInvoiceDate.Text = "Ngày lập: ";
      //
      // lblEmployee
      //
      this.lblEmployee.AutoSize = true;
      this.lblEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblEmployee.Location = new System.Drawing.Point(10, 60);
      this.lblEmployee.Name = "lblEmployee";
      this.lblEmployee.Size = new System.Drawing.Size(73, 15);
      this.lblEmployee.TabIndex = 2;
      this.lblEmployee.Text = "Nhân viên: ";
      //
      // lblInvoiceTotal
      //
      this.lblInvoiceTotal.AutoSize = true;
      this.lblInvoiceTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblInvoiceTotal.Location = new System.Drawing.Point(10, 85);
      this.lblInvoiceTotal.Name = "lblInvoiceTotal";
      this.lblInvoiceTotal.Size = new System.Drawing.Size(77, 15);
      this.lblInvoiceTotal.TabIndex = 3;
      this.lblInvoiceTotal.Text = "Tổng tiền: ";
      //
      // lblPaymentStatus
      //
      this.lblPaymentStatus.AutoSize = true;
      this.lblPaymentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblPaymentStatus.Location = new System.Drawing.Point(300, 85);
      this.lblPaymentStatus.Name = "lblPaymentStatus";
      this.lblPaymentStatus.Size = new System.Drawing.Size(117, 15);
      this.lblPaymentStatus.TabIndex = 4;
      this.lblPaymentStatus.Text = "Chưa thanh toán";
      this.lblPaymentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      //
      // btnPay
      //
      this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
      this.btnPay.FlatAppearance.BorderSize = 0;
      this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnPay.ForeColor = System.Drawing.Color.White;
      this.btnPay.Location = new System.Drawing.Point(352, 450);
      this.btnPay.Name = "btnPay";
      this.btnPay.Size = new System.Drawing.Size(120, 35);
      this.btnPay.TabIndex = 3;
      this.btnPay.Text = "Thanh toán";
      this.btnPay.UseVisualStyleBackColor = false;
      this.btnPay.Visible = false;
      this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
      //
      // btnShutdown
      //
      this.btnShutdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.btnShutdown.FlatAppearance.BorderSize = 0;
      this.btnShutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnShutdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnShutdown.ForeColor = System.Drawing.Color.White;
      this.btnShutdown.Location = new System.Drawing.Point(226, 450);
      this.btnShutdown.Name = "btnShutdown";
      this.btnShutdown.Size = new System.Drawing.Size(120, 35);
      this.btnShutdown.TabIndex = 4;
      this.btnShutdown.Text = "Tắt máy";
      this.btnShutdown.UseVisualStyleBackColor = false;
      this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
      //
      // btnRefresh
      //
      this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(151)))), ((int)(((byte)(253)))));
      this.btnRefresh.FlatAppearance.BorderSize = 0;
      this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnRefresh.ForeColor = System.Drawing.Color.White;
      this.btnRefresh.Location = new System.Drawing.Point(138, 450);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(82, 35);
      this.btnRefresh.TabIndex = 5;
      this.btnRefresh.Text = "Làm mới";
      this.btnRefresh.UseVisualStyleBackColor = false;
      this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
      //
      // btnClose
      //
      this.btnClose.BackColor = System.Drawing.Color.Silver;
      this.btnClose.FlatAppearance.BorderSize = 0;
      this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnClose.ForeColor = System.Drawing.Color.White;
      this.btnClose.Location = new System.Drawing.Point(12, 450);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(120, 35);
      this.btnClose.TabIndex = 6;
      this.btnClose.Text = "Đóng";
      this.btnClose.UseVisualStyleBackColor = false;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      //
      // Form_ComputerDetail
      //
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(484, 500);
      this.Controls.Add(this.panelMain);
      this.Controls.Add(this.panelSession);
      this.Controls.Add(this.panelInvoice);
      this.Controls.Add(this.btnPay);
      this.Controls.Add(this.btnShutdown);
      this.Controls.Add(this.btnRefresh);
      this.Controls.Add(this.btnClose);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form_ComputerDetail";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Chi tiết máy";
      this.panelMain.ResumeLayout(false);
      this.panelMain.PerformLayout();
      this.panelSession.ResumeLayout(false);
      this.panelSession.PerformLayout();
      this.panelInvoice.ResumeLayout(false);
      this.panelInvoice.PerformLayout();
      this.ResumeLayout(false);
    }

    private System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.Label lblComputerId;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.Label lblRoom;
    private System.Windows.Forms.Label lblPrice;
    private System.Windows.Forms.Panel panelSession;
    private System.Windows.Forms.Label lblSessionId;
    private System.Windows.Forms.Label lblCustomer;
    private System.Windows.Forms.Label lblBalance;
    private System.Windows.Forms.Label lblStartTime;
    private System.Windows.Forms.Label lblUsageTime;
    private System.Windows.Forms.Label lblCurrentCost;
    private System.Windows.Forms.Panel panelInvoice;
    private System.Windows.Forms.Label lblInvoiceId;
    private System.Windows.Forms.Label lblInvoiceDate;
    private System.Windows.Forms.Label lblEmployee;
    private System.Windows.Forms.Label lblInvoiceTotal;
    private System.Windows.Forms.Label lblPaymentStatus;
    private System.Windows.Forms.Button btnPay;
    private System.Windows.Forms.Button btnShutdown;
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.Button btnClose;
  }
}
