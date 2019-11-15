using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using System.Text.RegularExpressions;

namespace Kurs.Forms
{
    public partial class InfoControl : UserControl
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly KursDbContext _context;

        public InfoControl(KursDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void InfoControl_Load(object sender, EventArgs e)
        {
            var user = _context.Users.FirstOrDefault(u => u.IsActive == true);
            labelLogin.Text = user.Login;
            textBoxEmail.Text = user.Email;
        }

        private void buttonSavePassword_Click(object sender, EventArgs e)
        {
            if (check()) {
                var user = _context.Users.FirstOrDefault(u => u.IsActive == true);
                if (user.Password == textBoxOld.Text)
                {
                    user.Password = textBoxNew.Text;
                    _context.SaveChanges();
                    if (user.Email != null)
                        SendEmail.SendMessage(user.Email, LetterTemplates.updatePasswordLetter(user.Login));

                    MessageBox.Show("Успешно!");
                }
            }
            MessageBox.Show("Ошибка!");
        }

        private bool check()
        {
            if (string.IsNullOrEmpty(textBoxNew.Text)) return false;
            if (string.IsNullOrEmpty(textBoxOld.Text)) return false;
            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxEmail.Text))
            {
                var user = _context.Users.FirstOrDefault(u => u.IsActive == true);
                string pattern = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
                if (Regex.IsMatch(textBoxEmail.Text, pattern))
                {
                    user.Email = textBoxEmail.Text;
                    _context.SaveChanges();
                    MessageBox.Show("Успешно!");
                    return;
                }
                MessageBox.Show("Ошибка!");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxEmail.Clear();
        }
    }
}
