using System.Collections;

namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// Represents a search condition.
/// </summary>
public class ApiSearchConditionBase
{
    public string Field { get; set; } = string.Empty;
    public bool AndCond { get; set; } = true;
}

public class ApiSearchCondition : ApiSearchConditionBase
{
    public string Op { get; set; } = string.Empty;
    public object? Value { get; set; }

    public ApiSearchCondition()
    { }

    public ApiSearchCondition(string field, string op, object? value, bool andCond = true)
    {
        Field = field;
        Op = op;
        Value = value;
        AndCond = andCond;
    }
}

public class ApiSearchConditionInList : ApiSearchConditionBase
{
    public IList Values { get; } = new List<object>();

    public ApiSearchConditionInList()
    { }

    public ApiSearchConditionInList(string field, IEnumerable values, bool andCond = true)
    {
        Field = field;
        Values.AddRange(values);
        AndCond = andCond;
    }
}
