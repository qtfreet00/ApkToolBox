using System.Diagnostics;

namespace AutoAPKTool
{
    internal class CheckProtect
    {
        public static string Start(string input)
        {
            var output = "";
            var args = GetApkInfo(input);
            var processStartInfo = new ProcessStartInfo("cmd.exe", args)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            using (var process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();
                output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                process.Close();
            }
            var result = Check(output);
            return result;
        }

        private static string GetApkInfo(string inputApk)
        {
            return $"/c \"\"{Constants.CheckProtect}\" l \"{inputApk}\"";
        }


        private static string Check(string info)
        {
            var product = "未知";

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

            return product;
        }
    }
}