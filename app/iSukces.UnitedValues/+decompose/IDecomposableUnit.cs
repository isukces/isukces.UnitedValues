using System.Collections.Generic;

namespace iSukces.UnitedValues;

public interface IDecomposableUnit : IUnit
{
    IReadOnlyList<DecomposableUnitItem> Decompose();
}