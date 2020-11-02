namespace TreeViewFilterTest.Criterias
{
    public class CriteriaCustom : ICriteria
    {
        public string Name => "Custom";

        public HierarchicalEnumerable MeetCriteria(HierarchicalEnumerable hierarchicalEnumerable, HierarchicalItem parent = null)
        {
            foreach (HierarchicalItem h in hierarchicalEnumerable)
            {
                var item = (ItemViewModel)h.Item;
                item.Checked = item.Item.A & item.Item.B & item.Item.C;
                h.Children = MeetCriteria(h.Children, h);
            }
            return hierarchicalEnumerable;
        }
    }
}