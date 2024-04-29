namespace BlazorApp.Data
{
	public interface IDataAccessProvider
	{
		Task AddItem(int listId, ToDoItem item);

		Task AddList(ListMetadata metadata);

		Task UpdateItem(int listId, ToDoItem item);	

		Task UpdateTitle(int listId, string title);

		Task DeleteList(int listId);

		Task DeleteItem(int listId, int itemId);

		Task<List<ListMetadata>> GetListMetadata();

		Task<List<ToDoListEntry>> GetAllEntries();
	}
}
