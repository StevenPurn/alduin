using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public static class FS {

    public static void SaveData(string filePath, object obj, bool saveJson = true)
    {
        if (saveJson)
        {
            SaveToJson(filePath, obj);
        } else
        {
            SaveToXML(filePath, obj);
        }
    }

    private static void SaveToXML(string filePath, object obj, bool appendFile = false)
    {
        var serializer = new XmlSerializer(obj.GetType());

        using (var stream = new StreamWriter(filePath, appendFile))
        {
            serializer.Serialize(stream, obj);
        }
    }

    private static void SaveToJson(string filePath, object obj, bool appendFile = false)
    {
        using (StreamWriter file = File.CreateText(filePath))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, obj);
        }
    }

    public static T LoadData<T>(string filePath, string xmlRoot = "", bool loadJson = true)
    {
        T result;
        if (loadJson)
        {
            result = LoadFromJson<T>(filePath);
        } else
        {
            result = LoadFromXML<T>(filePath, xmlRoot);
        }
        return result;
    }

    private static T LoadFromXML<T>(string filePath, string xmlRoot)
    {
        T result;
        using (var reader = new StreamReader(filePath))
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T),
                new XmlRootAttribute(xmlRoot));
            result = (T)deserializer.Deserialize(reader);
        }
        return result;
    }

    private static T LoadFromJson<T>(string filePath)
    {
        T obj;
        using (StreamReader file = File.OpenText(filePath))
        using (JsonTextReader reader = new JsonTextReader(file))
        {
            string json = file.ReadToEnd();
            Debug.Log(json);
            obj = JArray.Parse(json).ToObject<T>();
        }
        return obj;
    }
}
