using CharlieMaths.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharlieMaths.Models
{
    public interface IQuestionGenerator
    {
        Question GetQuestion();
    }

    public abstract class QuestionGenerator : IQuestionGenerator
    {
        protected Random RandomNumber = new Random();

        public abstract Question GetQuestion();
    }

    public class AdditionQuestionGenerator : QuestionGenerator
    {
        public override Question GetQuestion()
        {
            var a = RandomNumber.Next(10);
            var b = RandomNumber.Next(10);

            return new Question
            {
                Text = $"{a} + {b} =",
                Answer = (a + b).ToString()
            };

        }
    }

    public class SubtractionQuestionGenerator1 : QuestionGenerator
    {
        public override Question GetQuestion()
        {
            var a = RandomNumber.Next(10);
            var b = RandomNumber.Next(a);

            return new Question
            {
                Text = $"{a} - {b} =",
                Answer = (a - b).ToString()
            };

        }
    }

    public class SubtractionQuestionGenerator2 : QuestionGenerator
    {
        public override Question GetQuestion()
        {
            var a = RandomNumber.Next(10);
            var b = RandomNumber.Next(a);

            return new Question
            {
                Text = $"{b} - {a} =",
                Answer = (b - a).ToString()
            };

        }
    }

    public class MultiplicationQuestionGenerator : QuestionGenerator
    {
        private int MaximumValue { get; set; }

        public MultiplicationQuestionGenerator(int maximumValue)
        {
            MaximumValue = maximumValue;
        }

        public override Question GetQuestion()
        {
            var a = RandomNumber.Next(MaximumValue);
            var b = RandomNumber.Next(MaximumValue);

            return new Question
            {
                Text = $"{a} x {b} =",
                Answer = (a * b).ToString()
            };
        }
    }

    public class DivisionQuestionGenerator : QuestionGenerator
    {
        private int MaximumValue { get; set; }

        public DivisionQuestionGenerator(int maximumValue)
        {
            MaximumValue = maximumValue;
        }

        public override Question GetQuestion()
        {
            var a = RandomNumber.Next(MaximumValue);
            var b = RandomNumber.Next(MaximumValue - 1) + 1;

            return new Question
            {
                Text = $"{a * b} / {b} =",
                Answer = a.ToString()
            };
        }
    }

    public class DivisionQuestionGenerator2 : QuestionGenerator
    {
        public override Question GetQuestion()
        {
            var a = RandomNumber.Next(10);
            var b = RandomNumber.Next(9) + 1;

            return new Question
            {
                Text = $"{a * b} / {b} =",
                Answer = a.ToString()
            };
        }
    }
}
