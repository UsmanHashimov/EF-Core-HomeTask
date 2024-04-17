using EntityFrameworkCoreCRUD.Models;

namespace EntityFrameworkCoreCRUD.Application.GymServices
{
    public interface IGymService
    {
        public Task<Gym> CreateGymAsync(GymDTO gym);
        public Task<Gym> UpdateGymAsync(int id, GymDTO gym);
        public Task<Gym> DeleteGymAsync(int id);
        public Task<List<Gym>> GetAllGymAsync();
        public Task<Gym> GetGymAsync(int id);
    }
}
