using iSukces.Code;

namespace UnitGenerator;

internal class FileHolder
{
    public FileHolder(CsFile file, CsNamespace ns, CsClass cl)
    {
        File = file;
        Ns   = ns;
        Cl   = cl;
    }

    public CsFile      File { get; }
    public CsNamespace Ns   { get; }
    public CsClass     Cl   { get; }
}
