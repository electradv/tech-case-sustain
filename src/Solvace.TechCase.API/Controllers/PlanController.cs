
using Microsoft.AspNetCore.Mvc;
using Solvace.TechCase.Domain.Entities.ActionPlan;
using Solvace.TechCase.Domain.Entities.ActionPlan.Dtos;
using Solvace.TechCase.Domain.Entities.ActionPlan.Enums;
using Solvace.TechCase.Domain.Inerface;
using Solvace.TechCase.Services;


namespace Solvace.TechCase.API.Controllers;


#region QUESTION 1
// TYPE YOUR RESPONSE HERE: 
//O código fornecido quebra o Princípio da Inversão de Dependência (Dependency Inversion Principle - DIP).
//_actionPlanService = new ActionPlanService();
//Isso faz com que o PlanController dependa diretamente da implementação concreta do ActionPlanService.
//Acoplamento forte entre as classes
#endregion


[ApiController]
[Route("api/v1/[controller]")]
public class PlanController : ControllerBase
{
    private readonly IPlan _iplan;
    public PlanController(IPlan iplan)
    {
        this._iplan =  iplan;
    }

    [HttpPost("create")]
    public async Task<ActionResult<ActionPlanDto>> Create([FromBody] CreateActionPlan actionPlan)
    {
        //Poderiamos usar essa validação para uma mensagem customizada do enum desconhecido, mas usaremos a anotaçao na propriedade
        //if (!Enum.IsDefined(typeof(EActionPlanStatus), actionPlan.StatusId))
        //{
        //    return BadRequest($"O valor '{actionPlan.StatusId}' não é um valor válido para o Status.");
        //}
        
        var result = await _iplan.Create(actionPlan);
        return Created($"/api/actionplans/{result.Id}", result);
    }
    [HttpPut()]
    public async Task<ActionResult> Update(UpdateActionPlan updateActionPlan)
    {
        await _iplan.Update(updateActionPlan);
        return Ok(new { message = $"updateActionPlan com ID {updateActionPlan.ActionPlanStatusId} atualizado com sucesso." });
    }
    [HttpPut("encerra/{id}")]
    public async Task<IActionResult> Encerra(int id)
    {
        try
        {
            await _iplan.Encerra(id);
            return Ok(new { message = $"ActionPlanStatus com ID {id} encerrado com sucesso." });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno no servidor.", details = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ActionPlanDto>> GetActionPlan(int id)
    {
        var actionPlanDto = await _iplan.Get(id);

        if (actionPlanDto == null)
        {
            return NotFound(new { message = $"ActionPlan com ID {id} não encontrado." });
        }

        return Ok(actionPlanDto);
    }
    [HttpGet("list")]
    public async Task<ActionResult<List<ActionPlanDto>>> GetActionPlans()
    {
        var actionPlans = await _iplan.GetlIST();
        return Ok(actionPlans);
    }
    [HttpGet]
    public async Task<ActionResult<PaginatedListDto<ActionPlanDto>>> GetActionPlans(int page = 1, int pageSize = 10)
    {
        if (page <= 0 || pageSize <= 0)
        {
            return BadRequest("Parâmetros inválidos. O número da página e o tamanho da página devem ser positivos.");
        }

        var paginatedResult = await _iplan.GetAllPaged(page, pageSize);

        return Ok(paginatedResult);
    }

}
