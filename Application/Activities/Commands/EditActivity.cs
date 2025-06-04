using System;
using Domain;
using MediatR;
using Persistence;
using AutoMapper;
using System.Data.Common;

namespace Application.Activities.Commands;

public class EditActivity
{
  public class Command : IRequest
  {
    //public required string Id { get; set; }
    //public required string Description { get; set; }
    //public required DateTime Date { get; set; }
    //public required string Category { get; set; }
    //public required string City { get; set; }
    //public required string Venue { get; set; }
    //public required string Title { get; set; }
    
    public required Activity Activity { get; set; }
  }

  public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
  {
    public async Task Handle(Command request, CancellationToken cancellationToken)
    {
      var activity = await context.Activities
          .FindAsync([request.Activity.Id], cancellationToken)
          ?? throw new Exception("Activity not found");


      // Use AutoMapper to map the properties from request.Activity to activity
      mapper.Map(request.Activity, activity);
      /*       activity.Title = request.Activity.Title;
            activity.Description = request.Activity.Description;
            activity.Date = request.Activity.Date;
            activity.Category = request.Activity.Category;
            activity.City = request.Activity.City;
            activity.Venue = request.Activity.Venue; */

      await context.SaveChangesAsync(cancellationToken);
    }
  }

}
