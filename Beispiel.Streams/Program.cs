using System.IO.Compression;
using System.Net;
using System.Text;

namespace Beispiel.Streams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BeispielStreamWriter();
        }
        static void BeispielStreamWriter()
        {
            using (StreamWriter sw = File.CreateText("StreamWriter.txt"))
            {
                sw.WriteLine("Ein\nkleines\nbisschen\nText");
            }
            using (StreamReader sr = File.OpenText("StreamWriter.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        static void BeispielStreamReader()
        {
            WebRequest request = WebRequest.Create("http://www.if-schleife.de");
            WebResponse response = request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());
            string responseString = sr.ReadToEnd();
            Console.WriteLine(responseString);
        }
        static void GZipDecompression(string sourceFile, string destFile)
        {
            using (FileStream sourceFS = File.OpenRead(sourceFile))
            {
                using (FileStream destFS = File.Create(destFile))
                {
                    using (GZipStream gzipFS = new GZipStream(sourceFS, CompressionMode.Decompress))
                    {
                        gzipFS.CopyTo(destFS);
                    }
                }
            }
        }

        static void GZipCompression(string sourceFile, string destFile)
        {
            using (FileStream sourceFS = File.OpenRead(sourceFile))
            {
                using (FileStream destFS = File.Create(destFile))
                {
                    using (GZipStream gzipFS = new GZipStream(destFS, CompressionMode.Compress))
                    {
                        sourceFS.CopyTo(gzipFS);
                    }
                }
            }
        }
        static void BeispielFileStream()
        {
            string filename = "demo.bin";
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                byte[] arrayOut = Encoding.ASCII.GetBytes("Ein kleiner Text...");
                fs.Write(arrayOut, 0, arrayOut.Length);
                fs.Position++;
                fs.Position++;
                fs.Position++;
                fs.Write(arrayOut, 0, arrayOut.Length);
            }
            Console.WriteLine("press Enter");
            Console.ReadLine();
            byte[] bytesFromFile;

            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                bytesFromFile = new byte[fs.Length];
                fs.Position = 0;
                fs.Read(bytesFromFile, 0, bytesFromFile.Length);
            }

            string textFromFile = Encoding.ASCII.GetString(bytesFromFile);
            Console.WriteLine(textFromFile);
          
        }
    }
}