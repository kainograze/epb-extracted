// 2a84840cc6f44442d81198ab56175e0c, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// GorillazEncrypt
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

internal class GorillazEncrypt
{
	private const int bitsInByte = 8;

	private const int blockSize = 32;

	public static string EncryptString(string InputText, string password, string salt)
	{
		InputText = "s:" + InputText.Length + ":\"" + InputText + "\";";
		byte[] bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(InputText);
		byte[] bytes2 = Encoding.GetEncoding("iso-8859-1").GetBytes(password);
		byte[] bytes3 = Encoding.GetEncoding("iso-8859-1").GetBytes(salt);
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		rijndaelManaged.Mode = CipherMode.ECB;
		rijndaelManaged.Padding = PaddingMode.None;
		rijndaelManaged.KeySize = 256;
		rijndaelManaged.BlockSize = 256;
		rijndaelManaged.Key = PBKDF2.GetBytes(bytes2, bytes3, 1000, 32);
		rijndaelManaged.GenerateIV();
		ICryptoTransform transform = rijndaelManaged.CreateEncryptor();
		byte[] array = new byte[32];
		Array.Copy(rijndaelManaged.IV, 0, array, 0, array.Length);
		byte[] array2 = new byte[bytes.Length];
		for (int i = 0; i < bytes.Length; i += 32)
		{
			int num = 32;
			if (bytes.Length - i < 32)
			{
				num = bytes.Length - i;
			}
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, 32);
			cryptoStream.FlushFinalBlock();
			byte[] array3 = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			if (array3.Length >= num)
			{
				for (int j = 0; j < num; j++)
				{
					array2[j + i] = (byte)(array3[j] ^ bytes[i + j]);
				}
			}
			int num2 = array.Length;
			while (--num2 >= 0 && ++array[num2] == 0)
			{
			}
		}
		string text = Encoding.GetEncoding("iso-8859-1").GetString(rijndaelManaged.IV);
		text += Encoding.GetEncoding("iso-8859-1").GetString(array2);
		byte[] bytes4 = Encoding.GetEncoding("iso-8859-1").GetBytes(text);
		byte[] bytes5 = PBKDF2.GetBytes(bytes4, rijndaelManaged.Key, 1000, 32);
		text += Encoding.GetEncoding("iso-8859-1").GetString(bytes5);
		byte[] bytes6 = Encoding.GetEncoding("iso-8859-1").GetBytes(text);
		return Convert.ToBase64String(bytes6);
	}

	public static string DecryptString(string InputText, string password, string salt)
	{
		byte[] bytes = Convert.FromBase64String(InputText);
		byte[] bytes2 = Encoding.GetEncoding("iso-8859-1").GetBytes(password);
		byte[] bytes3 = Encoding.GetEncoding("iso-8859-1").GetBytes(salt);
		string text = Encoding.GetEncoding("iso-8859-1").GetString(bytes);
		string text2 = text.Substring(0, 32);
		string text3 = text.Substring(32, text.Length - 64);
		string s = text2 + text3;
		string s2 = text.Substring(text.Length - 32);
		byte[] bytes4 = Encoding.GetEncoding("iso-8859-1").GetBytes(text2);
		byte[] bytes5 = Encoding.GetEncoding("iso-8859-1").GetBytes(text3);
		byte[] bytes6 = Encoding.GetEncoding("iso-8859-1").GetBytes(s2);
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		rijndaelManaged.Mode = CipherMode.ECB;
		rijndaelManaged.Padding = PaddingMode.None;
		rijndaelManaged.KeySize = 256;
		rijndaelManaged.BlockSize = 256;
		rijndaelManaged.Key = PBKDF2.GetBytes(bytes2, bytes3, 1000, 32);
		rijndaelManaged.IV = bytes4;
		string text4 = Convert.ToBase64String(PBKDF2.GetBytes(Encoding.GetEncoding("iso-8859-1").GetBytes(s), rijndaelManaged.Key, 1000, 32));
		string text5 = Convert.ToBase64String(bytes6);
		if (text4 != text5)
		{
			return "invalid";
		}
		ICryptoTransform transform = rijndaelManaged.CreateEncryptor();
		byte[] array = new byte[32];
		Array.Copy(rijndaelManaged.IV, 0, array, 0, array.Length);
		byte[] array2 = new byte[bytes5.Length];
		for (int i = 0; i < bytes5.Length; i += 32)
		{
			int num = 32;
			if (bytes5.Length - i < 32)
			{
				num = bytes5.Length - i;
			}
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, 32);
			cryptoStream.FlushFinalBlock();
			byte[] array3 = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			if (array3.Length >= num)
			{
				for (int j = 0; j < num; j++)
				{
					array2[j + i] = (byte)(array3[j] ^ bytes5[i + j]);
				}
			}
			int num2 = array.Length;
			while (--num2 >= 0 && ++array[num2] == 0)
			{
			}
		}
		string text6 = Encoding.GetEncoding("iso-8859-1").GetString(array2);
		int num3 = text6.IndexOf(":", 2) + 2;
		return text6.Substring(num3, text6.Length - num3 - 2);
	}
}