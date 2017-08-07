using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AutoAPKTool
{
    public partial class ArmForm : Form
    {
        public ArmForm()
        {
            InitializeComponent();
        }

        private void convert_Click(object sender, EventArgs e)
        {
            var outpotly = "";
            var instructionText = instruction.Text;
            if (string.IsNullOrEmpty(instructionText))
            {
                error_tip.Text = "请输入指令哦";
                return;
            }
            error_tip.Text = "";
            var compeler = new ProcessStartInfo();
            var processStartInfo = compeler;
            processStartInfo.FileName = ".\\tool\\as.exe";
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.CreateNoWindow = true;
            var streamWriter = new StreamWriter("tmp");
            streamWriter.Write(instructionText);
            streamWriter.Close();
            result_tip.Text = "正在努力执行中...";
            try
            {
                compeler.Arguments = "-mthumb tmp -al";
                var outText = Process.Start(compeler);
                var process = outText;
                if (process != null && !process.HasExited)
                {
                    outpotly = process.StandardOutput.ReadToEnd();
                }
                if(string.Equals(outpotly.Substring(38, 4),"    "))
                {
                    error_tip.Text = "请确认指令是否正确";
                    return;
                }
                thumb_text.Text = outpotly.Substring(38, 4);
                compeler.Arguments = "tmp -al";
                outText = Process.Start(compeler);
                process = outText;
                if (process != null && !process.HasExited)
                {
                    outpotly = process.StandardOutput.ReadToEnd();
                }
                arm_text.Text = outpotly.Substring(38, 8);
            }
            catch (Exception)
            {
                // ignored
                error_tip.Text = "转换出现异常";
                File.Delete("tmp");
                return;
            }
            result_tip.Text = "执行完成";
            File.Delete("tmp");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(".\\tool\\as.exe"))
            {
                error_tip.Text = "请检测根目录下是否包含as.exe程序";
            }
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            thumb_text.Text = "";
            arm_text.Text = "";
            instruction.Text = "";
        }
    }
}