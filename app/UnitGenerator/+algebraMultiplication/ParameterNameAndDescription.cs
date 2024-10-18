namespace UnitGenerator;

public class ParameterNameAndDescription
{
    public ParameterNameAndDescription(string name, string desctiption)
    {
        Name        = name;
        Desctiption = desctiption;
    }

    public override string ToString()
    {
        return $"Name={Name}, Desctiption={Desctiption}";
    }

    public string Name { get; }

    public string Desctiption { get; }
}