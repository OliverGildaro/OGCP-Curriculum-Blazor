using System.Text.Json;

namespace OGCP.Curriculums.BlazorServer.Utils;
public class JsonSerializerOptionsWrapper
{
    public JsonSerializerOptionsWrapper()
    {
        Options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
    }

    public JsonSerializerOptions Options { get; }
}