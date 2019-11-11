using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Threading;

namespace PasswordCrack 
{
    class Program
    {
        static void Main(string[] args)
        {
            string Hash = "";
            Console.WriteLine("Enter Your MD5 Hash : ");
            Hash = Console.ReadLine().ToUpper();
            
            string Pass = "";
            int Count = 0;
            bool closeLoop = true;
            
            StreamReader file = new StreamReader(@"rockyou.txt");
            
            while(closeLoop == true && (Pass = file.ReadLine()) != null)
            {
                if(MD5Hash(Pass) == Hash)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(Pass);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Cracked Hash = " + Pass+ "\n\r" + MD5Hash(Pass));
                    
                    Console.ResetColor();
                    Console.ReadKey();
                  
                    closeLoop = false;
                    
                    file.Close(); //close the file stream
                }
                
                else
                {
                    Console.WriteLine(Pass);
                }
                Count++;
                Console.Title = "Current Password Count : " + Count.ToString();
                Thread.Sleep(10); //if your cpu can handle more decrease number.
                
                
            }
            
            file.Close();
            Console.ReadKey();
        }
        
        public static string MD5Hash(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            MD5CryptoServiceProvider MD5Provider = new MD5CryptoServiceProvider();
            byte[] bytes = MD5Provider.ComputeHash(new UTF8Encoding().GetBytes(inputString));
            
            for(int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
