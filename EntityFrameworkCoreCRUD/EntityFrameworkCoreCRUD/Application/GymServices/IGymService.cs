using EntityFrameworkCoreCRUD.Models;

namespace EntityFrameworkCoreCRUD.Application.GymServices
{
    public interface IGymService
    {
        public Task<string> CreateGymAsync(Gym gym);
        public Task<string> UpdateGymAsync(int id, Gym gym);
        public Task<string> DeleteGymAsync(int id);
        public Task<List<Gym>> GetAllGymAsync();
        public Task<Gym> GetGymAsync(int id);
    }
}
