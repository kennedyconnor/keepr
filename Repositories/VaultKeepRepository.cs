using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetAll(int vaultId, string userId)
    {
      string query = @"SELECT * FROM vaultkeeps vk
      INNER JOIN keeps k on k.id = vk.keepId
      WHERE (vaultId = @vaultId AND vk.userId = @userId);
      
      ";
      IEnumerable<Keep> data = _db.Query<Keep>(query, new { vaultId, userId });
      if (data == null) throw new Exception("Invalid ID");
      return data;
    }

    public VaultKeep Create(VaultKeep data)
    {
      string query = @"
            INSERT INTO vaultkeeps (vaultId, keepId, userId)
            VALUES (@VaultId, @KeepId, @UserId);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(query, data);
      data.Id = id;
      return data;
    }

    public string Update(VaultKeep data)
    {
      string query = @"
      DELETE FROM vaultkeeps 
      WHERE userId = @UserId
       AND vaultId = @VaultId
       AND keepId = @KeepId;
           ";
      int changedRows = _db.Execute(query, new { data.VaultId, data.KeepId, data.UserId });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully Deleted Game";
    }
  }
}
