using System.Collections.Generic;
using System.IO;
using iSukces.Code;

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
            var info2 = CsFilesManager.Instance.GetFileInfo(name, _nameSpace);
            var file = info2.File;
            if (info2.IsEmbedded)
            {
                CsFilesManager.AddGeneratorName(file, GetType().Name);
                //file.BeginContent += "// generator: " + GetType().Name;
                // ProcessFile(file);
                var ns = file.GetOrCreateNamespace(_nameSpace);
                var cl = ns.GetOrCreateClass(name);
                cl.IsPartial  = true;
                /*info          = new FileHolder(file, ns, cl);
                _clases[name] = info;
                return info.Cl;*/
                return cl;
            }
            if (_clases.TryGetValue(name, out var info))
                return info.Cl;
            {
                //file.BeginContent += "// generator: " + GetType().Name;
                ProcessFile(file);
                var ns = file.GetOrCreateNamespace(_nameSpace);
                var cl = ns.GetOrCreateClass(name);
                cl.IsPartial  = true;
                info          = new FileHolder(file, ns, cl);
                _clases[name] = info;
                return info.Cl;
            }
        }

        private readonly Dictionary<string, FileHolder> _clases = new Dictionary<string, FileHolder>();
        private readonly string _nameSpace;
    }
}