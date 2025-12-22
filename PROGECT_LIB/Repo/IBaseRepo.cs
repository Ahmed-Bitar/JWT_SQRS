using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGECT_LIB.Repo;


public interface IBaseRepo<T> where T : class, IEntity
{
    public Task CreateAsync(T entity);
    public List<T> GetAllItems();
    public T GetItemById(int id);
    public Task InsertItem(T item);
    public Task<T> UpdateItem(T item);
    public void DeleteItem(int id);
}
