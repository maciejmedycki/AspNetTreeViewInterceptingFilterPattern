namespace TreeViewFilterTest.Criterias
{
    /// <summary>
    /// Change TreeViewNode color depending on custom logic.
    /// </summary>
    public class CriteriaColors: ICriteria
    {
        public string Name => "ColorIT!";

        public HierarchicalEnumerable MeetCriteria(HierarchicalEnumerable hierarchicalEnumerable, HierarchicalItem parent = null)
        {
            foreach (HierarchicalItem h in hierarchicalEnumerable)
            {
                var item = (ItemViewModel)h.Item;
                if (item.Item.A)
                    item.Name = $"<span style='color: red;'>{item.Name}</span>";
                if (item.Item.B)
                    item.Name = $"<span style='color: blue;'>{item.Name}</span>";
                if (item.Item.C)
                    item.Name = $"<span style='color: green;'>{item.Name}</span>";
                h.Children = MeetCriteria(h.Children, h);
            }
            return hierarchicalEnumerable;
        }
    }
}