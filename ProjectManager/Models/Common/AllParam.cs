using ProjectManager.Models.Database;
using System.Collections.Generic;

namespace ProjectManager.Models.Common
{
    public class AllParam
    {
        public List<Status_conf> Status { get; set; }
        public List<User> assigns { get; set; }
        public List<Client> clients { get; set; }
        public List<Issue_type> issueTypes { get; set; }
        public List<ProjectManager.Models.Database.Projet_type> projectTypes { get; set; }
        public List<Priority> prioritys { get; set; }
        public List<Team> teams { get; set; }
        public List<string> labels { get; set; } 


    }
    //public class Status
    //{
    //    public string Text { get; set; } = string.Empty;
    //    public string Value { get; set; } = string.Empty;
    //}
    //public class Assign
    //{
    //    public string Text { get; set; } = string.Empty;
    //    public string Value { get; set; } = string.Empty;
    //}
    //public class Client
    //{
    //    public string Text { get; set; } = string.Empty;
    //    public string Value { get; set; } = string.Empty;
    //}
    //public class IssueType
    //{
    //    public string Text { get; set; } = string.Empty;
    //    public string Value { get; set; } = string.Empty;
    //}
    //public class ProjectType
    //{
    //    public string Text { get; set; } = string.Empty;
    //    public string Value { get; set; } = string.Empty;
    //}

    //public class Priority
    //{
    //    public string Text { get; set; } = string.Empty;
    //    public string Value { get; set; } = string.Empty;
    //}
    //public class Team
    //{
    //    public string Text { get; set; } = string.Empty;
    //    public string Value { get; set; } = string.Empty;
    //}
    //public class Label
    //{
    //    public string Text { get; set; } = string.Empty;
    //    public string Value { get; set; } = string.Empty;
    //}


}
