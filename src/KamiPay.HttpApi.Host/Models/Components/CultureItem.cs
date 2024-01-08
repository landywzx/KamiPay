namespace KamiPay.Models.Components;

public class CultureItem(string code, string name, string flag)
{
    public string Code { get; set; } = code;

    public string Name { get; set; } = name;

    public string Flag { get; set; } = flag;
}