namespace AutoAPKTool
{
	partial class Form1
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.btn_Decompiler = new System.Windows.Forms.Button();
            this.btn_SignAPK = new System.Windows.Forms.Button();
            this.btn_BuildAndSign = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_dex2jar = new System.Windows.Forms.Button();
            this.btn_JdGUI = new System.Windows.Forms.Button();
            this.btn_openFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_jadx = new System.Windows.Forms.Button();
            this.btn_decompileDex = new System.Windows.Forms.Button();
            this.btn_compileDex = new System.Windows.Forms.Button();
            this.btn_env = new System.Windows.Forms.Button();
            this.my_sign = new System.Windows.Forms.Button();
            this.zipalgin = new System.Windows.Forms.Button();
            this.odex_decompile = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.签名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动App命令ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.博客ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.吾爱破解ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_path
            // 
            this.textBox_path.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_path.Location = new System.Drawing.Point(65, 36);
            this.textBox_path.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.ReadOnly = true;
            this.textBox_path.Size = new System.Drawing.Size(347, 26);
            this.textBox_path.TabIndex = 0;
            // 
            // btn_Decompiler
            // 
            this.btn_Decompiler.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Decompiler.Location = new System.Drawing.Point(18, 86);
            this.btn_Decompiler.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Decompiler.Name = "btn_Decompiler";
            this.btn_Decompiler.Size = new System.Drawing.Size(95, 33);
            this.btn_Decompiler.TabIndex = 1;
            this.btn_Decompiler.Text = "反编译apk";
            this.btn_Decompiler.UseVisualStyleBackColor = true;
            this.btn_Decompiler.Click += new System.EventHandler(this.btn_Decompiler_Click);
            // 
            // btn_SignAPK
            // 
            this.btn_SignAPK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SignAPK.Location = new System.Drawing.Point(264, 86);
            this.btn_SignAPK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_SignAPK.Name = "btn_SignAPK";
            this.btn_SignAPK.Size = new System.Drawing.Size(95, 33);
            this.btn_SignAPK.TabIndex = 3;
            this.btn_SignAPK.Text = "签名";
            this.btn_SignAPK.UseVisualStyleBackColor = true;
            this.btn_SignAPK.Click += new System.EventHandler(this.btn_SignAPK_Click);
            // 
            // btn_BuildAndSign
            // 
            this.btn_BuildAndSign.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_BuildAndSign.Location = new System.Drawing.Point(140, 86);
            this.btn_BuildAndSign.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_BuildAndSign.Name = "btn_BuildAndSign";
            this.btn_BuildAndSign.Size = new System.Drawing.Size(95, 33);
            this.btn_BuildAndSign.TabIndex = 4;
            this.btn_BuildAndSign.Text = "回编译apk";
            this.btn_BuildAndSign.UseVisualStyleBackColor = true;
            this.btn_BuildAndSign.Click += new System.EventHandler(this.btn_BuildAndSign_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "路径:\r\n";
            // 
            // btn_dex2jar
            // 
            this.btn_dex2jar.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_dex2jar.Location = new System.Drawing.Point(18, 130);
            this.btn_dex2jar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_dex2jar.Name = "btn_dex2jar";
            this.btn_dex2jar.Size = new System.Drawing.Size(95, 33);
            this.btn_dex2jar.TabIndex = 6;
            this.btn_dex2jar.Text = "dex转jar";
            this.btn_dex2jar.UseVisualStyleBackColor = true;
            this.btn_dex2jar.Click += new System.EventHandler(this.btn_dex2jar_Click);
            // 
            // btn_JdGUI
            // 
            this.btn_JdGUI.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_JdGUI.Location = new System.Drawing.Point(140, 130);
            this.btn_JdGUI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_JdGUI.Name = "btn_JdGUI";
            this.btn_JdGUI.Size = new System.Drawing.Size(95, 33);
            this.btn_JdGUI.TabIndex = 7;
            this.btn_JdGUI.Text = "打开jar";
            this.btn_JdGUI.UseVisualStyleBackColor = true;
            this.btn_JdGUI.Click += new System.EventHandler(this.btn_JdGUI_Click);
            // 
            // btn_openFile
            // 
            this.btn_openFile.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_openFile.Location = new System.Drawing.Point(419, 34);
            this.btn_openFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_openFile.Name = "btn_openFile";
            this.btn_openFile.Size = new System.Drawing.Size(69, 30);
            this.btn_openFile.TabIndex = 9;
            this.btn_openFile.Text = "打开";
            this.btn_openFile.UseVisualStyleBackColor = true;
            this.btn_openFile.Click += new System.EventHandler(this.btn_openFile_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(12, 213);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(476, 223);
            this.textBox1.TabIndex = 11;
            // 
            // btn_jadx
            // 
            this.btn_jadx.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_jadx.Location = new System.Drawing.Point(264, 130);
            this.btn_jadx.Name = "btn_jadx";
            this.btn_jadx.Size = new System.Drawing.Size(95, 33);
            this.btn_jadx.TabIndex = 12;
            this.btn_jadx.Text = "jadx";
            this.btn_jadx.UseVisualStyleBackColor = true;
            this.btn_jadx.Click += new System.EventHandler(this.Btn_jadxClick);
            // 
            // btn_decompileDex
            // 
            this.btn_decompileDex.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_decompileDex.Location = new System.Drawing.Point(18, 174);
            this.btn_decompileDex.Name = "btn_decompileDex";
            this.btn_decompileDex.Size = new System.Drawing.Size(95, 33);
            this.btn_decompileDex.TabIndex = 13;
            this.btn_decompileDex.Text = "反编译dex";
            this.btn_decompileDex.UseVisualStyleBackColor = true;
            this.btn_decompileDex.Click += new System.EventHandler(this.Btn_decompileDexClick);
            // 
            // btn_compileDex
            // 
            this.btn_compileDex.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_compileDex.Location = new System.Drawing.Point(140, 174);
            this.btn_compileDex.Name = "btn_compileDex";
            this.btn_compileDex.Size = new System.Drawing.Size(95, 33);
            this.btn_compileDex.TabIndex = 14;
            this.btn_compileDex.Text = "回编译dex";
            this.btn_compileDex.UseVisualStyleBackColor = true;
            this.btn_compileDex.Click += new System.EventHandler(this.Btn_compileDexClick);
            // 
            // btn_env
            // 
            this.btn_env.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_env.Location = new System.Drawing.Point(264, 174);
            this.btn_env.Name = "btn_env";
            this.btn_env.Size = new System.Drawing.Size(95, 33);
            this.btn_env.TabIndex = 15;
            this.btn_env.Text = "查壳";
            this.btn_env.UseVisualStyleBackColor = true;
            this.btn_env.Click += new System.EventHandler(this.Btn_CheckProtect);
            // 
            // my_sign
            // 
            this.my_sign.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.my_sign.Location = new System.Drawing.Point(386, 86);
            this.my_sign.Name = "my_sign";
            this.my_sign.Size = new System.Drawing.Size(95, 33);
            this.my_sign.TabIndex = 16;
            this.my_sign.Text = "自定义签名";
            this.my_sign.UseVisualStyleBackColor = true;
            this.my_sign.Click += new System.EventHandler(this.My_signClick);
            // 
            // zipalgin
            // 
            this.zipalgin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zipalgin.Location = new System.Drawing.Point(386, 130);
            this.zipalgin.Name = "zipalgin";
            this.zipalgin.Size = new System.Drawing.Size(95, 33);
            this.zipalgin.TabIndex = 17;
            this.zipalgin.Text = "zipalign";
            this.zipalgin.UseVisualStyleBackColor = true;
            this.zipalgin.Click += new System.EventHandler(this.ZipalginClick);
            // 
            // odex_decompile
            // 
            this.odex_decompile.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.odex_decompile.Location = new System.Drawing.Point(386, 174);
            this.odex_decompile.Name = "odex_decompile";
            this.odex_decompile.Size = new System.Drawing.Size(95, 33);
            this.odex_decompile.TabIndex = 18;
            this.odex_decompile.Text = "Odex反编译";
            this.odex_decompile.UseVisualStyleBackColor = true;
            this.odex_decompile.Click += new System.EventHandler(this.odex_dec);
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.配置ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(501, 25);
            this.menu.TabIndex = 19;
            this.menu.Text = "配置";
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.签名ToolStripMenuItem,
            this.启动App命令ToolStripMenuItem});
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.配置ToolStripMenuItem.Text = "配置";
            // 
            // 签名ToolStripMenuItem
            // 
            this.签名ToolStripMenuItem.Name = "签名ToolStripMenuItem";
            this.签名ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.签名ToolStripMenuItem.Text = "签名";
            this.签名ToolStripMenuItem.Click += new System.EventHandler(this.签名ToolStripMenuItemClick);
            // 
            // 启动App命令ToolStripMenuItem
            // 
            this.启动App命令ToolStripMenuItem.Name = "启动App命令ToolStripMenuItem";
            this.启动App命令ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.启动App命令ToolStripMenuItem.Text = "启动App命令";
            this.启动App命令ToolStripMenuItem.Click += new System.EventHandler(this.Btn_getArgsConmindLine);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.博客ToolStripMenuItem,
            this.吾爱破解ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 博客ToolStripMenuItem
            // 
            this.博客ToolStripMenuItem.Name = "博客ToolStripMenuItem";
            this.博客ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.博客ToolStripMenuItem.Text = "博客";
            this.博客ToolStripMenuItem.Click += new System.EventHandler(this.Btn_BlogClick);
            // 
            // 吾爱破解ToolStripMenuItem
            // 
            this.吾爱破解ToolStripMenuItem.Name = "吾爱破解ToolStripMenuItem";
            this.吾爱破解ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.吾爱破解ToolStripMenuItem.Text = "吾爱破解";
            this.吾爱破解ToolStripMenuItem.Click += new System.EventHandler(this.Btn_52pojieClick);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 448);
            this.Controls.Add(this.odex_decompile);
            this.Controls.Add(this.zipalgin);
            this.Controls.Add(this.my_sign);
            this.Controls.Add(this.btn_env);
            this.Controls.Add(this.btn_compileDex);
            this.Controls.Add(this.btn_decompileDex);
            this.Controls.Add(this.btn_jadx);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_openFile);
            this.Controls.Add(this.btn_JdGUI);
            this.Controls.Add(this.btn_dex2jar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_BuildAndSign);
            this.Controls.Add(this.btn_SignAPK);
            this.Controls.Add(this.btn_Decompiler);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apktool Box v1.5.2";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		private System.Windows.Forms.Button my_sign;
		private System.Windows.Forms.Button zipalgin;
		private System.Windows.Forms.Button odex_decompile;
		private System.Windows.Forms.TextBox textBox_path;
		private System.Windows.Forms.Button btn_Decompiler;
		private System.Windows.Forms.Button btn_SignAPK;
		private System.Windows.Forms.Button btn_BuildAndSign;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn_dex2jar;
		private System.Windows.Forms.Button btn_JdGUI;
		private System.Windows.Forms.Button btn_openFile;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btn_jadx;
		private System.Windows.Forms.Button btn_decompileDex;
		private System.Windows.Forms.Button btn_compileDex;
		private System.Windows.Forms.Button btn_env;
		private System.Windows.Forms.MenuStrip menu;
		private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 签名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 博客ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 吾爱破解ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启动App命令ToolStripMenuItem;
    }
}

