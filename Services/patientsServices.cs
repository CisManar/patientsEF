using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class patientsServices
    {
        patientsContext db = new patientsContext();
        public List<patients> getAll()
        {
            return db.patients.ToList(); ;
        }
        public patients getOne(int? id)
        {
            patients patients = db.patients.Find(id);

            return patients;

        }
        public bool addPatient(patients patient)
        {
            db.patients.Add(patient);
            db.SaveChanges();

            return true;
        }
        public bool updatePatient(patients patients)
        {
            db.Entry(patients).State = EntityState.Modified;
            db.SaveChanges();

            return true;
        }
        public bool deletePatient(patients patients)
        {
            db.patients.Remove(patients);
            db.SaveChanges();

            return true;
        }
    }
}
