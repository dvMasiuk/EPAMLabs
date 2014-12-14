using System.Collections;

namespace SystemSales.Presentation.Models
{
    public class ChartViewModel
    {
        public IEnumerable XValues { get; set; }
        public IEnumerable YValues { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public string Title { get; set; }
        public string NameSeries { get; set; }
    }
}