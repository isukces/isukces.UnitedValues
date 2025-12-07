namespace UnitGenerator;

internal sealed class CsGeneratorConfig
{
    public static bool UseJetBrains         { get; set; }
    public static bool UseReferenceNullable => !UseJetBrains;

}
