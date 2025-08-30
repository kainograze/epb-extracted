// 2a84840cc6f44442d81198ab56175e0c, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// PBKDF2
using System;
using System.Security.Cryptography;
using System.Text;

internal class PBKDF2
{
	private const int BLOCK_SIZE_IN_BYTES = 64;

	private const int HASH_SIZE_IN_BYTES = 32;

	private const byte IPAD = 54;

	private const byte OPAD = 92;

	public static byte[] GetBytes(string password, byte[] salt, int iterations, int howManyBytes)
	{
		return GetBytes(Encoding.UTF8.GetBytes(password), salt, iterations, howManyBytes);
	}

	public static byte[] GetBytes(byte[] password, byte[] salt, int iterations, int howManyBytes)
	{
		uint num = (uint)((howManyBytes + 32 - 1) / 32);
		byte[] array = new byte[salt.Length + 4];
		Array.Copy(salt, 0, array, 0, salt.Length);
		byte[] array2 = new byte[num * 32];
		int num2 = 0;
		SHA256Managed sHA256Managed = new SHA256Managed();
		SHA256Managed sHA256Managed2 = new SHA256Managed();
		if (password.Length > 64)
		{
			password = sHA256Managed.ComputeHash(password);
		}
		byte[] array3 = new byte[64];
		Array.Copy(password, 0, array3, 0, password.Length);
		byte[] array4 = new byte[64];
		byte[] array5 = new byte[64];
		for (int i = 0; i < 64; i++)
		{
			array4[i] = (byte)(array3[i] ^ 0x36);
			array5[i] = (byte)(array3[i] ^ 0x5C);
		}
		for (int j = 0; j < num; j++)
		{
			_incrementBigEndianIndex(array, salt.Length);
			byte[] array6 = array;
			for (int k = 0; k < iterations; k++)
			{
				sHA256Managed.Initialize();
				sHA256Managed.TransformBlock(array4, 0, 64, array4, 0);
				sHA256Managed.TransformFinalBlock(array6, 0, array6.Length);
				byte[] hash = sHA256Managed.Hash;
				sHA256Managed2.Initialize();
				sHA256Managed2.TransformBlock(array5, 0, 64, array5, 0);
				sHA256Managed2.TransformFinalBlock(hash, 0, hash.Length);
				array6 = sHA256Managed2.Hash;
				_xorByteArray(array6, 0, 32, array2, num2);
			}
			num2 += 32;
		}
		byte[] array7 = new byte[howManyBytes];
		Array.Copy(array2, 0, array7, 0, howManyBytes);
		return array7;
	}

	private static void _incrementBigEndianIndex(byte[] buf, int offset)
	{
		if (++buf[offset + 3] == 0 && ++buf[offset + 2] == 0 && ++buf[offset + 1] == 0 && ++buf[offset + 0] == 0)
		{
			throw new OverflowException();
		}
	}

	private static void _xorByteArray(byte[] src, int srcOffset, int cb, byte[] dest, int destOffset)
	{
		int num = checked(srcOffset + cb);
		while (srcOffset != num)
		{
			dest[destOffset] ^= src[srcOffset];
			srcOffset++;
			destOffset++;
		}
	}
}
