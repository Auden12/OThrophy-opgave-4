using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

    public class Trophy
{
        public int Id { get; set; }
        public string? Competition { get; set; }
        public int Year { get; set; }


        public void ValidateYear()
        {
            if (Year < 1970 || Year > 2024)
            {

                throw new ArgumentOutOfRangeException(
                   $"Year must be from 1970 to 2024: {Year}");


            }
        }
        public void ValidateCompetition()
        {
            if (Competition == null) { throw new ArgumentNullException("Competition name cannot be null"); }
            if (Competition.Trim().Length == 0)
            {
                throw new ArgumentOutOfRangeException("Competition name must have 1 or more letters");
            }

        }
        public override string ToString()
        {
            return Id + " " + Competition + " " + Year;
        }
    public void Validate()
    {
        ValidateYear();
        ValidateCompetition();
    }


}
