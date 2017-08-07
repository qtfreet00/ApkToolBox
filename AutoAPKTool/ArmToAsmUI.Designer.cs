namespace AutoAPKTool
{
    partial class ArmForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArmForm));
            this.instruction = new System.Windows.Forms.TextBox();
            this.convert = new System.Windows.Forms.Button();
            this.tip = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.GroupBox();
            this.result_tip = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.Button();
            this.arm_text = new System.Windows.Forms.TextBox();
            this.thumb_text = new System.Windows.Forms.TextBox();
            this.arm_tip = new System.Windows.Forms.Label();
            this.thumb_tip = new System.Windows.Forms.Label();
            this.error_tip = new System.Windows.Forms.Label();
            this.result.SuspendLayout();
            this.SuspendLayout();
            // 
            // instruction
            // 
            this.instruction.Location = new System.Drawing.Point(88, 30);
            this.instruction.Name = "instruction";
            this.instruction.Size = new System.Drawing.Size(230, 21);
            this.instruction.TabIndex = 0;
            // 
            // convert
            // 
            this.convert.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.convert.Location = new System.Drawing.Point(342, 24);
            this.convert.Name = "convert";
            this.convert.Size = new System.Drawing.Size(103, 32);
            this.convert.TabIndex = 1;
            this.convert.Text = "转换";
            this.convert.UseVisualStyleBackColor = true;
            this.convert.Click += new System.EventHandler(this.convert_Click);
            // 
            // tip
            // 
            this.tip.AutoSize = true;
            this.tip.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tip.Location = new System.Drawing.Point(17, 30);
            this.tip.Name = "tip";
            this.tip.Size = new System.Drawing.Size(63, 20);
            this.tip.TabIndex = 2;
            this.tip.Text = "arm指令";
            // 
            // result
            // 
            this.result.Controls.Add(this.result_tip);
            this.result.Controls.Add(this.clear);
            this.result.Controls.Add(this.arm_text);
            this.result.Controls.Add(this.thumb_text);
            this.result.Controls.Add(this.arm_tip);
            this.result.Controls.Add(this.thumb_tip);
            this.result.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.result.Location = new System.Drawing.Point(24, 79);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(409, 166);
            this.result.TabIndex = 3;
            this.result.TabStop = false;
            this.result.Text = "转换结果";
            // 
            // result_tip
            // 
            this.result_tip.AutoSize = true;
            this.result_tip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.result_tip.Location = new System.Drawing.Point(317, 139);
            this.result_tip.Name = "result_tip";
            this.result_tip.Size = new System.Drawing.Size(0, 20);
            this.result_tip.TabIndex = 5;
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(158, 128);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(87, 33);
            this.clear.TabIndex = 4;
            this.clear.Text = "清除结果";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // arm_text
            // 
            this.arm_text.Location = new System.Drawing.Point(115, 84);
            this.arm_text.Name = "arm_text";
            this.arm_text.ReadOnly = true;
            this.arm_text.Size = new System.Drawing.Size(177, 26);
            this.arm_text.TabIndex = 3;
            // 
            // thumb_text
            // 
            this.thumb_text.Location = new System.Drawing.Point(115, 43);
            this.thumb_text.Name = "thumb_text";
            this.thumb_text.ReadOnly = true;
            this.thumb_text.Size = new System.Drawing.Size(177, 26);
            this.thumb_text.TabIndex = 2;
            // 
            // arm_tip
            // 
            this.arm_tip.AutoSize = true;
            this.arm_tip.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.arm_tip.Location = new System.Drawing.Point(46, 86);
            this.arm_tip.Name = "arm_tip";
            this.arm_tip.Size = new System.Drawing.Size(38, 20);
            this.arm_tip.TabIndex = 1;
            this.arm_tip.Text = "arm:";
            // 
            // thumb_tip
            // 
            this.thumb_tip.AutoSize = true;
            this.thumb_tip.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thumb_tip.Location = new System.Drawing.Point(44, 45);
            this.thumb_tip.Name = "thumb_tip";
            this.thumb_tip.Size = new System.Drawing.Size(57, 20);
            this.thumb_tip.TabIndex = 0;
            this.thumb_tip.Text = "thumb:";
            // 
            // error_tip
            // 
            this.error_tip.AutoSize = true;
            this.error_tip.ForeColor = System.Drawing.Color.Red;
            this.error_tip.Location = new System.Drawing.Point(173, 64);
            this.error_tip.Name = "error_tip";
            this.error_tip.Size = new System.Drawing.Size(0, 12);
            this.error_tip.TabIndex = 4;
            // 
            // ArmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 257);
            this.Controls.Add(this.error_tip);
            this.Controls.Add(this.result);
            this.Controls.Add(this.tip);
            this.Controls.Add(this.convert);
            this.Controls.Add(this.instruction);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ArmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArmToAsm转换器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.result.ResumeLayout(false);
            this.result.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox instruction;
        private System.Windows.Forms.Button convert;
        private System.Windows.Forms.Label tip;
        private System.Windows.Forms.GroupBox result;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.TextBox arm_text;
        private System.Windows.Forms.TextBox thumb_text;
        private System.Windows.Forms.Label arm_tip;
        private System.Windows.Forms.Label thumb_tip;
        private System.Windows.Forms.Label error_tip;
        private System.Windows.Forms.Label result_tip;
    }
}

