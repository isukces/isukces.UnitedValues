using System.Linq;

namespace UnitGenerator
{
    public class ExpressionPath
    {
        private ExpressionPath(string path)
        {
            Path = path;
        }
        
        
        public string GetByDotsCounts( int dotsCount)
        {
            var partsExpected = dotsCount + 1;
            var r             = Path.Split('.');
            if (r.Length == partsExpected)
                return Path;
            if (r.Length < partsExpected)
                return null;
            return string.Join(".", r.Take(partsExpected));
        }
        
        public static  explicit operator ExpressionPath(string x)
        {
            x = x?.Trim();
            if (string.IsNullOrEmpty(x))
                return null;
            return new ExpressionPath(x);
        }

        public override string ToString()
        {
            return Path;
        }

        public string Path { get; }
        public int    Dots => Path.Split('.').Length - 1;

        public static ExpressionPath operator +(ExpressionPath left, string rigth)
        {
            var right2 = (ExpressionPath)rigth;

            if (left is null)
                return right2;
            if (right2 is null)
                return left;
            return (ExpressionPath)(left.Path + "." + right2.Path);
        }
    }
}