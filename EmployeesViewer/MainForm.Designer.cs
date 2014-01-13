namespace EmployeesViewer
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.buttonDBConnection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonShowEmployees = new System.Windows.Forms.ToolStripButton();
            this.buttonShowStats = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonDataFilter = new System.Windows.Forms.ToolStripButton();
            this.listView = new System.Windows.Forms.ListView();
            this.mainImageList16 = new System.Windows.Forms.ImageList(this.components);
            this.mainImageList32 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonDBConnection,
            this.toolStripSeparator1,
            this.buttonShowEmployees,
            this.buttonShowStats,
            this.toolStripSeparator2,
            this.buttonDataFilter});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(756, 39);
            this.toolStrip.TabIndex = 0;
            // 
            // buttonDBConnection
            // 
            this.buttonDBConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDBConnection.Image = ((System.Drawing.Image)(resources.GetObject("buttonDBConnection.Image")));
            this.buttonDBConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDBConnection.Name = "buttonDBConnection";
            this.buttonDBConnection.Size = new System.Drawing.Size(36, 36);
            this.buttonDBConnection.Text = "Изменить соединение с БД";
            this.buttonDBConnection.Click += new System.EventHandler(this.buttonDBConnection_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // buttonShowEmployees
            // 
            this.buttonShowEmployees.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonShowEmployees.Image = ((System.Drawing.Image)(resources.GetObject("buttonShowEmployees.Image")));
            this.buttonShowEmployees.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonShowEmployees.Name = "buttonShowEmployees";
            this.buttonShowEmployees.Size = new System.Drawing.Size(36, 36);
            this.buttonShowEmployees.Text = "Список сотрудников";
            this.buttonShowEmployees.Click += new System.EventHandler(this.buttonShowEmployees_Click);
            // 
            // buttonShowStats
            // 
            this.buttonShowStats.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonShowStats.Image = ((System.Drawing.Image)(resources.GetObject("buttonShowStats.Image")));
            this.buttonShowStats.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonShowStats.Name = "buttonShowStats";
            this.buttonShowStats.Size = new System.Drawing.Size(36, 36);
            this.buttonShowStats.Text = "Статистика";
            this.buttonShowStats.Click += new System.EventHandler(this.buttonShowStats_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // buttonDataFilter
            // 
            this.buttonDataFilter.CheckOnClick = true;
            this.buttonDataFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDataFilter.Enabled = false;
            this.buttonDataFilter.Image = ((System.Drawing.Image)(resources.GetObject("buttonDataFilter.Image")));
            this.buttonDataFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDataFilter.Name = "buttonDataFilter";
            this.buttonDataFilter.Size = new System.Drawing.Size(36, 36);
            this.buttonDataFilter.Text = "Фильтр данных";
            this.buttonDataFilter.Click += new System.EventHandler(this.buttonDataFilter_Click);
            // 
            // listView
            // 
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(0, 39);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(756, 429);
            this.listView.SmallImageList = this.mainImageList16;
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // mainImageList16
            // 
            this.mainImageList16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mainImageList16.ImageStream")));
            this.mainImageList16.TransparentColor = System.Drawing.Color.Transparent;
            this.mainImageList16.Images.SetKeyName(0, "user_id");
            // 
            // mainImageList32
            // 
            this.mainImageList32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mainImageList32.ImageStream")));
            this.mainImageList32.TransparentColor = System.Drawing.Color.Transparent;
            this.mainImageList32.Images.SetKeyName(0, "calendar_selection");
            this.mainImageList32.Images.SetKeyName(1, "database-info");
            this.mainImageList32.Images.SetKeyName(2, "filter");
            this.mainImageList32.Images.SetKeyName(3, "report-user");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 468);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip);
            this.Name = "MainForm";
            this.Text = "Программа просмотра данных о сотрудниках";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ToolStripButton buttonDBConnection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonShowEmployees;
        private System.Windows.Forms.ToolStripButton buttonShowStats;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton buttonDataFilter;
        private System.Windows.Forms.ImageList mainImageList32;
        private System.Windows.Forms.ImageList mainImageList16;
    }
}

