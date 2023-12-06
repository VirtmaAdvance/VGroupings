namespace VGroupings
{
	public class VGroup
	{

		private VGroupItem[] _items = Array.Empty<VGroupItem>();



		public bool Add(VGroupItem item)
		{
			if(ContainsKey(item.Name))
				return false;
			_items.Add(item);
			return true;
		}

		public void Add(string name, params KeyValuePair<string, object>[] values) => _items=_items.Add(new VGroupItem(name, values));

		public void Add(string name, Dictionary<string, object> values) => _items=_items.Add(new VGroupItem(name, values));

		public void Remove(string name) => 

		public bool ContainsKey(string key) => _items=_items.Any(q=>q.Name==key);



	}
}