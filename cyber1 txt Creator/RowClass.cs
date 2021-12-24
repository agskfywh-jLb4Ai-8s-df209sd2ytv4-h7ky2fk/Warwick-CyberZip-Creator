using System;
using System.Linq;

namespace cyber1_txt_Creator {
    public class RowClass {
        private string _name;
        private string _type;
        private string _description;

        public string Name { get => _name; set { _name = NameTruncator(value); } }
        public string Type { get => _type; set { _type = TypeValidator(value.ToLower()) ? value.ToLower() : throw new Exception("Invalid string Input"); } }
        public string Level { get; set; }
        public DateTime StartDate { get; set; }
        public int WorkingDays { get; set; }
        public string Description { get => _description; set { _description = value.Length <= 200 && !value.Contains(',') ? value : throw new Exception("Input too long"); } }

        /// <summary>
        /// Creates a new instance of the Row Class.
        /// </summary>
        public RowClass() { }

        /// <summary>
        /// Creates a new instance of the Row Class.
        /// </summary>
        /// <param name="name">The name of the course</param>
        /// <param name="type">The type of course (summer school, course, school/college project, work/placement project, own project, other)</param>
        /// <param name="level">Introduction, advanced, elite, {blank}</param>
        /// <param name="startDate">Format YYYY-MM-DD</param>
        /// <param name="workingDays">Duration in working days</param>
        /// <param name="description">Description</param>
        public RowClass(string name, string type, string level, DateTime startDate, int workingDays, string description) {
            Name = name;
            Type = type;
            Level = level;
            StartDate = startDate;
            WorkingDays = workingDays;
            Description = description;
        }

        private bool TypeValidator(string type) {
            string[] compareTo = new string[] { "summer school", "course", "school/college project", "work/placement project", "own project", "other" };
            return compareTo.Contains(type);
        }
        private string NameTruncator(string name) {
            if (name.Length <= 30) return name;
            else return name.Substring(0, 30);
            
        }


        public string DataAsCSV() {
            return $"{Name},{Type},{Level},{StartDate.ToString("yyyy-MM-dd")},{WorkingDays.ToString()},{Description}";
        }
    }
}
