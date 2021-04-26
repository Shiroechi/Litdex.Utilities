namespace Litdex.Utilities.Extension
{
	/// <summary>
	///		Integer extensions.
	/// </summary>
	public static class NumberExtensions
	{
		#region Left Rotate

		/// <summary>
		///		Rotate the bits to the left. 
		/// </summary>
		/// <param name="value">
		///		The number to rotate.
		/// </param>
		/// <param name="shiftBit">
		///		How many bit to shift.
		/// </param>
		/// <returns>
		///		Left rotate of the number.
		/// </returns>
		public static byte LeftRotate(this byte value, byte shiftBit)
		{
			return (byte)((value << shiftBit) | (value >> (sizeof(byte) - shiftBit)));
		}

		/// <summary>
		///		Rotate the bits to the left. 
		/// </summary>
		/// <param name="value">
		///		The number to rotate.
		/// </param>
		/// <param name="shiftBit">
		///		How many bit to shift.
		/// </param>
		/// <returns>
		///		Left rotate of the number.
		/// </returns>
		public static short LeftRotate(this short value, short shiftBit)
		{
			return (short)((value << shiftBit) | (value >> (sizeof(short) - shiftBit)));
		}

		/// <summary>
		///		Rotate the bits to the left. 
		/// </summary>
		/// <param name="value">
		///		The number to rotate.
		/// </param>
		/// <param name="shiftBit">
		///		How many bit to shift.
		/// </param>
		/// <returns>
		///		Left rotate of the number.
		/// </returns>
		public static ushort LeftRotate(this ushort value, ushort shiftBit)
		{
			return (ushort)((value << shiftBit) | (value >> (sizeof(ushort) - shiftBit)));
		}

		/// <summary>
		///		Rotate the bits to the left. 
		/// </summary>
		/// <param name="value">
		///		The number to rotate.
		/// </param>
		/// <param name="shiftBit">
		///		How many bit to shift.
		/// </param>
		/// <returns>
		///		Left rotate of the number.
		/// </returns>
		public static int LeftRotate(this int value, int shiftBit)
		{
			return (value << shiftBit) | (value >> (sizeof(int) - shiftBit));
		}

		/// <summary>
		///		Rotate the bits to the left. 
		/// </summary>
		/// <param name="value">
		///		The number to rotate.
		/// </param>
		/// <param name="shiftBit">
		///		How many bit to shift.
		/// </param>
		/// <returns>
		///		Left rotate of the number.
		/// </returns>
		public static uint LeftRotate(this uint value, int shiftBit)
		{
			return (value << shiftBit) | (value >> (sizeof(uint) - shiftBit));
		}

		/// <summary>
		///		Rotate the bits to the left. 
		/// </summary>
		/// <param name="value">
		///		The number to rotate.
		/// </param>
		/// <param name="shiftBit">
		///		How many bit to shift.
		/// </param>
		/// <returns>
		///		Left rotate of the number.
		/// </returns>
		public static long LeftRotate(this long value, int shiftBit)
		{
			return (value << shiftBit) | (value >> (sizeof(long) - shiftBit));
		}

		/// <summary>
		///		Rotate the bits to the left. 
		/// </summary>
		/// <param name="value">
		///		The number to rotate.
		/// </param>
		/// <param name="shiftBit">
		///		How many bit to shift.
		/// </param>
		/// <returns>
		///		Left rotate of the number.
		/// </returns>
		public static ulong LeftRotate(this ulong value, int shiftBit)
		{
			return (value << shiftBit) | (value >> (sizeof(ulong) - shiftBit));
		}

		#endregion Left Rotate

		#region Right Rotate

		/// <summary>
		///		Rotate the bits to the right. 
		/// </summary>
		/// <param name="value">
		///		The number to rotate.
		/// </param>
		/// <param name="shiftBit">
		///		How many bit to shift.
		/// </param>
		/// <returns>
		///		Right rotate of the number.
		/// </returns>
		public static byte RightRotate(this byte value, byte shiftBit)
		{
			return (byte)((value >> shiftBit) | (value << (sizeof(byte) - shiftBit)));
		}

		/// <summary>
		///		Rotate the bits to the right. 
		/// </summary>
		/// <param name="value">
		///		The number to rotate.
		/// </param>
		/// <param name="shiftBit">
		///		How many bit to shift.
		/// </param>
		/// <returns>
		///		Right rotate of the number.
		/// </returns>
		public static short RightRotate(this short value, short shiftBit)
		{
			return (short)((value >> shiftBit) | (value << (sizeof(short) - shiftBit)));
		}

		/// <summary>
		///		Rotate the bits to the right. 
		/// </summary>
		/// <param name="value">
		///		The number to rotate.
		/// </param>
		/// <param name="shiftBit">
		///		How many bit to shift.
		/// </param>
		/// <returns>
		///		Right rotate of the number.
		/// </returns>
		public static ushort RightRotate(this ushort value, ushort shiftBit)
		{
			return (ushort)((value >> shiftBit) | (value << (sizeof(ushort) - shiftBit)));
		}

		/// <summary>
		///		Rotate the bits to the right. 
		/// </summary>
		/// <param name="value">
		///		The number to rotate.
		/// </param>
		/// <param name="shiftBit">
		///		How many bit to shift.
		/// </param>
		/// <returns>
		///		Right rotate of the number.
		/// </returns>
		public static int RightRotate(this int value, int shiftBit)
		{
			return (value >> shiftBit) | (value << (sizeof(int) - shiftBit));
		}

		/// <summary>
		///		Rotate the bits to the right. 
		/// </summary>
		/// <param name="value">
		///		The number to rotate.
		/// </param>
		/// <param name="shiftBit">
		///		How many bit to shift.
		/// </param>
		/// <returns>
		///		Right rotate of the number.
		/// </returns>
		public static uint RightRotate(this uint value, int shiftBit)
		{
			return (value >> shiftBit) | (value << (sizeof(uint) - shiftBit));
		}

		/// <summary>
		///		Rotate the bits to the right. 
		/// </summary>
		/// <param name="value">
		///		The number to rotate.
		/// </param>
		/// <param name="shiftBit">
		///		How many bit to shift.
		/// </param>
		/// <returns>
		///		Right rotate of the number.
		/// </returns>
		public static long RightRotate(this long value, int shiftBit)
		{
			return (value >> shiftBit) | (value << (sizeof(long) - shiftBit));
		}

		/// <summary>
		///		Rotate the bits to the right. 
		/// </summary>
		/// <param name="value">
		///		The number to rotate.
		/// </param>
		/// <param name="shiftBit">
		///		How many bit to shift.
		/// </param>
		/// <returns>
		///		Right rotate of the number.
		/// </returns>
		public static ulong RightRotate(this ulong value, int shiftBit)
		{
			return (value >> shiftBit) | (value << (sizeof(ulong) - shiftBit));
		}

		#endregion Right Rotate
	}
}
