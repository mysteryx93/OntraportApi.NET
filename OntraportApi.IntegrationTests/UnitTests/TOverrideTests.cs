using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi.UnitTests;

// TOverrideExtension must be made public to run this test.
public class TOverrideTests
{
    //private static Dictionary<string, object> TestData => new Dictionary<string, object>() {
    //    { MyObject.IdKey, "MyId" },
    //    { MyObject.NameKey, "MyName" },
    //    { MyObject.EmailKey, "MyEmail" },
    //    { MyObject.DescriptionKey, "MyDescription" }
    //};

    //[Fact]
    //public void OverrideFields_SameTypes_ReturnSameDictionary()
    //{
    //    var query = TestData;

    //    var result = query.OverrideFields<MyObject, MyObject>();

    //    Assert.Same(result, query);
    //}

    //[Fact]
    //public void OverrideFields_DifferentTypes_ReturnsReplacedKeys()
    //{
    //    var query = TestData;

    //    var result = query.OverrideFields<MyObject, MyObjectDev>();

    //    Assert.Contains(MyObjectDev.NameKey, result);
    //    Assert.Contains(MyObjectDev.EmailKey, result);
    //    Assert.DoesNotContain(MyObjectDev.SomeOtherKey, result);
    //}
}

public class MyObject : ApiObject
{
    public const string NameKey = "11";
    public const string EmailKey = "22";
    public const string DescriptionKey = "00";
}

public class MyObjectDev : MyObject
{
    public new const string NameKey = "11-dev";
    public new const string EmailKey = "22-dev";
    public const string SomeOtherKey = "55-dev";
}
