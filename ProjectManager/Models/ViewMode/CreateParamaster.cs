namespace ProjectManager.Models.ViewMode
{
    public class CreateParamaster
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }

        public string IssueType { get; set; }

        public string ProjectType { get; set; }

        public string Priority { get; set; }

        public List<string> Team { get; set; }

        public List<string> Label { get; set; }

        public string AttachmentPath { get; set; }

        public string Description { get; set; }

        public int Starr { get; set; }

        public string Status { get; set; }
        public UserAsign assign { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DueDate { get; set; }

        public DateTime PoDate { get; set; }

        public DateTime DeliveryDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
    public class UserAsign
    {
        public int UserID { get; set; }
        public string AssignType { get; set; }
        public int ProjectId { get; set; }
    }
}
