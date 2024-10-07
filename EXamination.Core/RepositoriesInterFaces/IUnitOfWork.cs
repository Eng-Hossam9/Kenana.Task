using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXamination.Core.RepositoriesInterFaces
{
    public interface IUnitOfWork
    {
        Task<int> CompletSaveChangesAsync();

        IGenaricRepository<TEntity, TKey> CreateRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    }
}
