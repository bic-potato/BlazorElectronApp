using BlazorElectronApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazorElectronApp.Utils
{
    public class DbUtils<T> where T : class
    {
        private readonly DbContext context;

        public DbUtils()
        {
            context = new AppDbContext();
            context.Database.EnsureCreatedAsync();
            

        }

        public async Task<bool> InsertAsync(T entity)
        {
            await context.AddAsync(entity);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                context.Set<T>().Update(entity);
                return await context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }


        }
        public async Task<bool> DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUseIDAsync(int id)
        {
            T temp = await context.FindAsync<T>(id);
            if (temp != null)
            {
                context.Remove(temp);
                return await context.SaveChangesAsync() > 0;
            }
            else
            {
                return false;
            }
        }


        public async Task<T> FindAsync(int id)
        {
            return await context.FindAsync<T>(id);
        }
        /// <summary>
        /// 按照一定条件对数据库进行查询
        /// </summary>
        /// <param name="lambdaWhere">查询条件</param>
        /// <param name="includes">外链表</param>
        /// <returns>对象数组</returns>
        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> lambdaWhere, string[] includes)
        {
            try
            {
                IQueryable<T> model = context.Set<T>().AsNoTracking();

                if (includes != null && includes.Any())
                {
                    foreach (var include in includes)
                    {
                        model = model.Include(include);
                    }
                }
                if (lambdaWhere != null)
                {
                    model = model.Where(lambdaWhere);
                }
                return await model.ToListAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
