namespace EmployeesViewer
{
    partial class StatParamsChooseForm
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
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelHire = new System.Windows.Forms.Label();
            this.comboBoxHire = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.beginPeriod = new System.Windows.Forms.DateTimePicker();
            this.endPeriod = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(90, 9);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(140, 21);
            this.comboBoxStatus.TabIndex = 0;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(13, 12);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(41, 13);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "Статус";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(74, 130);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(155, 130);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "ОК";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelHire
            // 
            this.labelHire.AutoSize = true;
            this.labelHire.Location = new System.Drawing.Point(13, 39);
            this.labelHire.Name = "labelHire";
            this.labelHire.Size = new System.Drawing.Size(35, 13);
            this.labelHire.TabIndex = 7;
            this.labelHire.Text = "Найм";
            // 
            // comboBoxHire
            // 
            this.comboBoxHire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxHire.FormattingEnabled = true;
            this.comboBoxHire.Items.AddRange(new object[] {
            "Действующие",
            "Уволенные"});
            this.comboBoxHire.Location = new System.Drawing.Point(90, 36);
            this.comboBoxHire.Name = "comboBoxHire";
            this.comboBoxHire.Size = new System.Drawing.Size(140, 21);
            this.comboBoxHire.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Период с";
            // 
            // beginPeriod
            // 
            this.beginPeriod.Location = new System.Drawing.Point(90, 69);
            this.beginPeriod.Name = "beginPeriod";
            this.beginPeriod.Size = new System.Drawing.Size(140, 20);
            this.beginPeriod.TabIndex = 9;
            // 
            // endPeriod
            // 
            this.endPeriod.Location = new System.Drawing.Point(90, 95);
            this.endPeriod.Name = "endPeriod";
            this.endPeriod.Size = new System.Drawing.Size(140, 20);
            this.endPeriod.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "по";
            // 
            // StatParamsChooseForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(242, 164);
            this.Controls.Add(this.endPeriod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.beginPeriod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelHire);
            this.Controls.Add(this.comboBoxHire);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.comboBoxStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StatParamsChooseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Задайте параметры";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelHire;
        private System.Windows.Forms.ComboBox comboBoxHire;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker beginPeriod;
        private System.Windows.Forms.DateTimePicker endPeriod;
        private System.Windows.Forms.Label label2;
    }
}