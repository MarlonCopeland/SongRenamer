using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRenamer
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string path = @"c:\OldSongs\";
            var strFileName = @"C:\Users\Fiach\Desktop\sample_iTunes.mov";
            runRenamer(path);
        }

        static void runRenamer(string p)
        {
            string songTitle = "bartFart";
            //File songFile = Directory.get
            string songArtist = "ShortLife";

            string path = p;
            string targetPath = @"C:\NewSongs\";

            //get the file(s)
            string[] songfiles = Directory.GetFiles(path);

            foreach (string song in songfiles)
            {
                List<string> arrHeaders = new List<string>();
                
                Shell32.Shell shell = new Shell32.Shell();
                Shell32.Folder objFolder = shell.NameSpace(System.IO.Path.GetDirectoryName(song));
                Shell32.FolderItem folderItem = objFolder.ParseName(System.IO.Path.GetFileName(song));

                for (int i = 0; i < short.MaxValue; i++)
                {
                    string header = objFolder.GetDetailsOf(null, i);
                    if (String.IsNullOrEmpty(header))
                        break;
                    arrHeaders.Add(header);
                }

                for (int i = 0; i < arrHeaders.Count; i++)
                {
                    Console.WriteLine("{0}\t{1}: {2}", i, arrHeaders[i], objFolder.GetDetailsOf(folderItem, i));

                }
                songTitle = objFolder.GetDetailsOf(folderItem, 21);
                songArtist = objFolder.GetDetailsOf(folderItem, 13);
                FileAttributes attributes = File.GetAttributes(song);

                FileInfo fi = new FileInfo("bart.txt");
                //fi.a
                
                ////get the file property

                ////check if the dir exists
                if (!System.IO.Directory.Exists(targetPath + songArtist))
                {
                    Directory.CreateDirectory(targetPath + songArtist);
                }
                ////copy the file to target dir


                System.IO.File.Move(song, targetPath + songArtist + @"\" + songTitle + ".m4a");
                //rename the file to the Title of the Song
            }
            Console.ReadLine();
        }


    }
}
