using Carter.OpenApi;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Workout.API.Features.Exercise
{
    public class GetAllExercises: CarterModule
    {
        public GetAllExercises() : base(ExerciseConstants.ApiBase) { }
        
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app
                .MapGet("/", async (IMediator mediator) => await mediator.Send(new GetAllExercisesQuery()))
                .Produces<IEnumerable<GetExerciseResponse>>(StatusCodes.Status200OK)
                .IncludeInOpenApi();
        }

        public record GetAllExercisesQuery : IRequest<IEnumerable<GetExerciseResponse>>;

        public record GetExerciseResponse(string Name, string Description);

        public class GetAllExercisesQueryHandle
            : IRequestHandler<GetAllExercisesQuery, IEnumerable<GetExerciseResponse>>
        {
            public Task<IEnumerable<GetExerciseResponse>> Handle(GetAllExercisesQuery request, CancellationToken cancellationToken)
            {
                var result = new[] { new GetExerciseResponse("Supino", "Isso é um supino") };
                return Task.FromResult(result.AsEnumerable());
            }
        }
    }
}
