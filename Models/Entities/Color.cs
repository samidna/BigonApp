using BigonApp.Models.Entities.Common;

namespace BigonApp.Models.Entities;

public class Color : BaseEntity<int>
{
    public string Name { get; set; }
    public string HexCode { get; set; }
}
