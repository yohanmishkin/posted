namespace Posted.Tests.TestClasses
{
    internal class ComplexClass
    {
        public string Name { get; set; }
        public ComplexClass Parent { get; set; }
        public SimpleClass SimpleChild { get; set; }
    }
}