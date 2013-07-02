using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Lucid.Web.Portal.Models
{ 
    public class MessageRepository : IMessageRepository
    {
        LucidWebPortalContext context = new LucidWebPortalContext();

        public IQueryable<Message> All
        {
            get { return context.Messages; }
        }

        public IQueryable<Message> AllIncluding(params Expression<Func<Message, object>>[] includeProperties)
        {
            IQueryable<Message> query = context.Messages;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Message Find(int id)
        {
            return context.Messages.Find(id);
        }

        public void InsertOrUpdate(Message message)
        {
            if (message.Id == default(int)) {
                // New entity
                context.Messages.Add(message);
            } else {
                // Existing entity
                context.Entry(message).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var message = context.Messages.Find(id);
            context.Messages.Remove(message);
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

    public interface IMessageRepository : IDisposable
    {
        IQueryable<Message> All { get; }
        IQueryable<Message> AllIncluding(params Expression<Func<Message, object>>[] includeProperties);
        Message Find(int id);
        void InsertOrUpdate(Message message);
        void Delete(int id);
        void Save();
    }
}