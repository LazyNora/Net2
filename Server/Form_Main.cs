using Server.Helpers;
using SQl_Database.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Server
{
  public partial class Form_Main : Form
  {
    // Define theme colors
    private readonly Color themeBlue = ColorTranslator.FromHtml("#3297fd");
    private readonly Color themeWhite = Color.White;
    private readonly Color themeLight = Color.FromArgb(240, 240, 240);

    // Services
    private SessionService sessionService;

    // Timer for updating time
    private Timer clockTimer;

    // Status Dictionary for machines
    private Dictionary<string, Color> statusColors = new Dictionary<string, Color>
  {
    { "Sẵn sàng", Color.Green },
    { "Đang sử dụng", Color.Blue },
    { "Không hoạt động", Color.Red }
  };

    // Child forms
    private Form activeForm = null;

    // Management submenu panel
    private bool isManagementSubmenuOpen = true;

    public Form_Main()
    {
      InitializeComponent();

      // Initialize services
      sessionService = new SessionService();

      // Set up the UI
      SetupUI();

      // Set up clock timer
      SetupClockTimer();

      // Load computers
      LoadComputers();

      // Open the default Trang Chủ form
      OpenHomeForm();
    }

    private void SetupUI()
    {
      // Set sidebar color
      panelSidebar.BackColor = themeBlue;

      // Set the logged-in user information
      if (CurrentUser.IsLoggedIn)
      {
        lblUsername.Text = CurrentUser.CurrentEmployee.HoTen;
        lblRole.Text = CurrentUser.CurrentEmployee.TenViTri;
      }
    }

    private void SetupClockTimer()
    {
      // Timer for clock display
      clockTimer = new Timer();
      clockTimer.Interval = 1000; // 1 second
      clockTimer.Tick += (s, e) =>
      {
        lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
      };
      clockTimer.Start();
    }

    private void LoadComputers()
    {
      // This would load computers into the grid in the HomeForm
      // Implementation will be in the HomeForm class
    }

    private void OpenHomeForm()
    {
      OpenChildForm(new Form_Home());
    }

    private void OpenChildForm(Form childForm)
    {
      // Close the active form if there is one
      if (activeForm != null)
      {
        activeForm.Close();
      }

      // Set up the child form
      activeForm = childForm;
      childForm.TopLevel = false;
      childForm.FormBorderStyle = FormBorderStyle.None;
      childForm.Dock = DockStyle.Fill;

      // Add to the content panel
      panelContent.Controls.Clear();
      panelContent.Controls.Add(childForm);
      panelContent.Tag = childForm;

      // Show the form
      childForm.BringToFront();
      childForm.Show();
    }

    #region Sidebar Button Click Events
    private void btnHome_Click(object sender, EventArgs e)
    {
      OpenHomeForm();
      HideManagementSubmenu();
    }

    private void btnManagement_Click(object sender, EventArgs e)
    {
      ToggleManagementSubmenu();
    }

    private void btnStatistics_Click(object sender, EventArgs e)
    {
      // Will be implemented later
      MessageBox.Show("Chức năng đang được phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
      HideManagementSubmenu();
    }

    private void btnProfile_Click(object sender, EventArgs e)
    {
      // Will be implemented later
      MessageBox.Show("Chức năng đang được phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
      HideManagementSubmenu();
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
      // Close this form
      this.Close();
    }
    #endregion

    #region Management Submenu Methods
    private void ToggleManagementSubmenu()
    {
      if (isManagementSubmenuOpen)
      {
        HideManagementSubmenu();
      }
      else
      {
        ShowManagementSubmenu();
      }
    }

    private void ShowManagementSubmenu()
    {
      if (!isManagementSubmenuOpen)
      {
        panelManagementSubmenu.Visible = true;
        isManagementSubmenuOpen = true;
      }
    }

    private void HideManagementSubmenu()
    {
      if (isManagementSubmenuOpen)
      {
        panelManagementSubmenu.Visible = false;
        isManagementSubmenuOpen = false;
      }
    }

    private void btnAccountManagement_Click(object sender, EventArgs e)
    {
      OpenChildForm(new Form_QuanLyTaiKhoan());
    }

    private void btnProductManagement_Click(object sender, EventArgs e)
    {
      OpenChildForm(new Form_QuanLySanPham());
    }

    private void btnEmployeeManagement_Click(object sender, EventArgs e)
    {
      OpenChildForm(new Form_QuanLyNhanVien());
    }

    private void btnOrderManagement_Click(object sender, EventArgs e)
    {
      OpenChildForm(new Form_QuanLyHoaDon());
    }

    private void btnComputerManagement_Click(object sender, EventArgs e)
    {
      OpenChildForm(new Form_QuanLyMay());
    }
    #endregion

    private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
    {
      DialogResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (DialogResult == DialogResult.No)
      {
        e.Cancel = true; // Prevent closing the form
      }
      else
      {
        // Perform any necessary cleanup before closing
        clockTimer.Stop();
        activeForm?.Close();
        CurrentUser.Logout();
      }
    }
  }
}
