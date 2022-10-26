using MartianRobots.API.Controllers;
using MartianRobots.Application.DTOs;
using MartianRobots.Application.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;

namespace MartianRobots.API.Tests
{
    /// <summary>
    /// The InventoryItemsControllerTests class.
    /// </summary>
    public class MartianRobotsControllerTests
    {
        private MartianRobotsController controller;
        private IMartianRobotsApplicationService mockService;
        const string inputStringCase1 = "{\r\n  \"id\": \"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\r\n  \"xSize\": 5,\r\n  \"ySize\": 3,\r\n  \"robots\": [\r\n    {\r\n      \"initialX\": 1,\r\n      \"initialY\": 1,\r\n      \"orientation\": \"E\",\r\n      \"instructions\": \"RFRFRFRF\"\r\n    }\r\n  ]\r\n}";
        const string inputStringCase2 = "{\r\n  \"id\": \"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\r\n  \"xSize\": 5,\r\n  \"ySize\": 3,\r\n  \"robots\": [   \r\n\t {\r\n      \"initialX\": 3,\r\n      \"initialY\": 2,\r\n      \"orientation\": \"N\",\r\n      \"instructions\": \"FRRFLLFFRRFLL\"\r\n    }\r\n  ]\r\n}";
        const string inputStringCase3 = "{\r\n  \"id\": \"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\r\n  \"xSize\": 5,\r\n  \"ySize\": 3,\r\n  \"robots\": [    \r\n\t {\r\n      \"initialX\": 0,\r\n      \"initialY\": 3,\r\n      \"orientation\": \"W\",\r\n      \"instructions\": \"LLFFFRFLFL\"\r\n    }\r\n  ]\r\n}";
        const string inputStringAllCases = "{\r\n  \"id\": \"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\r\n  \"xSize\": 5,\r\n  \"ySize\": 3,\r\n  \"robots\": [\r\n    {\r\n      \"initialX\": 1,\r\n      \"initialY\": 1,\r\n      \"orientation\": \"E\",\r\n      \"instructions\": \"RFRFRFRF\"\r\n    },\r\n\t {\r\n      \"initialX\": 3,\r\n      \"initialY\": 2,\r\n      \"orientation\": \"N\",\r\n      \"instructions\": \"FRRFLLFFRRFLL\"\r\n    },\r\n\t {\r\n      \"initialX\": 0,\r\n      \"initialY\": 3,\r\n      \"orientation\": \"W\",\r\n      \"instructions\": \"LLFFFRFLFL\"\r\n    }\r\n  ]\r\n}";

        [SetUp]
        public void Setup()
        {
            mockService = Mock.Of<IMartianRobotsApplicationService>();
            controller = new MartianRobotsController(mockService, Mock.Of<ILogger<MartianRobotsController>>());
        }

        [Test]
        [Description("This is a test for the post method returning ok response testing the case 1")]
        public void MartianRobotsController_Solve_Case1_ReturnOk()
        {
            //Arrange

            MartianRobotsInputDTO input = JsonConvert.DeserializeObject<MartianRobotsInputDTO>(inputStringCase1);

            MartianRobotsOutputDTO output = new MartianRobotsOutputDTO()
            {
                FinalX = 1,
                FinalY = 1,
                Orientation = 'E',
                IsLost = false
            };

            Mock.Get(mockService).Setup(x => x.Solve(input)).Returns(new List<MartianRobotsOutputDTO>() { output });

            //Act
            var result = controller.Post(input);

            //Assert            
            Assert.AreEqual(result.Count(), 1);

            Assert.AreEqual(result.First().ToString(), output.ToString());
        }

        [Test]
        [Description("This is a test for the post method returning ok response testing the case 2")]
        public void MartianRobotsController_Solve_Case2_ReturnOk()
        {
            //Arrange

            MartianRobotsInputDTO input = JsonConvert.DeserializeObject<MartianRobotsInputDTO>(inputStringCase2);

            MartianRobotsOutputDTO output = new MartianRobotsOutputDTO()
            {
                FinalX = 3,
                FinalY = 3,
                Orientation = 'N',
                IsLost = true
            };

            Mock.Get(mockService).Setup(x => x.Solve(input)).Returns(new List<MartianRobotsOutputDTO>() { output });

            //Act
            var result = controller.Post(input);

            //Assert            
            Assert.AreEqual(result.Count(), 1);

            Assert.AreEqual(result.First().ToString(), output.ToString());
        }

        [Test]
        [Description("This is a test for the post method returning ok response testing the case 3")]
        public void MartianRobotsController_Solve_Case3_ReturnOk()
        {
            //Arrange

            MartianRobotsInputDTO input = JsonConvert.DeserializeObject<MartianRobotsInputDTO>(inputStringCase3);

            MartianRobotsOutputDTO output = new MartianRobotsOutputDTO()
            {
                FinalX = 4,
                FinalY = 2,
                Orientation = 'N',
                IsLost = false
            };

            Mock.Get(mockService).Setup(x => x.Solve(input)).Returns(new List<MartianRobotsOutputDTO>() { output });

            //Act
            var result = controller.Post(input);

            //Assert            
            Assert.AreEqual(result.Count(), 1);

            Assert.AreEqual(result.First().ToString(), output.ToString());
        }

        [Test]
        [Description("This is a test for the get method returning ok response testing all cases")]
        public void MartianRobotsController_Solve_AllCases_ReturnOk()
        {
            //Arrange

            MartianRobotsInputDTO input = JsonConvert.DeserializeObject<MartianRobotsInputDTO>(inputStringAllCases);

            var output = new List<MartianRobotsOutputDTO>() {
                new MartianRobotsOutputDTO()
                {
                    FinalX = 3,
                    FinalY = 3,
                    Orientation = 'N',
                    IsLost = true
                },
                new MartianRobotsOutputDTO()
                {
                    FinalX = 4,
                    FinalY = 2,
                    Orientation = 'N',
                    IsLost = false
                },
                new MartianRobotsOutputDTO()
                {
                    FinalX = 4,
                    FinalY = 2,
                    Orientation = 'N',
                    IsLost = false
                }
            };

            Mock.Get(mockService).Setup(x => x.Solve(input)).Returns(output);

            //Act
            var result = controller.Post(input);

            //Assert            
            Assert.AreEqual(result.Count(), 3);

            for (int i = 0; i < result.Count(); i++)
            {
                Assert.AreEqual(result[i].ToString(), output[i].ToString());
            }
        }

        [Test]
        [Description("This is a test for the post method returning throwing an exception and returning an empty list")]
        public void MartianRobotsController_Solve_Case3_ThrowingException()
        {
            //Arrange

            MartianRobotsInputDTO input = JsonConvert.DeserializeObject<MartianRobotsInputDTO>(inputStringCase3);
                      
            Mock.Get(mockService).Setup(x => x.Solve(input)).Throws(new System.Exception());

            //Act
            var result = controller.Post(input);

            //Assert            
            Assert.AreEqual(result.Count(), 0);
        }
    }
}