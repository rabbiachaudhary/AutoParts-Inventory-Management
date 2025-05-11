using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProjectG27.Controllers;

namespace FinalProjectG27.Views
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            int roleId = credentialsDL.AuthenticateUser(username, password); 

            if (roleId != -1)
            {
                string role = credentialsDL.GetRole(roleId); 

              

                
                switch (role)
                {
                    case "Admin":
                        MainDashBoard adminForm = new MainDashBoard();
                        adminForm.WindowState = this.WindowState;
                        if (this.WindowState != FormWindowState.Maximized)
                        {
                            adminForm.Size = this.Size;
                            adminForm.Location = this.Location;
                        }
                        adminForm.Show();
                        this.Hide();
                        break;

                    case "Staff":
                        MainDashBoard staffForm = new MainDashBoard();
                        staffForm.WindowState = this.WindowState;
                        if (this.WindowState != FormWindowState.Maximized)
                        {
                            staffForm.Size = this.Size;
                            staffForm.Location = this.Location;
                        }
                        staffForm.Show();
                        this.Hide();
                        break;

                    default:
                        MessageBox.Show("Role not recognized.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void RoundPanelCorners(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = panel.ClientRectangle;

            int diameter = radius * 2;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);
        }
        private void RoundButton(Button btn, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = btn.ClientRectangle;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            btn.Region = new Region(path);
        }
        private void RoundPictureBox(PictureBox picBox, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = picBox.ClientRectangle;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            picBox.Region = new Region(path);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            RoundPanelCorners(panel1, 20); 
            RoundPanelCorners(pan, 20); 
            RoundButton(btnlog, 50);
            RoundPictureBox(pictureBox1, 20); 
            RoundPictureBox(pictureBox2, 20); 

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
