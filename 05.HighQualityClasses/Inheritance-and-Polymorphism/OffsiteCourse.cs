namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string name)
            : this(name, null, new List<string>(), null)
        {

        }

        public OffsiteCourse(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>(), null)
        {

        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName, students, null)
        {

        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Offsite course town cannot be null or empty.", "Town");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Offsite" + base.ToString());
            if (this.Town != null)
            {
                int index = result.ToString().LastIndexOf(" }");
                result.Insert(index, "; Town = " + this.Town);
            }

            return result.ToString();
        }
    }
}
