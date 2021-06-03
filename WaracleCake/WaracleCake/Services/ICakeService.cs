using System.Collections.Generic;
using System.Threading.Tasks;
using WaracleCake.Models;

namespace WaracleCake.Services
{
    public interface ICakeService
    {
        bool CakeExists(int id);
        bool CakeExists(string name);
        Task<IEnumerable<Cake>> GetCakeAsync();
        Task<Cake> GetCakeAsync(int id);
        Task SaveCakeAsync(Cake cake);
        Task UpdateCakeAsync(Cake cake);
        Task DeleteCakeAsync(Cake cake);
    }
}