using Posted.LetterTemplates;
using Xunit;

namespace Posted.Tests
{
    public class HtmlEmailTemplateTests
    {
        [Fact]
        public void Render()
        {
            var templateTestClass = new TemplateTestClass { Name = "Charles" };
            var emailTemplate = new HtmlEmailTemplate("Email subject", "<h1>@Model.Name</h1>", templateTestClass);
            var renderedText = emailTemplate.Render();
            Assert.NotNull(renderedText);
            Assert.Equal("<h1>Charles</h1>", renderedText);
        }
    }
}
