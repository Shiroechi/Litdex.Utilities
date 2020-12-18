using System.Text;

using Litdex.Utilities.Base;

namespace Litdex.Utilities.Extension
{
	/// <summary>
	/// String Extension
	/// </summary>
	public static class StringExtension
	{
		/// <summary>
		/// Convert string to Base16.
		/// Encoding UTF-8.
		/// </summary>
		/// <param name="str">string to convert.</param>
		/// <returns>Base16 string.</returns>
		public static byte[] FromBase16(this char[] str)
		{
			return Base16.Decode(new string(str));
		}

		public static byte[] FromBase16(this string str)
		{
			return Base16.Decode(str);
		}

		public static byte[] FromBase64(this string str)
		{
			return Base64.Decode(str);
		}

		public static byte[] FromBase85(this string str)
		{
			return Base85.Decode(str);
		}

		public static byte[] FromBase91(this string str)
		{
			return Base91.Decode(str);
		}

		public static byte[] GetBytes(this string str)
		{
			return Encoding.UTF8.GetBytes(str);
		}
	}
}
