using System;
using System.Collections.Generic;
using System.Text;

namespace CharlieMaths.Models
{
    public class Lesson
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsCompleted { get; set; }

        public QuestionGenerator QuestionGenerator { get; set; }

        public static readonly List<Lesson> AllLessons = new List<Lesson>();

        public string Label => $"Lesson {Id}: {Name}";

        static Lesson()
        {
            int lessonCount = 0;

            AllLessons.Add(new Lesson { Id = ++lessonCount, Name = "Addition", QuestionGenerator = new AdditionQuestionGenerator() });
            AllLessons.Add(new Lesson { Id = ++lessonCount, Name = "Subtraction #1", QuestionGenerator = new SubtractionQuestionGenerator1() });
            AllLessons.Add(new Lesson { Id = ++lessonCount, Name = "Multiplication #1", QuestionGenerator = new MultiplicationQuestionGenerator() });
            AllLessons.Add(new Lesson { Id = ++lessonCount, Name = "Division #1", QuestionGenerator = new DivisionQuestionGenerator() });
            AllLessons.Add(new Lesson { Id = ++lessonCount, Name = "Subtraction #2", QuestionGenerator = new SubtractionQuestionGenerator2() });
            AllLessons.Add(new Lesson { Id = ++lessonCount, Name = "Multiplication #2", QuestionGenerator = new MultiplicationQuestionGenerator { MaximumValue = 10 } }); ;
            AllLessons.Add(new Lesson { Id = ++lessonCount, Name = "Division #2", QuestionGenerator = new DivisionQuestionGenerator { MaximumValue = 10 } });
            AllLessons.Add(new Lesson { Id = ++lessonCount, Name = "Brackets #1", QuestionGenerator = new BracketsQuestionGenerator() });
            AllLessons.Add(new Lesson { Id = ++lessonCount, Name = "Brackets #2", QuestionGenerator = new BracketsQuestionGenerator { SwitchOperators = true } });
            AllLessons.Add(new Lesson { Id = ++lessonCount, Name = "Brackets #3", QuestionGenerator = new BracketsQuestionGenerator { SwitchPosition = true } });
            AllLessons.Add(new Lesson { Id = ++lessonCount, Name = "Brackets #4", QuestionGenerator = new BracketsQuestionGenerator { MaximumValue = 8, SwitchOperators = true, SwitchPosition = true } });
        }
    }
}
