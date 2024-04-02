namespace CRSWeb.Models
{

    public class Report
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    // Models/Page.cs
    public class Page
    {
        public string Title { get; set; }
        public List<Report> Reports { get; set; }
        public string ReleaseDataUrl { get; set; }
    }
}