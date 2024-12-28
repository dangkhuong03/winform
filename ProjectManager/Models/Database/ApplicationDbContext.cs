//using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManager.Models.ViewMode;

namespace ProjectManager.Models.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){}

        public DbSet<Client> Clients { get; set; }
        public DbSet<Team> TEAM { get; set; }
        public DbSet<User> USER { get; set; }
        public DbSet<Issue_type> ISSUE_TYPE { get; set; }
        public DbSet<Projet_type> PROJECT_TYPE { get; set; }
        public DbSet<Status_conf> STATUS { get; set; }
        public DbSet<Project> PROJECT { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Priority> Prioritys { get; set; }
        public DbSet<ProjectCategory> ProjectCategorys { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserAssign> UserAssigns { get; set; }

    }
}