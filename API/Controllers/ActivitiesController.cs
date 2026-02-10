using Application.Activities.Commands;
using Application.Activities.DTOs;
using Application.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController: BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new GetActivityList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityDetail(string id)
        {
            var result = await Mediator.Send(new GetActivityDetails.Query { Id = id });

            return HandleResult(result);
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateActivity(CreateActivityDto activityDto)
        {
            var result = await Mediator.Send(new CreateActivity.Command { ActivityDto = activityDto });

            return HandleResult(result);
        }

        [HttpPut]
        public async Task<ActionResult> EditActivity([FromBody] EditActivityDto activity)
        {
            return HandleResult(await Mediator.Send(new EditActivity.Command { ActivityDto = activity  }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(string id)
        {
            return HandleResult(await Mediator.Send(new DeleteActivity.Command { Id = id }));
        }
    }
}
