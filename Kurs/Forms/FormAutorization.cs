﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace Kurs
{
    public partial class FormAutorization : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly KursDbContext _context;

        public FormAutorization(KursDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void FormAutorization_Load(object sender, EventArgs e)
        {

        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            if (check())
            {
                // изменить статус на активный и выполнить вход
                var user = _context.Users.FirstOrDefault(u => u.Login == textBoxLogin.Text && u.Password == textBoxPassword.Text);
                if (user == null)
                {
                    MessageBox.Show("Ошибка! Пользователь не найден");
                    return;
                }
                user.IsActive = true;
                _context.SaveChanges();
                this.Hide();
                var form = Container.Resolve<FormMain>();
                form.ShowDialog();
                textBoxLogin.Clear();
                textBoxPassword.Clear();
                this.Show();
            }
        }

        private bool check()
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
                return false;
            if (string.IsNullOrEmpty(textBoxLogin.Text))
                return false;
            return true;
        }
    }
}
