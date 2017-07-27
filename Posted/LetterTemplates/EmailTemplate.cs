using System.Linq.Expressions;
using System.Text.RegularExpressions;
using DynamicExpression = System.Linq.Dynamic.DynamicExpression;

namespace Posted
{
    public sealed class EmailTemplate : LetterTemplate
    {
        private readonly string _subject;
        private readonly string _template;
        private readonly object _model;

        public EmailTemplate(string subject, string template, object model)
        {
            _subject = subject;
            _template = template;
            _model = model;
        }

        public string Render()
        {
            const string expression = "@Model[\\.\\w]+(\\([^)]+\\))*";
            return Regex.Replace(_template, expression, match =>
            {
                var parameter = Expression.Parameter(_model.GetType(), "@Model");
                var capturedExpression =
                    DynamicExpression.ParseLambda(new[] { parameter }, null, match.Groups[0].Value);
                return (capturedExpression.Compile().DynamicInvoke(_model) ?? "").ToString();
            }).Replace("@Subject", _subject);
        }
    }
}