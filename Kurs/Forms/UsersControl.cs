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
using Unity.Resolution;

namespace Kurs.Forms
{
    public partial class UsersControl : UserControl
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly KursDbContext _context;

        public UsersControl(KursDbContext context)
        {
            InitializeComponent();
            _context = context;

            List<ColumnConfig> columns = new List<ColumnConfig>
            {
                new ColumnConfig { Name = "Id", Title = "Id", Width = 100, Visible = false },
                new ColumnConfig { Name = "Login", Title = "Логин", Width = 250, Visible = true },
                new ColumnConfig { Name = "Password", Title = "Пароль", Width = 232, Visible = true },
                new ColumnConfig { Name = "UserRole", Title = "Роль", Width = 232, Visible = true }

            };
            dataGridViewUsers.Columns.Clear();
            foreach (var column in columns)
            {
                dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = column.Title,
                    Name = string.Format("Column{0}", column.Name),
                    ReadOnly = true,
                    Visible = column.Visible,
                    Width = column.Width ?? 0,
                    AutoSizeMode = column.Width.HasValue ? DataGridViewAutoSizeColumnMode.None : DataGridViewAutoSizeColumnMode.Fill
                });
            }
            LoadData();
        }

        private void LoadData()
        {
            dataGridViewUsers.Rows.Clear();
            var users = _context.Users.ToArray();

            if (users == null)
            {
                throw new Exception("При загрузке возникла ошибка");
            }

            (Controls["dataGridViewUsers"] as DataGridView).Rows.Clear();
            foreach (var u in users)
            {
                (Controls["dataGridViewUsers"] as DataGridView).Rows.Add(new object[]
                {
                    u.UserId,
                    u.Login,
                    u.Password,
                    (UserRoles)u.UserRole
                });
            }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormUser>();
            form.ShowDialog();
                LoadData();
        }

        private void toolStripButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 1)
            {
                Guid id = new Guid(dataGridViewUsers.SelectedRows[0].Cells[0].Value.ToString());
                var form = Container.Resolve<FormUser>(
                    new ParameterOverrides
                    {
                        { "id", id }
                    }   
                    .OnType<FormUser>());
                form.ShowDialog();
                    LoadData();
            }
        }

        private void toolStripButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 1)
            {
                Guid id = new Guid(dataGridViewUsers.SelectedRows[0].Cells[0].Value.ToString());
                var user = _context.Users.FirstOrDefault(u => u.UserId == id);
                if (user == null)
                {
                    throw new Exception("При загрузке возникла ошибка");
                }
                if (user.IsActive == true)
                {
                    MessageBox.Show("Данный пользователь в настоящее время активен");
                    return;
                }
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            LoadData();
        }
    }
}
