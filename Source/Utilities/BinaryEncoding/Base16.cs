using System;

namespace Litdex.Utilities.BinaryEncoding
{
	/// <summary>
	///	Encode and decode in base 16 (hexadecimal).
	/// </summary>
	public static class Base16
	{
#if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
		private static ReadOnlySpan<byte> UpperCaseTable => new[]
		{
			(byte)'0', (byte)'1', (byte)'2', (byte)'3',
			(byte)'4', (byte)'5', (byte)'6', (byte)'7',
			(byte)'8', (byte)'9', (byte)'A', (byte)'B',
			(byte)'C', (byte)'D', (byte)'E', (byte)'F',
		};

		private static ReadOnlySpan<byte> LowerCaseTable => new[]
		{
			(byte)'0', (byte)'1', (byte)'2', (byte)'3',
			(byte)'4', (byte)'5', (byte)'6', (byte)'7',
			(byte)'8', (byte)'9', (byte)'a', (byte)'b',
			(byte)'c', (byte)'d', (byte)'e', (byte)'f',
		};
#else
		private static readonly char[] UpperCaseTable =
		{
			'0', '1', '2', '3',
			'4', '5', '6', '7',
			'8', '9', 'A', 'B',
			'C', 'D', 'E', 'F'
		};

		private static readonly char[] LowerCaseTable =
		{
			'0', '1', '2', '3',
			'4', '5', '6', '7',
			'8', '9', 'a', 'b',
			'c', 'd', 'e', 'f'
		};
#endif

		/// <summary>
		///	Encode <paramref name="bytes"/> to hexadecimal <see cref="string"/>.
		/// </summary>
		/// <param name="bytes">
		///	Array of <see cref="byte"/>s to encode.
		///	</param>
		/// <param name="upperCase">
		///	Hexadecimal output <see cref="string"/> letter case. Default is <see langword="true"/> to upper case.
		///	</param>
		/// <returns>
		///	Hexadecimal <see cref="string"/>.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	<paramref name="bytes"/> is null or empty.
		/// </exception>
		public static string Encode(byte[] bytes, bool upperCase = true)
		{
			if (bytes == null || bytes.Length == 0)
			{
				throw new ArgumentNullException(nameof(bytes), "Array can't null or empty.");
			}

			if (upperCase)
			{
#if NET5_0_OR_GREATER
				return Convert.ToHexString(bytes);
#else
				return EncodeUpper(bytes);
#endif
			}
			return EncodeLower(bytes);
		}

		/// <summary>
		///	Encode array of <see cref="byte"/>s to hexadecimal <see cref="string"/> in upper case.
		/// </summary>
		/// <param name="bytes">
		///	Array of <see cref="byte"/>s to encode.
		///	</param>
		/// <returns>
		///	Hexadecimal <see cref="string"/> in upper case.
		/// </returns>
		private static string EncodeUpper(byte[] bytes)
		{
			var result = new char[bytes.Length * 2];
			for (var i = 0; i < bytes.Length; ++i)
			{
				var j = i * 2;
				result[j] = (char)UpperCaseTable[bytes[i] >> 4];
				result[j + 1] = (char)UpperCaseTable[bytes[i] & 0xF];
			}

			return new string(result);
		}

		/// <summary>
		///		Encode array of <see cref="byte"/>s to hexadecimal string in lower case.
		/// </summary>
		/// <param name="bytes">
		///		Array of <see cref="byte"/>s to encode.
		///	</param>
		/// <returns>
		///		Hexadecimal <see cref="string"/> in lower case.
		/// </returns>
		private static string EncodeLower(byte[] bytes)
		{
#if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
			var result = bytes.Length * 2 < 32 ? stackalloc char[bytes.Length * 2] : new char[bytes.Length * 2];
			for (var i = 0; i < bytes.Length; ++i)
			{
				var j = i * 2;
				result[j] = (char)LowerCaseTable[bytes[i] >> 4];
				result[j + 1] = (char)LowerCaseTable[bytes[i] & 0xF];
			}

			return new string(result);
#else
			var result = new char[bytes.Length * 2];
			for (var i = 0; i < bytes.Length; ++i)
			{
				var j = i * 2;
				result[j] = LowerCaseTable[bytes[i] >> 4];
				result[j + 1] = LowerCaseTable[bytes[i] & 0xF];
			}

			return new string(result);
#endif
		}

		/// <summary>
		///	Decode hexadecimal <see cref="string"/> to array of <see cref="byte"/>s.
		/// </summary>
		/// <param name="hexString">
		///	Hexadecimal <see cref="string"/> to decode.
		///	</param>
		/// <returns>
		///	Array of <see cref="byte"/>s from decoded <paramref name="hexString"/>.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	<paramref name="hexString"/> is null, empty or only containing white spaces.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///	<paramref name="hexString"/> length is odd.
		/// </exception>
		public static byte[] Decode(string hexString)
		{
			if (string.IsNullOrWhiteSpace(hexString))
			{
				throw new ArgumentNullException(nameof(hexString), "Hexadecimal string can't null, empty or containing white spaces.");
			}

			if ((hexString.Length & 1) != 0)
			{
				throw new ArgumentOutOfRangeException(nameof(hexString), "The hexadecimal string is invalid because it has an odd length.");
			}

			var result = new byte[hexString.Length / 2];

			int high, low;

			for (var i = 0; i < result.Length; i++)
			{
				high = hexString[i * 2];
				low = hexString[i * 2 + 1];
				high = (high & 0xF) + ((high & 0x40) >> 6) * 9;
				low = (low & 0xF) + ((low & 0x40) >> 6) * 9;
				result[i] = (byte)((high << 4) | low);
			}
			return result;
		}

		/// <summary>
		///	Decode hexadecimal <see cref="string"/> to array of <see cref="byte"/>s.
		/// </summary>
		/// <param name="hexString">
		///	Hexadecimal <see cref="string"/> to decode.
		///	</param>
		/// <returns>
		///	Array of <see cref="byte"/>s from decoded <paramref name="hexString"/>.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	<paramref name="hexString"/> is null, empty or only containing white spaces.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///	<paramref name="hexString"/> length is odd.
		/// </exception>
		public static byte[] Decode(char[] hexString)
		{
			if (hexString.Length == 0 || hexString == null)
			{
				throw new ArgumentNullException(nameof(hexString), "Hexadecimal string can't null, empty or containing white spaces.");
			}

			if ((hexString.Length & 1) != 0)
			{
				throw new ArgumentOutOfRangeException(nameof(hexString), "The hexadecimal string is invalid because it has an odd length.");
			}

			var result = new byte[hexString.Length / 2];

			int high, low;

			for (var i = 0; i < result.Length; i++)
			{
				high = hexString[i * 2];
				low = hexString[i * 2 + 1];
				high = (high & 0xF) + ((high & 0x40) >> 6) * 9;
				low = (low & 0xF) + ((low & 0x40) >> 6) * 9;
				result[i] = (byte)((high << 4) | low);
			}
			return result;
		}
	}
}