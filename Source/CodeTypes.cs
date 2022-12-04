
using advent_of_code_csharp.Source;

public interface IDay
{
    string Identifier { get; }

    void ProcessExample();

    void PopulateData(string[] lines);
    void ProcessFirst();
    void ProcessSecond();
}