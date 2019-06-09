﻿using System.Text;

namespace GameSpyLib.Extensions
{
    public static class ByteExtensions
    {
        /// <summary>
        /// Converts the byte array to its Hex string equivlent
        /// </summary>
        /// <param name="upperCase">Do we uppercase the hex string?</param>
        /// <returns></returns>
        public static string ToHex(this byte[] bytes, bool upperCase = true)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));

            return result.ToString();
        }


        public static byte[] GameNametoHex(string gamename)
        {
            //convert gamename to lower case
            gamename = gamename.ToLower();
            //return the hex byte array
            return Encoding.ASCII.GetBytes(gamename);
        }

    }
}
