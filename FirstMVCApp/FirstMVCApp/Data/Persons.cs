using FirstMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMVCApp.Data
{
    public class Persons
    {
        static IList<Person> people = null;
        public static IList<Person> GetPeople()
        {
            if(people == null)
            {
                people = new List<Person>();
                people.Add(new Person() { Name = "Victor", Age = 24 });
                people.Add(new Person() { Name = "Ana", Age = 23 });
            }
            return people;
        }


    }
}