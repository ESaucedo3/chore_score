
namespace chore_score.Services;

public class ChoresService
{
  private readonly ChoresRepository _choresRepository;

  public ChoresService(ChoresRepository choresRepository)
  {
    _choresRepository = choresRepository;
  }

  internal Chore CreateChore(Chore choreData)
  {
    Chore createdChore = _choresRepository.CreateChore(choreData);
    return createdChore;
  }

  internal string DeleteChore(int choreId)
  {
    Chore chore = GetChoreById(choreId);
    _choresRepository.DeleteChore(choreId);
    return $"{chore.Name} successfully deleted!";
  }

  internal Chore GetChoreById(int choreId)
  {
    Chore chore = _choresRepository.GetChoreById(choreId);

    if (chore == null)
    {
      throw new Exception($"Invalid ID: {choreId}");
    }

    return chore;
  }

  internal List<Chore> GetChores()
  {
    List<Chore> chores = _choresRepository.GetChores();
    return chores;
  }

  internal Chore UpdateChore(int choreId, Chore choreData)
  {
    Chore chore = GetChoreById(choreId);
    return chore;
  }
}