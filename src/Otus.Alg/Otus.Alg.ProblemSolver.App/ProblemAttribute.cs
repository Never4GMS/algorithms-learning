[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
public sealed class ProblemAttribute : Attribute, IProblemDescriptor
{
    public ProblemAttribute(ushort month, ushort lesson, string name)
    {
        Month = month;
        Lesson = lesson;
        Name = name;
    }

    public ushort Month { get; }
    public ushort Lesson { get; }
    public string Name { get; }
}
