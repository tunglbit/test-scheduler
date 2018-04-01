using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PTTKGT
{
    class Course
    {
        // Propertises
        private string ID = null;

        public string Id
        {
            get { return ID; }
            set { ID = value; }
        }
        private string name = null;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private List<Group> listGroup = new List<Group>();

        internal List<Group> ListGroup
        {
            get { return listGroup; }
            set { listGroup = value; }
        }

        private List<String> enrolledStudent;

        public List<String> EnrolledStudent
        {
            get { return enrolledStudent; }
            set { enrolledStudent = value; }
        }

        private List<Course> listAdjacentCourse = new List<Course>();

        internal List<Course> ListAdjacentCourse
        {
            get { return listAdjacentCourse; }
            set { listAdjacentCourse = value; }
        }

        private int degree = 0;

        public int Degree
        {
            get { return degree; }
            set { degree = value; }
        }

        private int maxWeight = 0;

        public int MaxWeight
        {
            get { return maxWeight; }
            set { maxWeight = value; }
        }

        private Color color = null;

        internal Color Color
        {
            get { return color; }
            set { color = value; }
        }

        // Factory method
        public Course() {
            this.ID = null;
            this.name = null;
            this.listGroup = new List<Group>();
            this.enrolledStudent = new List<string>();
            this.listAdjacentCourse = new List<Course>();
            this.degree = 0;
            this.maxWeight = 0;
            this.color = null;
        }

        public Course(string ID, string name)
        {
            this.ID = ID;
            this.name = name;
            this.listGroup = new List<Group>();
            this.enrolledStudent = new List<string>();
            this.listAdjacentCourse = new List<Course>();
            this.degree = 0;
            this.maxWeight = 0;
            this.color = null;
        }
        public bool checkContainsGroup(Group group)
        {
            bool isContains = false;
            for (int k = 0; k < this.listGroup.Count; k++)
            {
                Group test = listGroup.ElementAt(k);
                if (group.GroupId == test.GroupId && group.Team == test.Team)
                {
                    isContains = true;
                    break;
                }
            }
            return isContains;
        }

        public List<Course> orderListAdjacentCourse()
        {
            List<Course> list = new List<Course>();
            list = this.listAdjacentCourse.OrderBy(x => x.maxWeight).ToList();
            list = list.OrderBy(x => x.degree).ToList();
            list.Reverse();
            return list;
        }

        public void assignColor(Color color)
        {
            this.color = color;
            color.ListCourse.Add(this);
        }
    }
}
