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
    public partial class ProjectsControl : UserControl
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly KursDbContext _context;

        public ProjectsControl(KursDbContext context)
        {
            InitializeComponent();
            _context = context;

            List<ColumnConfig> columns = new List<ColumnConfig>
            {
                new ColumnConfig { Name = "Id", Title = "Id", Width = 100, Visible = false },
                new ColumnConfig { Name = "Title", Title = "Название", Width = 357, Visible = true },
                new ColumnConfig { Name = "Description", Title = "Описание", Width = 357, Visible = true }

            };
            dataGridViewProjects.Columns.Clear();
            foreach (var column in columns)
            {
                dataGridViewProjects.Columns.Add(new DataGridViewTextBoxColumn
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
            dataGridViewProjects.Rows.Clear();

            var user = _context.Users.FirstOrDefault(u => u.IsActive == true);

            var projects = _context.Projects.ToArray();

            if (user.UserRole == 2)
            {
                var pr = _context.UserProjects.Where(p => p.UserId == user.UserId).Distinct();
                var projectUserIds = pr.Select(x => x.ProjectId).Distinct();
                projects = _context.Projects.Where(x => projectUserIds.Contains(x.ProjectId)).ToArray();

                toolStripButtonAdd.Enabled = false;
                toolStripButtonDel.Enabled = false;
            }
            

            if (projects == null)
            {
                //throw new Exception("При загрузке возникла ошибка");
                return;
            }

            (Controls["dataGridViewProjects"] as DataGridView).Rows.Clear();
            foreach (var p in projects)
            {
                (Controls["dataGridViewProjects"] as DataGridView).Rows.Add(new object[]
                {
                    p.ProjectId,
                    p.Title,
                    p.Description
                });
            }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormProject>();
            form.ShowDialog();
            LoadData();
        }

        private void toolStripButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewProjects.SelectedRows.Count == 1)
            {
                Guid id = new Guid(dataGridViewProjects.SelectedRows[0].Cells[0].Value.ToString());
                var form = Container.Resolve<FormProject>(
                    new ParameterOverrides
                    {
                        { "id", id }
                    }
                    .OnType<FormProject>());
                form.ShowDialog();
                LoadData();
            }
        }

        private void toolStripButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewProjects.SelectedRows.Count == 1)
            {
                Guid id = new Guid(dataGridViewProjects.SelectedRows[0].Cells[0].Value.ToString());
                var project = _context.Projects.FirstOrDefault(p => p.ProjectId == id);
                if (project == null)
                {
                    throw new Exception("При загрузке возникла ошибка");
                }
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
            LoadData();
        }
    }
}
