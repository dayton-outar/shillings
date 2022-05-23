
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
                .Field(f => f.Analyte)
                .Resolve(context => context.Parent<StatementAnalyte>().AnalyteFlags());
        }
    }
}