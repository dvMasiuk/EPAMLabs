using Grid.Mvc.Ajax.GridExtensions;

namespace SystemSales.Presentation.Models
{
    public class GridViewModel<T> where T : class
    {
        public AjaxGrid<T> Grid { get; set; }
        public bool EnabledControlColumn { get; set; }
        public string NameGrid { get; set; }
    }
}