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
    public partial class CertUI : Form
    {
        public CertUI()
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
            var op = new OpenFileDialog();
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
            var config = ConfigFile.LoadOrCreateFile(Constants.MySign);
            File.Copy(text_path.Text, Constants.CopySign, true);
            config["path"] = Constants.CopySign;
            config["alis"] = text_alis.Text;
            config["password"] = text_pass.Text;
            config["alispass"] = text_alis_pass.Text;
            MessageBox.Show("证书配置文件生成成功", "提示");
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

        private readonly string KEYVER = ".\\tool\\keyver.jar";


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