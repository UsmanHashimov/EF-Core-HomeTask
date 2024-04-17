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
        public async Task<Gym> CreateGymAsync(GymDTO model)
        {
            var gym = new Gym
            {
                name = model.name,
                description = model.description,
                location = model.location,
                rating = model.rating,
            };
            await _context.Gyms.AddAsync(gym);
            await _context.SaveChangesAsync();

            return gym;
        }

        public async Task<Gym> UpdateGymAsync(int id, GymDTO gym)
        {
            var gymToUpdate = await _context.Gyms.FindAsync(id);
            //if (gymToUpdate == null)
            //{
            //    return gym;
            //}

            gymToUpdate.name = gym.name;
            gymToUpdate.description = gym.description;
            gymToUpdate.location = gym.location;
            gymToUpdate.rating = gym.rating;


            await _context.SaveChangesAsync();
            return gymToUpdate;
        }

        public async Task<Gym> DeleteGymAsync(int id)
        {
            var gymToDelete = await _context.Gyms.FindAsync(id);
            if (gymToDelete == null)
            {
                return gymToDelete;
            }

            _context.Gyms.Remove(gymToDelete);
            await _context.SaveChangesAsync();
            return gymToDelete;
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
