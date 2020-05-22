using System;
using System.IO;

namespace Projekt_MiniTC
{
    static class KopiaDanych
    {
        public static void KopiujPliki(string _od, string _do)
        {
            FileInfo Od = new FileInfo(_od);
            DirectoryInfo Do= new DirectoryInfo(_do);

            string path = Do.FullName + "\\" + Od.Name;
            int i = 2;

            while (File.Exists(path))
            {
                path = Do.FullName + "\\" + Od.Name.Replace(Od.Extension, $"({i}){Od.Extension}");
                i++;
            }

            File.Copy(Od.FullName, path);
        }

        public static void KopiujFolder(string _od,string _do)
        {
            DirectoryInfo Od = new DirectoryInfo(_od);
            DirectoryInfo[] foldery = Od.GetDirectories();
            FileInfo[] pliki = Od.GetFiles();

            string path = _do + "\\" + Od.Name;
            int i = 2;

            while (Directory.Exists(path))
            {
                path = ($"{_do}\\{Od.Name} ({i})");
                i++;
            }

            Directory.CreateDirectory(path);

            foreach(FileInfo p in pliki)
            {
                File.Copy(p.FullName, path + "\\" + p.Name);
            }

            foreach(DirectoryInfo f in foldery)
            {
                KopiujFolder(f.FullName, path);
            }
        }
    }
}
