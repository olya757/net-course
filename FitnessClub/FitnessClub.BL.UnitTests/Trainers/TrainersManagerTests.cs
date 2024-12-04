using System.Linq.Expressions;
using FitnessClub.BL.Helpers;
using FitnessClub.BL.Trainers;
using FitnessClub.BL.Trainers.Entities;
using FitnessClub.BL.UnitTests.Mapper;
using FitnessClub.DataAccess;
using FitnessClub.DataAccess.Entities;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace FitnessClub.BL.UnitTests.Trainers;

public class TrainersManagerTests
{
    [Test]
    public void TestCreateTrainer_Success()
    {
        Mock<IRepository<TrainerEntity>> repositoryMock = new Mock<IRepository<TrainerEntity>>();
        repositoryMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<TrainerEntity, bool>>>()))
            .Returns(new List<TrainerEntity>().AsQueryable());
        var externalId = Guid.NewGuid();
        repositoryMock.Setup(x => x.Save(It.IsAny<TrainerEntity>()))
            .Returns((TrainerEntity x) =>
            {
                x.Id = 1;
                x.CreationTime = DateTime.Now;
                x.ModificationTime = DateTime.Now;
                x.ExternalId = externalId;
                return x;
            });

        var mapper = MapperHelper.Mapper;

        var trainerManager = new TrainersManager(repositoryMock.Object, mapper);

        var createTrainerModel = new CreateTrainerModel()
        {
            FirstName = "Bob",
            LastName = "Smith",
            Sex = 0,
            Position = "Junior Trainer",
            Birthday = new DateTime(1980, 1, 1)
        };

        var trainerModel = trainerManager.CreateTrainer(createTrainerModel);

        trainerModel.Should().NotBeNull();
        trainerModel.Id.Should().Be(externalId);
        trainerModel.Age.Should().Be(AgeHelper.GetAge(createTrainerModel.Birthday));
        trainerModel.Position.Should().Be(createTrainerModel.Position);
        trainerModel.Sex.Should().Be(createTrainerModel.Sex);
        trainerModel.FullName.Should().Be($"{createTrainerModel.FirstName} {createTrainerModel.LastName}");
    }
}