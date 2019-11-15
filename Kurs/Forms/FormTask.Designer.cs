namespace Kurs.Forms
{
    partial class FormTask
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
            this.tabPageSubtasks = new System.Windows.Forms.TabPage();
            this.buttonDelSubtask = new System.Windows.Forms.Button();
            this.dataGridViewSubtasks = new System.Windows.Forms.DataGridView();
            this.buttonUpdSubtask = new System.Windows.Forms.Button();
            this.buttonAddSubtask = new System.Windows.Forms.Button();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxFile = new System.Windows.Forms.GroupBox();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.buttonShowFile = new System.Windows.Forms.Button();
            this.labelFile = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxImp = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSubtasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubtasks)).BeginInit();
            this.tabPageInfo.SuspendLayout();
            this.groupBoxFile.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageSubtasks
            // 
            this.tabPageSubtasks.Controls.Add(this.buttonDelSubtask);
            this.tabPageSubtasks.Controls.Add(this.dataGridViewSubtasks);
            this.tabPageSubtasks.Controls.Add(this.buttonUpdSubtask);
            this.tabPageSubtasks.Controls.Add(this.buttonAddSubtask);
            this.tabPageSubtasks.Location = new System.Drawing.Point(4, 25);
            this.tabPageSubtasks.Name = "tabPageSubtasks";
            this.tabPageSubtasks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSubtasks.Size = new System.Drawing.Size(785, 612);
            this.tabPageSubtasks.TabIndex = 1;
            this.tabPageSubtasks.Text = "Подзадачи";
            this.tabPageSubtasks.UseVisualStyleBackColor = true;
            // 
            // buttonDelSubtask
            // 
            this.buttonDelSubtask.Location = new System.Drawing.Point(196, 6);
            this.buttonDelSubtask.Name = "buttonDelSubtask";
            this.buttonDelSubtask.Size = new System.Drawing.Size(76, 23);
            this.buttonDelSubtask.TabIndex = 3;
            this.buttonDelSubtask.Text = "Удалить";
            this.buttonDelSubtask.UseVisualStyleBackColor = true;
            this.buttonDelSubtask.Click += new System.EventHandler(this.buttonDelSubtask_Click);
            // 
            // dataGridViewSubtasks
            // 
            this.dataGridViewSubtasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSubtasks.Location = new System.Drawing.Point(6, 35);
            this.dataGridViewSubtasks.Name = "dataGridViewSubtasks";
            this.dataGridViewSubtasks.RowTemplate.Height = 24;
            this.dataGridViewSubtasks.Size = new System.Drawing.Size(764, 401);
            this.dataGridViewSubtasks.TabIndex = 0;
            // 
            // buttonUpdSubtask
            // 
            this.buttonUpdSubtask.Location = new System.Drawing.Point(101, 6);
            this.buttonUpdSubtask.Name = "buttonUpdSubtask";
            this.buttonUpdSubtask.Size = new System.Drawing.Size(89, 23);
            this.buttonUpdSubtask.TabIndex = 2;
            this.buttonUpdSubtask.Text = "Изменить";
            this.buttonUpdSubtask.UseVisualStyleBackColor = true;
            this.buttonUpdSubtask.Click += new System.EventHandler(this.buttonUpdSubtask_Click);
            // 
            // buttonAddSubtask
            // 
            this.buttonAddSubtask.Location = new System.Drawing.Point(6, 6);
            this.buttonAddSubtask.Name = "buttonAddSubtask";
            this.buttonAddSubtask.Size = new System.Drawing.Size(89, 23);
            this.buttonAddSubtask.TabIndex = 1;
            this.buttonAddSubtask.Text = "Добавить";
            this.buttonAddSubtask.UseVisualStyleBackColor = true;
            this.buttonAddSubtask.Click += new System.EventHandler(this.buttonAddSubtask_Click);
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.comboBoxStatus);
            this.tabPageInfo.Controls.Add(this.label4);
            this.tabPageInfo.Controls.Add(this.groupBoxFile);
            this.tabPageInfo.Controls.Add(this.label3);
            this.tabPageInfo.Controls.Add(this.comboBoxImp);
            this.tabPageInfo.Controls.Add(this.buttonCancel);
            this.tabPageInfo.Controls.Add(this.buttonSave);
            this.tabPageInfo.Controls.Add(this.textBoxDescription);
            this.tabPageInfo.Controls.Add(this.textBoxTitle);
            this.tabPageInfo.Controls.Add(this.label1);
            this.tabPageInfo.Controls.Add(this.label2);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 25);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(785, 612);
            this.tabPageInfo.TabIndex = 0;
            this.tabPageInfo.Text = "О задаче";
            this.tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(550, 139);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(213, 24);
            this.comboBoxStatus.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(487, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Статус:";
            // 
            // groupBoxFile
            // 
            this.groupBoxFile.Controls.Add(this.buttonAddFile);
            this.groupBoxFile.Controls.Add(this.buttonShowFile);
            this.groupBoxFile.Controls.Add(this.labelFile);
            this.groupBoxFile.Location = new System.Drawing.Point(17, 173);
            this.groupBoxFile.Name = "groupBoxFile";
            this.groupBoxFile.Size = new System.Drawing.Size(746, 105);
            this.groupBoxFile.TabIndex = 16;
            this.groupBoxFile.TabStop = false;
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Location = new System.Drawing.Point(18, 21);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(153, 23);
            this.buttonAddFile.TabIndex = 13;
            this.buttonAddFile.Text = "Добавить документ:";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // buttonShowFile
            // 
            this.buttonShowFile.Location = new System.Drawing.Point(18, 61);
            this.buttonShowFile.Name = "buttonShowFile";
            this.buttonShowFile.Size = new System.Drawing.Size(153, 23);
            this.buttonShowFile.TabIndex = 15;
            this.buttonShowFile.Text = "Открыть документ";
            this.buttonShowFile.UseVisualStyleBackColor = true;
            this.buttonShowFile.Click += new System.EventHandler(this.buttonShowFile_Click);
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(195, 27);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(0, 17);
            this.labelFile.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Исполнитель:";
            // 
            // comboBoxImp
            // 
            this.comboBoxImp.FormattingEnabled = true;
            this.comboBoxImp.Location = new System.Drawing.Point(132, 136);
            this.comboBoxImp.Name = "comboBoxImp";
            this.comboBoxImp.Size = new System.Drawing.Size(213, 24);
            this.comboBoxImp.TabIndex = 11;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(688, 313);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(580, 313);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(88, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(96, 43);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(667, 72);
            this.textBoxDescription.TabIndex = 5;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(96, 11);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(667, 22);
            this.textBoxTitle.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Описание:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageInfo);
            this.tabControl1.Controls.Add(this.tabPageSubtasks);
            this.tabControl1.Location = new System.Drawing.Point(7, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(793, 641);
            this.tabControl1.TabIndex = 6;
            // 
            // FormTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 669);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormTask";
            this.Text = "Задача";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTask_FormClosed);
            this.Load += new System.EventHandler(this.FormTask_Load);
            this.tabPageSubtasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubtasks)).EndInit();
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageInfo.PerformLayout();
            this.groupBoxFile.ResumeLayout(false);
            this.groupBoxFile.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageSubtasks;
        private System.Windows.Forms.Button buttonDelSubtask;
        private System.Windows.Forms.DataGridView dataGridViewSubtasks;
        private System.Windows.Forms.Button buttonUpdSubtask;
        private System.Windows.Forms.Button buttonAddSubtask;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.Button buttonShowFile;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxImp;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBoxFile;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label label4;
    }
}