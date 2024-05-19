using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public interface IRepository<TEntity, TEntityId> : IQuery<TEntity>//çalışacağı tipi tanımladık TEntity olarak, bu tipin neyiyle çalışacağımızı belirttik : Id
        where TEntity : Entity<TEntityId>//Entity'yi implement edenler kullanabilecek
    {
        TEntity? Get
            (
                Expression<Func<TEntity, bool>> predicate, //lambdayla operasyon alabileceğiz 
                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, //joinli işlem için
                bool withDeleted = false,//soft delete ile çalıştığımızdan silinenleri getirmesin diye false olarak tanımladık
                bool enableTracking = true, // ef'in izlenip izlenmemesi için
                CancellationToken cancellationToken = default//asenkron operasyonlarda özellikle, iptal etme işlemlerinde  
            );

        IPaginate<TEntity> GetList
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

        IPaginate<TEntity> GetListByDynamic
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

        bool Any
            (
                Expression<Func<TEntity, bool>>? predicate = null,
                bool withDeleted = false,
                bool enableTracking = true,
                CancellationToken cancellationToken = default
            );

        TEntity Add(TEntity entity);

        ICollection<TEntity> AddRange(ICollection<TEntity> entity);

        TEntity Update (TEntity entity);

        ICollection<TEntity> UpdateRange(ICollection<TEntity> entity);

        TEntity Delete(TEntity entity, bool permanent = false);//permanent : kalıcı

        ICollection<TEntity> DeleteRange(ICollection<TEntity> entity, bool permanent = false);

    }
}
