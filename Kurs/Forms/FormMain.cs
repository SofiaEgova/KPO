using Kurs.Forms;
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

namespace Kurs
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly KursDbContext _context;

        public FormMain(KursDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var activeUser = _context.Users.FirstOrDefault(u => u.IsActive == true);

            if (activeUser == null)
            {
                throw new Exception("При загрузке возникла ошибка");
            }

            switch (activeUser.UserRole)
            {
                case 0:
                    this.Text = "Главная. Администратор";
                    generateMenuAdmin();
                    break;
                case 1:
                    this.Text = "Главная. Преподаватель";
                    //generateMenuTeacher();
                    break;
                case 2:
                    this.Text = "Главная. Студент";
                    //generateMenuStudent();
                    break;
            }
        }

        #region Admin

        private void generateMenuAdmin()
        {
            ToolStripMenuItem usersItem = new ToolStripMenuItem("Пользователи");
            menuStrip.Items.Add(usersItem);
            usersItem.Click += usersItemToolStripMenuItem_Click;
        }

        private void usersItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control = Container.Resolve<UsersControl>();
            ApplyControl(control);
        }

        #endregion

        #region Teacher

        private void generateMenuTeacher()
        {
            ToolStripMenuItem userInfoItem = new ToolStripMenuItem("Мои данные");
            menuStrip.Items.Add(userInfoItem);
            userInfoItem.Click += userInfoItemToolStripMenuItem_Click;

            ToolStripMenuItem projectsItem = new ToolStripMenuItem("Проекты");
            menuStrip.Items.Add(projectsItem);
            projectsItem.Click += projectsItemToolStripMenuItem_Click;
        }

        private void userInfoItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control = Container.Resolve<UserInfoControl>();
            ApplyControl(control);
        }

        private void projectsItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control = Container.Resolve<ProjectsControl>();
            ApplyControl(control);
        }

        #endregion

        private void ApplyControl(Control control)
        {
            control.Left = 0;
            control.Top = 25;
            control.Height = Height - 60;
            control.Width = Width - 15;
            control.Anchor = (((AnchorStyles.Top
                        | AnchorStyles.Bottom)
                        | AnchorStyles.Left)
                        | AnchorStyles.Right);
            while (Controls.Count > 1)
            {
                Controls.RemoveAt(Controls.Count - 1);
            }
            Controls.Add(control);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // выход пользователя
        }
    }
}
