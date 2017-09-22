using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using AutoAPKTool.Properties;

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
                error_tip.Text = Resources.pls_input_opcode;
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
            result_tip.Text = Resources.working_hard;
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
                    error_tip.Text = Resources.pls_make_sure;
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
                error_tip.Text = Resources.convert_expcetion;
                File.Delete("tmp");
                return;
            }
            result_tip.Text = Resources.complete;
            File.Delete("tmp");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(".\\tool\\as.exe"))
            {
                error_tip.Text = Resources.pls_insure_your_as_path;
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