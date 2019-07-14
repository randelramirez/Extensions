using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.DataInitializer.Helper
{
    public static class DbContextHelper
    {
        public async static Task Seed<T, U>(T context, List<U> data)
           where T : DbContext
           where U : class, new()
        {
            await Add(context, data);
        }

        public async static Task Seed<T, U>(T context, U[] data) where T : DbContext
            where U : class, new()
        {
            await Add(context, data);
        }

        public async static Task Seed<T, U>(T context, Func<List<U>> data) where T : DbContext
            where U : class, new()
        {
            await Add(context, data());
        }

        public async static Task Seed<T, U>(T context, Func<U[]> data) where T : DbContext
            where U : class, new()
        {
            await Add(context, data());
        }

        private async static Task Add<T, U>(T context, List<U> data)
            where T : DbContext
            where U : class, new()
        {
            if (!context.Set<U>().Any())
            {
                data.ForEach(async u => await context.AddAsync<U>(u));
                await context.SaveChangesAsync();
            }
        }

        private async static Task Add<T, U>(T context, U[] data)
           where T : DbContext
           where U : class, new()
        {
            if (!context.Set<U>().Any())
            {
                foreach (var item in data)
                {
                    await context.AddAsync<U>(item);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
