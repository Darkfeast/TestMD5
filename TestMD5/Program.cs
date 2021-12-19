using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TestMD5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string path = @"C:/Apo/MD5/";

            if (Directory.Exists(path))
            {
                string[] files= Directory.GetFiles(path);
                for (int i = 0; i < files.Length; i++)
                {
                    string md5= GetMD5(files[i]);
                    Console.WriteLine($"{files[i]}   {md5}");
                }
            }
            else
            {
                Console.WriteLine($"path not exist {path}");
            }
        }

        public static string GetMD5(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            int len = (int) fs.Length;
            byte[] data = new byte[len];
            fs.Read(data, 0, len);
            fs.Close();
                
            MD5 md5 = MD5.Create();
            // DF.Log(data.ToString()  +"      "+data.Length,E_ColorType.Temp);
            byte[] result = md5.ComputeHash(data);
            string fileMD5 = "";
            foreach (byte b in result)
            {
                fileMD5 += Convert.ToString(b, 16);
            }

            //或者
            //for (int i = 0; i < result.Length; i++)
            //{

            //	//“x2”表示输出按照16进制，且为2位对齐输出。
            //	fileMD5+=result[i].ToString("x2");
            //}

            return fileMD5;
        }
    }
}