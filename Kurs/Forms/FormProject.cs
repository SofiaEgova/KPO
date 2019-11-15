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
using Unity.Resolution;

namespace Kurs.Forms
{
    public partial class FormProject : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly KursDbContext _context;
        private Guid? _id;

        public FormProject(KursDbContext context, Guid? id = null)
        {
            InitializeComponent();
            _context = context;
            _id = id;
        }

        // Добавить пользователей!!!
        private void FormProject_Load(object sender, EventArgs e)
        {
            var pr = _context.UserProjects.Where(p => p.ProjectId == _id).Distinct();
            var projectUserIds = pr.Select(x => x.UserId).Distinct();
            var users = _context.Users.Where(x => !projectUserIds.Contains(x.UserId));

            comboBoxAddUsers.ValueMember = "UserId";
            comboBoxAddUsers.DisplayMember = "Login";
            foreach (var u in users)
            {
                comboBoxAddUsers.Items.Add(u.Login);
            }
            comboBoxAddUsers.SelectedItem = null;

            List<ColumnConfig> columns = new List<ColumnConfig>
            {
                new ColumnConfig { Name = "Id", Title = "Id", Width = 100, Visible = false },
                new ColumnConfig { Name = "Login", Title = "Логин", Width = 450, Visible = true }

            };
            dataGridViewProjectUsers.Columns.Clear();
            foreach (var column in columns)
            {
                dataGridViewProjectUsers.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = column.Title,
                    Name = string.Format("Column{0}", column.Name),
                    ReadOnly = true,
                    Visible = column.Visible,
                    Width = column.Width ?? 0,
                    AutoSizeMode = column.Width.HasValue ? DataGridViewAutoSizeColumnMode.None : DataGridViewAutoSizeColumnMode.Fill
                });
            }

            columns = new List<ColumnConfig>
            {
                new ColumnConfig { Name = "Id", Title = "Id", Width = 100, Visible = false },
                new ColumnConfig { Name = "Title", Title = "Название", Width = 200, Visible = true },
                new ColumnConfig { Name = "Description", Title = "Описание", Width = 200, Visible = true }

            };
            dataGridViewTasks.Columns.Clear();
            foreach (var column in columns)
            {
                dataGridViewTasks.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = column.Title,
                    Name = string.Format("Column{0}", column.Name),
                    ReadOnly = true,
                    Visible = column.Visible,
                    Width = column.Width ?? 0,
                    AutoSizeMode = column.Width.HasValue ? DataGridViewAutoSizeColumnMode.None : DataGridViewAutoSizeColumnMode.Fill
                });
            }

            if (_id.HasValue)
            {
                var user = _context.Users.FirstOrDefault(u => u.IsActive == true);
                if (user.UserRole == 2)
                {
                    groupBox.Hide();
                }
                var project = _context.Projects.FirstOrDefault(p => p.ProjectId == _id);
                if (project == null)
                {
                    throw new Exception("При загрузке возникла ошибка");
                }
                textBoxTitle.Text = project.Title;
                textBoxDescription.Text = project.Description;
                LoadData();
            }
            else
            {
                groupBox.Enabled = false;
                tabControl.TabPages.Remove(tabPageTasks);
            }
        }

        private void LoadData()
        {
            // тех пользователей, у которых есть привязка по юзерпроджект
            var pr = _context.UserProjects.Where(p => p.ProjectId == _id).Distinct();
            var projectUserIds = pr.Select(x => x.UserId).Distinct();
            var users = _context.Users.Where(x => projectUserIds.Contains(x.UserId));

            if (users == null)
            {
                throw new Exception("При загрузке возникла ошибка");
                //return;
            }

            (groupBox.Controls["dataGridViewProjectUsers"] as DataGridView).Rows.Clear();
            foreach (var u in users)
            {
                (groupBox.Controls["dataGridViewProjectUsers"] as DataGridView).Rows.Add(new object[]
                {
                    u.UserId,
                    u.Login
                });
            }

            var us = _context.Users.FirstOrDefault(u => u.IsActive == true);

            var tasks = _context.Tasks.Where(t => t.ProjectId == _id);
            if (us.UserRole == 2)
            {
                tasks = _context.Tasks.Where(t => t.ProjectId == _id && t.UserId == us.UserId);
            }
            (tabPageTasks.Controls["dataGridViewTasks"] as DataGridView).Rows.Clear();
            foreach (var t in tasks)
            {
                (tabPageTasks.Controls["dataGridViewTasks"] as DataGridView).Rows.Add(new object[]
                {
                    t.TaskId,
                    t.Title,
                    t.Description
                });
            }
        }

        private bool check()
        {
            if (string.IsNullOrEmpty(textBoxTitle.Text))
                return false;
            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (check())
            {
                if (_id.HasValue)
                {
                    var project = _context.Projects.FirstOrDefault(p => p.ProjectId == _id);
                    if (project == null)
                    {
                        throw new Exception("При загрузке возникла ошибка");
                    }
                    project.Title = textBoxTitle.Text;
                    project.Description = textBoxDescription.Text;
                }
                else
                {
                    _context.Projects.Add(new Project { ProjectId = Guid.NewGuid(), Title = textBoxTitle.Text, Description = textBoxDescription.Text });
                    groupBox.Enabled = true;
                    tabControl.TabPages.Add(tabPageTasks);
                }
                _context.SaveChanges();
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // добавить из списка пользователей, в списке все кроме тех, у кого есть привязка по юзерпроджект
            var user = _context.Users.FirstOrDefault(u => u.Login == comboBoxAddUsers.SelectedItem.ToString());
            _context.UserProjects.Add(new UserProject { UserProjectId = Guid.NewGuid(), ProjectId = _id.Value, UserId = user.UserId });
            LoadData();

            if (user.Email != null)
                SendEmail.SendMessage(user.Email, LetterTemplates.addToProject(user.Login, textBoxTitle.Text));
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewProjectUsers.SelectedRows.Count == 1)
            {
                Guid id = new Guid(dataGridViewProjectUsers.SelectedRows[0].Cells[0].Value.ToString());
                var pu = _context.UserProjects.FirstOrDefault(u => u.UserId == id && u.ProjectId == _id);
                if (pu == null)
                {
                    throw new Exception("При загрузке возникла ошибка");
                }
                _context.UserProjects.Remove(pu);
                _context.SaveChanges();
            }
            LoadData();
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTask>(
                    new ParameterOverrides
                    {
                        { "idProject", _id }
                    }
                    .OnType<FormTask>());
            form.ShowDialog();
            LoadData();
        }

        private void buttonUpdTask_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count == 1)
            {
                Guid id = new Guid(dataGridViewTasks.SelectedRows[0].Cells[0].Value.ToString());
                var form = Container.Resolve<FormTask>(
                    new ParameterOverrides
                    {
                        { "id", id },
                        { "idProject", _id }
                    }
                    .OnType<FormTask>());
                form.ShowDialog();
                LoadData();
            }
        }

        private void buttonDelTask_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count == 1)
            {
                Guid id = new Guid(dataGridViewTasks.SelectedRows[0].Cells[0].Value.ToString());
                var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);
                if (task == null)
                {
                    throw new Exception("При загрузке возникла ошибка");
                }
                _context.Tasks.Remove(task);

                _context.SaveChanges();
            }
            LoadData();
        }
    }
}
