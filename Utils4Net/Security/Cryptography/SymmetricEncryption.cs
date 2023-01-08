using System.Security.Cryptography;

namespace Utils4Net.Security.Cryptography
{
    public enum SymmetricEncryptionAlgorithms
    {
        AES128,
        AES192,
        AES256,
        DES,
        TRIPLE_DES128,
        TRIPLE_DES192
    }

    public static class SymmetricEncryptionAlgorithmsExtension
    {
        public static SymmetricAlgorithm GetSymmetricAlgorithm(this SymmetricEncryptionAlgorithms algorithm)
        {
            SymmetricAlgorithm symmetricAlgorithm;
            switch (algorithm)
            {
                case SymmetricEncryptionAlgorithms.AES128:
                    symmetricAlgorithm = Aes.Create();
                    symmetricAlgorithm.KeySize = 128;
                    return symmetricAlgorithm;
                case SymmetricEncryptionAlgorithms.AES192:
                    symmetricAlgorithm = Aes.Create();
                    symmetricAlgorithm.KeySize = 192;
                    return symmetricAlgorithm;
                case SymmetricEncryptionAlgorithms.AES256:
                    symmetricAlgorithm = Aes.Create();
                    symmetricAlgorithm.KeySize = 256;
                    return symmetricAlgorithm;
                case SymmetricEncryptionAlgorithms.DES:
                    symmetricAlgorithm = System.Security.Cryptography.DES.Create();
                    return symmetricAlgorithm;
                case SymmetricEncryptionAlgorithms.TRIPLE_DES128:
                    symmetricAlgorithm = TripleDES.Create();
                    symmetricAlgorithm.KeySize = 128;
                    return symmetricAlgorithm;
                case SymmetricEncryptionAlgorithms.TRIPLE_DES192:
                    symmetricAlgorithm = TripleDES.Create();
                    symmetricAlgorithm.KeySize = 192;
                    return symmetricAlgorithm;
                default: throw new ArgumentException(nameof(algorithm) + " is not a valid algorithm");
            }
        }

        public static byte[] Encrypt(this SymmetricEncryptionAlgorithms algorithm, byte[] key, byte[] iv, byte[] data)
        {
            return new SymmetricEncryption(GetSymmetricAlgorithm(algorithm), key, iv).Encrypt(data);
        }

        public static byte[] Encrypt(this SymmetricEncryptionAlgorithms algorithm, CipherMode mode, byte[] key, byte[] iv, byte[] data)
        {
            return new SymmetricEncryption(GetSymmetricAlgorithm(algorithm), mode, key, iv).Encrypt(data);
        }

        public static byte[] Decrypt(this SymmetricEncryptionAlgorithms algorithm, byte[] key, byte[] iv, byte[] data)
        {
            return new SymmetricEncryption(GetSymmetricAlgorithm(algorithm), key, iv).Decrypt(data);
        }

        public static byte[] Decrypt(this SymmetricEncryptionAlgorithms algorithm, CipherMode mode, byte[] key, byte[] iv, byte[] data)
        {
            return new SymmetricEncryption(GetSymmetricAlgorithm(algorithm), mode, key, iv).Decrypt(data);
        }

        public static byte[] GenerateKey(this SymmetricEncryptionAlgorithms algorithm)
        {
            SymmetricAlgorithm symmetricAlgorithm = GetSymmetricAlgorithm(algorithm);
            symmetricAlgorithm.GenerateKey();
            return symmetricAlgorithm.Key;
        }

        public static byte[] GenerateIv(this SymmetricEncryptionAlgorithms algorithm)
        {
            SymmetricAlgorithm symmetricAlgorithm = GetSymmetricAlgorithm(algorithm);
            symmetricAlgorithm.GenerateIV();
            return symmetricAlgorithm.IV;
        }
    }

    public class SymmetricEncryption
    {
        public readonly SymmetricAlgorithm Algorithm;

        public SymmetricEncryption(SymmetricAlgorithm algorithm) :
        this(algorithm, CipherMode.CBC)
        {
        }

        public SymmetricEncryption(SymmetricAlgorithm algorithm, CipherMode mode) :
        this(algorithm, mode, Array.Empty<byte>(), Array.Empty<byte>())
        {
        }

        public SymmetricEncryption(SymmetricAlgorithm algorithm, byte[]? key, byte[]? iv) :
        this(algorithm, CipherMode.CBC, key, iv)
        {
        }

        public SymmetricEncryption(SymmetricAlgorithm algorithm, CipherMode mode, byte[]? key, byte[]? iv)
        {
            Algorithm = algorithm ?? throw new ArgumentNullException(nameof(algorithm));
            Algorithm.Mode = mode;

            if (key == null || key.Length == 0)
            {
                Algorithm.GenerateKey();
            }
            else
            {
                Algorithm.Key = key;
            }

            if (iv == null || iv.Length == 0)
            {
                Algorithm.GenerateIV();
            }
            else
            {
                Algorithm.IV = iv;
            }
        }

        public byte[] Decrypt(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (data.Length == 0)
            {
                throw new ArgumentException(nameof(data) + " is empty");
            }

            byte[] decryptedData = new byte[data.Length];
            using (MemoryStream ms = new())
            {
                using (CryptoStream cs = new(ms, Algorithm.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                    cs.Close();
                }
                decryptedData = ms.ToArray();
            }
            Algorithm.Clear();
            return decryptedData;
        }

        public string Decrypt(string data)
        {
            return Convert.ToBase64String(Decrypt(Convert.FromBase64String(data)));
        }

        public byte[] Encrypt(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (data.Length == 0)
            {
                throw new ArgumentException(nameof(data) + " is empty");
            }

            byte[] encryptedData = new byte[data.Length];
            using (MemoryStream ms = new())
            {
                using (CryptoStream cs = new(ms, Algorithm.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                    cs.Close();
                }
                encryptedData = ms.ToArray();
            }
            Algorithm.Clear();
            return encryptedData;
        }

        public string Encrypt(string data)
        {
            return Convert.ToBase64String(Encrypt(Convert.FromBase64String(data)));
        }
    }

    public class AES128 : SymmetricEncryption
    {
        public AES128() : base(SymmetricEncryptionAlgorithms.AES128.GetSymmetricAlgorithm())
        {
        }

        public AES128(CipherMode mode) : base(SymmetricEncryptionAlgorithms.AES128.GetSymmetricAlgorithm(), mode)
        {
        }

        public AES128(byte[] key, byte[] iv) : base(SymmetricEncryptionAlgorithms.AES128.GetSymmetricAlgorithm(), key, iv)
        {
        }

        public AES128(CipherMode mode, byte[] key, byte[] iv) : base(SymmetricEncryptionAlgorithms.AES128.GetSymmetricAlgorithm(), mode, key, iv)
        {
        }
    }

    public class AES192 : SymmetricEncryption
    {
        public AES192() : base(SymmetricEncryptionAlgorithms.AES192.GetSymmetricAlgorithm())
        {
        }

        public AES192(CipherMode mode) : base(SymmetricEncryptionAlgorithms.AES192.GetSymmetricAlgorithm(), mode)
        {
        }

        public AES192(byte[] key, byte[] iv) : base(SymmetricEncryptionAlgorithms.AES192.GetSymmetricAlgorithm(), key, iv)
        {
        }

        public AES192(CipherMode mode, byte[] key, byte[] iv) : base(SymmetricEncryptionAlgorithms.AES192.GetSymmetricAlgorithm(), mode, key, iv)
        {
        }
    }

    public class AES256 : SymmetricEncryption
    {
        public AES256() : base(SymmetricEncryptionAlgorithms.AES256.GetSymmetricAlgorithm())
        {
        }

        public AES256(CipherMode mode) : base(SymmetricEncryptionAlgorithms.AES256.GetSymmetricAlgorithm(), mode)
        {
        }

        public AES256(byte[] key, byte[] iv) : base(SymmetricEncryptionAlgorithms.AES256.GetSymmetricAlgorithm(), key, iv)
        {
        }

        public AES256(CipherMode mode, byte[] key, byte[] iv) : base(SymmetricEncryptionAlgorithms.AES256.GetSymmetricAlgorithm(), mode, key, iv)
        {
        }
    }

    public class DES : SymmetricEncryption
    {
        public DES() : base(SymmetricEncryptionAlgorithms.DES.GetSymmetricAlgorithm())
        {
        }

        public DES(CipherMode mode) : base(SymmetricEncryptionAlgorithms.DES.GetSymmetricAlgorithm(), mode)
        {
        }

        public DES(byte[] key, byte[] iv) : base(SymmetricEncryptionAlgorithms.DES.GetSymmetricAlgorithm(), key, iv)
        {
        }

        public DES(CipherMode mode, byte[] key, byte[] iv) : base(SymmetricEncryptionAlgorithms.DES.GetSymmetricAlgorithm(), mode, key, iv)
        {
        }
    }

    public class TripleDES128 : SymmetricEncryption
    {
        public TripleDES128() : base(SymmetricEncryptionAlgorithms.TRIPLE_DES128.GetSymmetricAlgorithm())
        {
        }

        public TripleDES128(CipherMode mode) : base(SymmetricEncryptionAlgorithms.TRIPLE_DES128.GetSymmetricAlgorithm(), mode)
        {
        }

        public TripleDES128(byte[] key, byte[] iv) : base(SymmetricEncryptionAlgorithms.TRIPLE_DES128.GetSymmetricAlgorithm(), key, iv)
        {
        }

        public TripleDES128(CipherMode mode, byte[] key, byte[] iv) : base(SymmetricEncryptionAlgorithms.TRIPLE_DES128.GetSymmetricAlgorithm(), mode, key, iv)
        {
        }
    }

    public class TripleDES192 : SymmetricEncryption
    {
        public TripleDES192() : base(SymmetricEncryptionAlgorithms.TRIPLE_DES192.GetSymmetricAlgorithm())
        {
        }

        public TripleDES192(CipherMode mode) : base(SymmetricEncryptionAlgorithms.TRIPLE_DES192.GetSymmetricAlgorithm(), mode)
        {
        }

        public TripleDES192(byte[] key, byte[] iv) : base(SymmetricEncryptionAlgorithms.TRIPLE_DES192.GetSymmetricAlgorithm(), key, iv)
        {
        }

        public TripleDES192(CipherMode mode, byte[] key, byte[] iv) : base(SymmetricEncryptionAlgorithms.TRIPLE_DES192.GetSymmetricAlgorithm(), mode, key, iv)
        {
        }
    }
}
