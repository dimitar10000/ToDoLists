namespace BlazorApp.Data
{
	public class ToDoList
	{
		public List<ToDoItem> Items { get; set; }

		public ToDoList()
		{
			Items = new List<ToDoItem>();
		}

		public void AddItem(int id,string title="",bool completed = false)
		{
			Items.Add(new ToDoItem(id,title,completed));
		}
	}
}
