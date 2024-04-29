using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public class ListsContext : DbContext
	{

		public ListsContext(DbContextOptions options) : base(options)
		{ 
			
		}

		public DbSet<ToDoListEntry> ToDoLists { get; set; }

		public DbSet<ListMetadata> Metadata { get; set; }
	}
}
