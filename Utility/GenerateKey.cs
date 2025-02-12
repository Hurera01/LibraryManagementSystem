using System.Security.Cryptography;

namespace LibraryManagementSystem.Utility
{
    public class GenerateKey
    {
        public static void generate() {
            Console.WriteLine(Convert.ToBase64String(RandomNumberGenerator.GetBytes(32)));
        }

        public static void main(string[] args) 
        {
            generate();    
        }

    }
}
