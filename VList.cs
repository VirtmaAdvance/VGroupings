using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGroupings
{
	public class VList<T>
	{

		private T[] _items=Array.Empty<T>();

		public int Length => _items.Length;



		public void Add(T item)
		{
			Array.Resize(ref _items, _items.Length+1);
			_items[^1]=item;
		}
		/// <summary>
		/// Finds the first occurance of the
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int IndexOf(T item)
		{
			for(int i = 0;i<Length;i++)
				if(_items[i]!.Equals(item))
					return i;
			return -1;
		}
		/// <summary>
		/// Moves/Copies the item at the <paramref name="sourceIndex"/> to the <paramref name="destinationIndex"/>.
		/// </summary>
		/// <param name="sourceIndex"></param>
		/// <param name="destinationIndex"></param>
		/// <returns></returns>
		public bool Move(int sourceIndex, int destinationIndex)
		{
			if(IsInRange(sourceIndex, destinationIndex))
			{
				T sourceItem=_items[sourceIndex];
				_items[destinationIndex]=sourceItem;
				return true;
			}
			return false;
		}
		/// <summary>
		/// Swaps two items in the collection with each other.
		/// </summary>
		/// <param name="sourceIndex"></param>
		/// <param name="destinationIndex"></param>
		/// <returns></returns>
		public bool Swap(int sourceIndex, int destinationIndex)
		{
			if(IsInRange(sourceIndex, destinationIndex))
			{
				T sourceItem=_items[sourceIndex];
				T destinationItem=_items[destinationIndex];
				_items[destinationIndex]=sourceItem;
				_items[sourceIndex]=destinationItem;
				return true;
			}
			return false;
		}
		/// <summary>
		/// Shifts all of the items starting at the <paramref name="startIndex"/> and shifts all of the items in the collection to the left by the given <paramref name="length"/>.
		/// </summary>
		/// <param name="startIndex"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public bool Shift(int startIndex, int length)
		{
			if(IsInRange(startIndex, startIndex-length))
			{
				for(int i = startIndex;i<Length;i++)
					Move(i, i-length);
				return true;
			}
			throw new Exception("The calculated shift references an index position the is outside of the range of the collection. (Formula: startIndex-length; Calculated: "+startIndex.ToString()+" - "+length.ToString()+" = "+(startIndex-length).ToString()+";)");
		}
		/// <summary>
		/// Removes the first occurance of an item or items from the collection.
		/// </summary>
		/// <param name="items"></param>
		public void Remove(params T[] items)
		{
			foreach(var item in items)
			{
				Shift(IndexOf(item), 1);
				Array.Resize(ref _items, Length-1);
			}
		}

		public bool IsInRange(params int[] indicies) => indicies.All(index=>index>-1 && index<Length);



	}
}
