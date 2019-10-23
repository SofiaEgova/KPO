using Kurs.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace Kurs.Forms
{
    public partial class FormUser : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly KursDbContext _context;
        private Guid? _id;

        public FormUser(KursDbContext context, Guid? id=null)
        {
            InitializeComponent();
            _context = context;
            _id = id;
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            comboBoxRole.ValueMember = "Value";
            comboBoxRole.DisplayMember = "Display";
            comboBoxRole.DataSource = Enum.GetValues(typeof(UserRoles));
            comboBoxRole.SelectedItem = null;

            if (_id.HasValue)
            {
                var user = _context.Users.FirstOrDefault(u => u.UserId == _id);
                if (user == null)
                {
                    throw new Exception("При загрузке возникла ошибка");
                }
                textBoxLogin.Text = user.Login;
                textBoxPassword.Text = user.Password;
                comboBoxRole.SelectedIndex = user.UserRole;
            }
        }

        private bool check()
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
                return false;
            if (string.IsNullOrEmpty(textBoxPassword.Text))
                return false;
            if (comboBoxRole.SelectedValue == null)
                return false;
            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (check())
            {
                UserRoles role;
                Enum.TryParse<UserRoles>(comboBoxRole.SelectedValue.ToString(), out role);
                if (_id.HasValue)
                {
                    var user = _context.Users.FirstOrDefault(u => u.UserId == _id);
                    if (user == null)
                    {
                        throw new Exception("При загрузке возникла ошибка");
                    }
                    user.Login = textBoxLogin.Text;
                    user.Password = textBoxPassword.Text;
                    user.UserRole = (int)role;
                }
                else _context.Users.Add(new User { UserId = Guid.NewGuid(), Login = textBoxLogin.Text, Password = textBoxPassword.Text, IsActive = false, UserRole = (int)role });
                _context.SaveChanges();
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
