using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace TreeViewFilterTest
{
    /// <summary>
    /// IHierarchicalEnumerable implementation so TreeView DataSource can be used
    /// </summary>
    public class HierarchicalEnumerable : IHierarchicalEnumerable
    {
        private readonly IList<HierarchicalItem> _enumerable = new List<HierarchicalItem>();

        public int Count => _enumerable.Count;

        public void Add(HierarchicalItem item)
        {
            _enumerable.Add(item);
        }

        public IEnumerator GetEnumerator()
        {
            return _enumerable.GetEnumerator();
        }

        public IHierarchyData GetHierarchyData(object enumeratedItem)
        {
            return _enumerable.SingleOrDefault(x => x == enumeratedItem);
        }
    }
}