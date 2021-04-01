using iSukces.UnitedValues;

namespace UnitGenerator
{
    internal class ProductUnitDefs
    {
        public static ProductUnit IsProduct(TypesGroup right)
        {
            foreach (var i in All.Items)
                if (i.UnitTypes.Value == right.Value)
                    return i;
            return null;
        }


        public static ProductUnitsCollection All
        {
            get
            {
                if (!(_allProductUnitses is null)) return _allProductUnitses;
                var q = Ext.GetStaticFieldsValues<ProductUnitDefs, ProductUnit>();
                _allProductUnitses = new ProductUnitsCollection(q);

                return _allProductUnitses;
            }
        }

        public static readonly ProductUnit Torque
            = ProductUnit.Make<Torque, Force, Length>();


        public static readonly ProductUnit MassDetlaKelvin
            = ProductUnit.Make<MassDetlaKelvin, Mass, DeltaKelvinTemperature>();

        private static ProductUnitsCollection _allProductUnitses;
        


    }
}