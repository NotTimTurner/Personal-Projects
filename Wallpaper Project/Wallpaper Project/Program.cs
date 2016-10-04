using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Wallpaper_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
              
                string Basepath = @"C:\Users\tturner\Dropbox\IFTTT\hotredditwallpaper\";
                string NewFilePath = "";
                string DirPath = "";

                

                DirectoryInfo dir = new DirectoryInfo(Basepath);


                FileInfo[] files = dir.GetFiles();




            foreach (FileInfo file in files)
            {
                string Oldfilepath = Basepath + file.Name;

                // Console.WriteLine(Basepath+file.Name);
                // Console.WriteLine(filepaths[i]);
                if (File.Exists(Oldfilepath))
                {
                    var content = MimeTypes.GetContentType(Oldfilepath);
                    if (content.StartsWith("image"))
                    {

                        Image img = Image.FromFile(Oldfilepath);


                        if (img.Width >= 1600 && img.Width <= 1700)
                        {
                            NewFilePath = @"C:\Users\tturner\Dropbox\IFTTT\WorkWallpapers";
                        }
                        else if (img.Width >= 1900 && img.Width <= 2000)
                        {
                            NewFilePath = @"C:\Users\tturner\Dropbox\IFTTT\HomeWallpapers";
                        }
                        else
                        {
                            NewFilePath = "delete";
                        }

                        /*
                        //string directory = @"C:\Users\tturner\Dropbox\IFTTT\";
                       // string DirectoryName = img.Width + "X" + img.Height;
                        // string filename = string.Format("{0:yyyy-MM-dd}__{1}", DateTime.Now, "TransferLog.txt");
                       // string Dirpath = Path.Combine(directory, DirectoryName);

                        if (!Directory.Exists(DirectoryName))
                        {
                            System.IO.Directory.CreateDirectory(Dirpath);
                        }
                         * */
                        DirPath = Path.Combine(NewFilePath, file.Name);
                        img.Dispose();
                        if (NewFilePath != "delete" && File.Exists(DirPath) == false)
                        {
                            Console.WriteLine("saving too " + DirPath);
                            System.IO.File.Move(Oldfilepath, DirPath);
                        }
                        else
                        {
                            DeleteFile(Oldfilepath);
                        }
                    }
                }
            }

                    
                    
                    


                }
        public static void DeleteFile(string FilePath)
        {
            Console.WriteLine("Deleting file " + FilePath);
            System.IO.File.Delete(FilePath);
        }

    }

       



        //catch (IOException ex)
        //{
        //    Console.WriteLine(ex);
        //    Console.ReadLine();
        //}

    }





