using System;
using System.Collections.Generic;
using Librasoft.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Librasoft.DataAccess.EFs
{
    public partial class PiranhaCoreContext : DbContext
    {
        public PiranhaCoreContext()
        {
        }

        public PiranhaCoreContext(DbContextOptions<PiranhaCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminAccount> AdminAccounts { get; set; }
        public virtual DbSet<PiranhaAlias> PiranhaAliases { get; set; }
        public virtual DbSet<PiranhaApplicationForm> PiranhaApplicationForms { get; set; }
        public virtual DbSet<PiranhaBlock> PiranhaBlocks { get; set; }
        public virtual DbSet<PiranhaBlockField> PiranhaBlockFields { get; set; }
        public virtual DbSet<PiranhaCategory> PiranhaCategories { get; set; }
        public virtual DbSet<PiranhaCfcountry> PiranhaCfcountries { get; set; }
        public virtual DbSet<PiranhaCfindustry> PiranhaCfindustries { get; set; }
        public virtual DbSet<PiranhaCfpartnerImg> PiranhaCfpartnerImgs { get; set; }
        public virtual DbSet<PiranhaCfreasonReaching> PiranhaCfreasonReachings { get; set; }
        public virtual DbSet<PiranhaContactForm> PiranhaContactForms { get; set; }
        public virtual DbSet<PiranhaContent> PiranhaContents { get; set; }
        public virtual DbSet<PiranhaContentBlock> PiranhaContentBlocks { get; set; }
        public virtual DbSet<PiranhaContentBlockField> PiranhaContentBlockFields { get; set; }
        public virtual DbSet<PiranhaContentBlockFieldTranslation> PiranhaContentBlockFieldTranslations { get; set; }
        public virtual DbSet<PiranhaContentField> PiranhaContentFields { get; set; }
        public virtual DbSet<PiranhaContentFieldTranslation> PiranhaContentFieldTranslations { get; set; }
        public virtual DbSet<PiranhaContentGroup> PiranhaContentGroups { get; set; }
        public virtual DbSet<PiranhaContentTranslation> PiranhaContentTranslations { get; set; }
        public virtual DbSet<PiranhaContentType> PiranhaContentTypes { get; set; }
        public virtual DbSet<PiranhaEvent> PiranhaEvents { get; set; }
        public virtual DbSet<PiranhaEventImage> PiranhaEventImages { get; set; }
        public virtual DbSet<PiranhaEventParticipant> PiranhaEventParticipants { get; set; }
        public virtual DbSet<PiranhaLanguage> PiranhaLanguages { get; set; }
        public virtual DbSet<PiranhaMediaFolder> PiranhaMediaFolders { get; set; }
        public virtual DbSet<PiranhaMediaVersion> PiranhaMediaVersions { get; set; }
        public virtual DbSet<PiranhaMedium> PiranhaMedia { get; set; }
        public virtual DbSet<PiranhaPage> PiranhaPages { get; set; }
        public virtual DbSet<PiranhaPageBlock> PiranhaPageBlocks { get; set; }
        public virtual DbSet<PiranhaPageComment> PiranhaPageComments { get; set; }
        public virtual DbSet<PiranhaPageField> PiranhaPageFields { get; set; }
        public virtual DbSet<PiranhaPagePermission> PiranhaPagePermissions { get; set; }
        public virtual DbSet<PiranhaPageRevision> PiranhaPageRevisions { get; set; }
        public virtual DbSet<PiranhaPageType> PiranhaPageTypes { get; set; }
        public virtual DbSet<PiranhaParam> PiranhaParams { get; set; }
        public virtual DbSet<PiranhaPost> PiranhaPosts { get; set; }
        public virtual DbSet<PiranhaPostBlock> PiranhaPostBlocks { get; set; }
        public virtual DbSet<PiranhaPostComment> PiranhaPostComments { get; set; }
        public virtual DbSet<PiranhaPostField> PiranhaPostFields { get; set; }
        public virtual DbSet<PiranhaPostPermission> PiranhaPostPermissions { get; set; }
        public virtual DbSet<PiranhaPostRevision> PiranhaPostRevisions { get; set; }
        public virtual DbSet<PiranhaPostType> PiranhaPostTypes { get; set; }
        public virtual DbSet<PiranhaRole> PiranhaRoles { get; set; }
        public virtual DbSet<PiranhaRoleClaim> PiranhaRoleClaims { get; set; }
        public virtual DbSet<PiranhaSite> PiranhaSites { get; set; }
        public virtual DbSet<PiranhaSiteField> PiranhaSiteFields { get; set; }
        public virtual DbSet<PiranhaSiteType> PiranhaSiteTypes { get; set; }
        public virtual DbSet<PiranhaTag> PiranhaTags { get; set; }
        public virtual DbSet<PiranhaTaxonomy> PiranhaTaxonomies { get; set; }
        public virtual DbSet<PiranhaUser> PiranhaUsers { get; set; }
        public virtual DbSet<PiranhaUserClaim> PiranhaUserClaims { get; set; }
        public virtual DbSet<PiranhaUserInformation> PiranhaUserInformations { get; set; }
        public virtual DbSet<PiranhaUserLogin> PiranhaUserLogins { get; set; }
        public virtual DbSet<PiranhaUserToken> PiranhaUserTokens { get; set; }
        public virtual DbSet<RootImage> RootImages { get; set; }
        public virtual DbSet<Temp> Temps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=192.168.1.187;Database=PiranhaCore;User ID=sa;Password=Sa2019;Integrated Security=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PiranhaAlias>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaApplicationForm>(entity =>
            {
                entity.Property(e => e.Phone).IsFixedLength();
            });

            modelBuilder.Entity<PiranhaBlock>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaBlockField>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaCategory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaCfcountry>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK__Piranha___10D1609F9FFE3BDC");
            });

            modelBuilder.Entity<PiranhaCfindustry>(entity =>
            {
                entity.HasKey(e => e.IndustyId)
                    .HasName("PK__Piranha___101795B3EAC23AD4");
            });

            modelBuilder.Entity<PiranhaCfpartnerImg>(entity =>
            {
                entity.HasKey(e => e.PartnerImgId)
                    .HasName("PK__Piranha___0F211E7882A697BA");
            });

            modelBuilder.Entity<PiranhaCfreasonReaching>(entity =>
            {
                entity.HasKey(e => e.ReasonReachingId)
                    .HasName("PK__Piranha___350A614E74328257");
            });

            modelBuilder.Entity<PiranhaContactForm>(entity =>
            {
                entity.Property(e => e.Phone).IsFixedLength();

                entity.HasOne(d => d.ReasonReaching)
                    .WithMany(p => p.PiranhaContactForms)
                    .HasForeignKey(d => d.ReasonReachingId)
                    .HasConstraintName("FK__Piranha_C__Reaso__339FAB6E");
            });

            modelBuilder.Entity<PiranhaContent>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasMany(d => d.Taxonomies)
                    .WithMany(p => p.Contents)
                    .UsingEntity<Dictionary<string, object>>(
                        "PiranhaContentTaxonomy",
                        l => l.HasOne<PiranhaTaxonomy>().WithMany().HasForeignKey("TaxonomyId").OnDelete(DeleteBehavior.ClientSetNull),
                        r => r.HasOne<PiranhaContent>().WithMany().HasForeignKey("ContentId"),
                        j =>
                        {
                            j.HasKey("ContentId", "TaxonomyId");

                            j.ToTable("Piranha_ContentTaxonomies");

                            j.HasIndex(new[] { "TaxonomyId" }, "IX_Piranha_ContentTaxonomies_TaxonomyId");
                        });
            });

            modelBuilder.Entity<PiranhaContentBlock>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaContentBlockField>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaContentBlockFieldTranslation>(entity =>
            {
                entity.HasKey(e => new { e.FieldId, e.LanguageId });
            });

            modelBuilder.Entity<PiranhaContentField>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaContentFieldTranslation>(entity =>
            {
                entity.HasKey(e => new { e.FieldId, e.LanguageId });
            });

            modelBuilder.Entity<PiranhaContentGroup>(entity =>
            {
                entity.Property(e => e.IsHidden).HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<PiranhaContentTranslation>(entity =>
            {
                entity.HasKey(e => new { e.ContentId, e.LanguageId });

                entity.Property(e => e.LastModified).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");
            });

            modelBuilder.Entity<PiranhaEvent>(entity =>
            {
                entity.HasMany(d => d.IdParticipants)
                    .WithMany(p => p.IdEvents)
                    .UsingEntity<Dictionary<string, object>>(
                        "PiranhaEventsParticipant",
                        l => l.HasOne<PiranhaEventParticipant>().WithMany().HasForeignKey("IdParticipants").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Piranha_Events_Participants_Piranha_EventParticipant"),
                        r => r.HasOne<PiranhaEvent>().WithMany().HasForeignKey("IdEvent").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Piranha_Events_Participants_Piranha_Event"),
                        j =>
                        {
                            j.HasKey("IdEvent", "IdParticipants");

                            j.ToTable("Piranha_Events_Participants");

                            j.IndexerProperty<int>("IdEvent").HasColumnName("ID_Event");

                            j.IndexerProperty<int>("IdParticipants").HasColumnName("ID_Participants");
                        });
            });

            modelBuilder.Entity<PiranhaEventImage>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ImgPath });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.PiranhaEventImages)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Piranha_EventImages_Piranha_Event");
            });

            modelBuilder.Entity<PiranhaEventParticipant>(entity =>
            {
                entity.Property(e => e.Phone).IsFixedLength();
            });

            modelBuilder.Entity<PiranhaLanguage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaMediaFolder>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaMediaVersion>(entity =>
            {
                entity.HasIndex(e => new { e.MediaId, e.Width, e.Height }, "IX_Piranha_MediaVersions_MediaId_Width_Height")
                    .IsUnique()
                    .HasFilter("([Height] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaMedium>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaPage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContentType).HasDefaultValueSql("(N'Page')");

                entity.Property(e => e.EnableComments).HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.MetaFollow).HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.Property(e => e.MetaIndex).HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.Property(e => e.MetaPriority).HasDefaultValueSql("((5.0000000000000000e-001))");
            });

            modelBuilder.Entity<PiranhaPageBlock>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaPageComment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaPageField>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaPagePermission>(entity =>
            {
                entity.HasKey(e => new { e.PageId, e.Permission });
            });

            modelBuilder.Entity<PiranhaPageRevision>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaParam>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaPost>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EnableComments).HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.MetaFollow).HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.Property(e => e.MetaIndex).HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.Property(e => e.MetaPriority).HasDefaultValueSql("((5.0000000000000000e-001))");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PiranhaPosts)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasMany(d => d.Tags)
                    .WithMany(p => p.Posts)
                    .UsingEntity<Dictionary<string, object>>(
                        "PiranhaPostTag",
                        l => l.HasOne<PiranhaTag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.ClientSetNull),
                        r => r.HasOne<PiranhaPost>().WithMany().HasForeignKey("PostId"),
                        j =>
                        {
                            j.HasKey("PostId", "TagId");

                            j.ToTable("Piranha_PostTags");

                            j.HasIndex(new[] { "TagId" }, "IX_Piranha_PostTags_TagId");
                        });
            });

            modelBuilder.Entity<PiranhaPostBlock>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaPostComment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaPostField>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaPostPermission>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.Permission });
            });

            modelBuilder.Entity<PiranhaPostRevision>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaSite>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaSiteField>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaTag>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaTaxonomy>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "PiranhaUserRole",
                        l => l.HasOne<PiranhaRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<PiranhaUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("Piranha_UserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_Piranha_UserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<PiranhaUserInformation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PiranhaUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<PiranhaUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
