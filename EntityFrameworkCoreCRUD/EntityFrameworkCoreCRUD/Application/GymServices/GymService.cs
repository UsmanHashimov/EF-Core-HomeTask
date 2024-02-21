using EntityFrameworkCoreCRUD.Infrastructure;
using EntityFrameworkCoreCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreCRUD.Application.GymServices
{
    public class GymService : IGymService
    {
        private readonly ApplicationDbContext _context;
        public GymService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateGymAsync(Gym model)
        {
            await _context.Gyms.AddAsync(model);
            await _context.SaveChangesAsync();

            return "Malumot Yaratildi";
        }

        public async Task<string> UpdateGymAsync(int id, Gym gym)
        {
            var gymToUpdate = await _context.Gyms.FindAsync(id);
            if (gymToUpdate == null)
            {
                return "Gym not found";
            }

            gymToUpdate.name = gym.name;
            gymToUpdate.description = gym.description;
            gymToUpdate.location = gym.location;
            gymToUpdate.rating = gym.rating;

            await _context.SaveChangesAsync();
            return "Malumot Yangilandi";
        }

        public async Task<string> DeleteGymAsync(int id)
        {
            var gymToDelete = await _context.Gyms.FindAsync(id);
            if (gymToDelete == null)
            {
                return "Gym not found";
            }

            _context.Gyms.Remove(gymToDelete);
            await _context.SaveChangesAsync();
            return "Malumot O'chirildi";
        }

        public async Task<List<Gym>> GetAllGymAsync()
        {
            return await _context.Gyms.ToListAsync();
        }

        public async Task<Gym> GetGymAsync(int id)
        {
            var gym = await _context.Gyms.FindAsync(id);
            return gym;
        }

    }
}
