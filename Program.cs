using System;
using System.Text;

namespace DocumentationBuilder
{
    public class Documentation
    {
        private readonly StringBuilder content = new StringBuilder();

        // Додає текст до документа
        public void AddContent(string text)
        {
            content.AppendLine(text);
        }

        // Повертає згенерований документ
        public string GetContent()
        {
            return content.ToString();
        }
    }

    public interface IDocumentationBuilder
    {
        void AddTitle(string title);
        void AddSection(string section);
        void AddFootnote(string footnote);
        Documentation GetDocumentation();
    }

    // Реалізація будівельника
    public class DocumentationBuilder : IDocumentationBuilder
    {
        private readonly Documentation documentation = new Documentation();

        public void AddTitle(string title)
        {
            documentation.AddContent($"=== {title} ===\n");
        }

        public void AddSection(string section)
        {
            documentation.AddContent($"--- {section} ---\n");
        }

        public void AddFootnote(string footnote)
        {
            documentation.AddContent($"* Примітка: {footnote}\n");
        }

        public Documentation GetDocumentation()
        {
            return documentation;
        }
    }

    // Директор, який керує процесом створення документації
    public class DocumentationDirector
    {
        private readonly IDocumentationBuilder builder;

        public DocumentationDirector(IDocumentationBuilder builder)
        {
            this.builder = builder;
        }

        public void BuildSimpleDocumentation()
        {
            builder.AddTitle("Заголовок документа");
            builder.AddSection("Основна секція");
            builder.AddFootnote("Це примітка до документа.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створення будівельника
            IDocumentationBuilder builder = new DocumentationBuilder();

            // Директор будує документацію
            DocumentationDirector director = new DocumentationDirector(builder);
            director.BuildSimpleDocumentation();

            // Отримання документації
            Documentation documentation = builder.GetDocumentation();

            // Вивід документації
            Console.WriteLine("Згенерована документація:");
            Console.WriteLine(documentation.GetContent());
        }
    }
}