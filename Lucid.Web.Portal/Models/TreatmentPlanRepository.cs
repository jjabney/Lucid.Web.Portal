using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Lucid.Web.Portal.Models
{ 
    public class TreatmentPlanRepository : ITreatmentPlanRepository
    {
        LucidWebPortalContext context = new LucidWebPortalContext();

        public IQueryable<TreatmentPlan> All
        {
            get { return context.TreatmentPlans; }
        }

        public IQueryable<TreatmentPlan> AllIncluding(params Expression<Func<TreatmentPlan, object>>[] includeProperties)
        {
            IQueryable<TreatmentPlan> query = context.TreatmentPlans;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public TreatmentPlan Find(int id)
        {
            return context.TreatmentPlans.Find(id);
        }

        public void InsertOrUpdate(TreatmentPlan treatmentplan)
        {
            if (treatmentplan.Id == default(int)) {
                // New entity
                context.TreatmentPlans.Add(treatmentplan);
            } else {
                // Existing entity
                context.Entry(treatmentplan).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var treatmentplan = context.TreatmentPlans.Find(id);
            context.TreatmentPlans.Remove(treatmentplan);
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

    public interface ITreatmentPlanRepository : IDisposable
    {
        IQueryable<TreatmentPlan> All { get; }
        IQueryable<TreatmentPlan> AllIncluding(params Expression<Func<TreatmentPlan, object>>[] includeProperties);
        TreatmentPlan Find(int id);
        void InsertOrUpdate(TreatmentPlan treatmentplan);
        void Delete(int id);
        void Save();
    }
}