using Carter.OpenApi;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using Workout.API.Features.Exercise.SeedWork;

namespace Workout.API.Features.Exercise
{
    public class GetExerciseById : BaseModule
    {
        public GetExerciseById()
            : base(ExerciseConstants.ApiBase) { }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            base.AddRoutes(app);

            app
                .MapGet("{id:int}", async (IMediator mediator, int id) => await mediator.Send(new GetAllExerciseByIdQuery(id)))
                .Produces<GetExerciseResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .IncludeInOpenApi()
                .WithApiVersionSet(apiVersionSet);
        }

        public record GetAllExerciseByIdQuery(int Id) : IRequest<GetExerciseResponse>;

        public class GetExerciseByIdResponseHandler
            : IRequestHandler<GetAllExerciseByIdQuery, GetExerciseResponse>
        {
            public Task<GetExerciseResponse> Handle(GetAllExerciseByIdQuery request, CancellationToken cancellationToken)
            {
                var result = new GetExerciseResponse(request.Id.ToString(), $"ID is {request.Id}");

                return Task.FromResult(result);
            }
        }
    }
}
