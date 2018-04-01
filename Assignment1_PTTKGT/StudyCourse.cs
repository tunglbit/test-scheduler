using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PTTKGT
{
    class StudyCourse
    {

        // Propertises
        string studentId = null;

        public string StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }
        string courseId = null;

        public string CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }
        string group = null;

        public string Group
        {
            get { return group; }
            set { group = value; }
        }
        string team = null;

        public string Team
        {
            get { return team; }
            set { team = value; }
        }

        // Factory method

        public StudyCourse()
        {
            this.studentId = null;
            this.courseId = null;
            this.group = null;
            this.team = null;
        }

        public StudyCourse(string studentId, string courseId, string group, string team)
        {
            this.studentId = studentId;
            this.courseId = courseId;
            this.group = group;
            this.team = team;
        }
    }
}
