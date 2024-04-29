using Microsoft.EntityFrameworkCore;
using Npgsql.Internal.Postgres;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Data
{
	[PrimaryKey(nameof(Id))]
	public class ListMetadata
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Title { get; set; }

        public DateTime Created { get; set; }
        
    }
}
