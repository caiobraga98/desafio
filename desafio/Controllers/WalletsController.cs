using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using desafio.Data;
using desafio.Model;
using desafio.Repository;
using Microsoft.AspNetCore.Authorization;

namespace desafio.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController : ControllerBase
    {
        private readonly IWalletRepository _walletRepository;

        public WalletsController(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        // GET: api/Wallets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wallet>>> GetWallets()
        {
            var wallets = await _walletRepository.GetAll();
            return Ok(wallets); // Return Ok with the list
        }

        // GET: api/Wallets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wallet>> GetWallet(int id)
        {
            var wallet = await _walletRepository.GetWalletById(id);

            if (wallet == null)
            {
                return NotFound();
            }

            return Ok(wallet); // Return Ok with the wallet
        }

        // PUT: api/Wallets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWallet(int id, Wallet wallet)
        {
            if (id != wallet.Id)
            {
                return BadRequest();
            }

            try
            {
                await _walletRepository.Update(wallet);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                var existingWallet = await _walletRepository.GetWalletById(id);
                if (existingWallet == null)
                {
                    return NotFound();
                }
                else
                {
                    throw; // Re-throw the exception if the wallet exists
                }
            }
        }

        // POST: api/Wallets
        [HttpPost]
        public async Task<ActionResult<Wallet>> PostWallet(Wallet wallet)
        {
            await _walletRepository.CreateWallet(wallet);
            return CreatedAtAction("GetWallet", new { id = wallet.Id }, wallet);
        }

        // DELETE: api/Wallets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWallet(int id)
        {
            var wallet = await _walletRepository.GetWalletById(id);
            if (wallet == null)
            {
                return NotFound();
            }

            await _walletRepository.Remove(id);
            return NoContent();
        }
    }
}

