using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PTTKGT
{
    class Student
    {
        // Propertises
        string id = null;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        string classId = null;

        public string ClassId
        {
            get { return classId; }
            set { classId = value; }
        }
        string lastMiddleName = null;

        public string LastMiddleName
        {
            get { return lastMiddleName; }
            set { lastMiddleName = value; }
        }
        string firstName = null;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        string email = null;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        // Factory method
        public Student()
        {
            this.id = null;
            this.classId = null;
            this.lastMiddleName = null;
            this.firstName = null;
            this.email = null;
        }

        public Student(string id, string classId, string lastMiddleName, string firstName, string email)
        {
            this.id = id;
            this.classId = classId;
            this.lastMiddleName = lastMiddleName;
            this.firstName = firstName;
            this.email = email;
        }

    }
}
