namespace UnitGenerator
{
    public class DerivedUnitItem
    {
        /// <summary>
        /// </summary>
        /// <param name="fieldName">static field name that holds unit name</param>
        /// <param name="unitCode"></param>
        /// <param name="factor"></param>
        /// <param name="fromMethodNameSufix"></param>
        public DerivedUnitItem(string fieldName, string unitCode, decimal factor, string fromMethodNameSufix = null)
        {
            FieldName           = fieldName;
            UnitCode            = unitCode;
            Factor              = factor;
            FromMethodNameSufix = fromMethodNameSufix;
        }

        public override string ToString()
        {
            return
                $"FieldName={FieldName}, UnitCode={UnitCode}, Factor={Factor}, FromMethodNameSufix={FromMethodNameSufix}";
        }

        /// <summary>
        ///     static field name that holds unit name
        /// </summary>
        public string FieldName { get; }

        public string UnitCode { get; }

        public decimal Factor { get; }

        public string FromMethodNameSufix { get; }
    }
}