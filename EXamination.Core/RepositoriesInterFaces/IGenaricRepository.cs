using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXamination.Core.RepositoriesInterFaces
{
    public interface IGenaricRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Tkey Id);
        Task<int> AddAsync(TEntity entity);
        Task<int> Update(TEntity entity);
        Task<int> Delete(Tkey entityId);
    }
}
