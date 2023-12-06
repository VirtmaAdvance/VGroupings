using System.Collections;

namespace VGroupings
{
	public struct VGroupItem : IEnumerable<KeyValuePair<string, object>>
	{

		private static Exception s_exception = new Exception("Unable to convert the value.");
		/// <summary>
		/// The name of this group item.
		/// </summary>
		public string Name { get; set; }

		private Dictionary<string, object> _items = new Dictionary<string, object>();
		/// <summary>
		/// Gets or sets the key values pair in the collection.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public object this[string key]
		{
			get => Get(key);
			set
			{
				if(_items.ContainsKey(key))
					_items[key]=value;
				else
					_items.Add(key, value);
			}
		}

		/// <inheritdoc cref="VGroupItem(string)"/>
		public VGroupItem() => Name=string.Empty;
		/// <inheritdoc cref="VGroupItem(string, KeyValuePair{string, object})"/>
		public VGroupItem(string name) => Name=name;
		/// <summary>
		/// Creates a new instance of the <see cref="VGroupItem"/> struct object.
		/// </summary>
		/// <param name="name">The name of the item.</param>
		/// <param name="values">The <see cref="KeyValuePair{string, object}"/> to add.</param>
		public VGroupItem(string name, params KeyValuePair<string, object>[] values)
		{
			Name=name;
			foreach(var sel in values)
				_items.Add(sel.Key, sel.Value);
		}
		/// <summary>
		/// Creates a new instance of the <see cref="VGroupItem"/> struct object.
		/// </summary>
		/// <param name="name">The name of the item.</param>
		/// <param name="value">The <see cref="Dictionary{string, object}"/> to add.</param>
		public VGroupItem(string name, Dictionary<string, object> value)
		{
			Name=name;
			_items=value;
		}
		/// <summary>
		/// Adds a new item to the collection.
		/// </summary>
		/// <param name="name">The name/key of the item.</param>
		/// <param name="value">The values associated with the <paramref name="name"/>.</param>
		/// <returns>a <see cref="bool">boolean</see> values representing the status of the operation.</returns>
		public readonly bool Add(string name, object value)
		{
			if(_items.ContainsKey(name))
				return false;
			_items.Add(name, value);
			return true;
		}
		/// <summary>
		/// Determines if the <paramref name="key"/> exists within the collection.
		/// </summary>
		/// <param name="key">The key of the item to look for.</param>
		/// <returns>a <see cref="bool">boolean</see> values representing the status of the operation.</returns>
		public bool ContainsKey(string key) => _items.ContainsKey(key);
		/// <summary>
		/// Removes an item that has the <paramref name="name"/>.
		/// </summary>
		/// <param name="name">The name/key of the item to remove.</param>
		/// <returns>a <see cref="bool">boolean</see> values representing the status of the operation.</returns>
		public bool Remove(string name) => ContainsKey(name) ? _items.Remove(name) : false;
		/// <summary>
		/// Clears the collection.
		/// </summary>
		public readonly void Clear() => _items.Clear();

		public object Get(string key) => ContainsKey(key) ? _items[key] : throw new ArgumentException("The given key value does not exist within the collection.");
		/// <summary>
		/// Determines if the <paramref name="key"/> and stored data-type match the given <paramref name="type"/>.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		private bool CheckType(string key, Type type) => ContainsKey(key) && _items[key].GetType() == type;

		private object? GetValue(string key, Type type) => CheckType(key, type) ? _items[key] : null;

		private string GetString(string key) => (GetValue(key, typeof(string))?.ToString()) ?? throw s_exception;

		private byte GetByte(string key) => Convert.ToByte(GetValue(key, typeof(byte))??throw s_exception);

		private char GetChar(string key) => Convert.ToChar(GetValue(key, typeof(char))??throw s_exception);

		private int GetInt(string key) => Convert.ToInt32(GetValue(key, typeof(int))??throw s_exception);

		private long GetLong(string key) => Convert.ToInt64(GetValue(key, typeof(long))??throw s_exception);

		private short GetShort(string key) => Convert.ToInt16(GetValue(key, typeof(short))??throw s_exception);

		IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator() => _items.GetEnumerator();

		public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => _items.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
	}
}
