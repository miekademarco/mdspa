using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MicZDem.MdSpa.Domain;
using MicZDem.MdSpa.SqlData;

namespace MicZDem.MdSpa.WebUI.Controllers
{
    public class PersonsController : ApiController
    {

        private SqlData.SqlDbContext _sqlDbContext;

        public PersonsController()
        {
            _sqlDbContext = new SqlDbContext();
        }

        // GET api/values
        public IEnumerable<Person> Get()
        {
            return _sqlDbContext.Persons.ToList();
        }

        // GET api/values/5
        public Person Get(int id)
        {
            var ret = _sqlDbContext.Persons.Find(id);
            return ret;
        }

        // POST api/values
        public Person Post(Person value)
        {
            if (value.Age <= 0)
            {
                throw new ArgumentException();
            }
            
            var ret = _sqlDbContext.Persons.Add(value);
            _sqlDbContext.SaveChanges();
            return ret;
            //throw new NotImplementedException();
        }

        // PUT api/values/5
        public Person Put(int id, Person value)
        {
            if (value.Age <= 0)
            {
                throw new ArgumentException();
            }
            var toUpdate = _sqlDbContext.Persons.Find(id);
            toUpdate.FirstName = value.FirstName;
            toUpdate.LastName = value.LastName;
            toUpdate.Age = value.Age;
            toUpdate.Location = value.Location;
            _sqlDbContext.Entry(toUpdate).State = EntityState.Modified; 
            _sqlDbContext.SaveChanges();
            return toUpdate;
        }

        // DELETE api/values/5
        public Person Delete(int id)
        {
            var toDelete = _sqlDbContext.Persons.Find(id);
            var ret = _sqlDbContext.Persons.Remove(toDelete);
            _sqlDbContext.SaveChanges();
            return ret;
        }
    }
}
