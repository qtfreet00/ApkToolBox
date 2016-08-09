/*
 * 由SharpDevelop创建。
 * 用户： qtfreet
 * 日期: 2016/2/20
 * 时间: 13:11
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using AutoAPKTool.Properties;

namespace AutoAPKTool
{
    /// <summary>
    /// Description of Form2.
    /// </summary>
    public partial class Form2 : Form
    {
        public Form2()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        public void Sel_signClick(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                text_path.Text = op.FileName;
            }
        }

        private void MakeClick(object sender, EventArgs e)
        {
            if (text_path.Text == "" || text_alis.Text == "" || text_pass.Text == "" || text_alis_pass.Text == "")
            {
                MessageBox.Show(Resources.pls_config, Resources.info_);
                return;
            }
            var text = "path=" + text_path.Text + "\n" + "alis=" + text_alis.Text + "\n" + "password=" + text_pass.Text +
                       "\n" + "alispass=" + text_alis_pass.Text;
            Write(text);
        }


        public void Write(string text)
        {
            if (File.Exists(Constants.MySign))
            {
                File.Delete(Constants.MySign);
            }
            var fs = new FileStream(Constants.MySign, FileMode.Create);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(text);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
            MessageBox.Show(Resources.make_succ, Resources.info_);
        }

        private void Verify_keyClick(object sender, EventArgs e)
        {
            var ver = this.verify_key_IS(text_path.Text, text_pass.Text, text_alis.Text, text_alis_pass.Text);
            new Thread(ExcuteJar).Start(ver);
        }

        private string verify_key_IS(string path, string pass, string alis, string alis_pass)
        {
            return $"-jar \"{this.KEYVER}\"  \"{path}\"  \"{pass}\" \"{alis}\" \"{alis_pass}\"";
        }

        private string KEYVER = ".\\tool\\keyver.jar";


        // ExcuteJar
        private void ExcuteJar(object args)
        {
            var processStartInfo = new ProcessStartInfo("java.exe", args.ToString())
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            var mes = "";
            using (var process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.OutputDataReceived +=
                    delegate(object s, DataReceivedEventArgs e)
                    {
                        base.Invoke(new Action(delegate { mes += e.Data; }));
                    };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                process.Close();
                MessageBox.Show(mes);
            }
        }
    }
}