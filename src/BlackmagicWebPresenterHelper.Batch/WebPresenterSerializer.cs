using System.ComponentModel;
using System.Reflection;
using System.Text;

public class WebPresenterSerializer 
{

    public byte[] SerializeBytes<T>(T input) where T : new() => System.Text.Encoding.ASCII.GetBytes(Serialize(input));

    public string Serialize<T>(T input) where T : new()
    {
        StringBuilder output = new();

        // Write Section name
        var myType = typeof(T);
        output.Append(GetName(myType));
        output.AppendLine(":");

        var props = new List<PropertyInfo>(myType.GetProperties());
        foreach (var prop in props) 
        {
            var propValue = prop.GetValue(input, null);

            if (propValue != null)
            {
                // Write Property Name: Value
                output.Append(GetName(prop));
                output.Append(": ");
                output.AppendLine(propValue.ToString());
            }
        }
        // Write end section line
        output.AppendLine();

        return output.ToString();
    }

    public T? Deserialize<T>(string input) where T : new()
    {
        var lines = SplitOnNewLine(input);

        var output = (T?)Deserialize(lines, typeof(T));

        return output;
    }

    // public object? Deserialize(string input) 
    // {
    //     var lines = SplitOnNewLine(input);

    //     return Deserialize(lines);
    // }

    //public object? Deserialize(List<string> input) 
    //{
        //var type = new Type();//TODO: find what type the object is and call Deserialize(List<string> input, Type type)

        //return Deserialize(input,type);
    //}

    // public List<object?> DeserializeMulti(string input) 
    // {
    //     var lines = SplitOnNewLine(input);

    //     return DeserializeMulti(lines);
    // }

    // public List<object?> DeserializeMulti(List<string> input)
    // {
    //     List<List<string>> objectGroups = new();

    //     List<string> currentGroup = new();
    //     foreach(var line in input)
    //     {
    //         currentGroup.Add(line);
    //         if (string.IsNullOrEmpty(line))
    //         {
    //             objectGroups.Add(currentGroup);
    //             currentGroup = new();
    //         }
    //     }

    //     // In theory everything should have a extra new line in it. But hey theory isnt practice... Check to make sure that if it isnt here throw it in the list anyways.
    //     if (currentGroup.Count > 0)
    //     {
    //         objectGroups.Add(currentGroup);
    //     }

    //     return objectGroups.Select(g => Deserialize(g)).ToList();
    // }

    public object? Deserialize(List<string> input, Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) == null){
            return null;
        }
        object? output = Activator.CreateInstance(type);

        foreach (var line in input) 
        {
            if (!string.IsNullOrEmpty(line))
            {
                int seperator = line.IndexOf(":");

                var field = line[.. seperator];
                var value = line[(seperator + 1) ..];

                if (!string.IsNullOrEmpty(value))//TODO: Make this read the field and create the correct object here
                {
                    var memberInfo = GetReflectionInfoFromName(field,type);

                    memberInfo?.SetValue(output, Convert.ChangeType(value, memberInfo.PropertyType), null);
                }
            }
        }

        return output;
    }
    
    private List<string> SplitOnNewLine(string input) => input.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                                                              .ToList();
    private DescriptionAttribute? GetDescription(MemberInfo prop)
        => prop.GetCustomAttributes(typeof(DescriptionAttribute), true)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault();

    private string GetName(MemberInfo prop) 
    {
        var attributeName = GetDescription(prop)?.Description;

        if (attributeName == null)
        {
            return prop.Name;
        }
        return attributeName;
    }

    private PropertyInfo? GetReflectionInfoFromName<T>(string name) => GetReflectionInfoFromName(name,typeof(T));

    private PropertyInfo? GetReflectionInfoFromName(string name, Type type) 
    {
        PropertyInfo? info = type.GetProperty(name);
        if (info == null)
        {
            info = type.GetProperties()
                       .Where(t => GetName(t) == name)
                       .FirstOrDefault();
        }

        return info;
    }
}