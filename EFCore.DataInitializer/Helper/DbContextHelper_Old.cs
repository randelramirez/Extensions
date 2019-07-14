using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore.DataInitializer.Helper
{
    public static class DbContextHelper_Old
    {
        public static void Seed<T, U>(T context, List<U> data)
           where T : DbContext
           where U : class, new()
        {
            Add(context, data);
        }

        public static void Seed<T, U>(T context, U[] data) where T : DbContext
            where U : class, new()
        {
            Add(context, data);
        }

        public static void Seed<T, U>(T context, Func<List<U>> data) where T : DbContext
            where U : class, new()
        {
            Add(context, data());
        }

        public static void Seed<T, U>(T context, Func<U[]> data) where T : DbContext
            where U : class, new()
        {
            Add(context, data());
        }

        private static void Add<T, U>(T context, List<U> data)
            where T : DbContext
            where U : class, new()
        {
            if (!context.Set<U>().Any())
            {
                data.ForEach(u => context.Add<U>(u));
                context.SaveChanges();
            }
        }

        private static void Add<T, U>(T context, U[] data)
           where T : DbContext
           where U : class, new()
        {
            if (!context.Set<U>().Any())
            {
                foreach (var item in data)
                {
                    context.Add<U>(item);
                }
                context.SaveChanges();
            }
        }
    }
}
