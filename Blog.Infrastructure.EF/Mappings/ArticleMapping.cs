using Blog.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.EF.Mappings
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title);
            builder.Property(x => x.ImgAddress);
            builder.Property(x => x.ImgAlt);
            builder.Property(x => x.ShortDscp);
            builder.Property(x => x.Body);
            builder.Property(x => x.IsDeleted);
            builder.Property(x => x.CreationDate);
            builder.Property(x => x.Title);
            builder.HasOne(x=>x.articlecategory)
                .WithMany(c=>c.articles)
                .HasForeignKey(x=>x.CategoryId);
        }
    }
}
