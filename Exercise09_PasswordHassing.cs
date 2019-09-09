/*************************************
 * Name: Passwordauthentication
 * Author: Cherif Ouedraogo
 * Date: September 03,2019
 * 
 * ***********************************/


using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Exercise09_Hashing_Password
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintUI();
            
        }
       public static string username;
       public static  string password;
       public static Dictionary<string, string> MyUsersPasswords = new Dictionary<string, string>();

            private static void GetNewUser()
            {
                Console.WriteLine("Enter Username:");
                 username = Console.ReadLine();
                if (MyUsersPasswords.ContainsKey(username))
                {
                    Console.WriteLine("User already exists");
                    GetNewUser();
                }
            try
            {
                Console.WriteLine(" Enter Password: ");
                password = ReadPassword();
                MyUsersPasswords.Add(username, Encrypt(password));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(" The Username/password already exists in the dictionary",e.Message);
                PrintUI();
            }
               
                
            }
            private static void GetUser()
            {
                int match = 0;
                Console.WriteLine("Enter Username:");
                string matchUsername = Console.ReadLine();
                Console.WriteLine(" Enter Password: ");
                string matchpassword = Encrypt( ReadPassword());
                if(MyUsersPasswords.ContainsKey(matchUsername))
                {
                    foreach(KeyValuePair<string,string> kvp in MyUsersPasswords)
                        if(kvp.Key==matchUsername && kvp.Value==matchpassword)
                        {
                            match++;
                            Console.WriteLine(" The user and password match. Authentication was Successful!");
                        }
                    if(match==0)
                    {
                        Console.WriteLine(" The Password does not match. Authentication Failed!");
                    }
                }
                else
                {
                    Console.WriteLine(" Could not find the specified Username! Try Again or Create a new Username ");
                }

            }

                private static void PrintUsers()
            {
                foreach (KeyValuePair<string, string> e in MyUsersPasswords)
                {
                    Console.WriteLine($" Username(s)/Password(s):{ e}");
                }
            }

            public static void Exit()
            {
                System.Environment.Exit(0);
            }
           public static void PrintUI()
            {
                Console.WriteLine("----------------------------------------------------------\n");
                Console.WriteLine(" PASSWORD AUTHENTICATION SYSTEM \n");
                Console.WriteLine(" Please select one option: \n");
                Console.WriteLine(" 1. Establish an account\n 2. Authenticate a User\n 3. Exit the System \n");
                Console.Write(" Enter your Selection : \n\n");
                Console.WriteLine("----------------------------------------------------------");
                int user_input;

                if (!int.TryParse(Console.ReadLine(), out user_input))
                {
                    user_input = 4;
                }
                if(user_input==1)
                {
                    GetNewUser();
                    PrintUI();
                }
                else if(user_input==2)
                {
                    GetUser();
                    PrintUI();
                }
                else if(user_input==3)
                {
                Console.WriteLine(" AUTHENTICATION SYSTEM SESSION LOG REPORT ");
                Console.WriteLine();
                    PrintUsers();
                Console.WriteLine();
                    Exit();
                }
                else
                {
                  Console.WriteLine(" Invalid Input! Try Again!");
                    PrintUI();
                }
            }
                    
             
        public static string Encrypt(string plainText)
        {
             string PasswordHash = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ23456789";
            string SaltKey = "S@LT&KEY";
             string VIKey = "@1B2c3D4e5F6g7H8";
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        password = password.Substring(0, password.Length - 1);
                        int pos = Console.CursorLeft;
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
             Console.WriteLine();
            return password;
        }

    }
    
}
