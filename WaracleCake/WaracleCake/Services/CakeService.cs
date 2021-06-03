using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaracleCake.Data;
using WaracleCake.Models;

namespace WaracleCake.Services
{
    public class CakeService : ICakeService
    {

        private readonly WaracleCakeContext _context;

        public CakeService(WaracleCakeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cake>> GetCakeAsync()
        {
            return await _context.Cake.ToListAsync();
        }

        public async Task<Cake> GetCakeAsync(int id)
        {
            return await _context.Cake.FindAsync(id);
        }

        public async Task SaveCakeAsync(Cake cake)
        {
            _context.Cake.Add(cake);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCakeAsync(Cake cake)
        {
            _context.Entry(cake).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCakeAsync(Cake cake)
        {
            _context.Cake.Remove(cake);
            await _context.SaveChangesAsync();
        }

        public bool CakeExists(int id)
        {
            return _context.Cake.Any(e => e.Id == id);
        }

        public bool CakeExists(string name)
        {
            return _context.Cake.Any(x => x.Name.ToUpper() == name.ToUpper());
        }

    }
}
