namespace KamiPay.Models.Components;

public class MenuItem(string icon, string name, string category, string page)
{
    public string Icon { get; set; } = icon;

    public string Name { get; set; } = name;

    public string Category { get; set; } = category;

    public string Page { get; set; } = page;
}