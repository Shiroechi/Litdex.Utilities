using System;

using Litdex.Utilities.Base;

namespace Litdex.Utilities.Extension
{
	/// <summary>
	/// Byte[] Extension.
	/// </summary>
	public static class ByteArrayExtensions
	{
		/// <summary>
		///		Encode the array of <see cref="byte"/>s to Base16 <see cref="string"/>.
		/// </summary>
		/// <param name="bytes">
		///		Array of <see cref="byte"/> to encode.
		/// </param>
		/// <param name="upperCase">
		///		Base16 <see cref="string"/> letter case. Default is upper case.
		/// </param>
		/// <returns>
		///		Base16 <see cref="string"/>.
		/// </returns>
		public static string ToBase16(this byte[] bytes, bool upperCase = true)
		{
			return Base16.Encode(bytes, upperCase);
		}

		/// <summary>
		///		Encode the array of <see cref="byte"/>s to Base64 <see cref="string"/>.
		/// </summary>
		/// <param name="bytes">
		///		Array of <see cref="byte"/> to encode.
		/// </param>
		/// <returns>
		///		Base64 <see cref="string"/>.
		/// </returns>
		public static string ToBase64(this byte[] bytes)
		{
			return Base64.Encode(bytes);
		}

		/// <summary>
		///		Encode the array of <see cref="byte"/>s to Base85 <see cref="string"/>.
		/// </summary>
		/// <param name="bytes">
		///		Array of <see cref="byte"/> to encode.
		/// </param>
		/// <returns>
		///		Base85 <see cref="string"/>.
		/// </returns>
		public static string ToBase85(this byte[] bytes)
		{
			return Base85.Encode(bytes);
		}

		/// <summary>
		///		Encode the array of <see cref="byte"/>s to Base91 <see cref="string"/>.
		/// </summary>
		/// <param name="bytes">
		///		Array of <see cref="byte"/> to encode.
		/// </param>
		/// <returns>
		///		Base91 <see cref="string"/>.
		/// </returns>
		public static string ToBase91(this byte[] bytes)
		{
			return Base91.Encode(bytes);
		}

		/// <summary>
		///		Convert array of <see cref="byte"/>s to UTF-8 <see cref="string"/>.
		/// </summary>
		/// <param name="bytes">
		///		Array of <see cref="byte"/>s to convert.
		///	</param>
		/// <returns>
		///		UTF-8 <see cref="string"/>.
		///	</returns>
		public static string GetString(this byte[] bytes)
		{
			return System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
		}
	}
}
