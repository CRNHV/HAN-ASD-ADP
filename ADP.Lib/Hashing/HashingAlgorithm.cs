using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Lib.Hashing;

/// <summary>
/// Thanks to:
/// https://stackoverflow.com/questions/14409466/simple-hash-functions
/// </summary>
internal static class HashingAlgorithm
{
    public static int Djb2(int number, ulong modulo)
    {
        byte[] numberBytes = BitConverter.GetBytes(number);
        return Djb2(numberBytes, modulo);
    }

    public static int Djb2(string str, ulong modulo)
    {
        var strBytes = Encoding.UTF8.GetBytes(str);
        return Djb2(strBytes, modulo);
    }

    public static int Djb2(byte[] bytes, ulong modulo)
    {
        ulong hash = 5381;
        foreach (byte c in bytes)
        {
            hash = ((hash << 5) + hash) + c; // hash * 33 + c
        }
        return (int)(hash % modulo);
    }
}
