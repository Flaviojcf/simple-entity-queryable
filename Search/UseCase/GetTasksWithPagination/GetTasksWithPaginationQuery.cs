using MediatR;
using Search.Dto;
using Search.Enum;

namespace Search.UseCase.GetTasks
{
    public class GetTasksWithPaginationQuery : IRequest<IList<GetTaskResponse>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
