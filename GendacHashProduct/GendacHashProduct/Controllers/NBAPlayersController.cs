using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GendacHashProduct.Data;
using GendacHashProduct.Models;

namespace GendacHashProduct.Controllers
{
    public class NBAPlayersController : Controller
    {
        private readonly NBAPlayerContext _context;

        public NBAPlayersController(NBAPlayerContext context)
        {
            _context = context;
        }

        /*
        // GET: NBAPlayers
        public async Task<IActionResult> Index()
        {
            return View(await _context.NBAPlayers.ToListAsync());
        }
        */
        public async Task<IActionResult> Index(string playerteam, string searchString)
        {
            IQueryable<string> teamQuery = from m in _context.NBAPlayers
                                           orderby m.TeamName
                                           select m.TeamName;

            var players = from m in _context.NBAPlayers
                          select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                players = players.Where(s => s.PlayerName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(playerteam))
            {
                players = players.Where(x => x.TeamName == playerteam);
            }

            var teamModelV = new TeamViewModel
            {
                AllTeams = new SelectList(await teamQuery.Distinct().ToListAsync()),
                AllNBAPlayers = await players.ToListAsync()
            };

            return View(teamModelV);
            //return View(await movies.ToListAsync());
        }

        // GET: NBAPlayers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nBAPlayer = await _context.NBAPlayers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nBAPlayer == null)
            {
                return NotFound();
            }

            return View(nBAPlayer);
        }

        // GET: NBAPlayers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NBAPlayers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlayerName,TeamName,PointsPerGame")] NBAPlayer nBAPlayer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nBAPlayer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nBAPlayer);
        }

        // GET: NBAPlayers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nBAPlayer = await _context.NBAPlayers.FindAsync(id);
            if (nBAPlayer == null)
            {
                return NotFound();
            }
            return View(nBAPlayer);
        }

        // POST: NBAPlayers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlayerName,TeamName,PointsPerGame")] NBAPlayer nBAPlayer)
        {
            if (id != nBAPlayer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nBAPlayer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NBAPlayerExists(nBAPlayer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nBAPlayer);
        }

        // GET: NBAPlayers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nBAPlayer = await _context.NBAPlayers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nBAPlayer == null)
            {
                return NotFound();
            }

            return View(nBAPlayer);
        }

        // POST: NBAPlayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nBAPlayer = await _context.NBAPlayers.FindAsync(id);
            _context.NBAPlayers.Remove(nBAPlayer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NBAPlayerExists(int id)
        {
            return _context.NBAPlayers.Any(e => e.Id == id);
        }
    }
}
