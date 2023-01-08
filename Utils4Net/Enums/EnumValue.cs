using System.Reflection;

namespace Utils4Net.Enums
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class EnumValue : Attribute
    {
        public readonly object? Value;

        public EnumValue(object? value)
        {
            Value = value;
        }

        public static T? Get<T>(Enum _enum, int index = 0)
        {
            EnumValue[]? values = (EnumValue[]?)(_enum?.GetType()?.GetField(_enum.ToString())?.GetCustomAttributes<EnumValue>());

            if (values == null || values.Length == 0)
            {
                throw new Exception("Enumerable does not contain an EnumValue");
            }

            return (T?)values[index].Value;
        }

        public static bool GetBool(Enum _enum, int index = 0)
        {
            return Get<bool>(_enum, index);
        }

        public static byte GetByte(Enum _enum, int index = 0)
        {
            return Get<byte>(_enum, index);
        }

        public static sbyte GetSByte(Enum _enum, int index = 0)
        {
            return Get<sbyte>(_enum, index);
        }

        public static short GetShort(Enum _enum, int index = 0)
        {
            return Get<short>(_enum, index);
        }

        public static ushort GetUShort(Enum _enum, int index = 0)
        {
            return Get<ushort>(_enum, index);
        }

        public static int GetInt(Enum _enum, int index = 0)
        {
            return Get<int>(_enum, index);
        }

        public static uint GetUInt(Enum _enum, int index = 0)
        {
            return Get<uint>(_enum, index);
        }

        public static long GetLong(Enum _enum, int index = 0)
        {
            return Get<long>(_enum, index);
        }

        public static ulong GetULong(Enum _enum, int index = 0)
        {
            return Get<ulong>(_enum, index);
        }

        public static float GetFloat(Enum _enum, int index = 0)
        {
            return Get<float>(_enum, index);
        }

        public static double GetDouble(Enum _enum, int index = 0)
        {
            return Get<double>(_enum, index);
        }

        public static decimal GetDecimal(Enum _enum, int index = 0)
        {
            return Get<decimal>(_enum, index);
        }

        public static char GetChar(Enum _enum, int index = 0)
        {
            return Get<char>(_enum, index);
        }

        public static string? GetString(Enum _enum, int index = 0)
        {
            return Get<string>(_enum, index);
        }

        public static DateTime GetDateTime(Enum _enum, int index = 0)
        {
            return Get<DateTime>(_enum, index);
        }

        public static object? GetObject(Enum _enum, int index = 0)
        {
            return Get<object>(_enum, index);
        }
    }

    public static class EnumValueExtensions
    {
        public static T? Get<T>(this Enum _enum, int index = 0)
        {
            return EnumValue.Get<T>(_enum, index);
        }

        public static bool GetBool(this Enum _enum, int index = 0)
        {
            return EnumValue.GetBool(_enum, index);
        }

        public static byte GetByte(this Enum _enum, int index = 0)
        {
            return EnumValue.GetByte(_enum, index);
        }

        public static sbyte GetSByte(this Enum _enum, int index = 0)
        {
            return EnumValue.GetSByte(_enum, index);
        }

        public static short GetShort(this Enum _enum, int index = 0)
        {
            return EnumValue.GetShort(_enum, index);
        }

        public static ushort GetUShort(this Enum _enum, int index = 0)
        {
            return EnumValue.GetUShort(_enum, index);
        }

        public static int GetInt(this Enum _enum, int index = 0)
        {
            return EnumValue.GetInt(_enum, index);
        }

        public static uint GetUInt(this Enum _enum, int index = 0)
        {
            return EnumValue.GetUInt(_enum, index);
        }

        public static long GetLong(this Enum _enum, int index = 0)
        {
            return EnumValue.GetLong(_enum, index);
        }

        public static ulong GetULong(this Enum _enum, int index = 0)
        {
            return EnumValue.GetULong(_enum, index);
        }

        public static float GetFloat(this Enum _enum, int index = 0)
        {
            return EnumValue.GetFloat(_enum, index);
        }

        public static double GetDouble(this Enum _enum, int index = 0)
        {
            return EnumValue.GetDouble(_enum, index);
        }

        public static decimal GetDecimal(this Enum _enum, int index = 0)
        {
            return EnumValue.GetDecimal(_enum, index);
        }

        public static char GetChar(this Enum _enum, int index = 0)
        {
            return EnumValue.GetChar(_enum, index);
        }

        public static string? GetString(this Enum _enum, int index = 0)
        {
            return EnumValue.GetString(_enum, index);
        }

        public static DateTime GetDateTime(this Enum _enum, int index = 0)
        {
            return EnumValue.GetDateTime(_enum, index);
        }

        public static object? GetObject(this Enum _enum, int index = 0)
        {
            return EnumValue.GetObject(_enum, index);
        }
    }
}
