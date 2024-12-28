using Microsoft.CodeAnalysis;
using ProjectManager.Models.Database;
using System.Globalization;
using System.Text;
using System.Data.SQLite;
using ProjectManager.Models;
using ProjectManager.Models.BusinessLogic;
using ProjectManager.Models.Database;
using ProjectManager.Models.ViewMode;
using ProjectInfo = ProjectManager.Models.Common.ProjectInfo;
using Project = ProjectManager.Models.Database.Project;
using Dashboard = ProjectManager.Models.ViewMode.Dashboard;

namespace ProjectManager.Models.BusinessLogic
{
    public class SqlModel
    {
        private string connectionString = "Data Source=D:\\ms_c#_web\\ProjectManager1.0-master\\ProjectManager\\Modern.db";

       

        public List<Project> GetProjects()
        {
            var projects = new List<Project>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand("SELECT * FROM project WHERE IssueType = 'Project'", connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var project = new Project
                        {
                            ProjectId = reader["ProjectId"].ToString(),
                            ProjectName = reader["ProjectName"].ToString(),
                            CategoryId = Convert.ToInt32(reader["CategoryId"]),
                            ClientId = Convert.ToInt32(reader["ClientId"]),
                            Starred = Convert.ToInt32(reader["Starred"]),
                            IssueType = reader["IssueType"].ToString(),
                            TeamId = Convert.ToInt32(reader["TeamId"]),
                            Priority = reader["Priority"].ToString(),
                            StartDate = ParseDateTime(reader["StartDate"]),
                            POReceiveDate = ParseDateTime(reader["POReceiveDate"]),
                            DeliveryDate = ParseDateTime(reader["DeliveryDate"]),
                            DueDate = ParseDateTime(reader["DueDate"]),
                            FinishDate = ParseDateTime(reader["FinishDate"]),
                            Stage = reader["Stage"].ToString(),
                            Status = reader["Status"].ToString(),
                            Label = reader["Label"].ToString(),
                            ReportId = Convert.ToInt32(reader["ReportId"]),
                            Description = reader["Description"].ToString(),
                            CreateAt = ParseDateTime(reader["CreateAt"]),
                            UpdateAt = ParseDateTime(reader["UpdateAt"]),
                            ParentId = Convert.ToInt32(reader["ParentId"])
                        };

                        projects.Add(project);
                    }
                }
            }

            return projects;
        }
        public Dashboard Dashboard_header(string input, string status, string clientid, string assign, string pic)
        {
            var dashboard = new Dashboard();

            using (var connection = new SQLiteConnection(connectionString))
            {
                string sql = @"
SELECT 
    COUNT(c.ClientId) AS sumclient,
    (SELECT COUNT(*) FROM project WHERE IssueType = 'PROJECT') AS sum_project,
    (SELECT COUNT(*) FROM project WHERE IssueType = 'EPIC') AS sum_epic,
    (SELECT COUNT(*) FROM project WHERE IssueType = 'TASK') AS sum_task,
    (SELECT COUNT(*) FROM project WHERE IssueType = 'ISSUE') AS sum_issue
FROM 
    client c;";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        // Check if any rows are returned
                        if (reader.Read())
                        {
                            // Populate the dashboard object with the values from the first row
                            dashboard.SumClients = Convert.ToInt32(reader["sumclient"]);
                            dashboard.SumProjects = Convert.ToInt32(reader["sum_project"]);
                            dashboard.SumEpics = Convert.ToInt32(reader["sum_epic"]);
                            dashboard.SumTasks = Convert.ToInt32(reader["sum_task"]);
                        }
                        else
                        {
                            // If no rows are returned, return null
                            return null;
                        }
                    }
                }
            }

            // Return the dashboard object if data was found
            return dashboard;
        }


        public List<ProjectInfo> GetProjectInfo(string input, string status, string clientid, string assign, string pic)
        {
            var projects = new List<ProjectInfo>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                var sql = new StringBuilder(@"
            select  a.IssueType,a.ProjectId,a.Starred ,a.ProjectName,a.Status,d.UserName AssigneeUserName,a.DueDate,a.Priority,a.label,e.ClientName,a.CreateAt,a.UpdateAt,c.UserName PicUserName,a.ParentId
            from project a,user_assign b,""user"" c ,""user"" d,user_assign f,client e
            where a.ProjectId =b.ProjectId and c.UserId =b.UserId 
            and d.UserId =f.UserId  and f.ProjectId =a.ProjectId 
            and b.Assign_type ='PIC' and f.Assign_type ='Assign1'            
            and e.ClientId =a.ClientId  
        ");

                if (!string.IsNullOrEmpty(input))
                {
                    sql.Append(" AND a.ProjectName LIKE @input ");
                }
                if (!string.IsNullOrEmpty(status))
                {
                    sql.Append(" AND a.Status = @status ");
                }
                if (!string.IsNullOrEmpty(clientid))
                {
                    sql.Append(" AND a.ClientId = @clientid ");
                }
                if (!string.IsNullOrEmpty(assign))
                {
                    sql.Append(" AND f.UserId = @assign ");
                }
                if (!string.IsNullOrEmpty(pic))
                {
                    sql.Append(" AND b.UserId = @pic ");
                }

                sql.Append(" ORDER BY a.Starred DESC,a.CreateAt DESC");

                using (var command = new SQLiteCommand(sql.ToString(), connection))
                {
                    if (!string.IsNullOrEmpty(input))
                    {
                        command.Parameters.AddWithValue("@input", $"%{input}%");
                    }
                    if (!string.IsNullOrEmpty(status))
                    {
                        command.Parameters.AddWithValue("@status", status);
                    }
                    if (!string.IsNullOrEmpty(clientid))
                    {
                        command.Parameters.AddWithValue("@clientid", clientid);
                    }
                    if (!string.IsNullOrEmpty(assign))
                    {
                        command.Parameters.AddWithValue("@assign", assign);
                    }
                    if (!string.IsNullOrEmpty(pic))
                    {
                        command.Parameters.AddWithValue("@pic", pic);
                    }

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var project = new ProjectInfo
                            {
                                IssueType = reader["IssueType"].ToString(),
                                ProjectId = Convert.ToInt32(reader["ProjectId"]),
                                Starred = Convert.ToInt32(reader["Starred"]),
                                ProjectName = reader["ProjectName"].ToString(),
                                Status = reader["Status"].ToString(),
                                AssigneeUserName = reader["AssigneeUserName"].ToString(),
                                DueDate = Convert.ToDateTime(reader["DueDate"]),
                                Priority = reader["Priority"].ToString(),                              
                                Label = reader["label"].ToString(),
                                ClientName = reader["ClientName"].ToString(),
                                CreatedAt = Convert.ToDateTime(reader["CreateAt"]),
                                UpdatedAt = Convert.ToDateTime(reader["UpdateAt"]),
                                PicUserName = reader["PicUserName"].ToString(),
                                ParentId = Convert.ToInt32(reader["ParentId"])
                            };

                            projects.Add(project);
                        }
                    }
                }
            }

            return projects;
        }

        public List<Client> getClient()
        {
            var clients = new List<Client>(); // Danh sách để lưu trữ kết quả

            using (var connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand("SELECT * FROM client", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var client = new Client
                        {
                            ClientName = reader["ClientName"].ToString(),
                            ClientId = Convert.ToInt32(reader["ClientId"]), // Chuyển đổi ClientId
                            Phone = reader["Phone"] != DBNull.Value ? Convert.ToInt32(reader["Phone"]) : 0, // Kiểm tra giá trị null
                            Fax = reader["Fax"].ToString(),
                            Email = reader["Email"].ToString(), // Đã sửa từ Fax sang Email
                            Address1 = reader["Address1"].ToString(),
                            Address2 = reader["Address2"].ToString(),
                            Contact = reader["Contact"].ToString(),
                        };
                        clients.Add(client);
                    }
                }
            }

            return clients;
        }
        public int getMaxProjectId()
        {
            int projectid = 0;
            using (var connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand(" select max(CAST(ProjectId as int)) as projectID from project", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        projectid = Convert.ToInt32(reader["projectID"]);

                    }
                }
            }

            return projectid + 1;
        }

        public bool InsertProject(int projectId)
        {
            string createdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("INSERT INTO project (ProjectId,CreateAt) VALUES (@ProjectId,@createddate)", connection);
                command.Parameters.AddWithValue("@ProjectId", projectId);
                command.Parameters.AddWithValue("@createddate", createdate);
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Lỗi khi chèn dự án: " + ex.Message);
                    return false;
                }
            }
        }

        public bool UpdateProject(CreateParamaster project)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("UPDATE project SET ProjectName=@ProjectName, /*CategoryId=@CategoryId, ClientId=@ClientId,*/ Starred=@Starred, IssueType=@IssueType, TeamId=@TeamId, Priority=@Priority, StartDate=@StartDate, POReceiveDate=@POReceiveDate, DeliveryDate=@DeliveryDate, DueDate=@DueDate, FinishDate=@FinishDate, Stage=@Stage, Status=@Status, Label=@Label, ReportId=@ReportId, Description=@Description, CreateAt=@CreateAt, UpdateAt=@UpdateAt, ParentId=@ParentId, Project_type=@Project_type WHERE ProjectId=@ProjectId;", connection);

                command.Parameters.AddWithValue("@ProjectId", project.ProjectID);
                command.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                //command.Parameters.AddWithValue("@CategoryId", project.CategoryId);
                //command.Parameters.AddWithValue("@ClientId", project.ClientId);
                command.Parameters.AddWithValue("@Starred", project.Starr);
                command.Parameters.AddWithValue("@IssueType", project.IssueType);
                command.Parameters.AddWithValue("@TeamId", project.Team);
                command.Parameters.AddWithValue("@Priority", project.Priority);
                command.Parameters.AddWithValue("@StartDate", project.StartDate);
                command.Parameters.AddWithValue("@POReceiveDate", project.PoDate);
                command.Parameters.AddWithValue("@DeliveryDate", project.DeliveryDate);
                command.Parameters.AddWithValue("@DueDate", project.DueDate);
                command.Parameters.AddWithValue("@FinishDate", project.FinishDate);
                //command.Parameters.AddWithValue("@Stage", project.Stage);
                command.Parameters.AddWithValue("@Status", project.Status);
                command.Parameters.AddWithValue("@Label", project.Label);
                //command.Parameters.AddWithValue("@ReportId", project.ReportId);
                command.Parameters.AddWithValue("@Description", project.Description);
                command.Parameters.AddWithValue("@CreateAt", project.CreateDate);
                command.Parameters.AddWithValue("@UpdateAt", project.UpdateDate);
                //command.Parameters.AddWithValue("@ParentId", project.ParentId);
                command.Parameters.AddWithValue("@Project_type", project.ProjectType);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Lỗi khi cập nhật dự án: " + ex.Message);
                    return false; // Trả về false nếu có lỗi
                }
            }
        }

        public bool CreateProject(int projectId)
        {
            string createdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("INSERT INTO project (ProjectId,CreateAt) VALUES (@ProjectId,@createddate)", connection);
                command.Parameters.AddWithValue("@ProjectId", projectId);
                command.Parameters.AddWithValue("@createddate", createdate);
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Lỗi khi chèn dự án: " + ex.Message);
                    return false;
                }
            }
        }
        public List<User> getUser()
        {
            var users = new List<User>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand("SELECT * FROM user", connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new User
                        {
                            UserName = reader["UserName"].ToString(),
                            UserId = Convert.ToInt32(reader["UserId"]),
                        };
                        users.Add(user);
                    }
                }
            }

            return users;
        }
        public List<Issue_type> getIssueType()
        {
            var issuetypes = new List<Issue_type>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand("SELECT * FROM Issue_type", connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var issuetype = new Issue_type
                        {
                            ISSUE_TYPE = reader["issue_type"].ToString(),
                            TYPE_ID = Convert.ToInt32(reader["type_id"]),
                        };
                        issuetypes.Add(issuetype);
                    }
                }
            }

            return issuetypes;
        }

        public List<Projet_type> getProjectType()
        {
            var projecttypes = new List<Projet_type>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand("SELECT * FROM Projet_type", connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var projecttype = new Projet_type
                        {
                            PROJECT_TYPE = reader["Project_type"].ToString(),
                            TYPE_ID = Convert.ToInt32(reader["type_id"]),
                        };
                        projecttypes.Add(projecttype);
                    }
                }
            }

            return projecttypes;
        }

        public List<Team> getTeam()
        {
            var teams = new List<Team>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand("SELECT * FROM team", connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var team = new Team
                        {
                            TeamName = reader["TeamName"].ToString(),
                            TeamId = Convert.ToInt32(reader["TeamId"]),
                        };
                        teams.Add(team);
                    }
                }
            }

            return teams;
        }
        public List<(int RowNumber, string Label)> getLabel()
        {
            var labels = new List<(int RowNumber, string Label)>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand("SELECT distinct label FROM project where label is not null order by 1", connection);
                connection.Open();
                int i = 1;
                using (var reader = command.ExecuteReader())
                {
                    i++;
                    while (reader.Read())
                    {
                        var label = (i, reader["label"].ToString());
                        labels.Add(label);
                    }
                }
            }

            return labels;
        }

        private DateTime ParseDateTime(object dbValue)
        {
            if (dbValue == DBNull.Value || string.IsNullOrWhiteSpace(dbValue.ToString()))
            {
                return DateTime.MinValue; // Giá trị mặc định cho DateTime nếu là null hoặc chuỗi trống
            }

            // Sử dụng TryParseExact để xác định các định dạng ngày tháng có thể có
            DateTime parsedDate;
            string dateString = dbValue.ToString();
            string[] formats = { "yyyy-MM-dd", "yyyy-MM-dd HH:mm:ss", "MM/dd/yyyy", "dd/MM/yyyy" };
            if (DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                return parsedDate;
            }
            else
            {
                return DateTime.MinValue; // Giá trị mặc định nếu không thể chuyển đổi
            }
        }
        


        public int GetEpics()
        {
            return 450; // Giả sử giá trị cố định
            using (var connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand("SELECT COUNT(*) FROM Project", connection);
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public int GetTasks()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand("SELECT COUNT(*) FROM Project where  issuetype='Task' ", connection);
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public int GetIssues()
        {
            return 150; // Giả sử giá trị cố định
            using (var connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand("SELECT COUNT(*) FROM Issues", connection);
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public int GetReports()
        {
            return 150; // Giả sử giá trị cố định
            using (var connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand("SELECT COUNT(*) FROM Reports", connection);
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public List<string> GetChartLabels()
        {
            // Giả sử giá trị cố định
            var labels = new List<string>();
            return labels;
            using (var connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand("SELECT LabelColumn FROM ChartData", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        labels.Add(reader.GetString(0));
                    }
                }
            }
            return labels;
        }

        public List<int> GetChartValues()
        {
            var values = new List<int>();
            return values;
            using (var connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand("SELECT ValueColumn FROM ChartData", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        values.Add(reader.GetInt32(0));
                    }
                }
            }
            return values;
        }

    }
}
