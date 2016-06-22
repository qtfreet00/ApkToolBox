/*
 * 由SharpDevelop创建。
 * 用户： qtfreet
 * 日期: 2016/2/20
 * 时间: 13:11
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace AutoAPKTool
{
	partial class Form2
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox text_path;
		private System.Windows.Forms.Button sel_sign;
		private System.Windows.Forms.Label path;
		private System.Windows.Forms.Label alis;
		private System.Windows.Forms.Label password;
		private System.Windows.Forms.TextBox text_alis;
		private System.Windows.Forms.TextBox text_pass;

		private System.Windows.Forms.Button make;
		private System.Windows.Forms.Label alis_pass;
		private System.Windows.Forms.TextBox text_alis_pass;
		private System.Windows.Forms.Button verify_key;
	
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
			this.text_path = new System.Windows.Forms.TextBox();
			this.sel_sign = new System.Windows.Forms.Button();
			this.path = new System.Windows.Forms.Label();
			this.alis = new System.Windows.Forms.Label();
			this.password = new System.Windows.Forms.Label();
			this.text_alis = new System.Windows.Forms.TextBox();
			this.text_pass = new System.Windows.Forms.TextBox();
			this.make = new System.Windows.Forms.Button();
			this.alis_pass = new System.Windows.Forms.Label();
			this.text_alis_pass = new System.Windows.Forms.TextBox();
			this.verify_key = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// text_path
			// 
			this.text_path.Location = new System.Drawing.Point(65, 12);
			this.text_path.Name = "text_path";
			this.text_path.ReadOnly = true;
			this.text_path.Size = new System.Drawing.Size(156, 25);
			this.text_path.TabIndex = 0;
			// 
			// sel_sign
			// 
			this.sel_sign.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.sel_sign.Location = new System.Drawing.Point(227, 8);
			this.sel_sign.Name = "sel_sign";
			this.sel_sign.Size = new System.Drawing.Size(72, 33);
			this.sel_sign.TabIndex = 1;
			this.sel_sign.Text = "选择";
			this.sel_sign.UseVisualStyleBackColor = true;
			this.sel_sign.Click += new System.EventHandler(this.Sel_signClick);
			// 
			// path
			// 
			this.path.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.path.Location = new System.Drawing.Point(5, 14);
			this.path.Name = "path";
			this.path.Size = new System.Drawing.Size(54, 22);
			this.path.TabIndex = 2;
			this.path.Text = "路径:";
			// 
			// alis
			// 
			this.alis.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.alis.Location = new System.Drawing.Point(4, 65);
			this.alis.Name = "alis";
			this.alis.Size = new System.Drawing.Size(55, 20);
			this.alis.TabIndex = 3;
			this.alis.Text = "别名:";
			// 
			// password
			// 
			this.password.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.password.Location = new System.Drawing.Point(4, 102);
			this.password.Name = "password";
			this.password.Size = new System.Drawing.Size(93, 20);
			this.password.TabIndex = 4;
			this.password.Text = "签名密码:";
			// 
			// text_alis
			// 
			this.text_alis.Location = new System.Drawing.Point(95, 60);
			this.text_alis.Name = "text_alis";
			this.text_alis.Size = new System.Drawing.Size(137, 25);
			this.text_alis.TabIndex = 5;
			// 
			// text_pass
			// 
			this.text_pass.Location = new System.Drawing.Point(95, 102);
			this.text_pass.Name = "text_pass";
			this.text_pass.PasswordChar = '*';
			this.text_pass.Size = new System.Drawing.Size(137, 25);
			this.text_pass.TabIndex = 6;
			// 
			// make
			// 
			this.make.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.make.Location = new System.Drawing.Point(105, 193);
			this.make.Name = "make";
			this.make.Size = new System.Drawing.Size(96, 34);
			this.make.TabIndex = 8;
			this.make.Text = "生成";
			this.make.UseVisualStyleBackColor = true;
			this.make.Click += new System.EventHandler(this.MakeClick);
			// 
			// alis_pass
			// 
			this.alis_pass.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.alis_pass.Location = new System.Drawing.Point(4, 142);
			this.alis_pass.Name = "alis_pass";
			this.alis_pass.Size = new System.Drawing.Size(93, 21);
			this.alis_pass.TabIndex = 9;
			this.alis_pass.Text = "别名密码:";
			// 
			// text_alis_pass
			// 
			this.text_alis_pass.Location = new System.Drawing.Point(95, 142);
			this.text_alis_pass.Name = "text_alis_pass";
			this.text_alis_pass.PasswordChar = '*';
			this.text_alis_pass.Size = new System.Drawing.Size(137, 25);
			this.text_alis_pass.TabIndex = 10;
			// 
			// verify_key
			// 
			this.verify_key.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.verify_key.Location = new System.Drawing.Point(242, 81);
			this.verify_key.Name = "verify_key";
			this.verify_key.Size = new System.Drawing.Size(60, 63);
			this.verify_key.TabIndex = 11;
			this.verify_key.Text = "验证";
			this.verify_key.UseVisualStyleBackColor = true;
			this.verify_key.Click += new System.EventHandler(this.Verify_keyClick);
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(314, 239);
			this.Controls.Add(this.verify_key);
			this.Controls.Add(this.text_alis_pass);
			this.Controls.Add(this.alis_pass);
			this.Controls.Add(this.make);
			this.Controls.Add(this.text_pass);
			this.Controls.Add(this.text_alis);
			this.Controls.Add(this.password);
			this.Controls.Add(this.alis);
			this.Controls.Add(this.path);
			this.Controls.Add(this.sel_sign);
			this.Controls.Add(this.text_path);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form2";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "签名选择";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		
	
	}
}
