using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Lucid.Web.Portal.Models
{ 
    public class PatientRepository : IPatientRepository
    {
        LucidWebPortalContext context = new LucidWebPortalContext();

        public IQueryable<Patient> All
        {
            get { return context.Patients; }
        }

        public IQueryable<Patient> AllIncluding(params Expression<Func<Patient, object>>[] includeProperties)
        {
            IQueryable<Patient> query = context.Patients;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Patient Find(int id)
        {
            return context.Patients.Find(id);
        }

        public void InsertOrUpdate(Patient patient)
        {
            if (patient.Id == default(int)) {
                // New entity
                context.Patients.Add(patient);
            } else {
                // Existing entity
                context.Entry(patient).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var patient = context.Patients.Find(id);
            context.Patients.Remove(patient);
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

    public interface IPatientRepository : IDisposable
    {
        IQueryable<Patient> All { get; }
        IQueryable<Patient> AllIncluding(params Expression<Func<Patient, object>>[] includeProperties);
        Patient Find(int id);
        void InsertOrUpdate(Patient patient);
        void Delete(int id);
        void Save();
    }
}