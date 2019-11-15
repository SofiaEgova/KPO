namespace Kurs.Forms
{
    partial class FormProject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.dataGridViewProjectUsers = new System.Windows.Forms.DataGridView();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.tabPageTasks = new System.Windows.Forms.TabPage();
            this.dataGridViewTasks = new System.Windows.Forms.DataGridView();
            this.buttonAddTask = new System.Windows.Forms.Button();
            this.buttonUpdTask = new System.Windows.Forms.Button();
            this.buttonDelTask = new System.Windows.Forms.Button();
            this.comboBoxAddUsers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjectUsers)).BeginInit();
            this.groupBox.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            this.tabPageTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(483, 540);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 23);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(610, 540);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Описание:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(88, 18);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(597, 22);
            this.textBoxTitle.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Название:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(90, 50);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(595, 85);
            this.textBoxDescription.TabIndex = 11;
            // 
            // dataGridViewProjectUsers
            // 
            this.dataGridViewProjectUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProjectUsers.Location = new System.Drawing.Point(6, 61);
            this.dataGridViewProjectUsers.Name = "dataGridViewProjectUsers";
            this.dataGridViewProjectUsers.RowTemplate.Height = 24;
            this.dataGridViewProjectUsers.Size = new System.Drawing.Size(667, 287);
            this.dataGridViewProjectUsers.TabIndex = 12;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.comboBoxAddUsers);
            this.groupBox.Controls.Add(this.buttonDel);
            this.groupBox.Controls.Add(this.buttonAdd);
            this.groupBox.Controls.Add(this.dataGridViewProjectUsers);
            this.groupBox.Location = new System.Drawing.Point(6, 141);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(679, 376);
            this.groupBox.TabIndex = 13;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Доступ имеют:";
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(6, 32);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(100, 23);
            this.buttonDel.TabIndex = 14;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(570, 32);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 23);
            this.buttonAdd.TabIndex = 13;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageInfo);
            this.tabControl.Controls.Add(this.tabPageTasks);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(713, 624);
            this.tabControl.TabIndex = 14;
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.label2);
            this.tabPageInfo.Controls.Add(this.groupBox);
            this.tabPageInfo.Controls.Add(this.buttonCancel);
            this.tabPageInfo.Controls.Add(this.textBoxDescription);
            this.tabPageInfo.Controls.Add(this.buttonSave);
            this.tabPageInfo.Controls.Add(this.label3);
            this.tabPageInfo.Controls.Add(this.textBoxTitle);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 25);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(705, 595);
            this.tabPageInfo.TabIndex = 0;
            this.tabPageInfo.Text = "О проекте";
            this.tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // tabPageTasks
            // 
            this.tabPageTasks.Controls.Add(this.buttonDelTask);
            this.tabPageTasks.Controls.Add(this.buttonUpdTask);
            this.tabPageTasks.Controls.Add(this.buttonAddTask);
            this.tabPageTasks.Controls.Add(this.dataGridViewTasks);
            this.tabPageTasks.Location = new System.Drawing.Point(4, 25);
            this.tabPageTasks.Name = "tabPageTasks";
            this.tabPageTasks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTasks.Size = new System.Drawing.Size(705, 595);
            this.tabPageTasks.TabIndex = 1;
            this.tabPageTasks.Text = "Задачи";
            this.tabPageTasks.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTasks
            // 
            this.dataGridViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTasks.Location = new System.Drawing.Point(6, 48);
            this.dataGridViewTasks.Name = "dataGridViewTasks";
            this.dataGridViewTasks.RowTemplate.Height = 24;
            this.dataGridViewTasks.Size = new System.Drawing.Size(693, 304);
            this.dataGridViewTasks.TabIndex = 0;
            // 
            // buttonAddTask
            // 
            this.buttonAddTask.Location = new System.Drawing.Point(6, 6);
            this.buttonAddTask.Name = "buttonAddTask";
            this.buttonAddTask.Size = new System.Drawing.Size(81, 23);
            this.buttonAddTask.TabIndex = 1;
            this.buttonAddTask.Text = "Добавить";
            this.buttonAddTask.UseVisualStyleBackColor = true;
            this.buttonAddTask.Click += new System.EventHandler(this.buttonAddTask_Click);
            // 
            // buttonUpdTask
            // 
            this.buttonUpdTask.Location = new System.Drawing.Point(93, 6);
            this.buttonUpdTask.Name = "buttonUpdTask";
            this.buttonUpdTask.Size = new System.Drawing.Size(82, 23);
            this.buttonUpdTask.TabIndex = 2;
            this.buttonUpdTask.Text = "Изменить";
            this.buttonUpdTask.UseVisualStyleBackColor = true;
            this.buttonUpdTask.Click += new System.EventHandler(this.buttonUpdTask_Click);
            // 
            // buttonDelTask
            // 
            this.buttonDelTask.Location = new System.Drawing.Point(181, 6);
            this.buttonDelTask.Name = "buttonDelTask";
            this.buttonDelTask.Size = new System.Drawing.Size(75, 23);
            this.buttonDelTask.TabIndex = 3;
            this.buttonDelTask.Text = "Удалить";
            this.buttonDelTask.UseVisualStyleBackColor = true;
            this.buttonDelTask.Click += new System.EventHandler(this.buttonDelTask_Click);
            // 
            // comboBoxAddUsers
            // 
            this.comboBoxAddUsers.FormattingEnabled = true;
            this.comboBoxAddUsers.Location = new System.Drawing.Point(385, 32);
            this.comboBoxAddUsers.Name = "comboBoxAddUsers";
            this.comboBoxAddUsers.Size = new System.Drawing.Size(169, 24);
            this.comboBoxAddUsers.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "выбрать пользователя:";
            // 
            // FormProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 642);
            this.Controls.Add(this.tabControl);
            this.Name = "FormProject";
            this.Text = "Проект";
            this.Load += new System.EventHandler(this.FormProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjectUsers)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageInfo.PerformLayout();
            this.tabPageTasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.DataGridView dataGridViewProjectUsers;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.TabPage tabPageTasks;
        private System.Windows.Forms.DataGridView dataGridViewTasks;
        private System.Windows.Forms.Button buttonDelTask;
        private System.Windows.Forms.Button buttonUpdTask;
        private System.Windows.Forms.Button buttonAddTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxAddUsers;
    }
}