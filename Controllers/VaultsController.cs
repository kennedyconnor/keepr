using keepr.Repositories;
using keepr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class VaultsController : ControllerBase
  {
    private readonly VaultRepository _repo;
    public VaultsController(VaultRepository repo)
    {
      _repo = repo;
    }
    //GET api/vaults
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      try
      {
        return Ok(_repo.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // GET api/vaults/5
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      try
      {
        return Ok(_repo.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    //POST api/vaualts
    [HttpPost]
    public ActionResult<Vault> Post([FromBody] Vault data)
    {
      try
      {
        return Ok(_repo.Create(data));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    //PUT api/vaults/5
    [HttpPut("{id}")]
    public ActionResult<Vault> Put(int id, [FromBody] Vault data)
    {
      try
      {
        data.Id = id;
        return Ok(_repo.Update(data));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_repo.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}