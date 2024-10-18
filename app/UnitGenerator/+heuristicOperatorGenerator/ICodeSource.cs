using System.Collections.Generic;

namespace UnitGenerator;

public interface ICodeSource1
{
    string Code { get; }
        

}
interface ICodeSource:ICodeSource1
{
   
        
    bool DependsOnLeftArgument { get; }
}