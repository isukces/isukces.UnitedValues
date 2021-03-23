using System.Collections.Generic;
using System.IO;
using iSukces.Code;
using iSukces.Code.CodeWrite;

namespace UnitGenerator
{
    public abstract class MultipleFilesGenerator
    {
        protected MultipleFilesGenerator(string nameSpace)
        {
            _nameSpace = nameSpace;
        }

        public void Save(string path)
        {
            foreach (var i in _clases.Values)
            {
                var fi = Path.Combine(path, i.Cl.Name + ".auto.cs");
                i.File.SaveIfDifferent(fi);
            }
        }

        protected virtual void ProcessFile(CsFile file)
        {
            file.AddImportNamespace("System");
        }

        private protected CsClass GetClass(string name)
        {
            if (_clases.TryGetValue(name, out var info))
                return info.Cl;
            var file = new CsFile();
            ProcessFile(file);
            var ns = file.GetOrCreateNamespace(_nameSpace);
            var cl = ns.GetOrCreateClass(name);
            cl.IsPartial  = true;
            info          = new FileHolder(file, ns, cl);
            _clases[name] = info;
            return info.Cl;
        }

        private readonly Dictionary<string, FileHolder> _clases = new Dictionary<string, FileHolder>();
        private readonly string _nameSpace;
    }
}