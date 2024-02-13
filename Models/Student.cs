using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAssessment.Models
{
    public class Student { 
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Score { get; set; }

        public Student(int id, string name, int age, double score)
        {
            Id = id;
            Name = name;
            Age = age;
            Score = score;
        }
        public override string ToString()
        {
            return 
            $@" 
            ---------------
            Id:     {Id}
            Name:   {Name}
            Age:    {Age}
            Score:  {Score}
            ---------------";
        }

    }
}
