using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Workout.API.Features.Exercise
{
    public class GetExerciseByName : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app
                .MapGet("api/exercise/{id:int}", async (IMediator mediator, int id) => await mediator.Send(new GetAllExerciseByIdQuery(id)))
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);
        }

        public record GetAllExerciseByIdQuery(int Id): IRequest<GetExerciseByIdResponse>;

        public record GetExerciseByIdResponse(string Name, string Description);

        public class GetExerciseByIdResponseHandler
            : IRequestHandler<GetAllExerciseByIdQuery, GetExerciseByIdResponse>
        {
            public Task<GetExerciseByIdResponse> Handle(GetAllExerciseByIdQuery request, CancellationToken cancellationToken)
            {
                var result = new GetExerciseByIdResponse(request.Id.ToString(), $"Isso é um {request.Id}");

                return Task.FromResult(result);
            }
        }
    }
}
