using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace BlazorApp.Data
{
    [PrimaryKey(nameof(Id),nameof(ItemPosition))]
    public class ToDoListEntry
    {
        [ForeignKey(nameof(ListMetadata.Id))]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id {  get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ItemPosition { get; set; }

        [DefaultValue("")]
        public string ItemTitle { get; set; }

        [DefaultValue(false)]
		public bool ItemIsCompleted { get; set; }
    }
}
