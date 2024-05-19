using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public interface IAsyncRepository<TEntity, TEntityId> : IQuery<TEntity>//çalışacağı tipi tanımladık TEntity olarak, bu tipin neyiyle çalışacağımızı belirttik : Id
        where TEntity : Entity<TEntityId>//Entity'yi implement edenler kullanabilecek
    {
        Task<TEntity?> GetAsync
            (
                Expression<Func<TEntity, bool>> predicate, //lambdayla operasyon alabileceğiz 
                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, //joinli işlem için
                bool withDeleted = false,//soft delete ile çalıştığımızdan silinenleri getirmesin diye false olarak tanımladık
                bool enableTracking = true, // ef'in izlenip izlenmemesi için
                CancellationToken cancellationToken = default//asenkron operasyonlarda özellikle, iptal etme işlemlerinde  
            );

        Task<IPaginate<TEntity>> GetListAsync
            (
                Expression<Func<TEntity, bool>> predicate = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                int index = 0,
                int size = 10,
                bool withDeleted = false,
                bool enableTracking = true,
                CancellationToken cancellationToken = default
            );

        Task<IPaginate<TEntity>> GetListByDynamicAsync
            (
                DynamicQuery dynamic,
                Expression<Func<TEntity, bool>> predicate = null,
                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                int index = 0,
                int size = 10,
                bool withDeleted = false,
                bool enableTracking = true,
                CancellationToken cancellationToken = default
            );

        Task<bool> AnyAsync
            (
                Expression<Func<TEntity, bool>>? predicate = null,
                bool withDeleted = false,
                bool enableTracking = true,
                CancellationToken cancellationToken = default
            );

        Task<TEntity> AddAsync(TEntity entity);

        Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entity);

        Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false);//permanent : kalıcı
    
        Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entity, bool permanent = false);
        
    }
}
