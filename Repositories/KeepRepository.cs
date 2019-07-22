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

    public Keep Create(Keep data)
    {
      string query = @"
            INSERT INTO teams (name, description, userId)
            VALUES (@Name, @Description, @UserId);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(query, data);
      data.Id = id;
      return data;
    }

    public Keep Update(Keep data)
    {
      string query = @"
            UPDATE teams 
            SET
            name = @Name,
            description = @Description,
            WHERE id = @Id ;
            SELECT * FROM teams WHERE id = @Id ;
           ";
      return _db.QueryFirstOrDefault<Keep>(query, data);
    }

    public string Delete(int id)
    {
      string query = "DELETE FROM keeps WHERE id = @Id;";
      int changedRows = _db.Execute(query, new { id });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully Deleted Team";
    }
  }
}