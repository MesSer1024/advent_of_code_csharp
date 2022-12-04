
using advent_of_code_csharp.Source;

public interface IDay
{
    string Identifier { get; }
    bool SameData { get; }

    void ProcessExample();
    void ProcessFirst(string[] input);
    void ProcessSecond(string[] input);
}