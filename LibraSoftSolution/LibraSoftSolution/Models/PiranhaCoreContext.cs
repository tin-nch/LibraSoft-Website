using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraSoftSolution.Models
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

        public virtual DbSet<PiranhaAlias> PiranhaAliases { get; set; } = null!;
        public virtual DbSet<PiranhaBlock> PiranhaBlocks { get; set; } = null!;
        public virtual DbSet<PiranhaBlockField> PiranhaBlockFields { get; set; } = null!;
        public virtual DbSet<PiranhaCategory> PiranhaCategories { get; set; } = null!;
        public virtual DbSet<PiranhaCfcountry> PiranhaCfcountries { get; set; } = null!;
        public virtual DbSet<PiranhaCfindustry> PiranhaCfindustries { get; set; } = null!;
        public virtual DbSet<PiranhaCfpartnerImg> PiranhaCfpartnerImgs { get; set; } = null!;
        public virtual DbSet<PiranhaCfreasonReaching> PiranhaCfreasonReachings { get; set; } = null!;
        public virtual DbSet<PiranhaContactForm> PiranhaContactForms { get; set; } = null!;
        public virtual DbSet<PiranhaContent> PiranhaContents { get; set; } = null!;
        public virtual DbSet<PiranhaContentBlock> PiranhaContentBlocks { get; set; } = null!;
        public virtual DbSet<PiranhaContentBlockField> PiranhaContentBlockFields { get; set; } = null!;
        public virtual DbSet<PiranhaContentBlockFieldTranslation> PiranhaContentBlockFieldTranslations { get; set; } = null!;
        public virtual DbSet<PiranhaContentField> PiranhaContentFields { get; set; } = null!;
        public virtual DbSet<PiranhaContentFieldTranslation> PiranhaContentFieldTranslations { get; set; } = null!;
        public virtual DbSet<PiranhaContentGroup> PiranhaContentGroups { get; set; } = null!;
        public virtual DbSet<PiranhaContentTranslation> PiranhaContentTranslations { get; set; } = null!;
        public virtual DbSet<PiranhaContentType> PiranhaContentTypes { get; set; } = null!;
        public virtual DbSet<PiranhaLanguage> PiranhaLanguages { get; set; } = null!;
        public virtual DbSet<PiranhaMediaFolder> PiranhaMediaFolders { get; set; } = null!;
        public virtual DbSet<PiranhaMediaVersion> PiranhaMediaVersions { get; set; } = null!;
        public virtual DbSet<PiranhaMedium> PiranhaMedia { get; set; } = null!;
        public virtual DbSet<PiranhaPage> PiranhaPages { get; set; } = null!;
        public virtual DbSet<PiranhaPageBlock> PiranhaPageBlocks { get; set; } = null!;
        public virtual DbSet<PiranhaPageComment> PiranhaPageComments { get; set; } = null!;
        public virtual DbSet<PiranhaPageField> PiranhaPageFields { get; set; } = null!;
        public virtual DbSet<PiranhaPagePermission> PiranhaPagePermissions { get; set; } = null!;
        public virtual DbSet<PiranhaPageRevision> PiranhaPageRevisions { get; set; } = null!;
        public virtual DbSet<PiranhaPageType> PiranhaPageTypes { get; set; } = null!;
        public virtual DbSet<PiranhaParam> PiranhaParams { get; set; } = null!;
        public virtual DbSet<PiranhaPost> PiranhaPosts { get; set; } = null!;
        public virtual DbSet<PiranhaPostBlock> PiranhaPostBlocks { get; set; } = null!;
        public virtual DbSet<PiranhaPostComment> PiranhaPostComments { get; set; } = null!;
        public virtual DbSet<PiranhaPostField> PiranhaPostFields { get; set; } = null!;
        public virtual DbSet<PiranhaPostPermission> PiranhaPostPermissions { get; set; } = null!;
        public virtual DbSet<PiranhaPostRevision> PiranhaPostRevisions { get; set; } = null!;
        public virtual DbSet<PiranhaPostType> PiranhaPostTypes { get; set; } = null!;
        public virtual DbSet<PiranhaRole> PiranhaRoles { get; set; } = null!;
        public virtual DbSet<PiranhaRoleClaim> PiranhaRoleClaims { get; set; } = null!;
        public virtual DbSet<PiranhaSite> PiranhaSites { get; set; } = null!;
        public virtual DbSet<PiranhaSiteField> PiranhaSiteFields { get; set; } = null!;
        public virtual DbSet<PiranhaSiteType> PiranhaSiteTypes { get; set; } = null!;
        public virtual DbSet<PiranhaTag> PiranhaTags { get; set; } = null!;
        public virtual DbSet<PiranhaTaxonomy> PiranhaTaxonomies { get; set; } = null!;
        public virtual DbSet<PiranhaUser> PiranhaUsers { get; set; } = null!;
        public virtual DbSet<PiranhaUserClaim> PiranhaUserClaims { get; set; } = null!;
        public virtual DbSet<PiranhaUserLogin> PiranhaUserLogins { get; set; } = null!;
        public virtual DbSet<PiranhaUserToken> PiranhaUserTokens { get; set; } = null!;
        public virtual DbSet<RootImage> RootImages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local);Database=PiranhaCore;User Id=;Password=;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PiranhaAlias>(entity =>
            {
                entity.ToTable("Piranha_Aliases");

                entity.HasIndex(e => new { e.SiteId, e.AliasUrl }, "IX_Piranha_Aliases_SiteId_AliasUrl")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AliasUrl).HasMaxLength(256);

                entity.Property(e => e.RedirectUrl).HasMaxLength(256);

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.PiranhaAliases)
                    .HasForeignKey(d => d.SiteId);
            });

            modelBuilder.Entity<PiranhaBlock>(entity =>
            {
                entity.ToTable("Piranha_Blocks");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Clrtype)
                    .HasMaxLength(256)
                    .HasColumnName("CLRType");

                entity.Property(e => e.Title).HasMaxLength(128);
            });

            modelBuilder.Entity<PiranhaBlockField>(entity =>
            {
                entity.ToTable("Piranha_BlockFields");

                entity.HasIndex(e => new { e.BlockId, e.FieldId, e.SortOrder }, "IX_Piranha_BlockFields_BlockId_FieldId_SortOrder")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Clrtype)
                    .HasMaxLength(256)
                    .HasColumnName("CLRType");

                entity.Property(e => e.FieldId).HasMaxLength(64);

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.PiranhaBlockFields)
                    .HasForeignKey(d => d.BlockId);
            });

            modelBuilder.Entity<PiranhaCategory>(entity =>
            {
                entity.ToTable("Piranha_Categories");

                entity.HasIndex(e => new { e.BlogId, e.Slug }, "IX_Piranha_Categories_BlogId_Slug")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Slug).HasMaxLength(64);

                entity.Property(e => e.Title).HasMaxLength(64);

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.PiranhaCategories)
                    .HasForeignKey(d => d.BlogId);
            });

            modelBuilder.Entity<PiranhaCfcountry>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK__Piranha___10D1609FC8851A8F");

                entity.ToTable("Piranha_CFCountry");

                entity.Property(e => e.CountryName).HasMaxLength(500);
            });

            modelBuilder.Entity<PiranhaCfindustry>(entity =>
            {
                entity.HasKey(e => e.IndustyId)
                    .HasName("PK__Piranha___101795B39C81C80C");

                entity.ToTable("Piranha_CFIndustry");

                entity.Property(e => e.IndustyName).HasMaxLength(500);
            });

            modelBuilder.Entity<PiranhaCfpartnerImg>(entity =>
            {
                entity.HasKey(e => e.PartnerImgId)
                    .HasName("PK__Piranha___0F211E78EA633589");

                entity.ToTable("Piranha_CFPartnerImg");

                entity.Property(e => e.PartnerName).HasMaxLength(500);
            });

            modelBuilder.Entity<PiranhaCfreasonReaching>(entity =>
            {
                entity.HasKey(e => e.ReasonReachingId)
                    .HasName("PK__Piranha___350A614EAEA19C0B");

                entity.ToTable("Piranha_CFReasonReaching");

                entity.Property(e => e.ReasonReachingContent).HasMaxLength(2000);
            });

            modelBuilder.Entity<PiranhaContactForm>(entity =>
            {
                entity.ToTable("Piranha_ContactForm");

                entity.Property(e => e.Email).HasMaxLength(500);

                entity.Property(e => e.FullName).HasMaxLength(250);


                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.ReasonReaching)
                    .WithMany(p => p.PiranhaContactForms)
                    .HasForeignKey(d => d.ReasonReachingId)
                    .HasConstraintName("FK__Piranha_C__Reaso__18EBB532");
            });

            modelBuilder.Entity<PiranhaContent>(entity =>
            {
                entity.ToTable("Piranha_Content");

                entity.HasIndex(e => e.CategoryId, "IX_Piranha_Content_CategoryId");

                entity.HasIndex(e => e.TypeId, "IX_Piranha_Content_TypeId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TypeId).HasMaxLength(64);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PiranhaContents)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.PiranhaContents)
                    .HasForeignKey(d => d.TypeId);

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
                entity.ToTable("Piranha_ContentBlocks");

                entity.HasIndex(e => e.ContentId, "IX_Piranha_ContentBlocks_ContentId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Clrtype)
                    .HasMaxLength(256)
                    .HasColumnName("CLRType");

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.PiranhaContentBlocks)
                    .HasForeignKey(d => d.ContentId);
            });

            modelBuilder.Entity<PiranhaContentBlockField>(entity =>
            {
                entity.ToTable("Piranha_ContentBlockFields");

                entity.HasIndex(e => new { e.BlockId, e.FieldId, e.SortOrder }, "IX_Piranha_ContentBlockFields_BlockId_FieldId_SortOrder")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Clrtype)
                    .HasMaxLength(256)
                    .HasColumnName("CLRType");

                entity.Property(e => e.FieldId).HasMaxLength(64);

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.PiranhaContentBlockFields)
                    .HasForeignKey(d => d.BlockId);
            });

            modelBuilder.Entity<PiranhaContentBlockFieldTranslation>(entity =>
            {
                entity.HasKey(e => new { e.FieldId, e.LanguageId });

                entity.ToTable("Piranha_ContentBlockFieldTranslations");

                entity.HasIndex(e => e.LanguageId, "IX_Piranha_ContentBlockFieldTranslations_LanguageId");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.PiranhaContentBlockFieldTranslations)
                    .HasForeignKey(d => d.FieldId);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.PiranhaContentBlockFieldTranslations)
                    .HasForeignKey(d => d.LanguageId);
            });

            modelBuilder.Entity<PiranhaContentField>(entity =>
            {
                entity.ToTable("Piranha_ContentFields");

                entity.HasIndex(e => new { e.ContentId, e.RegionId, e.FieldId, e.SortOrder }, "IX_Piranha_ContentFields_ContentId_RegionId_FieldId_SortOrder");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Clrtype)
                    .HasMaxLength(256)
                    .HasColumnName("CLRType");

                entity.Property(e => e.FieldId).HasMaxLength(64);

                entity.Property(e => e.RegionId).HasMaxLength(64);

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.PiranhaContentFields)
                    .HasForeignKey(d => d.ContentId);
            });

            modelBuilder.Entity<PiranhaContentFieldTranslation>(entity =>
            {
                entity.HasKey(e => new { e.FieldId, e.LanguageId });

                entity.ToTable("Piranha_ContentFieldTranslations");

                entity.HasIndex(e => e.LanguageId, "IX_Piranha_ContentFieldTranslations_LanguageId");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.PiranhaContentFieldTranslations)
                    .HasForeignKey(d => d.FieldId);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.PiranhaContentFieldTranslations)
                    .HasForeignKey(d => d.LanguageId);
            });

            modelBuilder.Entity<PiranhaContentGroup>(entity =>
            {
                entity.ToTable("Piranha_ContentGroups");

                entity.Property(e => e.Id).HasMaxLength(64);

                entity.Property(e => e.Clrtype)
                    .HasMaxLength(255)
                    .HasColumnName("CLRType");

                entity.Property(e => e.Icon).HasMaxLength(64);

                entity.Property(e => e.IsHidden)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Title).HasMaxLength(128);
            });

            modelBuilder.Entity<PiranhaContentTranslation>(entity =>
            {
                entity.HasKey(e => new { e.ContentId, e.LanguageId });

                entity.ToTable("Piranha_ContentTranslations");

                entity.HasIndex(e => e.LanguageId, "IX_Piranha_ContentTranslations_LanguageId");

                entity.Property(e => e.LastModified).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.Title).HasMaxLength(128);

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.PiranhaContentTranslations)
                    .HasForeignKey(d => d.ContentId);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.PiranhaContentTranslations)
                    .HasForeignKey(d => d.LanguageId);
            });

            modelBuilder.Entity<PiranhaContentType>(entity =>
            {
                entity.ToTable("Piranha_ContentTypes");

                entity.Property(e => e.Id).HasMaxLength(64);

                entity.Property(e => e.Clrtype).HasColumnName("CLRType");

                entity.Property(e => e.Group).HasMaxLength(64);
            });

            modelBuilder.Entity<PiranhaLanguage>(entity =>
            {
                entity.ToTable("Piranha_Languages");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Culture).HasMaxLength(6);

                entity.Property(e => e.Title).HasMaxLength(64);
            });

            modelBuilder.Entity<PiranhaMediaFolder>(entity =>
            {
                entity.ToTable("Piranha_MediaFolders");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name).HasMaxLength(128);
            });

            modelBuilder.Entity<PiranhaMediaVersion>(entity =>
            {
                entity.ToTable("Piranha_MediaVersions");

                entity.HasIndex(e => new { e.MediaId, e.Width, e.Height }, "IX_Piranha_MediaVersions_MediaId_Width_Height")
                    .IsUnique()
                    .HasFilter("([Height] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FileExtension).HasMaxLength(8);

                entity.HasOne(d => d.Media)
                    .WithMany(p => p.PiranhaMediaVersions)
                    .HasForeignKey(d => d.MediaId);
            });

            modelBuilder.Entity<PiranhaMedium>(entity =>
            {
                entity.ToTable("Piranha_Media");

                entity.HasIndex(e => e.FolderId, "IX_Piranha_Media_FolderId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AltText).HasMaxLength(128);

                entity.Property(e => e.ContentType).HasMaxLength(256);

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Filename).HasMaxLength(128);

                entity.Property(e => e.Title).HasMaxLength(128);

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.PiranhaMedia)
                    .HasForeignKey(d => d.FolderId);
            });

            modelBuilder.Entity<PiranhaPage>(entity =>
            {
                entity.ToTable("Piranha_Pages");

                entity.HasIndex(e => e.PageTypeId, "IX_Piranha_Pages_PageTypeId");

                entity.HasIndex(e => e.ParentId, "IX_Piranha_Pages_ParentId");

                entity.HasIndex(e => new { e.SiteId, e.Slug }, "IX_Piranha_Pages_SiteId_Slug")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContentType)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("(N'Page')");

                entity.Property(e => e.EnableComments)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.MetaDescription).HasMaxLength(256);

                entity.Property(e => e.MetaFollow).HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.Property(e => e.MetaIndex).HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.Property(e => e.MetaKeywords).HasMaxLength(128);

                entity.Property(e => e.MetaPriority).HasDefaultValueSql("((5.0000000000000000e-001))");

                entity.Property(e => e.MetaTitle).HasMaxLength(128);

                entity.Property(e => e.NavigationTitle).HasMaxLength(128);

                entity.Property(e => e.OgDescription).HasMaxLength(256);

                entity.Property(e => e.OgTitle).HasMaxLength(128);

                entity.Property(e => e.PageTypeId).HasMaxLength(64);

                entity.Property(e => e.RedirectUrl).HasMaxLength(256);

                entity.Property(e => e.Route).HasMaxLength(256);

                entity.Property(e => e.Slug).HasMaxLength(128);

                entity.Property(e => e.Title).HasMaxLength(128);

                entity.HasOne(d => d.PageType)
                    .WithMany(p => p.PiranhaPages)
                    .HasForeignKey(d => d.PageTypeId);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId);

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.PiranhaPages)
                    .HasForeignKey(d => d.SiteId);
            });

            modelBuilder.Entity<PiranhaPageBlock>(entity =>
            {
                entity.ToTable("Piranha_PageBlocks");

                entity.HasIndex(e => e.BlockId, "IX_Piranha_PageBlocks_BlockId");

                entity.HasIndex(e => new { e.PageId, e.SortOrder }, "IX_Piranha_PageBlocks_PageId_SortOrder")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.PiranhaPageBlocks)
                    .HasForeignKey(d => d.BlockId);

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.PiranhaPageBlocks)
                    .HasForeignKey(d => d.PageId);
            });

            modelBuilder.Entity<PiranhaPageComment>(entity =>
            {
                entity.ToTable("Piranha_PageComments");

                entity.HasIndex(e => e.PageId, "IX_Piranha_PageComments_PageId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Author).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.Url).HasMaxLength(256);

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.PiranhaPageComments)
                    .HasForeignKey(d => d.PageId);
            });

            modelBuilder.Entity<PiranhaPageField>(entity =>
            {
                entity.ToTable("Piranha_PageFields");

                entity.HasIndex(e => new { e.PageId, e.RegionId, e.FieldId, e.SortOrder }, "IX_Piranha_PageFields_PageId_RegionId_FieldId_SortOrder");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Clrtype)
                    .HasMaxLength(256)
                    .HasColumnName("CLRType");

                entity.Property(e => e.FieldId).HasMaxLength(64);

                entity.Property(e => e.RegionId).HasMaxLength(64);

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.PiranhaPageFields)
                    .HasForeignKey(d => d.PageId);
            });

            modelBuilder.Entity<PiranhaPagePermission>(entity =>
            {
                entity.HasKey(e => new { e.PageId, e.Permission });

                entity.ToTable("Piranha_PagePermissions");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.PiranhaPagePermissions)
                    .HasForeignKey(d => d.PageId);
            });

            modelBuilder.Entity<PiranhaPageRevision>(entity =>
            {
                entity.ToTable("Piranha_PageRevisions");

                entity.HasIndex(e => e.PageId, "IX_Piranha_PageRevisions_PageId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.PiranhaPageRevisions)
                    .HasForeignKey(d => d.PageId);
            });

            modelBuilder.Entity<PiranhaPageType>(entity =>
            {
                entity.ToTable("Piranha_PageTypes");

                entity.Property(e => e.Id).HasMaxLength(64);

                entity.Property(e => e.Clrtype)
                    .HasMaxLength(256)
                    .HasColumnName("CLRType");
            });

            modelBuilder.Entity<PiranhaParam>(entity =>
            {
                entity.ToTable("Piranha_Params");

                entity.HasIndex(e => e.Key, "IX_Piranha_Params_Key")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.Key).HasMaxLength(64);
            });

            modelBuilder.Entity<PiranhaPost>(entity =>
            {
                entity.ToTable("Piranha_Posts");

                entity.HasIndex(e => new { e.BlogId, e.Slug }, "IX_Piranha_Posts_BlogId_Slug")
                    .IsUnique();

                entity.HasIndex(e => e.CategoryId, "IX_Piranha_Posts_CategoryId");

                entity.HasIndex(e => e.PostTypeId, "IX_Piranha_Posts_PostTypeId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EnableComments)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.MetaDescription).HasMaxLength(256);

                entity.Property(e => e.MetaFollow).HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.Property(e => e.MetaIndex).HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.Property(e => e.MetaKeywords).HasMaxLength(128);

                entity.Property(e => e.MetaPriority).HasDefaultValueSql("((5.0000000000000000e-001))");

                entity.Property(e => e.MetaTitle).HasMaxLength(128);

                entity.Property(e => e.OgDescription).HasMaxLength(256);

                entity.Property(e => e.OgTitle).HasMaxLength(128);

                entity.Property(e => e.PostTypeId).HasMaxLength(64);

                entity.Property(e => e.RedirectUrl).HasMaxLength(256);

                entity.Property(e => e.Route).HasMaxLength(256);

                entity.Property(e => e.Slug).HasMaxLength(128);

                entity.Property(e => e.Title).HasMaxLength(128);

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.PiranhaPosts)
                    .HasForeignKey(d => d.BlogId);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PiranhaPosts)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PostType)
                    .WithMany(p => p.PiranhaPosts)
                    .HasForeignKey(d => d.PostTypeId);

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
                entity.ToTable("Piranha_PostBlocks");

                entity.HasIndex(e => e.BlockId, "IX_Piranha_PostBlocks_BlockId");

                entity.HasIndex(e => new { e.PostId, e.SortOrder }, "IX_Piranha_PostBlocks_PostId_SortOrder")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.PiranhaPostBlocks)
                    .HasForeignKey(d => d.BlockId);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PiranhaPostBlocks)
                    .HasForeignKey(d => d.PostId);
            });

            modelBuilder.Entity<PiranhaPostComment>(entity =>
            {
                entity.ToTable("Piranha_PostComments");

                entity.HasIndex(e => e.PostId, "IX_Piranha_PostComments_PostId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Author).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.Url).HasMaxLength(256);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PiranhaPostComments)
                    .HasForeignKey(d => d.PostId);
            });

            modelBuilder.Entity<PiranhaPostField>(entity =>
            {
                entity.ToTable("Piranha_PostFields");

                entity.HasIndex(e => new { e.PostId, e.RegionId, e.FieldId, e.SortOrder }, "IX_Piranha_PostFields_PostId_RegionId_FieldId_SortOrder");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Clrtype)
                    .HasMaxLength(256)
                    .HasColumnName("CLRType");

                entity.Property(e => e.FieldId).HasMaxLength(64);

                entity.Property(e => e.RegionId).HasMaxLength(64);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PiranhaPostFields)
                    .HasForeignKey(d => d.PostId);
            });

            modelBuilder.Entity<PiranhaPostPermission>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.Permission });

                entity.ToTable("Piranha_PostPermissions");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PiranhaPostPermissions)
                    .HasForeignKey(d => d.PostId);
            });

            modelBuilder.Entity<PiranhaPostRevision>(entity =>
            {
                entity.ToTable("Piranha_PostRevisions");

                entity.HasIndex(e => e.PostId, "IX_Piranha_PostRevisions_PostId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PiranhaPostRevisions)
                    .HasForeignKey(d => d.PostId);
            });

            modelBuilder.Entity<PiranhaPostType>(entity =>
            {
                entity.ToTable("Piranha_PostTypes");

                entity.Property(e => e.Id).HasMaxLength(64);

                entity.Property(e => e.Clrtype)
                    .HasMaxLength(256)
                    .HasColumnName("CLRType");
            });

            modelBuilder.Entity<PiranhaRole>(entity =>
            {
                entity.ToTable("Piranha_Roles");

                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<PiranhaRoleClaim>(entity =>
            {
                entity.ToTable("Piranha_RoleClaims");

                entity.HasIndex(e => e.RoleId, "IX_Piranha_RoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PiranhaRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<PiranhaSite>(entity =>
            {
                entity.ToTable("Piranha_Sites");

                entity.HasIndex(e => e.InternalId, "IX_Piranha_Sites_InternalId")
                    .IsUnique();

                entity.HasIndex(e => e.LanguageId, "IX_Piranha_Sites_LanguageId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Culture).HasMaxLength(6);

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.Hostnames).HasMaxLength(256);

                entity.Property(e => e.InternalId).HasMaxLength(64);

                entity.Property(e => e.SiteTypeId).HasMaxLength(64);

                entity.Property(e => e.Title).HasMaxLength(128);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.PiranhaSites)
                    .HasForeignKey(d => d.LanguageId);
            });

            modelBuilder.Entity<PiranhaSiteField>(entity =>
            {
                entity.ToTable("Piranha_SiteFields");

                entity.HasIndex(e => new { e.SiteId, e.RegionId, e.FieldId, e.SortOrder }, "IX_Piranha_SiteFields_SiteId_RegionId_FieldId_SortOrder");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Clrtype)
                    .HasMaxLength(256)
                    .HasColumnName("CLRType");

                entity.Property(e => e.FieldId).HasMaxLength(64);

                entity.Property(e => e.RegionId).HasMaxLength(64);

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.PiranhaSiteFields)
                    .HasForeignKey(d => d.SiteId);
            });

            modelBuilder.Entity<PiranhaSiteType>(entity =>
            {
                entity.ToTable("Piranha_SiteTypes");

                entity.Property(e => e.Id).HasMaxLength(64);

                entity.Property(e => e.Clrtype)
                    .HasMaxLength(256)
                    .HasColumnName("CLRType");
            });

            modelBuilder.Entity<PiranhaTag>(entity =>
            {
                entity.ToTable("Piranha_Tags");

                entity.HasIndex(e => new { e.BlogId, e.Slug }, "IX_Piranha_Tags_BlogId_Slug")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Slug).HasMaxLength(64);

                entity.Property(e => e.Title).HasMaxLength(64);

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.PiranhaTags)
                    .HasForeignKey(d => d.BlogId);
            });

            modelBuilder.Entity<PiranhaTaxonomy>(entity =>
            {
                entity.ToTable("Piranha_Taxonomies");

                entity.HasIndex(e => new { e.GroupId, e.Type, e.Slug }, "IX_Piranha_Taxonomies_GroupId_Type_Slug")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.GroupId).HasMaxLength(64);

                entity.Property(e => e.Slug).HasMaxLength(64);

                entity.Property(e => e.Title).HasMaxLength(64);
            });

            modelBuilder.Entity<PiranhaUser>(entity =>
            {
                entity.ToTable("Piranha_Users");

                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

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

            modelBuilder.Entity<PiranhaUserClaim>(entity =>
            {
                entity.ToTable("Piranha_UserClaims");

                entity.HasIndex(e => e.UserId, "IX_Piranha_UserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PiranhaUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<PiranhaUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.ToTable("Piranha_UserLogins");

                entity.HasIndex(e => e.UserId, "IX_Piranha_UserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PiranhaUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<PiranhaUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.ToTable("Piranha_UserTokens");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PiranhaUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<RootImage>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Root)
                    .HasMaxLength(50)
                    .HasColumnName("root");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
