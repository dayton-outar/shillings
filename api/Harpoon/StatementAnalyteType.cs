
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

    public class StatementAnalyteInputType : InputObjectType<StatementAnalyte>
    {
        protected override void Configure(IInputObjectTypeDescriptor<StatementAnalyte> descriptor)
        {            
            descriptor
                .Field(f => f.Analyte).Type<ListType<NonNullType<AssayEnumType>>>();
        }
    }
}