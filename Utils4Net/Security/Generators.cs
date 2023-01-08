using System.Security.Cryptography;
using System.Text;

namespace Utils4Net.Security
{
    public static class Generators
    {
        public static string GetRandomText(int length, string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-?!#=<>&$@%")
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            if (string.IsNullOrWhiteSpace(allowedChars))
            {
                throw new ArgumentException(nameof(allowedChars) + " is empty.");
            }

            if (allowedChars.Length > 256)
            {
                throw new ArgumentException(nameof(allowedChars) + " contain more than 256 characters.");
            }

            StringBuilder result = new();
            while (result.Length < length)
            {
                byte[] buf = GetRandomBytes(128);
                for (int i = 0; i < buf.Length && result.Length < length; ++i)
                {
                    int outOfRangeStart = 256 - (256 % allowedChars.Length);
                    if (outOfRangeStart <= buf[i])
                    {
                        continue;
                    }

                    result.Append(allowedChars[buf[i] % allowedChars.Length]);
                }
            }

            return result.ToString();
        }

        public static byte[] GetRandomBytes(int length)
        {
            byte[] randomData = new byte[length];
            RandomNumberGenerator.Fill(randomData);
            return randomData;
        }

        public static byte[] GetDerivationKey(byte[] key, int length)
        {
            return GetDerivationKey(Convert.ToBase64String(key), length);
        }

        public static byte[] GetDerivationKey(string key, int length)
        {
            return new Rfc2898DeriveBytes(key, length, 20, HashAlgorithmName.SHA512).GetBytes(length);
        }
    }
}
