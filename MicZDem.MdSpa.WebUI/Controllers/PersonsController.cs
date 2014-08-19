using System;
using System.Collections.Generic;
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
            //var ret = _sqlDbContext.Persons.Add(value);
            //_sqlDbContext.SaveChanges();
            //return ret;
            throw new NotImplementedException();
        }

        // PUT api/values/5
        public Person Put(int id, Person value)
        {
            //var toUpdate = _sqlDbContext.Persons.Find(id);
            //toUpdate = value;
            //_sqlDbContext.SaveChanges();
            //return toUpdate;
            throw new NotImplementedException();
        }

        // DELETE api/values/5
        public Person Delete(int id)
        {
            //var toDelete = _sqlDbContext.Persons.Find(id);
            //var ret = _sqlDbContext.Persons.Remove(toDelete);
            //_sqlDbContext.SaveChanges();
            //return ret;
            throw new NotImplementedException();
        }
    }
}
