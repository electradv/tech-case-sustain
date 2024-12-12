using AutoMapper;
using Solvace.TechCase.Domain.Entities.ActionPlan;
using Solvace.TechCase.Domain.Entities.ActionPlan.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvace.TechCase.Services
{
    public class PlanProfile : Profile
    {
        public PlanProfile() 
        {
            CreateMap<ActionPlan, ActionPlanDto>();
        }
    }
}
