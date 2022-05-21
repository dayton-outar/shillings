
using HotChocolate;
using HotChocolate.Types;

using O8Query.Models;

namespace Harpoon
{
    public class StatementAnalyteType : ObjectType<StatementAnalyte>
    {
        protected override void Configure(IObjectTypeDescriptor<StatementAnalyte> descriptor)
        {
            descriptor
                .Field("analyteFlags")
                .Resolve(context => 
                {
                    //var q = context.
                    return "boom";
                });
        }
    }
}