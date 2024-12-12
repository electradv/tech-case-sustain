using Solvace.TechCase.Domain.Entities.ActionPlan.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvace.TechCase.Domain.Inerface
{
    public interface IPlan
    {
        Task<ActionPlanDto> Create(CreateActionPlan createActionPlan);
        Task Update(UpdateActionPlan updateActionPlan);

        Task Encerra(int id);
        Task<ActionPlanDto> Get(int id);
        Task<List<ActionPlanDto>> GetlIST();
        Task<PaginatedListDto<ActionPlanDto>> GetAllPaged(int page, int pageSize);




    }
}
