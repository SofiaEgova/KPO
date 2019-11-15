using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Resolution;

namespace Kurs.Forms
{
    public partial class FormTask : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly KursDbContext _context;
        private Guid? _id;
        private Guid _idProject;
        private Guid _idSubtask;
        private bool first = true;
        private bool subtask = false;

        public FormTask(KursDbContext context, Guid? idProject=null, Guid? idSubtask =null, Guid? id = null)
        {
            InitializeComponent();
            _context = context;
            _id = id;
            if(idProject.HasValue)
                _idProject = idProject.Value;
            if(idSubtask.HasValue)
                _idSubtask = idSubtask.Value;
        }

        private void FormTask_Load(object sender, EventArgs e)
        {
            var pr = _context.UserProjects.Where(p => p.ProjectId == _idProject).Distinct();
            var projectUserIds = pr.Select(x => x.UserId).Distinct();
            var users = _context.Users.Where(x => projectUserIds.Contains(x.UserId));

            if (_idSubtask.ToString()!="00000000-0000-0000-0000-000000000000")
            {
                var t = _context.Tasks.FirstOrDefault(st => st.TaskId == _idSubtask);
                pr = _context.UserProjects.Where(p => p.ProjectId == t.ProjectId).Distinct();
                projectUserIds = pr.Select(x => x.UserId).Distinct();
                users = _context.Users.Where(x => projectUserIds.Contains(x.UserId));
                subtask = true;
            }

            comboBoxImp.ValueMember = "UserId";
            comboBoxImp.DisplayMember = "Login";
            foreach (var u in users)
            {
                comboBoxImp.Items.Add(u.Login);
            }
            comboBoxImp.SelectedItem = null;

            comboBoxStatus.ValueMember = "Value";
            comboBoxStatus.DisplayMember = "Display";
            comboBoxStatus.DataSource = Enum.GetValues(typeof(TaskStatus));
            comboBoxStatus.SelectedItem = 0;

            List<ColumnConfig> columns = new List<ColumnConfig>
            {
                new ColumnConfig { Name = "Id", Title = "Id", Width = 100, Visible = false },
                new ColumnConfig { Name = "Title", Title = "Название", Width = 200, Visible = true },
                new ColumnConfig { Name = "Description", Title = "Описание", Width = 200, Visible = true }
            };
            dataGridViewSubtasks.Columns.Clear();
            foreach (var column in columns)
            {
                dataGridViewSubtasks.Columns.Add(new DataGridViewTextBoxColumn
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
                var task = _context.Tasks.FirstOrDefault(t=>t.TaskId == _id);
                if (task == null)
                {
                    throw new Exception("При загрузке возникла ошибка");
                }
                textBoxTitle.Text = task.Title;
                textBoxDescription.Text = task.Description;
                var usLogin = _context.Users.FirstOrDefault(u => u.UserId == task.UserId).Login;
                comboBoxImp.SelectedItem= usLogin;
                labelFile.Text = task.PdfTitle;
                comboBoxStatus.SelectedItem = task.Status;

                LoadData();
            }
            else
            {
                groupBoxFile.Enabled = false;
                tabControl1.TabPages.Remove(tabPageSubtasks);
            }
        }

        private void LoadData()
        {
            // тех пользователей, у которых есть привязка по юзерпроджект
            var subtasks = _context.Tasks.Where(s => s.SubtaskId == _id);

            if (subtasks == null)
            {
                throw new Exception("При загрузке возникла ошибка");
                //return;
            }

            (tabPageSubtasks.Controls["dataGridViewSubtasks"] as DataGridView).Rows.Clear();
            foreach (var s in subtasks)
            {
                (tabPageSubtasks.Controls["dataGridViewSubtasks"] as DataGridView).Rows.Add(new object[]
                {
                    s.TaskId,
                    s.Title,
                    s.Description
                });
            }
        }

        private bool check()
        {
            if (string.IsNullOrEmpty(textBoxTitle.Text))
                return false;
            if (comboBoxImp.SelectedItem == null)
                return false;
            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (check())
            {
                TaskStatus status;
                Enum.TryParse<TaskStatus>(comboBoxStatus.SelectedValue.ToString(), out status);
                var user = _context.Users.FirstOrDefault(u => u.Login == comboBoxImp.SelectedItem.ToString());
                if (_id.HasValue)
                {
                    var task = _context.Tasks.FirstOrDefault(t => t.TaskId == _id);
                    if (task == null)
                    {
                        throw new Exception("При загрузке возникла ошибка");
                    }
                    task.Title = textBoxTitle.Text;
                    task.Description = textBoxDescription.Text;
                    task.Status = (int)status;
                    task.UserId = user.UserId;
                }
                else if(first)
                {
                    first = false;
                    if (_idProject.ToString() != "00000000-0000-0000-0000-000000000000")
                    _context.Tasks.Add(new Model.Task { TaskId = Guid.NewGuid(), Title = textBoxTitle.Text, Description=textBoxDescription.Text, ProjectId = _idProject, UserId = user.UserId, Status=0 });
                    else
                        _context.Tasks.Add(new Model.Task { TaskId = Guid.NewGuid(), Title = textBoxTitle.Text, Description = textBoxDescription.Text, SubtaskId = _idSubtask, UserId = user.UserId, Status = 0 });
                    groupBoxFile.Enabled = true;
                    buttonShowFile.Enabled = false;
                    if(!subtask)tabControl1.TabPages.Add(tabPageSubtasks);
                }
                if (user.Email != null)
                    SendEmail.SendMessage(user.Email, LetterTemplates.addTask(user.Login, textBoxTitle.Text));
                _context.SaveChanges();
                Close();
                
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAddSubtask_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTask>(
                    new ParameterOverrides
                    {
                        { "idSubtask", _id }
                    }
                    .OnType<FormTask>());
            form.ShowDialog();
            LoadData();
        }

        private void buttonUpdSubtask_Click(object sender, EventArgs e)
        {
            if (dataGridViewSubtasks.SelectedRows.Count == 1)
            {
                Guid id = new Guid(dataGridViewSubtasks.SelectedRows[0].Cells[0].Value.ToString());
                var form = Container.Resolve<FormTask>(
                    new ParameterOverrides
                    {
                        { "id", id },
                        { "idSubtask", _id }
                    }
                    .OnType<FormTask>());
                form.ShowDialog();
                LoadData();
            }
        }

        private void buttonDelSubtask_Click(object sender, EventArgs e)
        {
            if (dataGridViewSubtasks.SelectedRows.Count == 1)
            {
                Guid id = new Guid(dataGridViewSubtasks.SelectedRows[0].Cells[0].Value.ToString());
                var subtask = _context.Tasks.FirstOrDefault(t=>t.TaskId == id);
                if (subtask == null)
                {
                    throw new Exception("При загрузке возникла ошибка");
                }
                _context.Tasks.Remove(subtask);
                _context.SaveChanges();
            }
            LoadData();
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            myStream = openFileDialog.OpenFile();

            byte[] buf = new byte[myStream.Length];

            myStream.Read(buf, 0, (int)myStream.Length);
            myStream.Close();

            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == _id);

            task.Pdf = buf;
            task.PdfTitle= Path.GetFileNameWithoutExtension(openFileDialog.FileName);
            labelFile.Text = task.PdfTitle;

            buttonShowFile.Enabled = true;
            _context.SaveChanges();
            
        }

        private void buttonShowFile_Click(object sender, EventArgs e)
        {
            var taskFile = _context.Tasks.FirstOrDefault(t => t.TaskId == _id).Pdf;
            FileStream f;
            using (f = File.Create("file.pdf"))
            {
                {
                    f.Write(taskFile, 0, taskFile.Length);
                }
            }

            System.Diagnostics.Process.Start("file.pdf");
        }

        private void FormTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("file.pdf");
        }
    }
}
