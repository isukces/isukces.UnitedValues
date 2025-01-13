using System.Linq;
using iSukces.Code;
using iSukces.UnitedValues;

namespace UnitGenerator;

public class TypeCodeAliases
{
    private TypeCodeAliases(string nameSingular, string namePlural)
    {
        nameSingular = nameSingular?.TrimToEmpty();
        namePlural   = namePlural?.TrimToEmpty();
        if (string.IsNullOrEmpty(namePlural) && !string.IsNullOrEmpty(nameSingular))
            namePlural = nameSingular + "s";

        NameSingular = nameSingular;
        NamePlural   = namePlural;
    }

    public static TypeCodeAliases? Make(string nameSingular, string namePlural)
    {
        nameSingular = nameSingular?.TrimToNull();
        namePlural   = namePlural.TrimToNull();
        if (nameSingular is null && namePlural is null)
            return null;
        return new TypeCodeAliases(nameSingular, namePlural);
    }

    public string[] Plus(string[] args)
    {
        var append = new[] {NameSingular, NamePlural}
            .Where(a => !string.IsNullOrWhiteSpace(a))
            .Select(a=>a.CsEncode())
            .ToArray();
        if (append.Length == 0)
            return args;
        var l = args.ToList();
        l.AddRange(append);
        return l.ToArray();
    }

    public string NameSingular { get; }

    public string NamePlural { get; }
}
