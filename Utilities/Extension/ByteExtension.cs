using System;

using Litdex.Utilities.Base;

namespace Litdex.Utilities.Extension
{
	/// <summary>
	/// Byte[] Extension.
	/// </summary>
	public static class ByteExtension
	{
		public static string ToBase16(this byte[] bytes, bool upper = true)
		{
			return Base16.Encode(bytes, upper);
		}

		public static string ToBase64(this byte[] bytes)
		{
			return Base64.Encode(bytes);
		}

		public static string ToBase85(this byte[] bytes)
		{
			return Base85.Encode(bytes);
		}

		public static string ToBase91(this byte[] bytes)
		{
			return Base91.Encode(bytes);
		}

		/// <summary>
		/// Convert byte[] to string.
		/// Encoding UTF-8.
		/// </summary>
		/// <param name="bytes">this byte[].</param>
		/// <returns>string from byte[].</returns>
		public static string GetString(this byte[] bytes)
		{
			return System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
		}

		/// <summary>
		/// Clear array.
		/// </summary>
		/// <param name="arr"></param>
		public static void Clear(this Array arr)
		{
			Array.Clear(arr, 0, arr.Length);
		}

		public static byte[] SubByte(this byte[] arr, int offset)
		{
			return arr.SubByte(offset, arr.Length);
		}

		public static byte[] SubByte(this byte[] arr, int ffset, int length)
		{
			var temp = new byte[length - ffset];
			Array.Copy(arr, ffset, temp, 0, length);
			return temp;
		}
	}
}
