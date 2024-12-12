using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solvace.TechCase.Domain.Entities.ActionPlan;
using Solvace.TechCase.Domain.Entities.ActionPlan.Dtos;
using Solvace.TechCase.Domain.Entities.ActionPlan.Enums;
using Solvace.TechCase.Domain.Inerface;
using Solvace.TechCase.Repository.Contexts;
using Solvace.TechCase.Services.Extensions;


namespace Solvace.TechCase.Services
{
    public class ActionPlanService : IPlan
    {
        private readonly DefaultContext _context;
        private readonly IMapper _mapper;



        public ActionPlanService()
        {
            var options = new DbContextOptionsBuilder<DefaultContext>()
            .UseSqlite("Data Source=database.db")
            .Options;

            _context = new DefaultContext(options);
        }

        public ActionPlanService(DefaultContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionPlanDto> Create(CreateActionPlan plan)
        {
            var newPlan = ActionPlan.Factories.Create(
               name: plan.Name,
               description: plan.Description,
               status: plan.StatusId
           );

            await _context.ActionPlans.AddAsync(newPlan);
            await _context.SaveChangesAsync();

            return newPlan.AsActionPlanDto();
        }

        public async Task Encerra(int id)
        {
            var result = _context.ActionPlanStatus.FirstOrDefault(p => p.Id == id);
            if (result != null && result.IsActive)
            {

                result.IsActive = false;

                _context.Entry(result).State = EntityState.Modified;

                _context.SaveChanges();
            }

        }

        public async Task<ActionPlanDto> Get(int id)
        {
            var result = _context.ActionPlans.FirstOrDefault(p => p.Id == id);

            return _mapper.Map<ActionPlanDto>(result);

        }

        public async Task<PaginatedListDto<ActionPlanDto>> GetAllPaged(int page, int pageSize)
        {
            var totalItems = await _context.ActionPlans.CountAsync();
            var actionPlans = await _context.ActionPlans
                .Skip((page - 1) * pageSize)
                .ToListAsync();

            var actionPlanDtos = _mapper.Map<List<ActionPlanDto>>(actionPlans);

            return new PaginatedListDto<ActionPlanDto>(actionPlanDtos, totalItems, page, pageSize);

        }

        public async Task<List<ActionPlanDto>> GetlIST()
        {
            var actionPlans = await _context.ActionPlans.ToListAsync();
            return _mapper.Map<List<ActionPlanDto>>(actionPlans);

        }

        public async Task Update(UpdateActionPlan updateActionPlan)
        {
            var result = _context.ActionPlans.FirstOrDefault(p => p.Id == updateActionPlan.ActionPlanStatusId);
            if (result != null)
            {

                result.Description = updateActionPlan.Description;

                _context.Entry(result).State = EntityState.Modified;

                _context.SaveChanges();
            }

        }
    }
}