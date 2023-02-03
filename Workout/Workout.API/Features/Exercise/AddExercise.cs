using Carter.OpenApi;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Workout.API.Features.Exercise
{
    public class AddExercise : CarterModule
    {
        public AddExercise() : base(ExerciseConstants.ApiBase) { }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost<AddExerciseCommand>("/", async (IMediator mediator, AddExerciseCommand command) =>
            {
                await mediator.Send(command);

                return TypedResults.NoContent();
            })
                .Produces(StatusCodes.Status422UnprocessableEntity)
                .IncludeInOpenApi();
        }

        public record AddExerciseCommand(string Name, string Description) : IRequest;

        public class AddExerciseCommandValidation
            : AbstractValidator<AddExerciseCommand>
        {
            public AddExerciseCommandValidation()
            {
                this.RuleFor(x => x.Name).NotEmpty();
                this.RuleFor(x => x.Description).NotEmpty();
            }
        }

        public class AddExerciseCommandHandler : IRequestHandler<AddExerciseCommand>
        {
            private readonly ILogger<AddExercise> logger;

            public AddExerciseCommandHandler(ILogger<AddExercise> logger)
            {
                this.logger = logger;
            }

            public Task<Unit> Handle(AddExerciseCommand request, CancellationToken cancellationToken)
            {
                logger.LogInformation($"{request.Name} added!");

                return Unit.Task;
            }
        }
    }
}
