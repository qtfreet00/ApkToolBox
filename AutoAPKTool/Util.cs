namespace AutoAPKTool
{
    public class Util
    {
        public static string GetBuildArg(string inputFolderName, string outputApk)
        {
            return $"-jar \"{Constants.JarApktool}\" b \"{inputFolderName}\" -o \"{outputApk}\"";
        }

        public static string ZipAlign(string apkNameOld, string apkNameNew)
        {
            return string.Format("/c " + Constants.Zipalign + " -f 4 " + apkNameOld + " " + apkNameNew);
        }

        public static string GetPackage(string apk)
        {
            return string.Format("/c " + Constants.Aapt + " dump badging " + apk);
        }


        public static string Signapk(string keypath, string keyw, string apkpath, string ais)
        {
            return
                string.Format(
                    "-jar " + Constants.ApkSigner + " -keystore \"{0}\" -alias  \"{1}\"  -pswd  \"{2}\"  \"{3}\"",
                    keypath, ais, keyw, apkpath);
        }

        public static string DecOdex(string inputOdex, string outputSmali)
        {
            return
                $"-jar \"{Constants.Baksmali}\" -d \"{Constants.OdexFramework}\" -x \"{inputOdex}\" -o \"{outputSmali}\"";
        }


        public static string GetBuildDex(string inputFolderName, string outputDex)
        {
            return $"-jar \"{Constants.Smali}\"  \"{inputFolderName}\" -o \"{outputDex}\"";
        }


        public static string GetDecompilerArg(string inputApk, string outputFolderName)
        {
            return $"-jar \"{Constants.JarApktool}\" d \"{inputApk}\" -o \"{outputFolderName}\"";
        }


        public static string GetDecompilerDex(string inputDex, string outputFolderName)
        {
            return $"-jar \"{Constants.Baksmali}\"  \"{inputDex}\" -o \"{outputFolderName}\"";
        }


        public static string GetDex2JarArg(string inputDex, string outputJar)
        {
            return $"/c \"\"{Constants.D2JDex2Jar}\" \"{inputDex}\" -o \"{outputJar}\"\"";
        }

        public static string GetApkinfo(string inputApk)
        {
            return $"/c \"\"{Constants.CheckProtect}\" l \"{inputApk}\"";
        }

        public static string GetSignArg(string apkName)
        {
            return string.Format("-jar " + Constants.ApkSigner + " -keystore " + Constants.KeyStore + "  -alias androiddebugkey -pswd android " + apkName);
        }
    }
}