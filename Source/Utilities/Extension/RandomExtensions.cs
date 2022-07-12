using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Litdex.Utilities.Extension
{
	/// <summary>
	///	<see cref="Random"/> Extension.
	/// </summary>
	public static class RandomExtensions
	{
		/// <summary>
		///	Select one element randomly from the given set.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to select.
		/// </param>
		/// <returns>
		///	Random element from the given set.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///	The items length or size can't be greater than int.MaxValue.
		/// </exception>
		private static T Choice<T>(this Random random, T[] items)
		{
			if (items.Length <= 0 || items == null)
			{
				ThrowNullArray();
			}

			var index = random.Next(0, items.Length - 1);
			return items[index];
		}

		/// <summary>
		///	Select arbitrary element randomly.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to select.
		/// </param>
		/// <param name="select">
		///	The desired amount to select.
		/// </param>
		/// <returns>
		///	Multiple random elements from the given set.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///	- The number of elements to be retrieved is negative or less than 1.
		///	- The number of elements to be retrieved exceeds the items size.
		/// </exception>
		public static T[] Choice<T>(this Random random, T[] items, int select)
		{
			if (items.Length <= 0 || items == null)
			{
				ThrowNullArray();
			}

			if (select < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(select), "The number of elements to be retrieved is negative or less than 1.");
			}
			else if (select > items.Length)
			{
				throw new ArgumentOutOfRangeException(nameof(select), "The number of elements to be retrieved exceeds the items size.");
			}
			else if (select == items.Length)
			{
				return items;
			}

			var selected = new T[select];
			int index;
			int length = items.Length - 1;

			for (var i = 0; i < select; i++)
			{
				index = random.Next(0, length);
				selected[i] = items[index];
			}

			return selected;
		}

		/// <summary>
		///	Select arbitrary element randomly.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to select.
		/// </param>
		/// <param name="select">
		///	The desired amount to select.
		/// </param>
		/// <returns>
		///	Multiple random elements from the given set.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///	- The number of elements to be retrieved is negative or less than 1.
		///	- The number of elements to be retrieved exceeds the items size.
		/// </exception>
		public static Task<T[]> ChoiceAsync<T>(this Random random, T[] items, int select)
		{
			return ChoiceAsync(random, items, select, CancellationToken.None);
		}

		/// <summary>
		///	Select arbitrary element randomly.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to select.
		/// </param>
		/// <param name="select">
		///	The desired amount to select.
		/// </param>
		/// <param name="cancellationToken">
		///	Token to cancel the operations.
		/// </param>
		/// <returns>
		///	Multiple random elements from the given set.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///	- The number of elements to be retrieved is negative or less than 1.
		///	- The number of elements to be retrieved exceeds the items size.
		/// </exception>
		public static Task<T[]> ChoiceAsync<T>(this Random random, T[] items, int select, CancellationToken cancellationToken)
		{
			return Task.Factory.StartNew(() =>
			{
				return Choice(random, items, select);
			}, cancellationToken);
		}

		/// <summary>
		///	Select one element randomly.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to select.
		/// </param>
		/// <returns>
		///	Random element from the given set.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///	The items length or size can't be greater than int.MaxValue.
		/// </exception>
		public static T Choice<T>(this Random random, IEnumerable<T> items)
		{
			if (!items.Any() || items == null)
			{
				ThrowNullArray();
			}
			var index = random.Next(0, items.Count() - 1);
			return items.ElementAt(index);
		}

		/// <summary>
		///	Select arbitrary element randomly.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to select.
		/// </param>
		/// <param name="select">
		///	The desired amount to select.
		/// </param>
		/// <returns>
		///	Multiple random elements from the given set.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		/// - The number of elements to be retrieved is negative or less than 1.
		/// - The number of elements to be retrieved exceeds the items size.
		/// </exception>
		public static T[] Choice<T>(this Random random, IEnumerable<T> items, int select)
		{
			if (!items.Any() || items == null)
			{
				ThrowNullArray();
			}

			if (select < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(select), "The number of elements to be retrieved is negative or less than 1.");
			}
			else if (select > items.Count())
			{
				throw new ArgumentOutOfRangeException(nameof(select), "The number of elements to be retrieved exceeds the items size.");
			}
			else if (select == items.Count())
			{
				return items.ToArray();
			}

			var selected = new T[select];
			int index;
			int length = items.Count() - 1;

			for (var i = 0; i < select; i++)
			{
				index = random.Next(0, length);
				selected[i] = items.ElementAt(index);
			}

			return selected;
		}

		/// <summary>
		///	Select arbitrary element randomly.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to select.
		/// </param>
		/// <param name="select">
		///	The desired amount to select.
		/// </param>
		/// <returns>
		///	Multiple random elements from the given set.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		/// - The number of elements to be retrieved is negative or less than 1.
		/// - The number of elements to be retrieved exceeds the items size.
		/// </exception>
		public static Task<T[]> ChoiceAsync<T>(this Random random, IEnumerable<T> items, int select)
		{
			return ChoiceAsync(random, items, select, CancellationToken.None);
		}

		/// <summary>
		///	Select arbitrary element randomly.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to select.
		/// </param>
		/// <param name="select">
		///	The desired amount to select.
		/// </param>
		/// <param name="cancellationToken">
		///	Token to cancel the operations.
		/// </param>
		/// <returns>
		///	Multiple random elements from the given set.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///	- The number of elements to be retrieved is negative or less than 1.
		///	- The number of elements to be retrieved exceeds the items size.
		/// </exception>
		public static Task<T[]> ChoiceAsync<T>(this Random random, IEnumerable<T> items, int select, CancellationToken cancellationToken)
		{
			return Task.Factory.StartNew(() =>
			{
				return Choice(random, items, select);
			}, cancellationToken);
		}

		/// <summary>
		///	Select arbitrary distinct element randomly.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		/// A set of items to select.
		/// </param>
		/// <param name="select">
		///	The desired amount to select.
		/// </param>
		/// <returns>
		///	Multiple random elements from the given set.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		/// <exception cref="ArgumentException">
		///	The number of elements to be retrieved is negative or less than 1.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///	The number of elements to be retrieved exceeds the items size.
		/// </exception>
		public static T[] Sample<T>(this Random random, T[] items, int select)
		{
			if (items.Length <= 0 || items == null)
			{
				ThrowNullArray();
			}

			if (select <= 0)
			{
				throw new ArgumentException("The number of elements to be retrieved is negative or less than 1.", nameof(select));
			}
			else if (select > items.Length)
			{
				throw new ArgumentOutOfRangeException(nameof(select), "The number of elements to be retrieved exceeds the items size.");
			}
			else if (select == items.Length)
			{
				return items;
			}

			var reservoir = new T[select];
			int index;

			Array.Copy(items, 0, reservoir, 0, reservoir.Length);

			for (var i = select; i < items.Length; i++)
			{
				index = random.Next(0, i);

				if (index < select)
				{
					reservoir[index] = items[i];
				}
			}

			return reservoir;
		}

		/// <summary>
		///	Select arbitrary distinct element randomly.
		/// </summary>
		/// <remarks>
		///	Used for large data, objects or arrays.
		/// </remarks>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		/// A set of items to select.
		/// </param>
		/// <param name="select">
		///	The desired amount to select.
		/// </param>
		/// <returns>
		///	Multiple random elements from the given set.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		/// <exception cref="ArgumentException">
		///	The number of elements to be retrieved is negative or less than 1.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///	The number of elements to be retrieved exceeds the items size.
		/// </exception>
		public static Task<T[]> SampleAsync<T>(this Random random, T[] items, int select)
		{
			return SampleAsync(random, items, select, CancellationToken.None);
		}

		/// <summary>
		///	Select arbitrary distinct element randomly.
		/// </summary>
		/// <remarks>
		///	Used for large data, objects or arrays.
		/// </remarks>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		/// A set of items to select.
		/// </param>
		/// <param name="select">
		///	The desired amount to select.
		/// </param>
		/// <param name="cancellationToken">
		///	Token to cancel the operations.
		/// </param>
		/// <returns>
		///	Multiple random elements from the given set.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		/// <exception cref="ArgumentException">
		///	The number of elements to be retrieved is negative or less than 1.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///	The number of elements to be retrieved exceeds the items size.
		/// </exception>
		public static Task<T[]> SampleAsync<T>(this Random random, T[] items, int select, CancellationToken cancellationToken)
		{
			return Task.Factory.StartNew(() =>
			{
				return Sample(random, items, select);
			}, cancellationToken);
		}

		/// <summary>
		///	Select arbitrary distinct element randomly.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to select.
		/// </param>
		/// <param name="select">
		///	The desired amount to select.
		/// </param>
		/// <returns>
		///	Multiple random elements from the given set.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		/// <exception cref="ArgumentException">
		///	The number of elements to be retrieved is negative or less than 1.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///	The number of elements to be retrieved exceeds the items size.
		/// </exception>
		public static T[] Sample<T>(this Random random, IEnumerable<T> items, int select)
		{
			if (items.Any() || items == null)
			{
				ThrowNullArray();
			}

			if (select <= 0)
			{
				throw new ArgumentException("The number of elements to be retrieved is negative or less than 1.", nameof(select));
			}
			else if (select > items.Count())
			{
				throw new ArgumentOutOfRangeException(nameof(select), "The number of elements to be retrieved exceeds the items size.");
			}
			else if (select == items.Count())
			{
				return items.ToArray();
			}

			var reservoir = new T[select];
			int index;

			for (var i = 0; i < items.Count(); i++)
			{
				reservoir[i] = items.ElementAt(i);
			}

			for (var i = select; i < items.Count(); i++)
			{
				index = random.Next(0, i);

				if (index < select)
				{
					reservoir[index] = items.ElementAt(i);
				}
			}

			return reservoir;
		}

		/// <summary>
		///	Select arbitrary distinct element randomly.
		/// </summary>
		/// <remarks>
		///	Used for large data, objects or arrays.
		/// </remarks>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		/// A set of items to select.
		/// </param>
		/// <param name="select">
		///	The desired amount to select.
		/// </param>
		/// <returns>
		///	Multiple random elements from the given set.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		/// <exception cref="ArgumentException">
		///	The number of elements to be retrieved is negative or less than 1.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///	The number of elements to be retrieved exceeds the items size.
		/// </exception>
		public static Task<T[]> SampleAsync<T>(this Random random, IEnumerable<T> items, int select)
		{
			return SampleAsync(random, items, select, CancellationToken.None);
		}

		/// <summary>
		///	Select arbitrary distinct element randomly.
		/// </summary>
		/// <remarks>
		///	Used for large data, objects or arrays.
		/// </remarks>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		/// A set of items to select.
		/// </param>
		/// <param name="select">
		///	The desired amount to select.
		/// </param>
		/// <param name="cancellationToken">
		///	Token to cancel the operations.
		/// </param>
		/// <returns>
		///	Multiple random elements from the given set.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		/// <exception cref="ArgumentException">
		///	The number of elements to be retrieved is negative or less than 1.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///	The number of elements to be retrieved exceeds the items size.
		/// </exception>
		public static Task<T[]> SampleAsync<T>(this Random random, IEnumerable<T> items, int select, CancellationToken cancellationToken)
		{
			return Task.Factory.StartNew(() =>
			{
				return Sample(random, items, select);
			}, cancellationToken);
		}

		/// <summary>
		///	Shuffle items with Fisher-Yates shuffle then return the shuffled item in new array.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to shuffle.
		/// </param>
		/// <returns>
		///	Array of shuffled items.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		public static T[] Shuffle<T>(this Random random, T[] items)
		{
			if (items.Length <= 0 || items == null)
			{
				ThrowNullArray();
			}

			var newArray = new T[items.Length];
			Array.Copy(items, newArray, newArray.Length);

			T temp;

			for (var i = newArray.Length - 1; i > 1; i--)
			{
				var index = random.Next(0, i);
				temp = newArray[i];
				newArray[i] = newArray[index];
				newArray[index] = temp;
			}

			return newArray;
		}

		/// <summary>
		///	Shuffle items with Fisher-Yates shuffle then return the shuffled item in new array.
		/// </summary>
		/// <remarks>
		///	Used for large data, objects or arrays.
		/// </remarks>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to shuffle.
		/// </param>
		/// <returns>
		///	Array of shuffled items.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		public static Task<T[]> ShuffleAsync<T>(this Random random, T[] items)
		{
			return ShuffleAsync(random, items, CancellationToken.None);
		}

		/// <summary>
		///	Shuffle items with Fisher-Yates shuffle then return the shuffled item in new array.
		/// </summary>
		/// <remarks>
		///	Used for large data, objects or arrays.
		/// </remarks>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to shuffle.
		/// </param>
		/// <param name="cancellationToken">
		///	Token to cancel the operations.
		/// </param>
		/// <returns>
		///	Array of shuffled items.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		public static Task<T[]> ShuffleAsync<T>(this Random random, T[] items, CancellationToken cancellationToken)
		{
			return Task.Factory.StartNew(() =>
			{
				return Shuffle(random, items);
			}, cancellationToken);
		}

		/// <summary>
		///	Shuffle items with Fisher-Yates shuffle then return the shuffled item in new array.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to shuffle.
		/// </param>
		/// <returns>
		///	Array of shuffled items.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		public static T[] Shuffle<T>(this Random random, IEnumerable<T> items)
		{
			return Shuffle(random, items.ToArray());
		}

		/// <summary>
		///	Shuffle items with Fisher-Yates shuffle then return the shuffled item in new array.
		/// </summary>
		/// <remarks>
		///	Used for large data, objects or arrays.
		/// </remarks>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to shuffle.
		/// </param>
		/// <returns>
		///	Array of shuffled items.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		public static Task<T[]> ShuffleAsync<T>(this Random random, IEnumerable<T> items)
		{
			return ShuffleAsync(random, items.ToArray(), CancellationToken.None);
		}

		/// <summary>
		///	Shuffle items with Fisher-Yates shuffle then return the shuffled item in new array.
		/// </summary>
		/// <remarks>
		///	Used for large data, objects or arrays.
		/// </remarks>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to shuffle.
		/// </param>
		/// <param name="cancellationToken">
		///	Token to cancel the operations.
		/// </param>
		/// <returns>
		///	Array of shuffled items.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		public static Task<T[]> ShuffleAsync<T>(this Random random, IEnumerable<T> items, CancellationToken cancellationToken)
		{
			return ShuffleAsync(random, items.ToArray(), cancellationToken);
		}

		/// <summary>
		///	Shuffle items in place with Fisher-Yates shuffle.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to shuffle.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		public static void ShuffleInPlace<T>(this Random random, T[] items)
		{
			if (items.Length <= 0 || items == null)
			{
				ThrowNullArray();
			}

			T temp;

			for (var i = items.Length - 1; i > 1; i--)
			{
				var index = random.Next(0, i);
				temp = items[i];
				items[i] = items[index];
				items[index] = temp;
			}
		}

		/// <summary>
		///	Shuffle items in place with Fisher-Yates shuffle.
		/// </summary>
		/// <remarks>
		///	Used for large data, objects or arrays.
		/// </remarks>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to shuffle.
		/// </param>
		/// <returns>
		///	Task based operations.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		public static Task ShuffleInPlaceAsync<T>(this Random random, T[] items)
		{
			return ShuffleInPlaceAsync(random, items, CancellationToken.None);
		}

		/// <summary>
		///	Shuffle items in place with Fisher-Yates shuffle.
		/// </summary>
		/// <remarks>
		///	Used for large data, objects or arrays.
		/// </remarks>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to shuffle.
		/// </param>
		/// <param name="cancellationToken">
		///	Token to cancel the operations.
		/// </param>
		/// <returns>
		///	Task based operations.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		public static Task ShuffleInPlaceAsync<T>(this Random random, T[] items, CancellationToken cancellationToken)
		{
			return Task.Factory.StartNew(() =>
			{
				ShuffleInPlace(random, items);
			}, cancellationToken);
		}

		/// <summary>
		///	Shuffle items in place with Fisher-Yates shuffle.
		/// </summary>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to shuffle.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		public static void ShuffleInPlace<T>(this Random random, IList<T> items)
		{
			if (items.Count <= 0 || items == null)
			{
				ThrowNullArray();
			}

			T temp;

			for (var i = items.Count - 1; i > 1; i--)
			{
				var index = random.Next(0, i);
				temp = items[i];
				items[i] = items[index];
				items[index] = temp;
			}
		}

		/// <summary>
		///	Shuffle items in place with Fisher-Yates shuffle.
		/// </summary>
		/// <remarks>
		///	Used for large data, objects or arrays.
		/// </remarks>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to shuffle.
		/// </param>
		/// <returns>
		///	Task based operations.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		public static Task ShuffleInPlaceAsync<T>(this Random random, IList<T> items)
		{
			return ShuffleInPlaceAsync(random, items, CancellationToken.None);
		}

		/// <summary>
		///	Shuffle items in place with Fisher-Yates shuffle.
		/// </summary>
		/// <remarks>
		///	Used for large data, objects or arrays.
		/// </remarks>
		/// <typeparam name="T">
		///	The type of objects in array.
		/// </typeparam>
		/// <param name="random">
		///	Random number genrator.
		/// </param>
		/// <param name="items">
		///	A set of items to shuffle.
		/// </param>
		/// <param name="cancellationToken">
		///	Token to cancel the operations.
		/// </param>
		/// <returns>
		///	Task based operations.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///	The items is null, empty or not initialized. 
		/// </exception>
		public static Task ShuffleInPlaceAsync<T>(this Random random, IList<T> items, CancellationToken cancellationToken)
		{
			return Task.Factory.StartNew(() =>
			{
				ShuffleInPlace(random, items);
			}, cancellationToken);
		}

		private static void ThrowNullArray()
		{
			throw new ArgumentNullException("items", "The items is empty or null.");
		}
	}
}
