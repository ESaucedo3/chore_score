


namespace chore_score.Repositories;

public class ChoresRepository
{
  private readonly IDbConnection _db;

  public ChoresRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Chore CreateChore(Chore choreData)
  {
    string sql = @"
    INSERT INTO
    chores (name, description)
    VALUES (@Name, @description);
    
    SELECT * FROM chores WHERE id = LAST_INSERT_ID();";

    Chore chore = _db.Query<Chore>(sql, choreData).FirstOrDefault();
    return chore;
  }

  internal void DeleteChore(int choreId)
  {
    string sql = "DELETE FROM chores WHERE id = @choreId LIMIT 1;";
    int rowsAffected = _db.Execute(sql, new { choreId });
    if (rowsAffected == 0)
    {
      throw new Exception("No chores were deleted, DELETE FAILED!");
    }
    else if (rowsAffected > 1)
    {
      throw new Exception("More than 1 chore was deleted, NOT GOOD!");
    }
  }

  internal Chore GetChoreById(int choreId)
  {
    string sql = "SELECT * FROM chores WHERE id = @choreId;";
    Chore chore = _db.Query<Chore>(sql, new { choreId }).FirstOrDefault();
    return chore;
  }

  internal List<Chore> GetChores()
  {
    string sql = "SELECT * FROM chores;";
    List<Chore> chores = _db.Query<Chore>(sql).ToList();
    return chores;
  }
}