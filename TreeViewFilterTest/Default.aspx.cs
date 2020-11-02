using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TreeViewFilterTest
{
    public partial class Default : System.Web.UI.Page
    {
        //beware we are using session, but it should be ok for Criterias
        private const string CriteriasSessionKey = "criteriasKey";

        private const string ItemViewStateKey = "itemKey";

        protected void MainTreeView_TreeNodeDataBound(object sender, TreeNodeEventArgs e)
        {
            var itemViewModel = (ItemViewModel)e.Node.DataItem;
            e.Node.Checked = itemViewModel.Checked;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadFilterList();
                LoadMainItem();
            }
            BuildCriteriasAndFilterTreeViewData();
        }

        /// <summary>
        /// Build data and filters it using specified criterias.
        /// </summary>
        private void BuildCriteriasAndFilterTreeViewData()
        {
            var criterias = new List<ICriteria>();
            foreach (RepeaterItem repeaterItem in FilterRepeater.Items)
            {
                if (repeaterItem.ItemType == ListItemType.Item || repeaterItem.ItemType == ListItemType.AlternatingItem)
                {
                    var checkBox = (CheckBox)repeaterItem.FindControl("CriteriaCheckBox");
                    if (checkBox != null && checkBox.Checked)
                    {
                        var criteria = GetCriteriaFromSession(checkBox.Text);
                        criterias.Add(criteria);
                    }
                }
            }
            var item = GetHierarchicalItems();
            foreach (var criteria in criterias)
            {
                item = criteria.MeetCriteria(item);
            }
            MainTreeView.DataSource = item;
            MainTreeView.DataBind();
        }

        /// <summary>
        /// Get filter/criteria from Session
        /// </summary>
        /// <param name="name">Name of the <see cref="ICriteria"/></param>
        /// <returns>First or default criteria of given name from Session.</returns>
        private ICriteria GetCriteriaFromSession(string name)
        {
            //TODO: null checks, session can expire
            var criterias = (IEnumerable<ICriteria>)Session[CriteriasSessionKey];
            return criterias.FirstOrDefault(c => c.Name == name);
        }

        /// <summary>
        /// Converts <see cref="ItemModel"/> data to <see cref="HierarchicalEnumerable"/> 
        /// </summary>
        /// <returns>Data that can be bound to TreeView</returns>
        private HierarchicalEnumerable GetHierarchicalItems()
        {
            var itemModel = (IEnumerable<ItemModel>)ViewState[ItemViewStateKey];
            var data = new HierarchicalEnumerable();
            foreach (var item in itemModel)
            {
                data.Add(new HierarchicalItem(new ItemViewModel(item), null));
            }
            return data;
        }

        /// <summary>
        /// Loads all filters/criterias, binds them to repeater control and saves data to ViewState, so it can be reused.
        /// </summary>
        private void LoadFilterList()
        {
            var criterias = ClassLoaderByNamespace.Load<ICriteria>("TreeViewFilterTest.Criterias");
            Session[CriteriasSessionKey] = criterias;
            FilterRepeater.DataSource = criterias;
            FilterRepeater.DataBind();
        }

        /// <summary>
        /// Loads example ItemModles data and stores them in ViewState.
        /// </summary>
        private void LoadMainItem()
        {
            var mainItem = ItemsGenerator.GetMainItems();
            ViewState[ItemViewStateKey] = mainItem;
        }
    }
}