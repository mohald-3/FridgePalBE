using Application.Queries.Dogs.GetById;
using Infrastructure.Database;

namespace Test.DogTests.QueryTest
{
    [TestFixture]
    public class GetDogByIdTests
    {

        // JAG VILL TESTA RADERA DOG MEDIATR COMMAND

        // JAG BEHÖVER ID - ID DÅ MÅSTE VARA GUID, INTE EMPTY, INTE NULL
        // JAG BEHÖVER DÅ HITTA HUNDEN I DB OCH SE OM DEN VERKLIGEN EXISTERAR
        // I FALL DEN EXISTERAR - RADERA
        // ANNARS RETURNER CUSTOM EXCEPTION ELLER MEDDELANDE ELLER VIKTIGT INFORMATION TILL ANVÄNDARE !

        //[Test]
        //public Task When_Trying_To_GetDogById_And_IT_doesnt_exist_in_db_then_throw_custom_execption
        // TEST NAMN - SUCCESS
        // ARRANGE
        // HÄR BEHÖVER JAG INTRODUCERA ID
        // ACT
        // HÄR BEHÖVER JAG SKICKA IVÄG KOMMANDOT
        // ASSERT
        // HÄR JÄMFÖR ID från arrange med ID från result...


        //private GetDogByIdQueryHandler _handler;
        //private MockDatabase _mockDatabase;

        //[SetUp]
        //public void SetUp()
        //{
        //    // Initialize the handler and mock database before each test
        //    _mockDatabase = new MockDatabase();
        //    _handler = new GetDogByIdQueryHandler(_mockDatabase);
        //}

        //[Test]
        //public async Task Handle_ValidId_ReturnsCorrectDog()
        //{
        //    // Arrange
        //    var dogId = new Guid("12345678-1234-5678-1234-567812345678");

        //    var query = new GetDogByIdQuery(dogId);

        //    // Act
        //    var result = await _handler.Handle(query, CancellationToken.None);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.That(result.Id, Is.EqualTo(dogId));
        //}

        //[Test]
        //public async Task Handle_InvalidId_ReturnsNull()
        //{
        //    // Arrange
        //    var invalidDogId = Guid.NewGuid();

        //    var query = new GetDogByIdQuery(invalidDogId);

        //    // Act
        //    var result = await _handler.Handle(query, CancellationToken.None);

        //    // Assert
        //    Assert.IsNull(result);
        //}
    }
}
