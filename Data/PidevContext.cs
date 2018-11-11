namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain.Entities;

    public partial class PidevContext : DbContext
    {
        public PidevContext()
            : base("name=PidevContext1")
        {
        }

        public virtual DbSet<admin> admin { get; set; }
        public virtual DbSet<_break> _break { get; set; }
        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<holiday> holiday { get; set; }
        public virtual DbSet<mandate> mandate { get; set; }
        public virtual DbSet<message> message { get; set; }
        public virtual DbSet<organigram> organigram { get; set; }
        public virtual DbSet<project> project { get; set; }
        public virtual DbSet<request> request { get; set; }
        public virtual DbSet<ressource> ressource { get; set; }
        public virtual DbSet<resume> resume { get; set; }
        public virtual DbSet<skill> skill { get; set; }
        public virtual DbSet<user> user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin>()
                .HasMany(e => e.message)
                .WithOptional(e => e.admin)
                .HasForeignKey(e => e.adminsend);

            modelBuilder.Entity<admin>()
                .HasMany(e => e.request)
                .WithOptional(e => e.admin)
                .HasForeignKey(e => e.reqadmin);

            modelBuilder.Entity<_break>()
                .HasMany(e => e.ressource1)
                .WithOptional(e => e.break1)
                .HasForeignKey(e => e.leaveId);

            modelBuilder.Entity<client>()
                .Property(e => e.clientAddress)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.clientCategory)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.clientLogo)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.clientNote)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.clientType)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .HasMany(e => e.message)
                .WithOptional(e => e.client)
                .HasForeignKey(e => e.clrecu);

            modelBuilder.Entity<client>()
                .HasMany(e => e.message1)
                .WithOptional(e => e.client1)
                .HasForeignKey(e => e.clsend);

            modelBuilder.Entity<client>()
                .HasMany(e => e.request)
                .WithOptional(e => e.client)
                .HasForeignKey(e => e.reqcl);

            modelBuilder.Entity<client>()
                .HasMany(e => e.project)
                .WithOptional(e => e.client)
                .HasForeignKey(e => e.ownerId);

            modelBuilder.Entity<holiday>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .HasMany(e => e.ressource)
                .WithOptional(e => e.mandate)
                .HasForeignKey(e => e.mandateId);

            modelBuilder.Entity<message>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e._object)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<organigram>()
                .Property(e => e.accountManager)
                .IsUnicode(false);

            modelBuilder.Entity<organigram>()
                .Property(e => e.assignementManager)
                .IsUnicode(false);

            modelBuilder.Entity<organigram>()
                .Property(e => e.managementLevel)
                .IsUnicode(false);

            modelBuilder.Entity<organigram>()
                .Property(e => e.programName)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.projectType)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .HasMany(e => e.ressource)
                .WithOptional(e => e.project)
                .HasForeignKey(e => e.projectId);

            modelBuilder.Entity<request>()
                .Property(e => e.duration)
                .IsUnicode(false);

            modelBuilder.Entity<request>()
                .Property(e => e.typeressource)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.availability)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.contractType)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.sector)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .HasMany(e => e._break)
                .WithOptional(e => e.ressource)
                .HasForeignKey(e => e.resource_userId);

            modelBuilder.Entity<ressource>()
                .HasMany(e => e.mandate1)
                .WithRequired(e => e.ressource1)
                .HasForeignKey(e => e.resourceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ressource>()
                .HasMany(e => e.message)
                .WithOptional(e => e.ressource)
                .HasForeignKey(e => e.rsrecu);

            modelBuilder.Entity<ressource>()
                .HasMany(e => e.message1)
                .WithOptional(e => e.ressource1)
                .HasForeignKey(e => e.rssend);

            modelBuilder.Entity<ressource>()
                .HasMany(e => e.project1)
                .WithMany(e => e.ressource1)
                .Map(m => m.ToTable("project_ressource").MapLeftKey("ressourcesList_userId").MapRightKey("Project_projectId"));

            modelBuilder.Entity<resume>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<resume>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .HasMany(e => e.project)
                .WithMany(e => e.skill)
                .Map(m => m.ToTable("project_skill", "pidev").MapLeftKey("skillsRequired_skillId").MapRightKey("Project_projectId"));

            modelBuilder.Entity<skill>()
                .HasMany(e => e.resume)
                .WithMany(e => e.skill)
                .Map(m => m.ToTable("resume_skill").MapLeftKey("skills_skillId").MapRightKey("Resume_resumeId"));

            modelBuilder.Entity<user>()
                .Property(e => e.confirmPassword)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.emailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.userType)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasOptional(e => e.admin)
                .WithRequired(e => e.user);

            modelBuilder.Entity<user>()
                .HasOptional(e => e.client)
                .WithRequired(e => e.user);
        }
    }
}
