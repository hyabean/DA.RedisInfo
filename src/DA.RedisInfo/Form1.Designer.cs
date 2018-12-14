namespace DA.RedisInfo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnStartCollect = new System.Windows.Forms.Button();
            this.btnStopCollect = new System.Windows.Forms.Button();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputBps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OnputBps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstantaneousInputKbps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstantaneousOnputKbps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.btnSelectFileAnalysis = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartCollect
            // 
            this.btnStartCollect.Location = new System.Drawing.Point(382, 12);
            this.btnStartCollect.Name = "btnStartCollect";
            this.btnStartCollect.Size = new System.Drawing.Size(75, 23);
            this.btnStartCollect.TabIndex = 0;
            this.btnStartCollect.Text = "开始收集";
            this.btnStartCollect.UseVisualStyleBackColor = true;
            this.btnStartCollect.Click += new System.EventHandler(this.btnStartCollect_Click);
            // 
            // btnStopCollect
            // 
            this.btnStopCollect.Location = new System.Drawing.Point(463, 12);
            this.btnStopCollect.Name = "btnStopCollect";
            this.btnStopCollect.Size = new System.Drawing.Size(75, 23);
            this.btnStopCollect.TabIndex = 0;
            this.btnStopCollect.Text = "停止收集";
            this.btnStopCollect.UseVisualStyleBackColor = true;
            this.btnStopCollect.Click += new System.EventHandler(this.btnStopCollect_Click);
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(13, 14);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(100, 21);
            this.tbIP.TabIndex = 1;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(136, 14);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(30, 21);
            this.tbPort.TabIndex = 1;
            this.tbPort.Text = "6380";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = ":";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(219, 14);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(79, 21);
            this.tbPassword.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.Location = new System.Drawing.Point(13, 41);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(75, 23);
            this.btnAnalysis.TabIndex = 0;
            this.btnAnalysis.Text = "开始分析";
            this.btnAnalysis.UseVisualStyleBackColor = true;
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(611, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.timeColumn,
            this.QPS,
            this.InputBps,
            this.OnputBps,
            this.InstantaneousInputKbps,
            this.InstantaneousOnputKbps});
            this.dataGridView1.Location = new System.Drawing.Point(13, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(775, 367);
            this.dataGridView1.TabIndex = 3;
            // 
            // timeColumn
            // 
            this.timeColumn.DataPropertyName = "EndTime";
            dataGridViewCellStyle1.Format = "F";
            dataGridViewCellStyle1.NullValue = null;
            this.timeColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.timeColumn.HeaderText = "Time";
            this.timeColumn.Name = "timeColumn";
            // 
            // QPS
            // 
            this.QPS.DataPropertyName = "QPS";
            this.QPS.HeaderText = "QPS";
            this.QPS.Name = "QPS";
            // 
            // InputBps
            // 
            this.InputBps.DataPropertyName = "InputBps";
            this.InputBps.HeaderText = "InputBps";
            this.InputBps.Name = "InputBps";
            // 
            // OnputBps
            // 
            this.OnputBps.DataPropertyName = "OnputBps";
            this.OnputBps.HeaderText = "OnputBps";
            this.OnputBps.Name = "OnputBps";
            // 
            // InstantaneousInputKbps
            // 
            this.InstantaneousInputKbps.DataPropertyName = "InstantaneousInputKbps";
            this.InstantaneousInputKbps.HeaderText = "InstantaneousInputKbps";
            this.InstantaneousInputKbps.Name = "InstantaneousInputKbps";
            // 
            // InstantaneousOnputKbps
            // 
            this.InstantaneousOnputKbps.DataPropertyName = "InstantaneousOnputKbps";
            this.InstantaneousOnputKbps.HeaderText = "InstantaneousOnputKbps";
            this.InstantaneousOnputKbps.Name = "InstantaneousOnputKbps";
            // 
            // tbCount
            // 
            this.tbCount.Location = new System.Drawing.Point(304, 14);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(72, 21);
            this.tbCount.TabIndex = 1;
            // 
            // btnSelectFileAnalysis
            // 
            this.btnSelectFileAnalysis.Location = new System.Drawing.Point(94, 41);
            this.btnSelectFileAnalysis.Name = "btnSelectFileAnalysis";
            this.btnSelectFileAnalysis.Size = new System.Drawing.Size(91, 23);
            this.btnSelectFileAnalysis.TabIndex = 0;
            this.btnSelectFileAnalysis.Text = "选择文件分析";
            this.btnSelectFileAnalysis.UseVisualStyleBackColor = true;
            this.btnSelectFileAnalysis.Click += new System.EventHandler(this.btnSelectFileAnalysis_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbCount);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnStopCollect);
            this.Controls.Add(this.btnSelectFileAnalysis);
            this.Controls.Add(this.btnAnalysis);
            this.Controls.Add(this.btnStartCollect);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartCollect;
        private System.Windows.Forms.Button btnStopCollect;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAnalysis;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputBps;
        private System.Windows.Forms.DataGridViewTextBoxColumn OnputBps;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstantaneousInputKbps;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstantaneousOnputKbps;
        private System.Windows.Forms.Button btnSelectFileAnalysis;
    }
}

