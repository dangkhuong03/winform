namespace ProjectManager.Models.Common
{
    public class ProjectInfo
    {
        public string IssueType { get; set; }
        public int ProjectId { get; set; }
        public int Starred { get; set; }
        public string ProjectName { get; set; }
        public string Status { get; set; }
        public string AssigneeUserName { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public string Label { get; set; }
        public string ClientName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string PicUserName { get; set; }

        public int ParentId { get; set; }

        public List<ProjectInfo> Children { get; set; } = new List<ProjectInfo>();
    }
}
