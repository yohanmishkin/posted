using System;
using Xunit;

namespace Posted.Tests
{
    public class EmailTemplateTests
    {
        [Fact]
        public void RenderSimpleObject()
        {
            var model = new SimpleClass { Name = "Charles" };
            var emailTemplate = new EmailTemplate("Email subject", "<h1>@Model.Name</h1>", model);
            var renderedText = emailTemplate.Render();
            Assert.NotNull(renderedText);
            Assert.Equal("<h1>Charles</h1>", renderedText);
        }

        [Fact]
        public void RendersEmailSubject()
        {
            var emailTemplate = new EmailTemplate("Email subject", "<title>@Subject</title>", new object());
            var renderedText = emailTemplate.Render();
            Assert.Contains("<title>Email subject</title>", renderedText);
        }

        [Fact]
        public void RenderComplexObject()
        {
            var model = new ComplexClass
            {
                Parent = new ComplexClass
                {
                    SimpleChild = new SimpleClass
                    {
                        Name = "Charles",
                        DateOfBirth = new DateTime(2012, 12, 12)
                    }
                }
            };

            var template = 
                "<h1>@Model.Parent.SimpleChild.Name (DOB: @Model.Parent.SimpleChild.DateOfBirth.ToString(\"MM/dd/yy\"))</h1>";

            var emailTemplate = new EmailTemplate("Email subject", template, model);
            var renderedText = emailTemplate.Render();
            Assert.NotNull(renderedText);
            Assert.Equal("<h1>Charles (DOB: 12/12/12)</h1>", renderedText);
        }

        [Fact]
        public void RenderNullChildProperties()
        {
            var model = new ComplexClass();
            var template = "<h1>@Model.Parent.SimpleChild.Name</h1>";
            var emailTemplate = new EmailTemplate(null, template, model);

            try
            {
                emailTemplate.Render();
            }
            catch (ArgumentNullException exception)
            {
                var expectedMessage = "@Model.Parent.SimpleChild.Name referenced in your email template is null";
                Assert.Equal(expectedMessage, exception.Message);
            }
        }
    }
}
