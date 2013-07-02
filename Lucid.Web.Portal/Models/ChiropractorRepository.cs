using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Lucid.Web.Portal.Models
{ 
    public class ChiropractorRepository : IChiropractorRepository
    {
        LucidWebPortalContext context = new LucidWebPortalContext();

        public IQueryable<Chiropractor> All
        {
            get { return context.Chiropractors; }
        }

        public IQueryable<Chiropractor> AllIncluding(params Expression<Func<Chiropractor, object>>[] includeProperties)
        {
            IQueryable<Chiropractor> query = context.Chiropractors;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Chiropractor Find(int id)
        {
            return context.Chiropractors.Find(id);
        }

        public void InsertOrUpdate(Chiropractor chiropractor)
        {
            if (chiropractor.Id == default(int)) {
                // New entity
                context.Chiropractors.Add(chiropractor);
            } else {
                // Existing entity
                context.Entry(chiropractor).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var chiropractor = context.Chiropractors.Find(id);
            context.Chiropractors.Remove(chiropractor);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IChiropractorRepository : IDisposable
    {
        IQueryable<Chiropractor> All { get; }
        IQueryable<Chiropractor> AllIncluding(params Expression<Func<Chiropractor, object>>[] includeProperties);
        Chiropractor Find(int id);
        void InsertOrUpdate(Chiropractor chiropractor);
        void Delete(int id);
        void Save();
    }
}