using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp
{
    public class ToDoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsCompleted { get; set; }

        
        public ToDoItem(int Id=1, string Title="", bool IsCompleted = false) 
        { 
            this.Id = Id;
            this.Title = Title;
            this.IsCompleted = IsCompleted;
        }
    }
}
