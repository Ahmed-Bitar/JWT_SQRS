using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PROGECT_LIB.Data;
using static System.Reflection.Metadata.BlobBuilder;

namespace PROGECT_LIB.Repo
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class, IEntity
    {
        private readonly AppDbContext _appDbContext;
        public BaseRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public List<T> GetAllItems()
        {
            var books = _appDbContext.Set<T>().ToList();
            return books;
        }

        public T GetItemById(int id)
        {
            var book = _appDbContext.Set<T>().Where(e => e.Id == id).FirstOrDefault();
            return book;
        }
        public async Task InsertItem(T item)
        {
            await _appDbContext.Set<T>().AddAsync(item);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<T> UpdateItem(T item)
        {
            try
            {
                _appDbContext.Set<T>().Attach(item);
                _appDbContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _appDbContext.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void DeleteItem(int id)
        {

            var borrowing = _appDbContext.Set<T>().Where(e => e.Id == id).FirstOrDefault();
            if (borrowing != null)
            {
                _appDbContext.Set<T>().Remove(borrowing);
                _appDbContext.SaveChanges();
            }

        }

        public async Task CreateAsync(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}