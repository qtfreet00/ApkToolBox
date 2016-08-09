using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AutoAPKTool.Properties;

namespace AutoAPKTool
{
    public partial class Form1 : Form
    {
        private string _apkinfo = "";
        private string _alis = "";
        private string _keyword = "";
        private string _path = "";
        private string _alispass = "";

        public Form1()
        {
            InitializeComponent();
            StartUp();
        }

        private static void StartUp()
        {
            var currentProcess = Process.GetCurrentProcess();
            foreach (var item in Process.GetProcessesByName(currentProcess.ProcessName))
            {
                if (item.Id == currentProcess.Id ||
                    !((item.StartTime - currentProcess.StartTime).TotalMilliseconds <= 0)) continue;
                item.Kill();
                item.WaitForExit();
                break;
            }
        }


        private void SetTextBoxStr(TextBox tb, string info)
        {
            if (tb == null) throw new ArgumentNullException(nameof(tb));
            tb.Text = info + Resources.enter;
            tb.SelectionStart = tb.Text.Length;
            tb.ScrollToCaret();
        }

        private const int ExcuteJava = 0;
        private const int ExcuteCmd = 1;

        private void Excute(int flag, object args)
        {
            base.Invoke(new Action(delegate { this.SetTextBoxStr(this.textBox1, "正在努力的工作中，请等待\r\n"); }));
            var sh = "";
            switch (flag)
            {
                case 0:
                    sh = "java.exe";
                    break;
                case 1:
                    sh = "cmd.exe";
                    break;
            }

            var processStartInfo = new ProcessStartInfo(sh, args.ToString())
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            using (var process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.OutputDataReceived += delegate(object s, DataReceivedEventArgs e)
                {
                    base.Invoke(new Action(delegate
                    {
                        if (!_showInfo) return;
                        if (_isCheckProtect)
                        {
                            _apkinfo += e.Data + "\n";
                        }
                        else if (_isGetInfo)
                        {
                            _apkinfo += e.Data + "\n";
                        }
                        else
                        {
                            this.SetTextBoxStr(this.textBox1, this.textBox1.Text + e.Data);
                        }
                    }));
                };
                process.Start();
                process.BeginOutputReadLine();
                process.WaitForExit();
                process.Close();
            }
            base.Invoke(new Action(delegate
            {
                this.SetTextBoxStr(this.textBox1, this.textBox1.Text + "完成!");
                _isCheckProtect = false;
                _isGetInfo = false;
                _showInfo = true;
            }));
        }


        private static bool _isCheckProtect = false;

        // button Click
        private void btn_Decompiler_Click(object sender, EventArgs e)
        {
            var text = this.textBox_path.Text;
            if (Directory.Exists(text))
            {
                if (MessageBox.Show(Resources.need_decompiles, Resources.info, MessageBoxButtons.OKCancel) !=
                    DialogResult.OK) return;
                var fileinfos = Directory.GetFiles(text);
                var size = fileinfos.Length;
                var list = new List<string>();

                for (var i = 0; i < size; i++)
                {
                    if (Path.GetExtension(fileinfos[i]) == ".apk")
                    {
                        list.Add(fileinfos[i]);
                    }
                }
                var len = list.Count;
                if (len == 0)
                {
                    MessageBox.Show(Resources.no_find_apk, Resources.info);
                    return;
                }


                new Thread(() =>
                {
                    for (var k = 0; k < len; k++)
                    {
                        Excute(ExcuteJava,
                            Util.GetDecompilerArg(list[k], text + "\\" + Path.GetFileNameWithoutExtension(list[k])));
                    }
                }).Start();
            }
            else if (!File.Exists(text) || Path.GetExtension(text) != ".apk")
            {
                MessageBox.Show(Resources.no_find_apk, Resources.info);
            }
            else
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = Resources.files,
                    InitialDirectory = Path.GetDirectoryName(text),
                    FileName = Path.GetFileNameWithoutExtension(text)
                };
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
                var outputFolderName = saveFileDialog.FileName.ToString();
                var decompilerArg = Util.GetDecompilerArg(text, outputFolderName);
                new Thread(() => { Excute(ExcuteJava, decompilerArg); }).Start();
            }
        }

        private void btn_SignAPK_Click(object sender, EventArgs e)
        {
            var text = this.textBox_path.Text;
            if (Directory.Exists(text))
            {
                if (MessageBox.Show(Resources.need_signs, Resources.info, MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;
                var allsign = Util.GetSignArg(text);
                new Thread(() => { Excute(ExcuteJava, allsign); }).Start();
            }
            else if (!File.Exists(text) || Path.GetExtension(text) != ".apk")
            {
                MessageBox.Show(Resources.no_find_apk, Resources.info);
            }
            else
            {
                var cmd = Util.GetSignArg(text);
                new Thread(() => { Excute(ExcuteJava, cmd); }).Start();
            }
        }

        private void btn_BuildAndSign_Click(object sender, EventArgs e)
        {
            var text = this.textBox_path.Text;
            if (!Directory.Exists(text))
            {
                MessageBox.Show(Resources.pls_confirm_decompile_package, Resources.info);
                return;
            }
            var saveFileDialog = new SaveFileDialog
            {
                Filter = Resources.apk_files,
                DefaultExt = "apk",
                InitialDirectory = Path.GetDirectoryName(text),
                FileName = Path.GetFileNameWithoutExtension(text) + "_Mod.apk"
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var text2 = saveFileDialog.FileName.ToString();

            Console.WriteLine(Resources.path, text2);
            var args1 = Util.GetBuildArg(text, text2);
            var args2 = Util.GetSignArg(text2);
            // Start
            new Thread(() =>
            {
                Excute(ExcuteJava, args1); // Build
                Excute(ExcuteJava, args2); // Sign				
            }).Start();
        }

        private void btn_dex2jar_Click(object sender, EventArgs e)
        {
            string text = this.textBox_path.Text;
            if (!File.Exists(text) || Path.GetExtension(text) != ".dex")
            {
                MessageBox.Show(Resources.no_find_dex, Resources.info);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = Resources.jar_files,
                InitialDirectory = Path.GetDirectoryName(text),
                FileName = Path.GetFileNameWithoutExtension(text)
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var outputJar = saveFileDialog.FileName.ToString();
            var dex2JarArg = Util.GetDex2JarArg(text, outputJar);
            Console.WriteLine(dex2JarArg);

            new Thread(() => { Excute(ExcuteCmd, dex2JarArg); }).Start();
        }

        // Form Event
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop, false) ? DragDropEffects.Copy : DragDropEffects.None;
        }


        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var fileInfo = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
            var filePath = string.Join("", fileInfo, 0, fileInfo.Length);

            textBox_path.Text = filePath;
        }


        private void btn_JdGUI_Click(object sender, EventArgs e)
        {
            var text = this.textBox_path.Text;
            if (!File.Exists(text) || Path.GetExtension(text) != ".jar")
            {
                MessageBox.Show(Resources.no_find_jar, Resources.info);
                return;
            }
            new Thread(() => { Excute(ExcuteCmd, "/c " + Constants.JarJdGui + " " + text); }).Start();
        }

        private void btn_openFile_Click(object sender, EventArgs e)
        {
            var op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                textBox_path.Text = op.FileName;
            }
        }


        private bool _showInfo = true;


        private void Btn_jadxClick(object sender, EventArgs e)
        {
            _showInfo = false;
            new Thread(() => { Excute(ExcuteJava, "-jar " + Constants.Jadx); }).Start();
        }


        private void Btn_decompileDexClick(object sender, EventArgs e)
        {
            var text = this.textBox_path.Text;
            if (!File.Exists(text) || Path.GetExtension(text) != ".dex")
            {
                MessageBox.Show(Resources.no_find_dex, Resources.info);
                return;
            }
            var saveFileDialog = new SaveFileDialog
            {
                Filter = Resources.files,
                InitialDirectory = Path.GetDirectoryName(text),
                FileName = Path.GetFileNameWithoutExtension(text)
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var outputFolderName = saveFileDialog.FileName.ToString();
            var decompilerDex = Util.GetDecompilerDex(text, outputFolderName);
            new Thread(() => { Excute(ExcuteJava, decompilerDex); }).Start();
        }

        private void Btn_compileDexClick(object sender, EventArgs e)
        {
            var text = this.textBox_path.Text;
            if (!Directory.Exists(text))
            {
                MessageBox.Show(Resources.no_find_smali_files, Resources.info);
                return;
            }
            var saveFileDialog = new SaveFileDialog
            {
                Filter = Resources.dex_files,
                DefaultExt = "dex",
                InitialDirectory = Path.GetDirectoryName(text),
                FileName = Path.GetFileNameWithoutExtension(text) + "_Mod.dex"
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var text2 = saveFileDialog.FileName;
            Console.WriteLine(Resources.path, text2);
            var buildDex = Util.GetBuildDex(text, text2);

            new Thread(() => { Excute(ExcuteJava, buildDex); }).Start();
        }



        private void My_signClick(object sender, EventArgs e)
        {
            Initsign();

            if (!File.Exists(Constants.MySign))
            {
                MessageBox.Show(Resources.no_sign, Resources.info);
                return;
            }
            var text = this.textBox_path.Text;
            if (Directory.Exists(text))
            {
                if (MessageBox.Show(Resources.need_signs, Resources.info, MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;
                var allsign = Util.Signapk(_path, _keyword, text, _alis);
                new Thread(() => { Excute(ExcuteJava, allsign); }).Start();
            }
            else if (!File.Exists(text) || Path.GetExtension(text) != ".apk")
            {
                MessageBox.Show(Resources.no_find_apk, Resources.info);
            }
            else
            {
                var args3 = Util.Signapk(_path, _keyword, text, _alis);
                new Thread(() => { Excute(ExcuteJava, args3); }).Start();
            }
        }

        private void Initsign()
        {
            if (!File.Exists(Constants.MySign))
            {
                return;
            }
            var sr = new StreamReader(Constants.MySign, Encoding.Default);
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("alis="))
                {
                    _alis = line.Substring(5);
                }
                else if (line.StartsWith("password="))
                {
                    _keyword = line.Substring(9);
                }
                else if (line.StartsWith("path="))
                {
                    _path = line.Substring(5);
                }
                else if (line.StartsWith("alispass="))
                {
                    _alispass = line.Substring(9);
                }
            }
            sr.Close();
        }

        private void 签名ToolStripMenuItemClick(object sender, EventArgs e)
        {
            var f = new Form2();
            f.Show();
        }

        private void ZipalginClick(object sender, EventArgs e)
        {
            var text = this.textBox_path.Text;
            if (!File.Exists(text) || Path.GetExtension(text) != ".apk")
            {
                MessageBox.Show(Resources.no_find_apk, Resources.info);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = Resources.apk_files,
                DefaultExt = "apk",
                InitialDirectory = Path.GetDirectoryName(text),
                FileName = Path.GetFileNameWithoutExtension(text) + "_zipaligned.apk"
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var text2 = saveFileDialog.FileName;
            var signArg = Util.ZipAlign(text, text2);
            new Thread(() =>
            {
                Excute(ExcuteCmd, signArg);
            }).Start();
        }

        private static bool _isGetInfo = false;


        public void SetText(string str)
        {
            if (this.InvokeRequired) // 获取一个值指示此次调用是否来自非UI线程
            {
                this.Invoke(new ChangeTextBoxValue(SetText), str);
            }
            else
            {
                this.textBox1.Text = str;
            }
        }

        public delegate void ChangeTextBoxValue(string str);

        private void GetString()
        {
            var sb = "";
            using (var sr = new StringReader(_apkinfo))
            {
                string line;
                const string rex = "'";
                sb = sb + ("adb shell am start -D -n ");
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("package: name"))
                    {
                        var info = line.Split(new char[] {System.Convert.ToChar(rex)});
                        sb = sb + (info[1] + "/");
                    }
                    if (!line.StartsWith("launchable-activity:")) continue;
                    {
                        var info = line.Split(new char[] {System.Convert.ToChar(rex)});
                        sb = sb + (info[1]);
                    }
                }
                Console.WriteLine(sb);
            }
            SetText(sb);
        }
        private void odex_dec(object sender, EventArgs e)
        {
            var text = this.textBox_path.Text;

            if (!Directory.Exists(Constants.OdexFramework))
            {
                MessageBox.Show(Resources.no_find_framework, Resources.info);
                return;
            }

            if (!File.Exists(text) || Path.GetExtension(text) != ".odex")
            {
                MessageBox.Show(Resources.no_find_odex, Resources.info);
                return;
            }
            var saveFileDialog = new SaveFileDialog
            {
                Filter = Resources.files,
                InitialDirectory = Path.GetDirectoryName(text),
                FileName = Path.GetFileNameWithoutExtension(text)
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var outputFolderName = saveFileDialog.FileName.ToString();
            var decodex = Util.DecOdex(text, outputFolderName);

            new Thread(() => { Excute(ExcuteJava, decodex); }).Start();
        }

        private void Btn_CheckProtect(object sender, EventArgs e)
        {
            _apkinfo = null;

            var text = this.textBox_path.Text;

            if (!File.Exists(text) || Path.GetExtension(text) != ".apk")
            {
                MessageBox.Show(Resources.no_find_apk, Resources.info);
                return;
            }
            var result = "未知";

            new Thread(() =>
            {
                result = CheckProtect.Start(text);
                MessageBox.Show(result);
            }).Start();
        }

        private void Btn_BlogClick(object sender, EventArgs e)
        {
            Process.Start("http://qtfreet.com/");
        }

        private void Btn_52pojieClick(object sender, EventArgs e)
        {
            Process.Start("http://www.52pojie.cn/");
        }

        private void Btn_getArgsConmindLine(object sender, EventArgs e)
        {
            _apkinfo = "";
            var text = this.textBox_path.Text;
            if (!File.Exists(text) || Path.GetExtension(text) != ".apk")
            {
                MessageBox.Show(Resources.no_find_apk, Resources.info);
                return;
            }
            _isGetInfo = true;
            var cmd = Util.GetPackage(text);
            Console.WriteLine(cmd);
            new Thread(() =>
            {
                Excute(ExcuteCmd, cmd);
                GetString();
            }).Start();
        }
    }
}