﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public partial class Cafe : Form
    {
        public Cafe()
        {
            InitializeComponent();

            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Size.Width, 64);


            loginField.Text = "Введите логин";
            loginField.ForeColor = Color.Gray;


            passField.Text = "Введите пароль";
            passField.ForeColor = Color.Gray;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Green;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        Point lastPoint;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Authorization.AuthorizationController.CheckInputFields(loginField.Text, passField.Text);
                string type = Authorization.AuthorizationController.CheckInputDataReturnType(loginField.Text, passField.Text);
                if (type == "adm")
                {
                   
                  //TODO: open admin form
                }

                if (type == "clt")
                {
                   //TODO: open worker form
                }
            }
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "login")
                {
                    MessageBox.Show("Неверный логин", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (ex.ParamName == "password")
                {
                    MessageBox.Show("Неверный пароль", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterLabel1_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            Menu myMenu = null;
            if (registration.ShowDialog() == DialogResult.OK)
            {
                this.Hide();
                myMenu = new Menu();
                myMenu.Show();
            }
        }

        private void RegisterLabel1_MouseEnter(object sender, EventArgs e)
        {
            RegisterLabel1.ForeColor = Color.Green;
        }

        private void RegisterLabel1_MouseLeave(object sender, EventArgs e)
        {
            RegisterLabel1.ForeColor = Color.White;
        }

        private void loginField_Enter(object sender, EventArgs e)
        {
            if (loginField.Text == "Введите логин")
            {
                loginField.Text = "";
                loginField.ForeColor = Color.Black;

            }
        }

        private void loginField_Leave(object sender, EventArgs e)
        {
            if (loginField.Text == "")
            {
                loginField.Text = "Введите логин";
                loginField.ForeColor = Color.Gray;
            }
        }

        private void passField_Enter(object sender, EventArgs e)
        {
            if (passField.Text == "Введите пароль")
            {
                passField.UseSystemPasswordChar = true;
                passField.Text = "";
                passField.ForeColor = Color.Black;

            }
        }

        private void passField_Leave(object sender, EventArgs e)
        {
            if (passField.Text == "")
            {
                passField.UseSystemPasswordChar = false;
                passField.Text = "Введите пароль";
                passField.ForeColor = Color.Gray;
            }
        }
    }
}