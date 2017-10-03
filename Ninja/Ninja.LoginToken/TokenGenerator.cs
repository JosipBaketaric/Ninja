using System;
using System.Security.Cryptography;

namespace Ninja.LoginToken
{
    //Author: josipba
    //Machine: P004794
    //Created: 10/3/2017 8:28:50 AM
    public class TokenGenerator
    {
        private string Sequence = "abcdefghijklmnoprstuvzxywqzABCDEFGHIJKLMNOPRSTUVZXYWQZ1234567890-_";
        private int TokenLength = 0x00000024;


        public string GenerateToken()
        {
            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
            byte[] randomNumbers = new byte[8];
            string token = "";

            for (int i = 0; i < TokenLength; i++)
            {
                rngCsp.GetBytes(randomNumbers);
                ulong value = BitConverter.ToUInt64(randomNumbers, 0);
                var result = (int)(value % (ulong)Sequence.Length);
                token += Sequence[result];
            }



            return token;
        }


    }
}
