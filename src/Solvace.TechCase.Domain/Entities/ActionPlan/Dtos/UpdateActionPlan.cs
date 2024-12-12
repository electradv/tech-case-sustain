using System.ComponentModel.DataAnnotations;

namespace Solvace.TechCase.Domain.Entities.ActionPlan.Dtos
{
    public class UpdateActionPlan
    {
        /// <summary>
        /// A detailed description of the action plan, with a maximum length of 4000 characters.
        /// </summary>
        [MaxLength(4000)]
        [MinLength(3)]
        public string Description { get; set; }
        /// <summary>
        /// A detailed type of the action plan.
        /// </summary>
        public required long ActionPlanStatusId { get; set; }
    }
}