using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Framework;

public static class Localization
{
    private static string language;
    private static JObject stringCollection;
    public static void SwitchLanguage(string lang)
    {
        language = lang;
        try
        {
            using (StreamReader file = File.OpenText("./resources/loc/" + lang + ".json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                stringCollection = (JObject)JToken.ReadFrom(reader);
            }
        }
        catch (FileNotFoundException e)
        {
            DebugConsole.LogError(e.Message);
            return;
        }
        
    }

    public static string GetString(string key)
    {
        if (stringCollection == null)
        {
            return "!~M~!";
        }
        if (stringCollection.ContainsKey(key))
        {
            return stringCollection[key].ToString();
        } 
        DebugConsole.LogError($"Localization: Missing String in '{language}'.json: {key}");
        return $"!!!({key})!!!";
    }
}