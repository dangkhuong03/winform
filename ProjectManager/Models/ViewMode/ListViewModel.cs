using Microsoft.CodeAnalysis;

namespace ProjectManager.Models.ViewMode
{
    public class ListViewModel
    {

        public int TotalProjects { get; set; }
        public int StarredProjects { get; set; }
        public int TodoProjects { get; set; }
        public int InProgressProjects { get; set; }
        public int OverdueProjects { get; set; }
        public int CompletedProjects { get; set; }
        public int CanceledProjects { get; set; }
        public List<ProjectManager.Models.Common.ProjectInfo> Projects { get; set; }

        public List<ProjectManager.Models.Common.ProjectInfo> ALLProjects { get; set; }
    }
}
