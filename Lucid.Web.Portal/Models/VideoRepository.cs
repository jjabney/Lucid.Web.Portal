using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Lucid.Web.Portal.Models
{ 
    public class VideoRepository : IVideoRepository
    {
        LucidWebPortalContext context = new LucidWebPortalContext();

        public IQueryable<Video> All
        {
            get { return context.Videos; }
        }

        public IQueryable<Video> AllIncluding(params Expression<Func<Video, object>>[] includeProperties)
        {
            IQueryable<Video> query = context.Videos;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Video Find(int id)
        {
            return context.Videos.Find(id);
        }

        public void InsertOrUpdate(Video video)
        {
            if (video.Id == default(int)) {
                // New entity
                context.Videos.Add(video);
            } else {
                // Existing entity
                context.Entry(video).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var video = context.Videos.Find(id);
            context.Videos.Remove(video);
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

    public interface IVideoRepository : IDisposable
    {
        IQueryable<Video> All { get; }
        IQueryable<Video> AllIncluding(params Expression<Func<Video, object>>[] includeProperties);
        Video Find(int id);
        void InsertOrUpdate(Video video);
        void Delete(int id);
        void Save();
    }
}