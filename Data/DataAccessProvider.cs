using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Data
{
	public class DataAccessProvider : IDataAccessProvider
	{
		private readonly ListsContext _context;
		private readonly ILogger _logger;

		public DataAccessProvider(ListsContext context, ILoggerFactory loggerFactory)
		{
			_context = context;
			_logger = loggerFactory.CreateLogger<DataAccessProvider>();
		}

		public async Task AddItem(int listId, ToDoItem item)
		{
			var list = _context.ToDoLists.Where(x => x.Id == listId).ToList();

			await _context.ToDoLists.AddAsync(new ToDoListEntry{Id = listId,ItemTitle = item.Title,
			ItemIsCompleted = item.IsCompleted});
			await _context.SaveChangesAsync();
		}

		public async Task AddList(ListMetadata metadata)
		{
			await _context.Metadata.AddAsync(metadata);
			await _context.SaveChangesAsync();
			await _context.ToDoLists.AddAsync(new ToDoListEntry { Id = metadata.Id,ItemTitle="" });
			await _context.SaveChangesAsync();
		}

		public async Task UpdateTitle(int listId, string title)
		{
			var entity = await _context.Metadata.FirstOrDefaultAsync(x => x.Id == listId);

			if (entity != null)
			{
				entity.Title = title;
				await _context.SaveChangesAsync();
			}
		}

		public async Task UpdateItem(int listId, ToDoItem item)
		{
			var entity = await _context.ToDoLists.FirstOrDefaultAsync(x => x.Id == listId && x.ItemPosition == item.Id);

			if (entity != null)
			{
				entity.ItemTitle = item.Title;
				entity.ItemIsCompleted = item.IsCompleted;
				await _context.SaveChangesAsync();
			}
		}

		public async Task DeleteList(int listId)
		{
			var items = await _context.ToDoLists.Where(x => x.Id == listId).ToListAsync();
			_context.RemoveRange(items);

			var entry = await _context.Metadata.FirstOrDefaultAsync(x => x.Id == listId);
			if (entry != null)
			{
				_context.Metadata.Remove(entry);
			}

			await _context.SaveChangesAsync();
		}

		public async Task DeleteItem(int listId, int itemId)
		{
			var entity = await _context.ToDoLists.FirstOrDefaultAsync(x => x.Id == listId && x.ItemPosition == itemId);
			var listItemsCount = _context.ToDoLists.Select(x => x.Id == listId).Count();

			if (entity != null)
			{
				if (listItemsCount == 1)
				{
					entity.ItemTitle = "";
				}
				else
				{
					_context.ToDoLists.Remove(entity);
				}

				await _context.SaveChangesAsync();
			}
		}

		public async Task<List<ToDoListEntry>> GetAllEntries()
		{
			var lists = await _context.ToDoLists.OrderBy(x => x.Id).ThenBy(x => x.ItemPosition).ToListAsync();

			return lists;
		}

		public async Task<List<ListMetadata>> GetListMetadata()
		{
			var metadata = await _context.Metadata.OrderBy(x => x.Id).ToListAsync();

			return metadata;
		}

	}
}
