namespace chore_score.Controllers;

// NOTE Data annotations
[ApiController]
[Route("api/chores")] // Route setup
public class ChoresController : ControllerBase
{
  private readonly ChoresService _choresService;

  public ChoresController(ChoresService choresService)
  {
    _choresService = choresService;
  }


  [HttpGet]
  public ActionResult<List<Chore>> GetChores()
  {
    try
    {
      List<Chore> chores = _choresService.GetChores();
      return Ok(chores);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{choreId}")]
  public ActionResult<Chore> GetChoreById(int choreId)
  {
    try
    {
      Chore chore = _choresService.GetChoreById(choreId);
      return Ok(chore);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<Chore> CreateChore([FromBody] Chore choreData)
  {
    try
    {
      Chore createdChore = _choresService.CreateChore(choreData);
      return Ok(createdChore);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{choreId}")]
  public ActionResult<string> DeleteChore(int choreId)
  {
    try
    {
      string deletedMsg = _choresService.DeleteChore(choreId);
      return Ok(deletedMsg);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{choreId}")]
  public ActionResult<Chore> UpdateChore(int choreId, [FromBody] Chore choreData)
  {
    try
    {
      Chore chore = _choresService.UpdateChore(choreId, choreData);
      return Ok(chore);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }
}