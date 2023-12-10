using System.Linq.Expressions;
using FitnessClub.BL.Trainers;
using FitnessClub.BL.UnitTests.Mapper;
using FitnessClub.DataAccess;
using FitnessClub.DataAccess.Entities;
using Moq;
using NUnit.Framework;

namespace FitnessClub.BL.UnitTests.Trainers;

[TestFixture]
public class TrainersProviderTests
{
    [Test]
    public void TestGetAllTrainers()
    {
        Expression expression = null;
        Mock<IRepository<TrainerEntity>> trainersRepository = new Mock<IRepository<TrainerEntity>>();
        trainersRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<TrainerEntity, bool>>>()))
            .Callback((Expression<Func<TrainerEntity, bool>> x) => { expression = x; });
        var trainersProvider = new TrainersProvider(trainersRepository.Object, MapperHelper.Mapper, 18);
        var trainers = trainersProvider.GetTrainers();

        trainersRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<TrainerEntity, bool>>>()), Times.Exactly(1));
    }
}