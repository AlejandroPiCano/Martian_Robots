using FluentValidation.Results;
using MartianRobots.API.Controllers;
using MartianRobots.Application.DTOs;
using MartianRobots.Application.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;

namespace InventoryManager.API.Tests
{
    /// <summary>
    /// The InventoryItemsControllerTests class.
    /// </summary>
    public class MartianRobotsInputControllerTests
    {
        private MartianRobotsInputController controller;
        private IMartianRobotsInputApplicationService mockService;
        const string inputStringCase1 = "{\r\n  \"id\": \"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\r\n  \"xSize\": 5,\r\n  \"ySize\": 3,\r\n  \"robots\": [\r\n    {\r\n      \"initialX\": 1,\r\n      \"initialY\": 1,\r\n      \"orientation\": \"E\",\r\n      \"instructions\": \"RFRFRFRF\"\r\n    }\r\n  ]\r\n}";
        const string inputStringCase2 = "{\r\n  \"id\": \"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\r\n  \"xSize\": 5,\r\n  \"ySize\": 3,\r\n  \"robots\": [   \r\n\t {\r\n      \"initialX\": 3,\r\n      \"initialY\": 2,\r\n      \"orientation\": \"N\",\r\n      \"instructions\": \"FRRFLLFFRRFLL\"\r\n    }\r\n  ]\r\n}";
        const string inputStringCase3 = "{\r\n  \"id\": \"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\r\n  \"xSize\": 5,\r\n  \"ySize\": 3,\r\n  \"robots\": [    \r\n\t {\r\n      \"initialX\": 0,\r\n      \"initialY\": 3,\r\n      \"orientation\": \"W\",\r\n      \"instructions\": \"LLFFFRFLFL\"\r\n    }\r\n  ]\r\n}";

        [SetUp]
        public void Setup()
        {
            mockService = Mock.Of<IMartianRobotsInputApplicationService>();
            controller = new MartianRobotsInputController(mockService, Mock.Of<ILogger<MartianRobotsInputController>>());
        }

        [Test]
        [Description("This is a test for the get method returning ok response")]
        public async Task MartianRobotsInputController_Get_ReturnOk()
        {
            //Arrange
            MartianRobotsInputDTO output1 = JsonConvert.DeserializeObject<MartianRobotsInputDTO>(inputStringCase1);
            MartianRobotsInputDTO output2 = JsonConvert.DeserializeObject<MartianRobotsInputDTO>(inputStringCase2);
            MartianRobotsInputDTO output3 = JsonConvert.DeserializeObject<MartianRobotsInputDTO>(inputStringCase3);
            var output = new List<MartianRobotsInputDTO>() { output1, output2, output3 };

            Mock.Get(mockService).Setup(x => x.GetAllInputsAsync()).Returns(Task.Run(() => output));

            //Act
            var result = await controller.Get();

            //Assert
            Assert.AreEqual(result.Count(), 3);

            for (int i = 0; i < result.Count(); i++)
            {
                Assert.AreEqual(result[i].Id, output[i].Id);
            }
        }

        [Test]
        [Description("This is a test for the get method throwing an axception and null response")]
        public async Task MartianRobotsInputController_Get_ThrowingException()
        {
            //Arrange
            Mock.Get(mockService).Setup(x => x.GetAllInputsAsync()).Throws(new System.Exception());

            //Act
            var result = await controller.Get();

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        [Description("This is a test for the get method returning ok response")]
        public async Task MartianRobotsInputController_GetId_ReturnOk()
        {
            //Arrange
            MartianRobotsInputDTO output1 = JsonConvert.DeserializeObject<MartianRobotsInputDTO>(inputStringCase1);

            Mock.Get(mockService).Setup(x => x.GetInputAsync(output1.Id)).Returns(Task.Run(() => output1));

            //Act
            var result = await controller.Get(output1.Id);

            //Assert
            Assert.AreEqual(result, output1);
        }

        [Test]
        [Description("This is a test for the get/id method throwing an axception and null response")]
        public async Task MartianRobotsInputController_GetId_ThrowingException()
        {
            //Arrange
            MartianRobotsInputDTO output1 = JsonConvert.DeserializeObject<MartianRobotsInputDTO>(inputStringCase1);

            Mock.Get(mockService).Setup(x => x.GetInputAsync(output1.Id)).Throws(new System.Exception());

            //Act
            var result = await controller.Get(output1.Id);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        [Description("This is a test for the Post method returning ok response")]
        public async Task MartianRobotsInputController_Post_ReturnOk()
        {
            //Arrange
            MartianRobotsInputDTO input1 = JsonConvert.DeserializeObject<MartianRobotsInputDTO>(inputStringCase1);
            var expectedResult = new ValidationResult();

            Mock.Get(mockService).Setup(x => x.CreateAsync(input1)).Returns(Task.Run(() => expectedResult));

            //Act
            var result = await controller.Post(input1);

            //Assert
            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        [Description("This is a test for the Post method returning ok response")]
        public async Task MartianRobotsInputController_Post_FailValidation_ReturnValidationError()
        {
            //Arrange
            MartianRobotsInputDTO input1 = JsonConvert.DeserializeObject<MartianRobotsInputDTO>(inputStringCase1);
            var expectedResult = new ValidationResult();
            string errorDescription = "Error Description";
            expectedResult.Errors.Add(new ValidationFailure(string.Empty, errorDescription));

            Mock.Get(mockService).Setup(x => x.CreateAsync(input1)).Returns(Task.Run(() => expectedResult));

            //Act
            var result = await controller.Post(input1);

            //Assert
            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        [Description("This is a test for the Post method throwing an axception and null response")]
        public async Task MartianRobotsInputController_Post_ThrowingException()
        {
            //Arrange
            MartianRobotsInputDTO input1 = JsonConvert.DeserializeObject<MartianRobotsInputDTO>(inputStringCase1);
            var expectedResult = new ValidationResult();
            string errorDescription = "Error Description";
            expectedResult.Errors.Add(new ValidationFailure(string.Empty, errorDescription));

            Mock.Get(mockService).Setup(x => x.CreateAsync(input1)).Throws(new System.Exception(errorDescription));

            //Act
            var result = await controller.Post(input1);

            //Assert
            Assert.AreEqual(result.Errors.First().ErrorMessage, expectedResult.Errors.First().ErrorMessage);
        }
    }
}