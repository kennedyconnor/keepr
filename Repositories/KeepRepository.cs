using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;
    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM keeps");
    }

    public Keep GetById(int id)
    {
      string query = "SELECT * FROM keeps WHERE id = @Id";
      Keep data = _db.QueryFirstOrDefault<Keep>(query, new { id });
      if (data == null) throw new Exception("Invalid ID");
      return data;
    }

    public IEnumerable<Keep> GetByUser(string userId)
    {
      string query = "SELECT * FROM keeps WHERE userId = @userId";
      IEnumerable<Keep> data = _db.Query<Keep>(query, new { userId });
      if (data == null) throw new Exception("Invalid ID");
      return data;
    }
    public Keep Create(Keep data)
    {
      string query = @"
            INSERT INTO keeps (name, description, img, isPrivate, userId)
            VALUES (@Name, @Description, @Img, @IsPrivate, @UserId);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(query, data);
      data.Id = id;
      return data;
    }

    public Keep Update(Keep data)
    {
      string query = @"
            UPDATE keeps 
            SET
            name = @Name,
            description = @Description,
            img = @Img,
            isPrivate = @IsPrivate,
            views = @Views,
            shares = @Shares,
            keeps = @Keeps,
            WHERE id = @Id ;
            SELECT * FROM keeps WHERE id = @Id ;
           ";
      return _db.QueryFirstOrDefault<Keep>(query, data);
    }


    public string Delete(int id)
    {
      string query = "DELETE FROM keeps WHERE id = @Id;";
      int changedRows = _db.Execute(query, new { id });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully Deleted Keep";
    }
  }
}