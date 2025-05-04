namespace IBll
{
    public interface IBll<T>
    {
           Task<List<T>> GetAllAsync();
          /*  Task<T> SelectByIdAsync(int id);
            Task<int> AddAsync(T t);
            Task<int> UpdateAsync(int id, T t);
            Task<int> DeleteAsync(int id);
          */
        }
    }