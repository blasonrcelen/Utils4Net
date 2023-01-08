namespace Utils4Net.Types
{
    public enum Types
    {
        Object,
        Bool,
        Byte,
        SByte,
        Char,
        Short,
        UShort,
        Int,
        UInt,
        Long,
        ULong,
        Float,
        Double,
        Decimal,
        String,
        DateTime
    }

    public static class TypesHelper
    {
        public static Types GetType(object value)
        {
            return GetType(value.GetType());
        }

        public static Types GetType<T>()
        {
            return GetType(typeof(T));
        }

        public static Types GetType(Type type)
        {
            if (type == typeof(bool))
            {
                return Types.Bool;
            }

            if (type == typeof(byte))
            {
                return Types.Byte;
            }

            if (type == typeof(sbyte))
            {
                return Types.SByte;
            }

            if (type == typeof(char))
            {
                return Types.Char;
            }

            if (type == typeof(short))
            {
                return Types.Short;
            }

            if (type == typeof(ushort))
            {
                return Types.UShort;
            }

            if (type == typeof(int))
            {
                return Types.Int;
            }

            if (type == typeof(uint))
            {
                return Types.UInt;
            }

            if (type == typeof(long))
            {
                return Types.Long;
            }

            if (type == typeof(ulong))
            {
                return Types.ULong;
            }

            if (type == typeof(float))
            {
                return Types.Float;
            }

            if (type == typeof(double))
            {
                return Types.Double;
            }

            if (type == typeof(decimal))
            {
                return Types.Decimal;
            }

            if (type == typeof(string))
            {
                return Types.String;
            }

            if (type == typeof(DateTime))
            {
                return Types.DateTime;
            }

            return Types.Object;
        }

        /*
         * Defaults
         */
        public static object? Default(this Types type)
        {
            return type switch
            {

                Types.Object => default(object),
                Types.Bool => default(bool),
                Types.Byte => default(byte),
                Types.SByte => default(sbyte),
                Types.Char => default(char),
                Types.Short => default(short),
                Types.UShort => default(ushort),
                Types.Int => default(int),
                Types.UInt => default(uint),
                Types.Long => default(long),
                Types.ULong => default(ulong),
                Types.Float => default(float),
                Types.Double => default(double),
                Types.Decimal => default(decimal),
                Types.String => default(string),
                Types.DateTime => default(DateTime),
                _ => throw new Exception(nameof(type) + " is not defined")
            };
        }

        /*
         * TO METHODS
         */
        public static bool ToBool(this Types type, object value)
        {
            return type switch
            {
                Types.Object => Convert.ToBoolean(value),
                Types.Bool => Convert.ToBoolean((bool)value),
                Types.Byte => Convert.ToBoolean((byte)value),
                Types.SByte => Convert.ToBoolean((sbyte)value),
                Types.Char => Convert.ToBoolean((char)value),
                Types.Short => Convert.ToBoolean((short)value),
                Types.UShort => Convert.ToBoolean((ushort)value),
                Types.Int => Convert.ToBoolean((int)value),
                Types.UInt => Convert.ToBoolean((uint)value),
                Types.Long => Convert.ToBoolean((long)value),
                Types.ULong => Convert.ToBoolean((ulong)value),
                Types.Float => Convert.ToBoolean((float)value),
                Types.Double => Convert.ToBoolean((double)value),
                Types.Decimal => Convert.ToBoolean((decimal)value),
                Types.String => Convert.ToBoolean((string)value),
                Types.DateTime => Convert.ToBoolean((DateTime)value),
                _ => throw new Exception(nameof(type) + " is not defined")
            };
        }

        public static byte ToByte(this Types type, object value)
        {
            return type switch
            {
                Types.Object => Convert.ToByte(value),
                Types.Bool => Convert.ToByte((bool)value),
                Types.Byte => Convert.ToByte((byte)value),
                Types.SByte => Convert.ToByte((sbyte)value),
                Types.Char => Convert.ToByte((char)value),
                Types.Short => Convert.ToByte((short)value),
                Types.UShort => Convert.ToByte((ushort)value),
                Types.Int => Convert.ToByte((int)value),
                Types.UInt => Convert.ToByte((uint)value),
                Types.Long => Convert.ToByte((long)value),
                Types.ULong => Convert.ToByte((ulong)value),
                Types.Float => Convert.ToByte((float)value),
                Types.Double => Convert.ToByte((double)value),
                Types.Decimal => Convert.ToByte((decimal)value),
                Types.String => Convert.ToByte((string)value),
                Types.DateTime => Convert.ToByte((DateTime)value),
                _ => throw new Exception(nameof(type) + " is not defined")
            };
        }

        public static sbyte ToSByte(this Types type, object value)
        {
            return type switch
            {
                Types.Object => Convert.ToSByte(value),
                Types.Bool => Convert.ToSByte((bool)value),
                Types.Byte => Convert.ToSByte((byte)value),
                Types.SByte => Convert.ToSByte((sbyte)value),
                Types.Char => Convert.ToSByte((char)value),
                Types.Short => Convert.ToSByte((short)value),
                Types.UShort => Convert.ToSByte((ushort)value),
                Types.Int => Convert.ToSByte((int)value),
                Types.UInt => Convert.ToSByte((uint)value),
                Types.Long => Convert.ToSByte((long)value),
                Types.ULong => Convert.ToSByte((ulong)value),
                Types.Float => Convert.ToSByte((float)value),
                Types.Double => Convert.ToSByte((double)value),
                Types.Decimal => Convert.ToSByte((decimal)value),
                Types.String => Convert.ToSByte((string)value),
                Types.DateTime => Convert.ToSByte((DateTime)value),
                _ => throw new Exception(nameof(type) + " is not defined")
            };
        }

        public static char ToChar(this Types type, object value)
        {
            return type switch
            {
                Types.Object => Convert.ToChar(value),
                Types.Bool => Convert.ToChar((bool)value),
                Types.Byte => Convert.ToChar((byte)value),
                Types.SByte => Convert.ToChar((sbyte)value),
                Types.Char => Convert.ToChar((char)value),
                Types.Short => Convert.ToChar((short)value),
                Types.UShort => Convert.ToChar((ushort)value),
                Types.Int => Convert.ToChar((int)value),
                Types.UInt => Convert.ToChar((uint)value),
                Types.Long => Convert.ToChar((long)value),
                Types.ULong => Convert.ToChar((ulong)value),
                Types.Float => Convert.ToChar((float)value),
                Types.Double => Convert.ToChar((double)value),
                Types.Decimal => Convert.ToChar((decimal)value),
                Types.String => Convert.ToChar((string)value),
                Types.DateTime => Convert.ToChar((DateTime)value),
                _ => throw new Exception(nameof(type) + " is not defined")
            };
        }

        public static short ToShort(this Types type, object value)
        {
            return type switch
            {
                Types.Object => Convert.ToInt16(value),
                Types.Bool => Convert.ToInt16((bool)value),
                Types.Byte => Convert.ToInt16((byte)value),
                Types.SByte => Convert.ToInt16((sbyte)value),
                Types.Char => Convert.ToInt16((char)value),
                Types.Short => Convert.ToInt16((short)value),
                Types.UShort => Convert.ToInt16((ushort)value),
                Types.Int => Convert.ToInt16((int)value),
                Types.UInt => Convert.ToInt16((uint)value),
                Types.Long => Convert.ToInt16((long)value),
                Types.ULong => Convert.ToInt16((ulong)value),
                Types.Float => Convert.ToInt16((float)value),
                Types.Double => Convert.ToInt16((double)value),
                Types.Decimal => Convert.ToInt16((decimal)value),
                Types.String => Convert.ToInt16((string)value),
                Types.DateTime => Convert.ToInt16((DateTime)value),
                _ => throw new Exception(nameof(type) + " is not defined")
            };
        }

        public static ushort ToUShort(this Types type, object value)
        {
            return type switch
            {
                Types.Object => Convert.ToUInt16(value),
                Types.Bool => Convert.ToUInt16((bool)value),
                Types.Byte => Convert.ToUInt16((byte)value),
                Types.SByte => Convert.ToUInt16((sbyte)value),
                Types.Char => Convert.ToUInt16((char)value),
                Types.Short => Convert.ToUInt16((short)value),
                Types.UShort => Convert.ToUInt16((ushort)value),
                Types.Int => Convert.ToUInt16((int)value),
                Types.UInt => Convert.ToUInt16((uint)value),
                Types.Long => Convert.ToUInt16((long)value),
                Types.ULong => Convert.ToUInt16((ulong)value),
                Types.Float => Convert.ToUInt16((float)value),
                Types.Double => Convert.ToUInt16((double)value),
                Types.Decimal => Convert.ToUInt16((decimal)value),
                Types.String => Convert.ToUInt16((string)value),
                Types.DateTime => Convert.ToUInt16((DateTime)value),
                _ => throw new Exception(nameof(type) + " is not defined")
            };
        }

        public static int ToInt(this Types type, object value)
        {
            return type switch
            {
                Types.Object => Convert.ToInt32(value),
                Types.Bool => Convert.ToInt32((bool)value),
                Types.Byte => Convert.ToInt32((byte)value),
                Types.SByte => Convert.ToInt32((sbyte)value),
                Types.Char => Convert.ToInt32((char)value),
                Types.Short => Convert.ToInt32((short)value),
                Types.UShort => Convert.ToInt32((ushort)value),
                Types.Int => Convert.ToInt32((int)value),
                Types.UInt => Convert.ToInt32((uint)value),
                Types.Long => Convert.ToInt32((long)value),
                Types.ULong => Convert.ToInt32((ulong)value),
                Types.Float => Convert.ToInt32((float)value),
                Types.Double => Convert.ToInt32((double)value),
                Types.Decimal => Convert.ToInt32((decimal)value),
                Types.String => Convert.ToInt32((string)value),
                Types.DateTime => Convert.ToInt32((DateTime)value),
                _ => throw new Exception(nameof(type) + " is not defined")
            };
        }

        public static uint ToUInt(this Types type, object value)
        {
            return type switch
            {
                Types.Object => Convert.ToUInt32(value),
                Types.Bool => Convert.ToUInt32((bool)value),
                Types.Byte => Convert.ToUInt32((byte)value),
                Types.SByte => Convert.ToUInt32((sbyte)value),
                Types.Char => Convert.ToUInt32((char)value),
                Types.Short => Convert.ToUInt32((short)value),
                Types.UShort => Convert.ToUInt32((ushort)value),
                Types.Int => Convert.ToUInt32((int)value),
                Types.UInt => Convert.ToUInt32((uint)value),
                Types.Long => Convert.ToUInt32((long)value),
                Types.ULong => Convert.ToUInt32((ulong)value),
                Types.Float => Convert.ToUInt32((float)value),
                Types.Double => Convert.ToUInt32((double)value),
                Types.Decimal => Convert.ToUInt32((decimal)value),
                Types.String => Convert.ToUInt32((string)value),
                Types.DateTime => Convert.ToUInt32((DateTime)value),
                _ => throw new Exception(nameof(type) + " is not defined")
            };
        }

        public static long ToLong(this Types type, object value)
        {
            return type switch
            {
                Types.Object => Convert.ToInt64(value),
                Types.Bool => Convert.ToInt64((bool)value),
                Types.Byte => Convert.ToInt64((byte)value),
                Types.SByte => Convert.ToInt64((sbyte)value),
                Types.Char => Convert.ToInt64((char)value),
                Types.Short => Convert.ToInt64((short)value),
                Types.UShort => Convert.ToInt64((ushort)value),
                Types.Int => Convert.ToInt64((int)value),
                Types.UInt => Convert.ToInt64((uint)value),
                Types.Long => Convert.ToInt64((long)value),
                Types.ULong => Convert.ToInt64((ulong)value),
                Types.Float => Convert.ToInt64((float)value),
                Types.Double => Convert.ToInt64((double)value),
                Types.Decimal => Convert.ToInt64((decimal)value),
                Types.String => Convert.ToInt64((string)value),
                Types.DateTime => Convert.ToInt64((DateTime)value),
                _ => throw new Exception(nameof(type) + " is not defined")
            };
        }

        public static ulong ToULong(this Types type, object value)
        {
            return type switch
            {
                Types.Object => Convert.ToUInt64(value),
                Types.Bool => Convert.ToUInt64((bool)value),
                Types.Byte => Convert.ToUInt64((byte)value),
                Types.SByte => Convert.ToUInt64((sbyte)value),
                Types.Char => Convert.ToUInt64((char)value),
                Types.Short => Convert.ToUInt64((short)value),
                Types.UShort => Convert.ToUInt64((ushort)value),
                Types.Int => Convert.ToUInt64((int)value),
                Types.UInt => Convert.ToUInt64((uint)value),
                Types.Long => Convert.ToUInt64((long)value),
                Types.ULong => Convert.ToUInt64((ulong)value),
                Types.Float => Convert.ToUInt64((float)value),
                Types.Double => Convert.ToUInt64((double)value),
                Types.Decimal => Convert.ToUInt64((decimal)value),
                Types.String => Convert.ToUInt64((string)value),
                Types.DateTime => Convert.ToUInt64((DateTime)value),
                _ => throw new Exception(nameof(type) + " is not defined")
            };
        }

        public static float ToFloat(this Types type, object value)
        {
            return type switch
            {
                Types.Object => Convert.ToSingle(value),
                Types.Bool => Convert.ToSingle((bool)value),
                Types.Byte => Convert.ToSingle((byte)value),
                Types.SByte => Convert.ToSingle((sbyte)value),
                Types.Char => Convert.ToSingle((char)value),
                Types.Short => Convert.ToSingle((short)value),
                Types.UShort => Convert.ToSingle((ushort)value),
                Types.Int => Convert.ToSingle((int)value),
                Types.UInt => Convert.ToSingle((uint)value),
                Types.Long => Convert.ToSingle((long)value),
                Types.ULong => Convert.ToSingle((ulong)value),
                Types.Float => Convert.ToSingle((float)value),
                Types.Double => Convert.ToSingle((double)value),
                Types.Decimal => Convert.ToSingle((decimal)value),
                Types.String => Convert.ToSingle((string)value),
                Types.DateTime => Convert.ToSingle((DateTime)value),
                _ => throw new Exception(nameof(type) + " is not defined")
            };
        }

        public static double ToDouble(this Types type, object value)
        {
            return type switch
            {
                Types.Object => Convert.ToDouble(value),
                Types.Bool => Convert.ToDouble((bool)value),
                Types.Byte => Convert.ToDouble((byte)value),
                Types.SByte => Convert.ToDouble((sbyte)value),
                Types.Char => Convert.ToDouble((char)value),
                Types.Short => Convert.ToDouble((short)value),
                Types.UShort => Convert.ToDouble((ushort)value),
                Types.Int => Convert.ToDouble((int)value),
                Types.UInt => Convert.ToDouble((uint)value),
                Types.Long => Convert.ToDouble((long)value),
                Types.ULong => Convert.ToDouble((ulong)value),
                Types.Float => Convert.ToDouble((float)value),
                Types.Double => Convert.ToDouble((double)value),
                Types.Decimal => Convert.ToDouble((decimal)value),
                Types.String => Convert.ToDouble((string)value),
                Types.DateTime => Convert.ToDouble((DateTime)value),
                _ => throw new Exception(nameof(type) + " is not defined")
            };
        }

        public static decimal ToDecimal(this Types type, object value)
        {
            return type switch
            {
                Types.Object => Convert.ToDecimal(value),
                Types.Bool => Convert.ToDecimal((bool)value),
                Types.Byte => Convert.ToDecimal((byte)value),
                Types.SByte => Convert.ToDecimal((sbyte)value),
                Types.Char => Convert.ToDecimal((char)value),
                Types.Short => Convert.ToDecimal((short)value),
                Types.UShort => Convert.ToDecimal((ushort)value),
                Types.Int => Convert.ToDecimal((int)value),
                Types.UInt => Convert.ToDecimal((uint)value),
                Types.Long => Convert.ToDecimal((long)value),
                Types.ULong => Convert.ToDecimal((ulong)value),
                Types.Float => Convert.ToDecimal((float)value),
                Types.Double => Convert.ToDecimal((double)value),
                Types.Decimal => Convert.ToDecimal((decimal)value),
                Types.String => Convert.ToDecimal((string)value),
                Types.DateTime => Convert.ToDecimal((DateTime)value),
                _ => throw new Exception(nameof(type) + " is not defined")
            };
        }

        public static object ToObject(this Types _, object value)
        {
            return value;
        }

        public static string? ToString(this Types type, object value)
        {
            return type switch
            {
                Types.Object => Convert.ToString(value),
                Types.Bool => Convert.ToString((bool)value),
                Types.Byte => Convert.ToString((byte)value),
                Types.SByte => Convert.ToString((sbyte)value),
                Types.Char => Convert.ToString((char)value),
                Types.Short => Convert.ToString((short)value),
                Types.UShort => Convert.ToString((ushort)value),
                Types.Int => Convert.ToString((int)value),
                Types.UInt => Convert.ToString((uint)value),
                Types.Long => Convert.ToString((long)value),
                Types.ULong => Convert.ToString((ulong)value),
                Types.Float => Convert.ToString((float)value),
                Types.Double => Convert.ToString((double)value),
                Types.Decimal => Convert.ToString((decimal)value),
                Types.String => Convert.ToString((string)value),
                Types.DateTime => Convert.ToString((DateTime)value),
                _ => throw new Exception(nameof(type) + " is not defined")
            };
        }

        public static DateTime ToDateTime(this Types type, object value)
        {
            return type switch
            {
                Types.Object => Convert.ToDateTime(value),
                Types.Bool => Convert.ToDateTime((bool)value),
                Types.Byte => Convert.ToDateTime((byte)value),
                Types.SByte => Convert.ToDateTime((sbyte)value),
                Types.Char => Convert.ToDateTime((char)value),
                Types.Short => Convert.ToDateTime((short)value),
                Types.UShort => Convert.ToDateTime((ushort)value),
                Types.Int => Convert.ToDateTime((int)value),
                Types.UInt => Convert.ToDateTime((uint)value),
                Types.Long => Convert.ToDateTime((long)value),
                Types.ULong => Convert.ToDateTime((ulong)value),
                Types.Float => Convert.ToDateTime((float)value),
                Types.Double => Convert.ToDateTime((double)value),
                Types.Decimal => Convert.ToDateTime((decimal)value),
                Types.String => Convert.ToDateTime((string)value),
                Types.DateTime => Convert.ToDateTime((DateTime)value),
                _ => throw new Exception(nameof(type) + " is not defined")
            };
        }
    }
}
