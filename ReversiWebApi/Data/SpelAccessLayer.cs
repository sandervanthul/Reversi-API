﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReversiWebApi.Models;
using ReversiWebApi.Repositories;

namespace ReversiWebApi.Data
{
    public class SpelAccessLayer : ISpelRepository
    {
        private ReversiContext _context;

        public SpelAccessLayer(ReversiContext context) // is injected in Startup.cs
        {
            _context = context;
        }

        public async Task AddSpel(Spel spel)
        {
            await _context.Spellen.AddAsync(spel);
            await _context.SaveChangesAsync();
        }

        public async Task<Spel> GetSpel(string spelToken) => await _context.Spellen.FirstOrDefaultAsync(s => s.Token == spelToken);

        public async Task<List<Spel>> GetSpellen() => await _context.Spellen.ToListAsync();

        public async Task<Spel> GetSpelMetSpelerToken(string spelerToken) =>
            await _context.Spellen.FirstOrDefaultAsync(s => s.Speler1Token == spelerToken || s.Speler2Token == spelerToken);

        public async Task Complete() => await _context.SaveChangesAsync();
    }
}