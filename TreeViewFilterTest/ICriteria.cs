namespace TreeViewFilterTest
{
    //Itercepting Filtr Pattern
    //https://www.c-sharpcorner.com/article/dynamic-filter-by-using-intercepting-filter-pattern/
    public interface ICriteria
    {
        /// <summary>
        /// Name of the criteria to be displayed
        /// </summary>
        string Name { get; }        

        /// <summary>
        /// Filtering method
        /// </summary>
        /// <param name="hierarchicalEnumerable"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        HierarchicalEnumerable MeetCriteria(HierarchicalEnumerable hierarchicalEnumerable, HierarchicalItem parent = null);
    }
}