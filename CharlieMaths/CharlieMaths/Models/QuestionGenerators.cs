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

        public int RandomInt(int max)
        {
            return RandomNumber.Next(max);
        }

        public bool RandomBool()
        {
            return RandomNumber.Next(2) == 0;
        }
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
        public int MaximumValue { get; set; } = 5;

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
        public int MaximumValue { get; set; } = 5;

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

    public class BracketsQuestionGenerator : QuestionGenerator
    {
        public int MaximumValue { get; set; } = 5;

        public bool SwitchOperators { get; set; }

        public bool SwitchPosition { get; set; }

        public override Question GetQuestion()
        {
            var a = RandomInt(MaximumValue);
            var b = RandomInt(MaximumValue);
            var c = RandomInt(MaximumValue);
            var d = SwitchOperators ? RandomBool() : true;
            var e = SwitchPosition ? RandomBool() : true;

            var op = e ? "+" : "-";

            return new Question
            {
                Text = d
                    ? $"({a} {op} {b}) * {c} ="
                    : $"{a} {op} ({b} * {c}) =",
                Answer = d
                    ? ((a + (e ? b : -b)) * c).ToString()
                    : (a + ((e ? b : -b) * c)).ToString()
            };
        }
    }
}
