using Feedback.Server.Database.Entities.Common;
using System.Reflection;
using System.Text;

namespace Feedback.Server.Helpers;

public static class CsvToEntity
{
    public static IEnumerable<TEntity>? GetEntitiesFromCsv<TEntity>(string path, Encoding encoding, char separator = ';') where TEntity : Entity
    {
        if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            yield break;

        string[] lines = File.ReadAllLines(path, encoding);

        if (lines.Length == 0)
            yield break;

        string[] fieldNamesFromCsv = lines.Take(1)
            .SelectMany(x => x.Split(';')
            .Select(x => x.TrimStart('"').TrimEnd('"')))
            .ToArray();

        PropertyInfo[] properties = typeof(TEntity).GetProperties();

        foreach (var line in lines.Skip(1))
        {
            yield return GetEntity<TEntity>(line, separator, fieldNamesFromCsv, properties);
        }
    }

    public static IEnumerable<TEntity>? GetEntitiesFromCsv<TEntity>(string path, char separator = ';') where TEntity : Entity
    {
        if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            yield break;

        string[] lines = File.ReadAllLines(path, Encoding.UTF8);

        if (lines.Length == 0)
            yield break;

        string[] fieldNamesFromCsv = lines.Take(1)
            .SelectMany(x => x.Split(';')
            .Select(x => x.TrimStart('"').TrimEnd('"')))
            .ToArray();

        PropertyInfo[] properties = typeof(TEntity).GetProperties();

        foreach (var line in lines.Skip(1))
        {
            yield return GetEntity<TEntity>(line, separator, fieldNamesFromCsv, properties);
        }
    }

    private static TEntity? GetEntity<TEntity>(string csvLine, char separator, string[] fieldNamesFromCsv, PropertyInfo[] properties) where TEntity : Entity
    {
        TEntity? entity = Activator.CreateInstance(typeof(TEntity)) as TEntity;

        string[] splitted = SplitCsvLine(csvLine, separator);

        foreach (var fName in fieldNamesFromCsv)
        {
            int index = Array.FindIndex(fieldNamesFromCsv, x => x == fName);

            PropertyInfo? currentProperty = properties.FirstOrDefault(x => x.Name == fName);

            object? normilizedValue = GetConvertedValue(currentProperty.PropertyType, splitted[index]);

            currentProperty.SetValue(entity, normilizedValue);
        }

        return entity;
    }

    private static object? GetConvertedValue(Type type, string value) =>
        type == typeof(bool) ? value == "1" : Convert.ChangeType(value, type);

    private static string[] SplitCsvLine(string line, char separator) =>
        line.Split(separator).Select(x => x.TrimStart('"').TrimEnd('"')).ToArray();
}