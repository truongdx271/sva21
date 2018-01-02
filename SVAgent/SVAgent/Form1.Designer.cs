namespace SVAgent
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Scan = new MetroFramework.Controls.MetroButton();
            this.Browse = new MetroFramework.Controls.MetroButton();
            this.name = new MetroFramework.Controls.MetroTextBox();
            this.po = new MetroFramework.Controls.MetroTextBox();
            this.resultGrid = new MetroFramework.Controls.MetroGrid();
            this.identify = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayTxt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectOwnerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.code = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projObjectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Scan
            // 
            this.Scan.Location = new System.Drawing.Point(91, 76);
            this.Scan.Name = "Scan";
            this.Scan.Size = new System.Drawing.Size(191, 39);
            this.Scan.TabIndex = 0;
            this.Scan.Text = "Scan";
            this.Scan.UseSelectable = true;
            this.Scan.Click += new System.EventHandler(this.Scan_Click);
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(91, 121);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(191, 39);
            this.Browse.TabIndex = 1;
            this.Browse.Text = "Browse";
            this.Browse.UseSelectable = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // name
            // 
            // 
            // 
            // 
            this.name.CustomButton.Image = null;
            this.name.CustomButton.Location = new System.Drawing.Point(219, 1);
            this.name.CustomButton.Name = "";
            this.name.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.name.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.name.CustomButton.TabIndex = 1;
            this.name.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.name.CustomButton.UseSelectable = true;
            this.name.CustomButton.Visible = false;
            this.name.Lines = new string[] {
        "ProjectName"};
            this.name.Location = new System.Drawing.Point(410, 107);
            this.name.MaxLength = 32767;
            this.name.Name = "name";
            this.name.PasswordChar = '\0';
            this.name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.name.SelectedText = "";
            this.name.SelectionLength = 0;
            this.name.SelectionStart = 0;
            this.name.ShortcutsEnabled = true;
            this.name.Size = new System.Drawing.Size(241, 23);
            this.name.TabIndex = 3;
            this.name.Text = "ProjectName";
            this.name.UseSelectable = true;
            this.name.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.name.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // po
            // 
            // 
            // 
            // 
            this.po.CustomButton.Image = null;
            this.po.CustomButton.Location = new System.Drawing.Point(219, 1);
            this.po.CustomButton.Name = "";
            this.po.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.po.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.po.CustomButton.TabIndex = 1;
            this.po.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.po.CustomButton.UseSelectable = true;
            this.po.CustomButton.Visible = false;
            this.po.Lines = new string[] {
        "PO"};
            this.po.Location = new System.Drawing.Point(410, 136);
            this.po.MaxLength = 32767;
            this.po.Name = "po";
            this.po.PasswordChar = '\0';
            this.po.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.po.SelectedText = "";
            this.po.SelectionLength = 0;
            this.po.SelectionStart = 0;
            this.po.ShortcutsEnabled = true;
            this.po.Size = new System.Drawing.Size(241, 23);
            this.po.TabIndex = 4;
            this.po.Text = "PO";
            this.po.UseSelectable = true;
            this.po.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.po.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // resultGrid
            // 
            this.resultGrid.AllowUserToAddRows = false;
            this.resultGrid.AllowUserToDeleteRows = false;
            this.resultGrid.AllowUserToResizeColumns = false;
            this.resultGrid.AllowUserToResizeRows = false;
            this.resultGrid.AutoGenerateColumns = false;
            this.resultGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.resultGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.resultGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resultGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.identify,
            this.displayTxt,
            this.pathFile,
            this.lineNumber,
            this.result,
            this.projectNameDataGridViewTextBoxColumn,
            this.projectCodeDataGridViewTextBoxColumn,
            this.projectOwnerDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn});
            this.resultGrid.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.resultGrid.DataSource = this.projObjectBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.resultGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.resultGrid.EnableHeadersVisualStyles = false;
            this.resultGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.resultGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.resultGrid.Location = new System.Drawing.Point(91, 206);
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.ReadOnly = true;
            this.resultGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resultGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.resultGrid.RowHeadersVisible = false;
            this.resultGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.resultGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultGrid.Size = new System.Drawing.Size(560, 194);
            this.resultGrid.Style = MetroFramework.MetroColorStyle.Silver;
            this.resultGrid.TabIndex = 5;
            this.resultGrid.Theme = MetroFramework.MetroThemeStyle.Light;
            this.resultGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultGrid_CellContentClick);
            // 
            // identify
            // 
            this.identify.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.identify.DataPropertyName = "identify";
            this.identify.FillWeight = 56.77291F;
            this.identify.HeaderText = "Code";
            this.identify.Name = "identify";
            this.identify.ReadOnly = true;
            this.identify.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.identify.Width = 57;
            // 
            // displayTxt
            // 
            this.displayTxt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.displayTxt.DataPropertyName = "displayTxt";
            this.displayTxt.FillWeight = 105.8866F;
            this.displayTxt.HeaderText = "Function";
            this.displayTxt.Name = "displayTxt";
            this.displayTxt.ReadOnly = true;
            this.displayTxt.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.displayTxt.Width = 76;
            // 
            // pathFile
            // 
            this.pathFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pathFile.DataPropertyName = "pathFile";
            this.pathFile.FillWeight = 89.70984F;
            this.pathFile.HeaderText = "Path";
            this.pathFile.Name = "pathFile";
            this.pathFile.ReadOnly = true;
            this.pathFile.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // lineNumber
            // 
            this.lineNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.lineNumber.DataPropertyName = "lineNumber";
            this.lineNumber.FillWeight = 103.2371F;
            this.lineNumber.HeaderText = "Line";
            this.lineNumber.Name = "lineNumber";
            this.lineNumber.ReadOnly = true;
            this.lineNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.lineNumber.Width = 51;
            // 
            // result
            // 
            this.result.DataPropertyName = "result";
            this.result.FillWeight = 144.3935F;
            this.result.HeaderText = "Status";
            this.result.Name = "result";
            this.result.ReadOnly = true;
            this.result.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.result.Width = 50;
            // 
            // projectNameDataGridViewTextBoxColumn
            // 
            this.projectNameDataGridViewTextBoxColumn.DataPropertyName = "projectName";
            this.projectNameDataGridViewTextBoxColumn.HeaderText = "projectName";
            this.projectNameDataGridViewTextBoxColumn.Name = "projectNameDataGridViewTextBoxColumn";
            this.projectNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.projectNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // projectCodeDataGridViewTextBoxColumn
            // 
            this.projectCodeDataGridViewTextBoxColumn.DataPropertyName = "projectCode";
            this.projectCodeDataGridViewTextBoxColumn.HeaderText = "projectCode";
            this.projectCodeDataGridViewTextBoxColumn.Name = "projectCodeDataGridViewTextBoxColumn";
            this.projectCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.projectCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // projectOwnerDataGridViewTextBoxColumn
            // 
            this.projectOwnerDataGridViewTextBoxColumn.DataPropertyName = "projectOwner";
            this.projectOwnerDataGridViewTextBoxColumn.HeaderText = "projectOwner";
            this.projectOwnerDataGridViewTextBoxColumn.Name = "projectOwnerDataGridViewTextBoxColumn";
            this.projectOwnerDataGridViewTextBoxColumn.ReadOnly = true;
            this.projectOwnerDataGridViewTextBoxColumn.Visible = false;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // projObjectBindingSource
            // 
            this.projObjectBindingSource.DataSource = typeof(SVAgent.Model.projObject);
            // 
            // code
            // 
            // 
            // 
            // 
            this.code.CustomButton.Image = null;
            this.code.CustomButton.Location = new System.Drawing.Point(219, 1);
            this.code.CustomButton.Name = "";
            this.code.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.code.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.code.CustomButton.TabIndex = 1;
            this.code.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.code.CustomButton.UseSelectable = true;
            this.code.CustomButton.Visible = false;
            this.code.Lines = new string[] {
        "ProjectCode"};
            this.code.Location = new System.Drawing.Point(410, 78);
            this.code.MaxLength = 32767;
            this.code.Name = "code";
            this.code.PasswordChar = '\0';
            this.code.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.code.SelectedText = "";
            this.code.SelectionLength = 0;
            this.code.SelectionStart = 0;
            this.code.ShortcutsEnabled = true;
            this.code.Size = new System.Drawing.Size(241, 23);
            this.code.TabIndex = 6;
            this.code.Text = "ProjectCode";
            this.code.UseSelectable = true;
            this.code.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.code.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.code.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 438);
            this.Controls.Add(this.code);
            this.Controls.Add(this.resultGrid);
            this.Controls.Add(this.po);
            this.Controls.Add(this.name);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.Scan);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "SVAgent Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projObjectBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton Browse;
        private MetroFramework.Controls.MetroButton Scan;
        private MetroFramework.Controls.MetroTextBox name;
        private MetroFramework.Controls.MetroTextBox po;
        private MetroFramework.Controls.MetroGrid resultGrid;
        private System.Windows.Forms.BindingSource projObjectBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn identify;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayTxt;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectOwnerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private MetroFramework.Controls.MetroTextBox code;
    }
}

