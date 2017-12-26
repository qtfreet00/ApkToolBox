using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AutoAPKTool.Properties;
using Ionic.Zip;

namespace AutoAPKTool
{
    public partial class MainUI : Form
    {
        private string _apkinfo = "";
        private string _alis = "";
        private string _keyword = "";
        private string _path = "";
        private string _alispass = "";

        public MainUI()
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

        private void Excute(int flag, object args, bool isshow)
        {
            base.Invoke(new Action(delegate { this.SetTextBoxStr(this.textBox1, "正在努力的工作中，请等待\r\n"); }));
            var sh = "";
            if (!string.IsNullOrEmpty(_apkinfo))
            {
                _apkinfo = "";
            }
            if (flag == 0)
                sh = "java.exe";
            else if (flag == 1)
            {
                sh = "cmd.exe";
            }

            var processStartInfo = new ProcessStartInfo(sh, args.ToString())
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            using (var process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.OutputDataReceived += delegate(object s, DataReceivedEventArgs e)
                {
                    base.Invoke(new Action(delegate
                    {
                        _apkinfo += e.Data + "\n";
                        if (isshow)
                        {
                            this.SetTextBoxStr(this.textBox1, this.textBox1.Text + e.Data);
                        }
                    }));
                };
                process.ErrorDataReceived += delegate(object s, DataReceivedEventArgs e)
                {
                    base.Invoke(new Action(delegate
                        {
                            this.SetTextBoxStr(this.textBox1, this.textBox1.Text + e.Data);
                        }
                    ));
                };
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                process.Close();
                process.Dispose();
            }
            base.Invoke(new Action(delegate { this.SetTextBoxStr(this.textBox1, this.textBox1.Text + "完成!"); }));
        }

        // button Click
        private void btn_Decompiler_Click(object sender, EventArgs e)
        {
            var inputApk = this.textBox_path.Text;
            if (Directory.Exists(inputApk))
            {
                if (MessageBox.Show(Resources.need_decompiles, Resources.info, MessageBoxButtons.OKCancel) !=
                    DialogResult.OK) return;
                var fileinfos = Directory.GetFiles(inputApk);
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
                            Util.GetDecompilerArg(list[k], inputApk + "\\" + Path.GetFileNameWithoutExtension(list[k])),
                            true);
                    }
                }).Start();
            }
            else if (!File.Exists(inputApk) || Path.GetExtension(inputApk) != ".apk")
            {
                MessageBox.Show(Resources.no_find_apk, Resources.info);
            }
            else
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = Resources.files,
                    InitialDirectory = Path.GetDirectoryName(inputApk),
                    FileName = Path.GetFileNameWithoutExtension(inputApk)
                };
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
                var outputFolderName = saveFileDialog.FileName.ToString();
                var decompilerArg = Util.GetDecompilerArg(inputApk, outputFolderName);
                new Thread(() => { Excute(ExcuteJava, decompilerArg, true); }).Start();
            }
        }

        private void btn_SignAPK_Click(object sender, EventArgs e)
        {
            var apkName = this.textBox_path.Text;
            if (Directory.Exists(apkName))
            {
                if (MessageBox.Show(Resources.need_signs, Resources.info, MessageBoxButtons.OKCancel) !=
                    DialogResult.OK)
                    return;
                var allsign = Util.GetSignArg(apkName);
                new Thread(() => { Excute(ExcuteJava, allsign, true); }).Start();
            }
            else if (!File.Exists(apkName) || Path.GetExtension(apkName) != ".apk")
            {
                MessageBox.Show(Resources.no_find_apk, Resources.info);
            }
            else
            {
                var cmd = Util.GetSignArg(apkName);
                new Thread(() => { Excute(ExcuteJava, cmd, true); }).Start();
            }
        }

        private void btn_BuildAndSign_Click(object sender, EventArgs e)
        {
            var intputFolder = this.textBox_path.Text;
            if (!Directory.Exists(intputFolder))
            {
                MessageBox.Show(Resources.pls_confirm_decompile_package, Resources.info);
                return;
            }
            var saveFileDialog = new SaveFileDialog
            {
                Filter = Resources.apk_files,
                DefaultExt = "apk",
                InitialDirectory = Path.GetDirectoryName(intputFolder),
                FileName = Path.GetFileName(intputFolder) + "_Mod.apk",   
            };
          
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var fileName = saveFileDialog.FileName;
            var args1 = Util.GetBuildArg(intputFolder, fileName);
            var args2 = Util.GetSignArg(fileName);
            // Start
            new Thread(() =>
            {
                Excute(ExcuteJava, args1, true); // Build
                Excute(ExcuteJava, args2, true); // Sign				
            }).Start();
        }

        private void btn_dex2jar_Click(object sender, EventArgs e)
        {
            var inputDex = this.textBox_path.Text;
            if (!File.Exists(inputDex) || Path.GetExtension(inputDex) != ".dex")
            {  
                MessageBox.Show(Resources.no_find_dex, Resources.info);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = Resources.jar_files,
                InitialDirectory = Path.GetDirectoryName(inputDex),
                FileName = Path.GetFileNameWithoutExtension(inputDex)
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var outputJar = saveFileDialog.FileName.ToString();
            var dex2JarArg = Util.GetDex2JarArg(inputDex, outputJar);
            new Thread(() => { Excute(ExcuteCmd, dex2JarArg, true); }).Start();
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
            var path = this.textBox_path.Text;
            if (!File.Exists(path) || Path.GetExtension(path) != ".jar")
            {
                MessageBox.Show(Resources.no_find_jar, Resources.info);
                return;
            }
            new Thread(() => { Excute(ExcuteCmd, "/c " + Constants.JarJdGui + " " + path, false); }).Start();
        }

        private void btn_openFile_Click(object sender, EventArgs e)
        {
            var op = new OpenFileDialog {Filter = Resources.support_file};
            if (op.ShowDialog() == DialogResult.OK)
            {
                textBox_path.Text = op.FileName;
            }
        }


        private void Btn_decompileDexClick(object sender, EventArgs e)
        {
            var inputDex = this.textBox_path.Text;
            if (!File.Exists(inputDex) || Path.GetExtension(inputDex) != ".dex")
            {
                MessageBox.Show(Resources.no_find_dex, Resources.info);
                return;
            }
            var saveFileDialog = new SaveFileDialog
            {
                Filter = Resources.files,
                InitialDirectory = Path.GetDirectoryName(inputDex),
                FileName = Path.GetFileNameWithoutExtension(inputDex)
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var outputFolderName = saveFileDialog.FileName.ToString();
            var decompilerDex = Util.GetDecompilerDex(inputDex, outputFolderName);
            new Thread(() => { Excute(ExcuteJava, decompilerDex, true); }).Start();
        }

        private void Btn_compileDexClick(object sender, EventArgs e)
        {
            var folderName = this.textBox_path.Text;
            if (!Directory.Exists(folderName))
            {
                MessageBox.Show(Resources.no_find_smali_files, Resources.info);
                return;
            }
            var saveFileDialog = new SaveFileDialog
            {
                Filter = Resources.dex_files,
                DefaultExt = "dex",
                InitialDirectory = Path.GetDirectoryName(folderName),
                FileName = Path.GetFileNameWithoutExtension(folderName) + "_Mod.dex"
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var fileName = saveFileDialog.FileName;
            var buildDex = Util.GetBuildDex(folderName, fileName);

            new Thread(() => { Excute(ExcuteJava, buildDex, true); }).Start();
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
                if (MessageBox.Show(Resources.need_signs, Resources.info, MessageBoxButtons.OKCancel) !=
                    DialogResult.OK)
                    return;
                var allsign = Util.Signapk(_path, _keyword, text, _alis);
                new Thread(() => { Excute(ExcuteJava, allsign, true); }).Start();
            }
            else if (!File.Exists(text) || Path.GetExtension(text) != ".apk")
            {
                MessageBox.Show(Resources.no_find_apk, Resources.info);
            }
            else
            {
                var signapk = Util.Signapk(_path, _keyword, text, _alis);
                new Thread(() => { Excute(ExcuteJava, signapk, true); }).Start();
            }
        }


        private void Initsign()
        {
            if (!File.Exists(Constants.MySign))
            {
                return;
            }
            var config = ConfigFile.LoadFile(Constants.MySign);
            _alis = config.GetConfigValue("alis");
            _keyword = config.GetConfigValue("password");
            _path = config.GetConfigValue("path");
            _alispass = config.GetConfigValue("alispass");
        }

        private void 签名ToolStripMenuItemClick(object sender, EventArgs e)
        {
            var f = new CertUI();
            f.Show();
        }


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
            using (new StringReader(_apkinfo))
            {
                sb = sb + ("adb shell am start -D -n " + _apkinfo);
                Console.WriteLine(sb);
            }
            SetText(sb);
        }


        private void Btn_CheckProtect(object sender, EventArgs e)
        {
            var text = this.textBox_path.Text;

            if (!File.Exists(text) || Path.GetExtension(text) != ".apk")
            {
                MessageBox.Show(Resources.no_find_apk, Resources.info);
                return;
            }
            //var cmd = Util.GetPackage(text);
            const string sel = @"classes.dex";

            new Thread(() =>
            {
                var zip = new ZipFile(text);
                var file = zip.SelectEntries(sel, @"\");

                if (file.Count <= 0) return;
                //这个文件存在！
                Stream decompressedStream = new MemoryStream();
                //解压文件 也可以直接使用上面的 file 来操作
                zip[sel].Extract(decompressedStream);
                decompressedStream.Position = 0;
                var reader = new StreamReader(decompressedStream);
                var dex = reader.ReadToEnd();
                MessageBox.Show(CheckProtect.checkProtect(dex), Resources.info);
            }).Start();
        }

        private void Btn_BlogClick(object sender, EventArgs e)
        {
            Process.Start("http://qtfreet.com/");
        }

        private void Btn_52pojieClick(object sender, EventArgs e)
        {
            Process.Start("https://www.52pojie.cn/");
        }

        private void getLauncher(object sender, EventArgs e)
        {
            var text = this.textBox_path.Text;
            if (!File.Exists(text) || Path.GetExtension(text) != ".apk")
            {
                MessageBox.Show(Resources.no_find_apk, Resources.info);
                return;
            }
            var cmd = Util.GetPackageNew(text);
            new Thread(() =>
            {
                Excute(ExcuteJava, cmd, false);
                GetString();
            }).Start();
        }

        private void Btn_Dec_odex(object sender, EventArgs e)
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

            new Thread(() => { Excute(ExcuteJava, decodex, true); }).Start();
        }

        private void Btn_ArmToAsm_Click(object sender, EventArgs e)
        {
            var f = new ArmForm();
            f.Show();
        }


        private void openJadx_Click(object sender, EventArgs e)
        {
            new Thread(() => { Excute(ExcuteCmd, "/c " + Constants.Jadx, false); }).Start();
        }

        private void Btn_jarToDexClick(object sender, EventArgs e)
        {
            var text = this.textBox_path.Text;
            if (!File.Exists(text) || Path.GetExtension(text) != ".jar")
            {
                MessageBox.Show(Resources.no_find_jar, Resources.info);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = Resources.dex_files,
                InitialDirectory = Path.GetDirectoryName(text),
                FileName = Path.GetFileNameWithoutExtension(text)
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var outputJar = saveFileDialog.FileName;
            var jar2DexArg = Util.GetJar2DexArg(text, outputJar);
            new Thread(() => { Excute(ExcuteCmd, jar2DexArg, true); }).Start();
        }

        private void MainUI_Load(object sender, EventArgs e)
        {

        }
    }
}