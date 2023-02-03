using Carter.OpenApi;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Workout.API.Features.Exercise
{
    public class GetExerciseByName : CarterModule
    {
        public GetExerciseByName()
            : base(ExerciseConstants.ApiBase) { }
        
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app
                .MapGet("{id:int}", async (IMediator mediator, int id) => await mediator.Send(new GetAllExerciseByIdQuery(id)))
                .Produces<GetExerciseByIdResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .IncludeInOpenApi();
        }

        public record GetAllExerciseByIdQuery(int Id) : IRequest<GetExerciseByIdResponse>;

        public record GetExerciseByIdResponse(string Name, string Description);

        public class GetExerciseByIdResponseHandler
            : IRequestHandler<GetAllExerciseByIdQuery, GetExerciseByIdResponse>
        {
            public Task<GetExerciseByIdResponse> Handle(GetAllExerciseByIdQuery request, CancellationToken cancellationToken)
            {
                var result = new GetExerciseByIdResponse(request.Id.ToString(), $"ID is {request.Id}");

                return Task.FromResult(result);
            }
        }
    }
}
