using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Data;

namespace BlazorApp.Controllers
{
	[Route("lists")]
	[ApiController]
	public class ListsController : ControllerBase
	{
		private readonly IDataAccessProvider _dataAccessProvider;

		public ListsController(IDataAccessProvider dataAccessProvider)
		{
			_dataAccessProvider = dataAccessProvider;
		}

		[HttpGet]
		public async Task<ActionResult<List<ToDoListEntry>>> GetLists()
		{
			var lists = await _dataAccessProvider.GetAllEntries();

			return lists;
		}

		[HttpPost]
		[Route("createList")]
		public async Task AddList(ListMetadata metadata)
		{
			await _dataAccessProvider.AddList(metadata);
		}

		[HttpPost]
		[Route("addNewItem/{id}")]
		public async Task AddItem(int id,ToDoItem item)
		{
			await _dataAccessProvider.AddItem(id, item);
		}


		[HttpPatch]
		[Route("updateTitle")]
		public async Task UpdateTitle(ListMetadata metadata)
		{
			await _dataAccessProvider.UpdateTitle(metadata.Id, metadata.Title);
		}

		[HttpPatch]
		[Route("updateItem/{listId}")]
		public async Task UpdateItem(int listId, ToDoItem item)
		{
			await _dataAccessProvider.UpdateItem(listId, item);
		}

		[HttpDelete]
		[Route("deleteList/{id}")]
		public async Task DeleteList(int id)
		{
			await _dataAccessProvider.DeleteList(id);
		}

		[HttpDelete]
		[Route("deleteItem/{listId}/{itemId}")]
		public async Task DeleteItem(int listId, int itemId)
		{
			await _dataAccessProvider.DeleteItem(listId, itemId);
		}

		[HttpGet]
		[Route("metadata")]
		public async Task<ActionResult<List<ListMetadata>>> GetListMetadata()
		{
			var metadata = await _dataAccessProvider.GetListMetadata();

			return metadata;
		}
	}
}
