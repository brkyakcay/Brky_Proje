using BookStore.WebApp.Data.Entities;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.WebUI.Code
{
    public interface IListService
    {
        SelectList GetAuthorList(object? selectedItem = null);
        SelectList GetCategoryList(object? selectedItem = null);
        SelectList GetPublisherList(object? selectedItem = null);
    }

    public class ListService : IListService
    {
        private readonly BookStoreContext db;

        public ListService(BookStoreContext context)
        {
            db = context;
        }

        public SelectList GetPublisherList(object? selectedItem = null)
        {
            return new SelectList(db.Publishers, "Id", "Name", selectedItem);
        }

        public SelectList GetCategoryList(object? selectedItem = null)
        {
            return new SelectList(db.Categories, "Id", "Name", selectedItem);
        }

        public SelectList GetAuthorList(object? selectedItem = null)
        {
            return new SelectList(db.Authors, "Id", "FullName", selectedItem);
        }
    }
}
