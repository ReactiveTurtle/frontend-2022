using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using To_Do_List_Backend.Domain;

namespace To_Do_List_Backend.Infrastructure.Data.TodoModel.EntityConfigurations
{
    public class TodoMap : IEntityTypeConfiguration<Todo>
    {
        public void Configure( EntityTypeBuilder<Todo> builder )
        {
            builder.HasKey( x => x.Id );
            builder.Property( x => x.Id ).ValueGeneratedOnAdd();

            builder.Property( x => x.Name );

            builder.Property( x => x.Title );

            builder.Property( x => x.IsDone );
        }
    }
}
