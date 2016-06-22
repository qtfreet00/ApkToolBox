using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
namespace apkdecompiler
{
    public partial class Form1 : Form
    {
        private static string APK_SIGNER = ".\\tool\\apksigner.jar";
        private static string KEY_STORE = ".\\tool\\debug.keystore";
        private static string SMALI = ".\\tool\\smali.jar";
        public static string MY_SIGN = ".\\tool\\key.txt";
        private static string ODEX_FRAMEWORK = ".\\tool\\framework";
        private static string JADX = ".\\tool\\jadx\\lib\\jadx-gui.jar";
        private static string JAR_APKTOOL = ".\\tool\\apktool.jar";
        private static string AAPT = ".\\tool\\aapt.exe";
        private static string JAR_JD_GUI = ".\\tool\\jd-gui.exe";
        private static string D2J_DEX2JAR = ".\\tool\\dex2jar\\d2j-dex2jar.bat";
        private static string BAKSMALI = ".\\tool\\baksmali.jar";
        private static string CHECK_PROTECT = ".\\tool\\aapt.exe";
        private static string ZIPALIGN = ".\\tool\\zipalign.exe";
        private string apkinfo = "";
        private string alis = "";
        private string keyword = "";
        private string path = "";
        private string alispass = "";
        private static string introduction = "\r\n\r\n更新日志: \r\n1.支持批量反编译，暂不支持批量回编译 \r\n2.支持批量签名 \r\n3.支持odex反编译 \r\n4.将之前的启动app命令放在工具栏的配置里 \r\n5.bug修复";

        public Form1()
        {
            InitializeComponent();
            StartUp();
            this.setTextBoxStr(this.textBox1, "为避免出现一系列的问题，请尽量不要使用中文路径以及中文apk名称,中文名称可能会导致签名，zipalign失败，么么哒  \r\n\t\t\t\t\t by qtfreet00" + introduction);
        }
        private void StartUp()
        {
            Process currentProcess = Process.GetCurrentProcess(); foreach (Process item in Process.GetProcessesByName(currentProcess.ProcessName)) { if (item.Id != currentProcess.Id && (item.StartTime - currentProcess.StartTime).TotalMilliseconds <= 0) { item.Kill(); item.WaitForExit(); break; } }
        }

        private string GetBuildArg(string input_FolderName, string output_APK)
        {
            return string.Format("-jar \"{0}\" b \"{1}\" -o \"{2}\"", JAR_APKTOOL, input_FolderName, output_APK);
        }

        private string zipAlign(string apkName_old, string apkName_new)
        {
            return string.Format("/c " + ZIPALIGN + " -f 4 " + apkName_old + " " + apkName_new);
        }

        private string getPackage(String apk)
        {

            return string.Format("/c " + AAPT + " dump badging " + apk);
        }


        private string signapk(string keypath, string keyw, string apkpath, string ais)
        {

            return string.Format("-jar " + APK_SIGNER + " -keystore \"{0}\" -alias  \"{1}\"  -pswd  \"{2}\"  \"{3}\"", keypath, ais, keyw, apkpath);

        }

        private string DecOdex(string input_odex, string output_smali)
        {
            return string.Format("-jar \"{0}\" -d \"{1}\" -x \"{2}\" -o \"{3}\"", BAKSMALI,ODEX_FRAMEWORK, input_odex, output_smali);
        }

        // Token: 0x0600000C RID: 12 RVA: 0x000020F4 File Offset: 0x000002F4
        private string GetBuildDEX(string input_FolderName, string output_DEX)
        {
            return string.Format("-jar \"{0}\"  \"{1}\" -o \"{2}\"", SMALI, input_FolderName, output_DEX);
        }

        // Token: 0x06000009 RID: 9 RVA: 0x000020B8 File Offset: 0x000002B8
        private string GetDecompilerArg(string input_APK, string output_FolderName)
        {
            return string.Format("-jar \"{0}\" d \"{1}\" -o \"{2}\"", JAR_APKTOOL, input_APK, output_FolderName);
        }

        // Token: 0x0600000A RID: 10 RVA: 0x000020CC File Offset: 0x000002CC
        private string GetDecompilerDex(string input_DEX, string output_FolderName)
        {
            return string.Format("-jar \"{0}\"  \"{1}\" -o \"{2}\"", BAKSMALI, input_DEX, output_FolderName);
        }

        // Token: 0x0600000E RID: 14 RVA: 0x0000213D File Offset: 0x0000033D
        private string GetDex2JarArg(string input_Dex, string output_Jar)
        {
            return string.Format("/c \"\"{0}\" \"{1}\" -o \"{2}\"\"", D2J_DEX2JAR, input_Dex, output_Jar);
        }

        private string GetAPKINFO(string input_APK)
        {
            return string.Format("/c \"\"{0}\" l \"{1}\"", CHECK_PROTECT, input_APK);
        }

        // Token: 0x0600000D RID: 13 RVA: 0x00002108 File Offset: 0x00000308
        private string GetSignArg(string apkName)
        {
            return string.Format("-jar " + APK_SIGNER + " -keystore " + KEY_STORE + "  -alias androiddebugkey -pswd android "  + apkName );
        }
        private void setTextBoxStr(TextBox tb, string info)
        {
            tb.Text = info + "\r\n";
            tb.SelectionStart = tb.Text.Length;
            tb.ScrollToCaret();
        }
        // ExcuteJar
        private void ExcuteJar(object args)
        {

            base.Invoke(new Action(delegate
            {
                this.setTextBoxStr(this.textBox1, "正在努力的工作中，请等待\r\n");
            }));
            ProcessStartInfo processStartInfo = new ProcessStartInfo("java.exe", args.ToString());
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.OutputDataReceived += delegate (object s, DataReceivedEventArgs e)
                {
                    base.Invoke(new Action(delegate
                    {
                        this.setTextBoxStr(this.textBox1, this.textBox1.Text + e.Data);
                    }));
                };
                process.ErrorDataReceived += delegate (object s, DataReceivedEventArgs e)
                {
                    base.Invoke(new Action(delegate
                    {
                        this.setTextBoxStr(this.textBox1, this.textBox1.Text + e.Data);
                    }));
                };
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                process.Close();
            }
            base.Invoke(new Action(delegate
            {
                TextBox textBox = this.textBox1;
                textBox.Text += "完成!\r\n";
                this.textBox1.SelectionStart = this.textBox1.Text.Length;
                this.textBox1.ScrollToCaret();
            }));
        }
        private void ExcuteCmd(object args)
        {
            base.Invoke(new Action(delegate
            {
                this.setTextBoxStr(this.textBox1, "正在努力的工作中，请等待\r\n");
            }));
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", args.ToString());
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.OutputDataReceived += delegate (object s, DataReceivedEventArgs e)
                {
                    base.Invoke(new Action(delegate
                    {
                        if (isCheckProtect)
                        {
                            apkinfo += e.Data + "\n";
                        }else if (isGetInfo)
                        {
                            apkinfo += e.Data + "\n";

                        }
                        else
                        {
                            this.setTextBoxStr(this.textBox1, this.textBox1.Text + e.Data);
                        }


                    }));
                };
                process.ErrorDataReceived += delegate (object s, DataReceivedEventArgs e)
                {
                    base.Invoke(new Action(delegate
                    {
                        this.setTextBoxStr(this.textBox1, this.textBox1.Text + e.Data);
                    }));
                };
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                process.Close();
            }
            base.Invoke(new Action(delegate
            {
                this.setTextBoxStr(this.textBox1, this.textBox1.Text + "完成!");
                isCheckProtect = false;
                isGetInfo = false;
            }));
        }


        private static Boolean isCheckProtect = false;

        // button Click
        private void btn_Decompiler_Click(object sender, EventArgs e)
        {
            string text = this.textBox_path.Text;
            if (Directory.Exists(text))
            {
                if (MessageBox.Show("需要批量反编译吗", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    String[] fileinfos = Directory.GetFiles(text);
                    int size = fileinfos.Length;
                    List<String> list = new List<String>();

                    for (int i = 0; i < size; i++)
                    {
                        if (Path.GetExtension(fileinfos[i])==".apk")
                        {
                            list.Add(fileinfos[i]);
                        }
                    }
                    int len = list.Count;
                    if (len == 0)
                    {

                        MessageBox.Show("未发现apk文件!", "提示");
                        return;
                    }
                

                    new Thread(() =>
                    {
                        for (int k = 0; k < len; k++)
                        {
                            ExcuteJar(GetDecompilerArg(list[k],text+"\\"+ Path.GetFileNameWithoutExtension(list[k])));
                        }
 
                    }).Start();
                }
                else
                {
                    return;
                }
            }
            else if (!File.Exists(text) || Path.GetExtension(text) != ".apk")
            {

                MessageBox.Show("未发现apk文件!", "提示");
                return;
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "文件夹|*";
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(text);
                saveFileDialog.FileName = Path.GetFileNameWithoutExtension(text);
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string output_FolderName = saveFileDialog.FileName.ToString();
                    string decompilerArg = this.GetDecompilerArg(text, output_FolderName);
                    new Thread(new ParameterizedThreadStart(this.ExcuteJar)).Start(decompilerArg);
                }
            }


        }

        private void btn_SignAPK_Click(object sender, EventArgs e)
        {
            string text = this.textBox_path.Text;
            if (Directory.Exists(text))
            {
                if (MessageBox.Show("需要批量签名吗", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    String allsign = GetSignArg(text);
                    new Thread(() =>
                    {
                        ExcuteJar(allsign);


                    }).Start();
                }
                else
                {
                    return;
                }
            }else if (!File.Exists(text) || Path.GetExtension(text) != ".apk")
            {
                MessageBox.Show("未发现apk文件!", "提示");
                return;
            }
            else
            {
                String cmd = GetSignArg(text);
                new Thread(() =>
                {
                    ExcuteJar(cmd);


                }).Start();
            }
        }
        private void btn_BuildAndSign_Click(object sender, EventArgs e)
        {
            string text = this.textBox_path.Text;
            if (!Directory.Exists(text))
            {
                MessageBox.Show("请确认是否已经拖入反编译后的文件夹!", "提示");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "APK|*.apk|All|*.*";
            saveFileDialog.DefaultExt = "apk";
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(text);
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(text) + "_Mod.apk";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                string text2 = saveFileDialog.FileName.ToString();

                Console.WriteLine("路径: {0}", text2);
                string args1 = this.GetBuildArg(text, text2);
                string args2 = this.GetSignArg(text2);
                // Start
                new Thread(() =>
                {
                    ExcuteJar(args1); // Build
                    ExcuteJar(args2); // Sign				
                }).Start();
            }
        }

        private void deleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        private void btn_dex2jar_Click(object sender, EventArgs e)
        {

            string text = this.textBox_path.Text;
            if (!File.Exists(text) || Path.GetExtension(text) != ".dex")
            {
                MessageBox.Show("未发现dex文件!", "提示");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Jar|*.jar";
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(text);
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(text);
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string output_Jar = saveFileDialog.FileName.ToString();
                string dex2JarArg = this.GetDex2JarArg(text, output_Jar);
                Console.WriteLine(dex2JarArg);
                new Thread(new ParameterizedThreadStart(this.ExcuteCmd)).Start(dex2JarArg);
            }
        }

        // Form Event
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileInfo = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string filePath = string.Join("", fileInfo, 0, fileInfo.Length);

            textBox_path.Text = filePath;
        }
        private void btn_JdGUI_Click(object sender, EventArgs e)
        {
            string text = this.textBox_path.Text;
            if (!File.Exists(text)|| Path.GetExtension(text) != ".jar")
            {
                MessageBox.Show("未发现jar文件!", "提示");
                return;
            }
            new Thread(new ParameterizedThreadStart(this.ExcuteCmd)).Start("/c " + JAR_JD_GUI + " " + text);
        }

        private void btn_openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                textBox_path.Text = op.FileName;
            }

        }
        void Btn_jadxClick(object sender, EventArgs e)
        {
            new Thread(new ParameterizedThreadStart(this.ExcuteJar)).Start("-jar " + JADX);
        }
        void Btn_decompileDexClick(object sender, EventArgs e)
        {
            string text = this.textBox_path.Text;
            if (!File.Exists(text)|| Path.GetExtension(text) != ".dex")
            {
                MessageBox.Show("未发现dex文件!", "提示");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "文件夹|*";
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(text);
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(text);
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string output_FolderName = saveFileDialog.FileName.ToString();
                string decompilerDex = this.GetDecompilerDex(text, output_FolderName);
                new Thread(new ParameterizedThreadStart(this.ExcuteJar)).Start(decompilerDex);
            }
        }
        void Btn_compileDexClick(object sender, EventArgs e)
        {
            string text = this.textBox_path.Text;
            if (!Directory.Exists(text))
            {
                MessageBox.Show("未发现smali文件夹!", "提示");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "DEX|*.dex|All|*.*";
            saveFileDialog.DefaultExt = "dex";
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(text);
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(text) + "_Mod.dex";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string text2 = saveFileDialog.FileName.ToString();
                Console.WriteLine("路径: {0}", text2);
                string buildDEX = this.GetBuildDEX(text, text2);
                new Thread(new ParameterizedThreadStart(this.ExcuteJar)).Start(buildDEX);
            }
        }
        private void check(String info)
        {
            string product = "未加壳";

            if (info.Contains("libjiagu.so"))
            {
                product = "360加固";
            }
            else if (info.Contains("apkprotect.com"))
            {
                product = "apkprotect加密";
            }
            else if (info.Contains("libexecmain.so"))
            {
                product = "爱加密加固";
            }
            else if (info.Contains("libDexHelper.so"))
            {
                product = "梆梆加固企业版";
            }
            else if (info.Contains("libsecmain.so"))
            {
                product = "梆梆加固";
            }
            else if (info.Contains("libbaiduprotect.so"))
            {
                product = "百度加固";
            }
            else if (info.Contains("libddog.so"))
            {
                product = "娜迦加固";
            }
            else if (info.Contains("libmobisec.so"))
            {
                product = "阿里加固";
            }
            else if (info.Contains("libnqshield.so"))
            {
                product = "网秦加固";
            }
            else if (info.Contains("libmono.so"))
            {
                product = "unity3d 游戏";
            }
            else if (info.Contains("libcocos2dlua.so"))
            {
                product = "cocos2d 游戏";
            }
            else if (info.Contains("libshella-"))
            {
                product = "腾讯乐固";
            }
            else if (info.Contains("libegisboot.so"))
            {
                product = "通付盾加固";
            }
            else if (info.Contains("libnesec.so"))
            {
                product = "网易云加密";
            }

            MessageBox.Show("    " + product, "提示");

        }
        void Btn_envClick(object sender, EventArgs e)
        {
            apkinfo = null;

            string text = this.textBox_path.Text;
  
            if (!File.Exists(text)||Path.GetExtension(text) != ".apk")
            {
                MessageBox.Show("未发现apk文件!", "提示");
                return;
            }

            string signArg = this.GetAPKINFO(text);
            isCheckProtect = true;
            new Thread(() =>
            {
                ExcuteCmd(signArg); // Build
                this.check(apkinfo);
            }).Start();

        }
        void My_signClick(object sender, EventArgs e)
        {
            initsign();

            if (!File.Exists(MY_SIGN))
            {
                MessageBox.Show("未发现签名文件!", "提示");
                return;
            }
            string text = this.textBox_path.Text;
            if (Directory.Exists(text))
            {
                if (MessageBox.Show("需要批量签名吗", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    String allsign = this.signapk(path, keyword, text, alis);
                    new Thread(() =>
                    {
                        ExcuteJar(allsign);


                    }).Start();
                }
                else
                {
                    return;
                }
            }
           else if (!File.Exists(text) || Path.GetExtension(text) != ".apk")
           {
               MessageBox.Show("未发现apk文件!", "提示");
               return;
           }
           else
           {
                string args3 = this.signapk(path, keyword, text, alis);
                new Thread(() =>
                {

                    ExcuteJar(args3);

                }).Start();
            }
    
        }

        private void initsign()
        {
            if (!File.Exists(MY_SIGN))
            {
                return;
            }
            StreamReader sr = new StreamReader(MY_SIGN, Encoding.Default);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("alis="))
                {
                    alis = line.Substring(5);
                }
                else if (line.StartsWith("password="))
                {
                    keyword = line.Substring(9);
                }
                else if (line.StartsWith("path="))
                {
                    path = line.Substring(5);
                }
                else if (line.StartsWith("alispass="))
                {
                    alispass = line.Substring(9);
                }
            }
            sr.Close();
        }
        void 签名ToolStripMenuItemClick(object sender, EventArgs e)
        {
            AutoAPKTool.Form2 f = new AutoAPKTool.Form2();
            f.Show();
        }
        void ZipalginClick(object sender, EventArgs e)
        {
            string text = this.textBox_path.Text;
            if (!File.Exists(text)|| Path.GetExtension(text) != ".apk")
            {
                MessageBox.Show("未发现apk文件!", "提示");
                return;
            }
  
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "APK|*.apk|All|*.*";
            saveFileDialog.DefaultExt = "apk";
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(text);
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(text) + "_zipaligned.apk";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string text2 = saveFileDialog.FileName.ToString();

                string signArg = this.zipAlign(text, text2);

                new Thread(() =>
                {


                    ExcuteCmd(signArg);
                    deleteFile(text);


                }).Start();
            }
        }
        void AboutClick(object sender, EventArgs e)
        {
            string text = this.textBox_path.Text;
            if (!File.Exists(ODEX_FRAMEWORK))
            {
                MessageBox.Show("未发现framework框架，请自行将odex所在的手机或模拟器上system下的framework文件夹放在工具箱的tool文件夹下内，请勿重命名!", "提示");
                return;
            }
            if (!File.Exists(text) || Path.GetExtension(text) != ".odex")
            {
                MessageBox.Show("未发现odex文件!", "提示");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "文件夹|*";
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(text);
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(text);
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string output_FolderName = saveFileDialog.FileName.ToString();
                string DECODEX = this.DecOdex(text, output_FolderName);
                new Thread(new ParameterizedThreadStart(this.ExcuteJar)).Start(DECODEX);
            }

        }

        private static Boolean isGetInfo = false;


        void SetText(string str)
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
        delegate void ChangeTextBoxValue(string str);
        private void getString()
        {

            string sb = "";
            using (StringReader sr = new StringReader(apkinfo))
            {
                string line;
                String rex = "'";
                sb = sb + ("adb shell am start -D -n ");
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("package: name"))
                    {

                        string[] info = line.Split(new char[] { System.Convert.ToChar(rex) });
                        sb = sb + (info[1] + "/");
                    }
                    if (line.StartsWith("launchable-activity:"))
                    {
                        string[] info = line.Split(new char[] { System.Convert.ToChar(rex) });
                        sb = sb + (info[1]);
                    }
                }
                Console.WriteLine(sb);
            }
                SetText(sb);          

        }

        private void 博客ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://qtfreet.com/");
        }

        private void 吾爱破解ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.52pojie.cn/");

        }

        private void 启动App命令ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apkinfo = "";
            string text = this.textBox_path.Text;
            if (!File.Exists(text) || Path.GetExtension(text) != ".apk")
            {
                MessageBox.Show("未发现apk文件!", "提示");
                return;
            }
            isGetInfo = true;
            String cmd = this.getPackage(text);
            new Thread(() =>
            {


                ExcuteCmd(cmd);
                getString();

            }).Start();
        }
    }
}
