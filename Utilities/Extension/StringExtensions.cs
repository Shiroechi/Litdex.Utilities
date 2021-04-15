using System.Text;

using Litdex.Utilities.Base;

namespace Litdex.Utilities.Extension
{
	/// <summary>
	///		String Extension
	/// </summary>
	public static class StringExtension
	{
		/// <summary>
		///		Decode Base16 <see cref="string"/> to array of <see cref="byte"/>s.
		/// </summary>
		/// <param name="str">
		///		Base16 <see cref="string"/> to decode.
		///	</param>
		/// <returns>
		///		Array of <see cref="byte"/> that decoded from Base16 <see cref="string"/>.
		///	</returns>
		public static byte[] FromBase16(this char[] str)
		{
			return Base16.Decode(new string(str));
		}

		/// <summary>
		///		Decode Base16 <see cref="string"/> to array of <see cref="byte"/>s.
		/// </summary>
		/// <param name="str">
		///		Base16 <see cref="string"/> to decode.
		///	</param>
		/// <returns>
		///		Array of <see cref="byte"/> that decoded from Base16 <see cref="string"/>.
		///	</returns>
		public static byte[] FromBase16(this string str)
		{
			return Base16.Decode(str);
		}

		/// <summary>
		///		Decode Base64 <see cref="string"/> to array of <see cref="byte"/>s.
		/// </summary>
		/// <param name="str">
		///		Base64 <see cref="string"/> to decode.
		///	</param>
		/// <returns>
		///		Array of <see cref="byte"/> that decoded from Base64 <see cref="string"/>.
		///	</returns>
		public static byte[] FromBase64(this string str)
		{
			return Base64.Decode(str);
		}

		/// <summary>
		///		Decode Base85 <see cref="string"/> to array of <see cref="byte"/>s.
		/// </summary>
		/// <param name="str">
		///		Base85 <see cref="string"/> to decode.
		///	</param>
		/// <returns>
		///		Array of <see cref="byte"/> that decoded from Base85 <see cref="string"/>.
		///	</returns>
		public static byte[] FromBase85(this string str)
		{
			return Base85.Decode(str);
		}

		/// <summary>
		///		Decode Base91 <see cref="string"/> to array of <see cref="byte"/>s.
		/// </summary>
		/// <param name="str">
		///		Base91 <see cref="string"/> to decode.
		///	</param>
		/// <returns>
		///		Array of <see cref="byte"/> that decoded from Base91 <see cref="string"/>.
		///	</returns>
		public static byte[] FromBase91(this string str)
		{
			return Base91.Decode(str);
		}

		/// <summary>
		///		Convert <see cref="string"/> to an array of <see cref="byte"/>.
		/// </summary>
		/// <param name="str">
		///		A <see cref="string"/> to convert.
		/// </param>
		/// <returns>
		///		An array of <see cref="byte"/>s from <see cref="string"/>.
		///	</returns>
		public static byte[] GetBytes(this string str)
		{
			return Encoding.UTF8.GetBytes(str);
		}
	}
}
