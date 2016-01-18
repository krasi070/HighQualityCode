namespace Methods
{
    using System;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other", "Student cannot be null value.");
            }
            else if (this.OtherInfo.Length < 10 || other.OtherInfo.Length < 10)
            {
                throw new ArgumentException("Student must have at least 10 characters in OtherInfo.");
            }

            DateTime firstDate = new DateTime();
            DateTime secondDate = new DateTime();

            if (DateTime.TryParse(this.OtherInfo.Substring(this.OtherInfo.Length - 10), out firstDate) ||
                DateTime.TryParse(other.OtherInfo.Substring(other.OtherInfo.Length - 10), out secondDate))
            {
                throw new ArgumentException("Student's OtherInfo is invalid.");
            }

            return firstDate > secondDate;
        }
    }
}
