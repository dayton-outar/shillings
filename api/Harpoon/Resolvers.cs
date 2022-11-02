namespace Harpoon;

using HotChocolate.Types;

using O8Query.Models;

using static O8Query.Models.StatementAnalyte;

public class StatementAnalyteType : ObjectType<StatementAnalyte>
{
    protected override void Configure(IObjectTypeDescriptor<StatementAnalyte> descriptor)
    {
        descriptor
            .Field(f => f.Analyte)
            .Resolve(context => context.Parent<StatementAnalyte>().AnalyteFlags());
    }
}

public class AssayEnumType : EnumType<Assay> { }

public class StatementAnalyteInputType : InputObjectType<StatementAnalyte>
{
    protected override void Configure(IInputObjectTypeDescriptor<StatementAnalyte> descriptor)
    {            
        descriptor
            .Field(f => f.Analyte).Type<ListType<NonNullType<AssayEnumType>>>();
    }
}