using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories.Dogs
{
    public class DogRepository: IDogRepository
    {
        private readonly RealDatabase _realDatabase;
        private readonly ILogger<DogRepository> _logger;

        public DogRepository(RealDatabase realDatabase, ILogger<DogRepository> logger)
        {
            _realDatabase = realDatabase;
            _logger = logger;
        }

        public async Task<List<Dog>> GetAllDogs()
        {
            try
            {
                List<Dog> allDogsFromDatabase = _realDatabase.Dogs.ToList();
                return await Task.FromResult(allDogsFromDatabase);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all dogs from the database");
                throw new Exception("An error occurred while getting all dogs from the databas", ex);
            }
        }

        public async Task<Dog> GetDogById(Guid dogId)
        {
            try
            {
                List<Dog> allDogsFromDatabase = _realDatabase.Dogs.ToList();

                Dog wantedDog = allDogsFromDatabase.FirstOrDefault(dog => dog.Id == dogId)!;

                return await Task.FromResult(wantedDog);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while getting a dog by Id {dogId} from the database");
                throw new Exception($"An error occurred while getting a dog by Id {dogId} from the databas", ex);
            }
        }
    }
}
