namespace OutputExcel
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStart_DY = new System.Windows.Forms.Button();
            this.numericUpDown_DY = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar1_DY = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar1_JQ = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_JQ = new System.Windows.Forms.NumericUpDown();
            this.btnStart_JQ = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.progressBar1_WH = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_WH = new System.Windows.Forms.NumericUpDown();
            this.btnStart_WH = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.progressBar1_NS = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_NS = new System.Windows.Forms.NumericUpDown();
            this.btnStart_NS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DY)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_JQ)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WH)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_NS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart_DY
            // 
            this.btnStart_DY.Location = new System.Drawing.Point(166, 29);
            this.btnStart_DY.Name = "btnStart_DY";
            this.btnStart_DY.Size = new System.Drawing.Size(73, 23);
            this.btnStart_DY.TabIndex = 0;
            this.btnStart_DY.Text = "开始导出";
            this.btnStart_DY.UseVisualStyleBackColor = true;
            this.btnStart_DY.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // numericUpDown_DY
            // 
            this.numericUpDown_DY.Location = new System.Drawing.Point(113, 29);
            this.numericUpDown_DY.Name = "numericUpDown_DY";
            this.numericUpDown_DY.Size = new System.Drawing.Size(34, 21);
            this.numericUpDown_DY.TabIndex = 1;
            this.numericUpDown_DY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBar1_DY);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDown_DY);
            this.groupBox1.Controls.Add(this.btnStart_DY);
            this.groupBox1.Location = new System.Drawing.Point(40, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 94);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DY 东岳";
            // 
            // progressBar1_DY
            // 
            this.progressBar1_DY.Location = new System.Drawing.Point(20, 58);
            this.progressBar1_DY.Name = "progressBar1_DY";
            this.progressBar1_DY.Size = new System.Drawing.Size(219, 23);
            this.progressBar1_DY.TabIndex = 4;
            this.progressBar1_DY.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "要导出的页数：";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBar1_JQ);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numericUpDown_JQ);
            this.groupBox2.Controls.Add(this.btnStart_JQ);
            this.groupBox2.Location = new System.Drawing.Point(40, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 94);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "JQ 金桥";
            // 
            // progressBar1_JQ
            // 
            this.progressBar1_JQ.Location = new System.Drawing.Point(20, 58);
            this.progressBar1_JQ.Name = "progressBar1_JQ";
            this.progressBar1_JQ.Size = new System.Drawing.Size(219, 23);
            this.progressBar1_JQ.TabIndex = 4;
            this.progressBar1_JQ.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "要导出的页数：";
            // 
            // numericUpDown_JQ
            // 
            this.numericUpDown_JQ.Location = new System.Drawing.Point(113, 29);
            this.numericUpDown_JQ.Name = "numericUpDown_JQ";
            this.numericUpDown_JQ.Size = new System.Drawing.Size(34, 21);
            this.numericUpDown_JQ.TabIndex = 1;
            this.numericUpDown_JQ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnStart_JQ
            // 
            this.btnStart_JQ.Location = new System.Drawing.Point(166, 29);
            this.btnStart_JQ.Name = "btnStart_JQ";
            this.btnStart_JQ.Size = new System.Drawing.Size(73, 23);
            this.btnStart_JQ.TabIndex = 0;
            this.btnStart_JQ.Text = "开始导出";
            this.btnStart_JQ.UseVisualStyleBackColor = true;
            this.btnStart_JQ.Click += new System.EventHandler(this.btnStart_JQ_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.progressBar1_WH);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.numericUpDown_WH);
            this.groupBox3.Controls.Add(this.btnStart_WH);
            this.groupBox3.Location = new System.Drawing.Point(330, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 94);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "WH 武汉";
            // 
            // progressBar1_WH
            // 
            this.progressBar1_WH.Location = new System.Drawing.Point(20, 58);
            this.progressBar1_WH.Name = "progressBar1_WH";
            this.progressBar1_WH.Size = new System.Drawing.Size(219, 23);
            this.progressBar1_WH.TabIndex = 4;
            this.progressBar1_WH.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "要导出的页数：";
            // 
            // numericUpDown_WH
            // 
            this.numericUpDown_WH.Location = new System.Drawing.Point(113, 29);
            this.numericUpDown_WH.Name = "numericUpDown_WH";
            this.numericUpDown_WH.Size = new System.Drawing.Size(34, 21);
            this.numericUpDown_WH.TabIndex = 1;
            this.numericUpDown_WH.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnStart_WH
            // 
            this.btnStart_WH.Location = new System.Drawing.Point(166, 29);
            this.btnStart_WH.Name = "btnStart_WH";
            this.btnStart_WH.Size = new System.Drawing.Size(73, 23);
            this.btnStart_WH.TabIndex = 0;
            this.btnStart_WH.Text = "开始导出";
            this.btnStart_WH.UseVisualStyleBackColor = true;
            this.btnStart_WH.Click += new System.EventHandler(this.btnStart_WH_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.progressBar1_NS);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.numericUpDown_NS);
            this.groupBox4.Controls.Add(this.btnStart_NS);
            this.groupBox4.Location = new System.Drawing.Point(330, 143);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(260, 94);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "NS 北盛";
            // 
            // progressBar1_NS
            // 
            this.progressBar1_NS.Location = new System.Drawing.Point(20, 58);
            this.progressBar1_NS.Name = "progressBar1_NS";
            this.progressBar1_NS.Size = new System.Drawing.Size(219, 23);
            this.progressBar1_NS.TabIndex = 4;
            this.progressBar1_NS.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "要导出的页数：";
            // 
            // numericUpDown_NS
            // 
            this.numericUpDown_NS.Location = new System.Drawing.Point(113, 29);
            this.numericUpDown_NS.Name = "numericUpDown_NS";
            this.numericUpDown_NS.Size = new System.Drawing.Size(34, 21);
            this.numericUpDown_NS.TabIndex = 1;
            this.numericUpDown_NS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnStart_NS
            // 
            this.btnStart_NS.Location = new System.Drawing.Point(166, 29);
            this.btnStart_NS.Name = "btnStart_NS";
            this.btnStart_NS.Size = new System.Drawing.Size(73, 23);
            this.btnStart_NS.TabIndex = 0;
            this.btnStart_NS.Text = "开始导出";
            this.btnStart_NS.UseVisualStyleBackColor = true;
            this.btnStart_NS.Click += new System.EventHandler(this.btnStart_NS_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 268);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "通用数据导出";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DY)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_JQ)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WH)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_NS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart_DY;
        private System.Windows.Forms.NumericUpDown numericUpDown_DY;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1_DY;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar progressBar1_JQ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_JQ;
        private System.Windows.Forms.Button btnStart_JQ;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar progressBar1_WH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_WH;
        private System.Windows.Forms.Button btnStart_WH;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ProgressBar progressBar1_NS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_NS;
        private System.Windows.Forms.Button btnStart_NS;
    }
}

