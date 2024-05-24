using System;
using System.Text;

namespace DecoratorPattern
{
    public abstract class StringBuilderDecorator  // Базовый класс декоратора
    {
        protected StringBuilder decoratedStringBuilder;

        public StringBuilderDecorator(StringBuilder decoratedStringBuilder)
        {
            this.decoratedStringBuilder = decoratedStringBuilder;
        }

        public virtual string ToString() => decoratedStringBuilder.ToString(); // Методы для делегирования

        public virtual StringBuilder Append(string value) => decoratedStringBuilder.Append(value);

        public virtual StringBuilder AppendLine(string value) => decoratedStringBuilder.AppendLine(value);
    }

    public class IndentedStringBuilder : StringBuilderDecorator // Конкретный декоратор для добавления пробелов
    {
        private int indentCount;

        public IndentedStringBuilder(StringBuilder decoratedStringBuilder, int indentCount) : base(decoratedStringBuilder)
        {
            this.indentCount = indentCount;
        }

        public override StringBuilder Append(string value)
        {
            return decoratedStringBuilder.Append(new string(' ', indentCount)).Append(value);
        }

        public override StringBuilder AppendLine(string value)
        {
            return decoratedStringBuilder.AppendLine(new string(' ', indentCount) + value);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder(); // Создаем стандартный StringBuilder

            IndentedStringBuilder indentedSb = new IndentedStringBuilder(sb, 4); // Создаем декоратор с отступом в 4 пробела

            indentedSb.Append("Hello,"); // Используем декоратор
            indentedSb.AppendLine("world!");
            indentedSb.Append("This is ");
            indentedSb.AppendLine("an indented string.");

            Console.WriteLine(indentedSb.ToString()); 

            Console.ReadLine();
        }
    }
}
