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

    public T Deserialize<T>(string input) where T : new()
    {
        var lines = input.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                         .ToList();

        T output = new();
        Type oType = output.GetType();

        foreach (var line in lines) 
        {
            if (!string.IsNullOrEmpty(line))
            {
                int seperator = line.IndexOf(":");

                var field = line[.. seperator];
                var value = line[(seperator + 1) ..];

                if (!string.IsNullOrEmpty(value))//TODO: Make this read the field and create the correct object here
                {
                    var memberInfo = GetReflectionInfoFromName<T>(field);

                    memberInfo?.SetValue(output, Convert.ChangeType(value, memberInfo.PropertyType), null);
                }
            }
        }
        return output;
    }

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