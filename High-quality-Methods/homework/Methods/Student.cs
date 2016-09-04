namespace Methods
{
    using System;

    public class Student
    {
        public Student(string firstName, string lastName, string otherInfo = null)
        {
            Student.ValidateName(new string[2] { firstName, lastName });

            this.FirstName = firstName;

            this.LastName = lastName;

            this.OtherInfo = otherInfo;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student otherStudent)
        {
            DateTime firstDate =
                Student.CalculateDate(this);
            DateTime secondDate =
               Student.CalculateDate(otherStudent);
            return firstDate > secondDate;
        }

        private static DateTime CalculateDate(Student student)
        {
            var result =
                DateTime.Parse(student.OtherInfo.Substring(student.OtherInfo.Length - 10));
            return result;
        }

        private static void ValidateName(string[] names)
        {
            foreach (var name in names)
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentNullException("Name cannot be null or empty");
                }
            }
        }
    }
}
