namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string name)
            : this(name, null, new List<string>(), null)
        {
            
        }

        public LocalCourse(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>(), null)
        {
            
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName, students, null)
        {

        }

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Course lab cannot be empty or null.", "Lab");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Local" + base.ToString());
            if (this.Lab != null)
            {
                int index = result.ToString().LastIndexOf(" }");
                result.Insert(index, "; Lab = " + this.Lab);
            }

            return result.ToString();
        }
    }
}
