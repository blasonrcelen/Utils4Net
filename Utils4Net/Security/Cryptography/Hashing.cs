using System.Security.Cryptography;

namespace Utils4Net.Security.Cryptography
{
    public enum HashAlgorithms
    {
        MD5,
        SHA1,
        SHA256,
        SHA384,
        SHA512
    }

    public static class HashExtensions
    {
        public static HashAlgorithm GetHashAlgorithm(this HashAlgorithms algorithm)
        {
            return algorithm switch
            {
                HashAlgorithms.MD5 => System.Security.Cryptography.MD5.Create(),
                HashAlgorithms.SHA1 => System.Security.Cryptography.SHA1.Create(),
                HashAlgorithms.SHA256 => System.Security.Cryptography.SHA256.Create(),
                HashAlgorithms.SHA384 => System.Security.Cryptography.SHA384.Create(),
                HashAlgorithms.SHA512 => System.Security.Cryptography.SHA512.Create(),
                _ => throw new ArgumentException(nameof(algorithm) + " is a invalid algorithm")
            };
        }

        public static Hashing GetHash(this HashAlgorithms algorithm, byte[] data, uint iterations = 1, byte[]? salt = null)
        {
            return new Hashing(GetHashAlgorithm(algorithm), data, iterations, salt);
        }
    }

    public class Hashing : IEquatable<Hashing>
    {
        public readonly HashAlgorithm Algorithm;
        public readonly byte[] Data;
        public readonly byte[] Salt;
        public readonly byte[] Hash;
        public readonly uint Iterations;

        public Hashing(HashAlgorithm algorithm, byte[] data, uint iterations = 1, byte[]? salt = null)
        {
            if (data == null || data.Length == 0)
            {
                throw new ArgumentException(nameof(data) + " can't be null or empty.");
            }

            if (iterations == 0)
            {
                throw new ArgumentException(nameof(iterations) + " can't be ZERO.");
            }

            Algorithm = algorithm ?? throw new ArgumentNullException(nameof(algorithm));
            Data = data;
            Iterations = iterations;
            Salt = salt == null || salt.Length == 0 ? Generators.GetRandomBytes(500) : salt;
            Hash = algorithm != null ? ComputeHash() : data;
        }

        /*
         * Compute Hash
         */
        private byte[] ComputeHash()
        {
            byte[] dataPlusSalt = new byte[Data.Length + Salt.Length];
            Data.CopyTo(dataPlusSalt, 0);
            Salt.CopyTo(dataPlusSalt, Data.Length);

            byte[] hash = Algorithm.ComputeHash(dataPlusSalt);
            byte[] stretching = Array.Empty<byte>();
            for (uint i = 1; i < Iterations; i++)
            {
                stretching = KeyStretching(stretching, hash);
                hash = Algorithm.ComputeHash(stretching);
            }

            return hash;
        }

        private byte[] KeyStretching(byte[] data, byte[] hash)
        {
            byte[] stretching = new byte[data.Length + hash.Length + Salt.Length];
            data.CopyTo(stretching, 0);
            hash.CopyTo(stretching, data.Length);
            Salt.CopyTo(stretching, data.Length + hash.Length);
            return stretching;
        }

        /*
         * IEquatable
         */
        public bool Equals(Hashing? other)
        {
            return other?.Hash == Hash;
        }

        public bool Equals(byte[] hash)
        {
            return Convert.ToBase64String(hash).Equals(Convert.ToBase64String(Hash));
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Hashing);
        }

        public static bool operator ==(Hashing op1, Hashing op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator ==(Hashing op1, byte[] op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator ==(byte[] op1, Hashing op2)
        {
            return op2.Equals(op1);
        }

        public static bool operator !=(Hashing op1, Hashing op2)
        {
            return !op1.Equals(op2);
        }

        public static bool operator !=(Hashing op1, byte[] op2)
        {
            return !op1.Equals(op2);
        }

        public static bool operator !=(byte[] op1, Hashing op2)
        {
            return !op2.Equals(op1);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /*
         * To
         */
        public string ToBase64String()
        {
            return Convert.ToBase64String(Hash);
        }

        public string ToHexString()
        {
            return BitConverter.ToString(Hash);
        }

        public override string ToString()
        {
            return ToBase64String();
        }

    }

    public class MD5 : Hashing
    {
        public MD5(byte[] data, uint iterations = 1, byte[]? salt = null) : base(System.Security.Cryptography.MD5.Create(), data, iterations, salt)
        {
        }
    }

    public class SHA1 : Hashing
    {
        public SHA1(byte[] data, uint iterations = 1, byte[]? salt = null) : base(System.Security.Cryptography.SHA1.Create(), data, iterations, salt)
        {
        }
    }

    public class SHA256 : Hashing
    {
        public SHA256(byte[] data, uint iterations = 1, byte[]? salt = null) : base(System.Security.Cryptography.SHA256.Create(), data, iterations, salt)
        {
        }
    }

    public class SHA384 : Hashing
    {
        public SHA384(byte[] data, uint iterations = 1, byte[]? salt = null) : base(System.Security.Cryptography.SHA384.Create(), data, iterations, salt)
        {
        }
    }

    public class SHA512 : Hashing
    {
        public SHA512(byte[] data, uint iterations = 1, byte[]? salt = null) : base(System.Security.Cryptography.SHA512.Create(), data, iterations, salt)
        {
        }
    }

}
