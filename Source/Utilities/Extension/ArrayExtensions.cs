using System;
using System.Collections.Generic;
using System.Linq;

namespace Litdex.Utilities.Extension
{
	/// <summary>
	///		Array extensions.
	/// </summary>
	public static class ArrayExtensions
	{
		/// <summary>
		///	Convert array of <see cref="byte"/>s to UTF-8 <see cref="string"/>.
		/// </summary>
		/// <param name="bytes">
		///	Array of <see cref="byte"/>s to convert.
		///	</param>
		/// <returns>
		///	UTF-8 <see cref="string"/>.
		///	</returns>
		public static string GetString(this byte[] bytes)
		{
			return System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
		}

		/// <summary>
		///	Clear all element inside the array.
		/// </summary>
		/// <param name="arr">
		///	<see cref="Array"/> to clear.
		/// </param>
		public static void Clear(this Array arr)
		{
			Array.Clear(arr, 0, arr.Length);
		}

		/// <summary>
		///	Slice the array to create a new copy of new array.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="array">
		///	An array that want to slice.
		/// </param>
		/// <param name="start">
		///	The start index to slice the array.
		/// </param>
		/// <returns>
		///	A deep copy of elements from the specified start index until the last element from the array.
		/// </returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///	- Start index can't be negative number and larger than arrray length.
		///	- Requested length can't exceed from remaining length of array after the start index.
		/// </exception>
		public static T[] Slice<T>(this T[] array, int start)
		{
			return ArrayExtensions.Slice(array, start, array.Length - start);
		}

		/// <summary>
		///	Slice the array to create a new copy of new array.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="array">
		///	An array that want to slice.
		/// </param>
		/// <param name="start">
		///	The start index to slice the array.
		/// </param>
		/// <param name="length">
		///	A requested length of how many element to slice from the start index.
		/// </param>
		/// <returns>
		///	A deep copy of elements between the specified start index and requested length.
		/// </returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///	- Start index can't be negative number and larger than arrray length.
		///	- Requested length can't exceed from remaining length of array after the start index.
		/// </exception>
		public static T[] Slice<T>(this T[] array, int start, int length)
		{
			if (array == null)
			{
				throw new NullReferenceException("The array is null");
			}

			if (start < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(start), "Start index can't be negative, must positive number.");
			}

			if (length < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(length), "Requested length can't be negative, must positive number.");
			}

			if (start > array.Length)
			{
				throw new ArgumentOutOfRangeException(nameof(start), "Start index can't be larger than array length.");
			}

			if (length > array.Length - start)
			{
				throw new ArgumentOutOfRangeException(nameof(length), "Requested length can't exceed from remaining length of array after the start index.");
			}

#if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
			var span = new Span<T>(array);

			return span.Slice(start, length).ToArray();
#else
			var temp = new T[length];

			Array.Copy(array, start, temp, 0, length);

			return temp;
#endif
		}

		/// <summary>
		///	Slice the array to create a new copy of new array.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="array">
		///	An array that want to slice.
		/// </param>
		/// <param name="start">
		///	The start index to slice the array.
		/// </param>
		/// <returns>
		///	A deep copy of elements between the specified start index and requested length.
		/// </returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///	- Start index can't be negative number and larger than arrray length.
		///	- Requested length can't exceed from remaining length of array after the start index.
		/// </exception>
		public static IEnumerable<T> Slice<T>(this IEnumerable<T> array, int start)
		{
			var length = array.Count() - start;
			return ArrayExtensions.Slice(array, start, length);
		}

		/// <summary>
		///	Slice the array to create a new copy of new array.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="array">
		///	An array that want to slice.
		/// </param>
		/// <param name="start">
		///	The start index to slice the array.
		/// </param>
		/// <param name="length">
		///	A requested length of how many element to slice from the start index.
		/// </param>
		/// <returns>
		///	A deep copy of elements between the specified start index and requested length.
		/// </returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///	- Start index can't be negative number and larger than arrray length.
		///	- Requested length can't exceed from remaining length of array after the start index.
		/// </exception>
		public static IEnumerable<T> Slice<T>(this IEnumerable<T> array, int start, int length)
		{
			if (array == null)
			{
				throw new NullReferenceException("The array is null");
			}

			if (start < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(start), "Start index can't be negative, must positive number.");
			}

			if (length < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(length), "Requested length can't be negative, must positive number.");
			}

			var arrayLength = array.Count();

			if (start > arrayLength)
			{
				throw new ArgumentOutOfRangeException(nameof(start), "Start index can't be larger than array length.");
			}

			if (length > arrayLength - start)
			{
				throw new ArgumentOutOfRangeException(nameof(length), "Requested length can't exceed from remaining length of array after the start index.");
			}

			return array.Skip(start).Take(length);
		}

		/// <summary>
		///	Concat with another array to create a new array.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="currentArray">
		///		
		/// </param>
		/// <param name="array">
		///	Array to concat.
		/// </param>
		/// <returns>
		///	A new array of concation of 2 array.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The two or one of the array is null.
		/// </exception>
		public static T[] Concat<T>(this T[] currentArray, T[] array)
		{
			if (currentArray == null)
			{
				throw new ArgumentNullException(nameof(currentArray), "Current array is null.");
			}

			if (array == null)
			{
				throw new ArgumentNullException(nameof(array), "Array is null.");
			}

			var temp = new T[currentArray.Length + array.Length];

			Array.Copy(currentArray, 0, temp, 0, currentArray.Length);
			Array.Copy(array, 0, temp, currentArray.Length, array.Length);

			return temp;
		}
	}
}