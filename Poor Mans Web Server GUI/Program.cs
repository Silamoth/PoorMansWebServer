using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using System.Diagnostics;
using System.Text;

namespace Poor_Mans_Web_Server_GUI
{
    static class Program
    {
        public static String phpExeDirectory = String.Empty;
        public static String directory = "";
        public static String defaultPage = "";

        static MainForm form = new MainForm();        
        static TcpListener listener = new TcpListener(form.port);
        static String toBeAdded = String.Empty;
        static Thread initThread;
        static Thread networkThread;
        static bool doStuff =  false;               

        [STAThread]
        static void Main()
        {
            initThread = new Thread(new ThreadStart(Init));
            networkThread = new Thread(new ThreadStart(CheckForStuff));
            
            initThread.Start();
            //networkThread.Start();
        }

        static void Init()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form);
        }

        static void CheckForStuff()
        {
            while (doStuff)
            {
                listener.Start();

                while (doStuff)
                {
                    TcpClient client = listener.AcceptTcpClient();

                    StreamReader reader = new StreamReader(client.GetStream());
                    StreamWriter writer = new StreamWriter(client.GetStream());

                    try
                    {
                        String request = reader.ReadLine();

                        toBeAdded = request;

                        Del del = new Del(GetToBeAdded);

                        form.Invoke(del);

                        String[] tokens = request.Split(' ');

                        String page = tokens[1];

                        if (page == "/")
                            page = defaultPage;

                        StreamReader file = new StreamReader(directory + page);

                        FileInfo fileInfo = new FileInfo(directory + page);

                        if (fileInfo.Extension.ToLower() == ".php")
                        {
                            Process process = new Process();
                            ProcessStartInfo processInfo = new ProcessStartInfo(phpExeDirectory, "spawn");
                            processInfo.UseShellExecute = false;
                            processInfo.RedirectStandardOutput = true;
                            processInfo.WorkingDirectory = directory;

                            //Console.WriteLine(directory.Remove(directory.IndexOf("/"), 1) + "\\" + page.Remove(page.IndexOf("/"), 1));

                            if (page.Contains("/"))
                                processInfo.Arguments = String.Format("{0} {1} {2}", @"-f", page.Remove(page.IndexOf("/"), 1), @"");
                            else
                                processInfo.Arguments = String.Format("{0} {1} {2}", @"-f", page, @"");

                            process.StartInfo = processInfo;

                            process.Start();

                            StreamReader phpReader = process.StandardOutput;

                            writer.WriteLine("HTTP/1.0 200 OK\n");

                            String data = phpReader.ReadLine();

                            while (data != null)
                            {
                                writer.WriteLine(data);
                                writer.Flush();

                                data = phpReader.ReadLine();
                            }
                        }
                        else if (fileInfo.Extension.ToLower() == ".png" || fileInfo.Extension.ToLower() == ".jpg" || fileInfo.Extension.ToLower() == ".jpeg" ||
                            fileInfo.Extension.ToLower() == ".gif" || fileInfo.Extension.ToLower() == ".ico")
                        {
                            writer.WriteLine("HTTP/1.0 200 OK\n");
                            //reader.Close();

                            //Console.WriteLine(directory.Remove(directory.IndexOf("/"), 1) + "\\" + fileInfo.Name);
                            FileStream stream = fileInfo.OpenRead();
                            byte[] ar;

                            using(FileStream fstream = new FileStream(fileInfo.FullName,FileMode.Open,FileAccess.Read))
                            {
                                ar = new byte[fstream.Length];

                                fstream.Read(ar, 0, (int)fstream.Length);
                            }

                            StringBuilder sbHeader = new StringBuilder();
                            sbHeader.AppendLine("HTTP/1.1 200 OK");
                            sbHeader.AppendLine("Content-Length: " + ar.Length);
                            sbHeader.AppendLine();

                            List<Byte> response = new List<Byte>();
                            response.AddRange(Encoding.ASCII.GetBytes(sbHeader.ToString()));
                            response.AddRange(ar);

                            byte[] responseByte = response.ToArray();

                            writer.BaseStream.Write(responseByte, 0, responseByte.Length);
                            writer.Flush();
                        }
                        else /*/(fileInfo.Extension == ".html" || fileInfo.Extension == ".htm")/*/
                        {
                            writer.WriteLine("HTTP/1.0 200 OK\n");

                            String data = file.ReadLine();

                            while (data != null)
                            {
                                writer.WriteLine(data);
                                writer.Flush();

                                data = file.ReadLine();
                            }
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        //writer.WriteLine("HTTP/1.0 404 ERROR");
                        //writer.WriteLine("<h1>Unfortunately, an error occurred...</h1>");
                        //writer.Flush();
                    }

                    client.Close();
                }
            }
        }

        static void GetToBeAdded()
        {
            form.InsertInTextBox(toBeAdded);
        }

        public static void setDoStuff(bool value)
        {
            doStuff = value;

            if (doStuff)
            {
                if (!networkThread.IsAlive)
                    networkThread.Start();
                else
                    networkThread.Resume();
            }
            else
                networkThread.Suspend();
        }

        public static bool getDoStuff()
        {
            return doStuff;
        }

        delegate void Del();
    }
}
