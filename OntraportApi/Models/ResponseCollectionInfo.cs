namespace HanumanInstitute.OntraportApi.Models;

public class ResponseCollectionInfo
{
    public ICollection<string> ListFields { get; set; } = new List<string>();
    [JsonConverter(typeof(JsonEmptyArrayConverter<Dictionary<string, string>>))]
    public Dictionary<string, string> ListFieldSettings { get; set; } = new Dictionary<string, string>();
    [JsonConverter(typeof(JsonEmptyArrayConverter<ResponseCardViewSettings?>))]
    public ResponseCardViewSettings? CardViewSettings { get; set; }
    [JsonConverter(typeof(JsonEmptyArrayConverter<int>))]
    public int ViewMode { get; set; }
    public int Count { get; set; }
}
