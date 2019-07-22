using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;
    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Vault> GetAll()
    {
      return _db.Query<Vault>("SELECT * FROM vaults");
    }

    public Vault GetById(int id)
    {
      string query = "SELECT * FROM vaults WHERE id = @Id";
      Vault data = _db.QueryFirstOrDefault<Vault>(query, new { id });
      if (data == null) throw new Exception("Invalid ID");
      return data;
    }

    public IEnumerable<Vault> GetByUser(string userId)
    {
      string query = "SELECT * FROM vaults WHERE userId = @userId";
      IEnumerable<Vault> data = _db.Query<Vault>(query, new { userId });
      if (data == null) throw new Exception("Invalid ID");
      return data;
    }
    public Vault Create(Vault data)
    {
      string query = @"
            INSERT INTO vaults (name, description, userId)
            VALUES (@Name, @Description, @UserId);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(query, data);
      data.Id = id;
      return data;
    }

    public Vault Update(Vault data)
    {
      string query = @"
            UPDATE vaults 
            SET
            name = @Name,
            description = @Description,
            WHERE id = @Id ;
            SELECT * FROM vaults WHERE id = @Id ;
           ";
      return _db.QueryFirstOrDefault<Vault>(query, data);
    }


    public string Delete(int id)
    {
      string query = "DELETE FROM vaults WHERE id = @Id;";
      int changedRows = _db.Execute(query, new { id });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully Deleted Vault";
    }
  }
}