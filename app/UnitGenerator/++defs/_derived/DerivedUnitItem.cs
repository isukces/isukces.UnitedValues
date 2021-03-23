namespace UnitGenerator
{
    public class DerivedUnitItem : Dy
    {
        /// <summary>
        /// </summary>
        /// <param name="fieldName">static field name that holds unit name</param>
        /// <param name="unitShortCode"></param>
        /// <param name="scaleFactor"></param>
        /// <param name="fromMethodNameSufix"></param>
        public DerivedUnitItem(string fieldName, string unitShortCode, decimal scaleFactor, string fromMethodNameSufix = null)
            : base(fieldName, unitShortCode, fromMethodNameSufix)
        {
            ScaleFactor = scaleFactor.CsEncode();
        }
        
        /// <summary>
        /// </summary>
        /// <param name="fieldName">static field name that holds unit name</param>
        /// <param name="unitShortCode"></param>
        /// <param name="scaleFactor"></param>
        /// <param name="fromMethodNameSufix"></param>
        public DerivedUnitItem(string fieldName, string unitShortCode, string scaleFactor, string fromMethodNameSufix = null)
            : base(fieldName, unitShortCode, fromMethodNameSufix)
        {
            ScaleFactor = scaleFactor;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Factor={ScaleFactor}";
        }

        /// <summary>
        ///     static field name that holds unit name
        /// </summary>
        
        public string ScaleFactor { get; }
    }
}