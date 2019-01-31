﻿using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading" +
                                                    " requires a minimum of 5 students to work");
            var studentGroup = (int)Math.Ceiling(Students.Count * 0.2);

            var grades = Students.OrderByDescending(g => g.AverageGrade).Select(g => g.AverageGrade).ToList();
            if (grades[studentGroup - 1] <= averageGrade)
                return 'A';
            else if (grades[(studentGroup * 2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(studentGroup * 3) - 1] <= averageGrade)
                return 'C';
            else if (grades[(studentGroup * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count > 5)
                base.CalculateStatistics();
            else
                Console.WriteLine("Ranked grading requires at least 5 students with grades" +
                                  " in order to properly calculate a student's overall grade.");
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count > 5)
                base.CalculateStudentStatistics(name);
            else
                Console.WriteLine("Ranked grading requires at least 5 students with grades" +
                                  " in order to properly calculate a student's overall grade.");
        }
    }
}