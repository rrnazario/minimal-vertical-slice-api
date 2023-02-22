using Asp.Versioning.Builder;
using Asp.Versioning.Conventions;

public abstract class BaseModule : CarterModule
{
    protected ApiVersionSet apiVersionSet;
    
    public BaseModule(string basePath) : base(basePath)
    {
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        apiVersionSet = app.NewApiVersionSet()
                .HasApiVersion(1.0)
                .ReportApiVersions()
                .Build();
    }
}