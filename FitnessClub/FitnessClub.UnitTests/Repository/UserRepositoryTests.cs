using FitnessClub.DataAccess;
using FitnessClub.DataAccess.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace FitnessClub.UnitTests.Repository;

[TestFixture]
[Category("Integration")]
public class UserRepositoryTests : RepositoryTestsBaseClass
{
    [Test]
    public void GetAllUsersTest()
    {
        //prepare
        using var context = DbContextFactory.CreateDbContext();
        var club = new ClubEntity()
        {
            Title = "My club",
            ExternalId = Guid.NewGuid()
        };
        context.Clubs.Add(club);
        context.SaveChanges();

        var users = new UserEntity[]
        {
            new UserEntity()
            {
                Birthday = new DateTime(2000, 12, 1),
                ClubId = club.Id,
                FirstName = "Test1",
                SecondName = "Test12",
                Patronymic = "Test123",
                ExternalId = Guid.NewGuid()
            },
            new UserEntity()
            {
                Birthday = new DateTime(2001, 11, 2),
                ClubId = club.Id,
                FirstName = "Test2",
                SecondName = "Test22",
                Patronymic = "Test223",
                ExternalId = Guid.NewGuid(),
            },
        };
        context.Users.AddRange(users);
        context.SaveChanges();
        
        //execute
        var repository = new Repository<UserEntity>(DbContextFactory);
        var actualUsers = repository.GetAll();

        //assert        
        actualUsers.Should().BeEquivalentTo(users, options => options.Excluding(x => x.Club));
    }

    [Test]
    public void GetAllUsersTest_ByDaniil()
    {
        //prepare
        //создать коллекцию юзеров expected
        //положить в базу
        //execute
        //создаем репозиторий
        //вызываем метод getall - actual
        //assert
        //проверяем, что expected = actual
    }

    [Test]
    public void GetAllUsersWithFilterTest()
    {
        //prepare
        using var context = DbContextFactory.CreateDbContext();
        var club = new ClubEntity()
        {
            Title = "My club",
            ExternalId = Guid.NewGuid()
        };
        context.Clubs.Add(club);
        context.SaveChanges();

        var users = new UserEntity[]
        {
            new UserEntity()
            {
                Birthday = new DateTime(2000, 12, 1),
                ClubId = club.Id,
                FirstName = "Test1",
                SecondName = "Test12",
                Patronymic = "Test123",
                ExternalId = Guid.NewGuid()
            },
            new UserEntity()
            {
                Birthday = new DateTime(2001, 11, 2),
                ClubId = club.Id,
                FirstName = "Test2",
                SecondName = "Test22",
                Patronymic = "Test223",
                ExternalId = Guid.NewGuid(),
            },
        };
        context.Users.AddRange(users);
        context.SaveChanges();
        //execute

        var repository = new Repository<UserEntity>(DbContextFactory);
        var actualUsers = repository.GetAll(x => x.FirstName == "Test1").ToArray();

        //assert
        actualUsers.Should().BeEquivalentTo(users.Where(x => x.FirstName == "Test1"),
            options => options.Excluding(x => x.Club));
    }

    [Test]
    public void SaveNewUserTest()
    {
        //prepare
        using var context = DbContextFactory.CreateDbContext();
        var club = new ClubEntity()
        {
            Title = "My club",
            ExternalId = Guid.NewGuid()
        };
        context.Clubs.Add(club);
        context.SaveChanges();

        //execute

        var user = new UserEntity()
        {
            Birthday = new DateTime(2000, 12, 1),
            ClubId = club.Id,
            FirstName = "Test1",
            SecondName = "Test12",
            Patronymic = "Test123"            
        };
        var repository = new Repository<UserEntity>(DbContextFactory);
        repository.Save(user);

        //assert
        var actualUser = context.Users.SingleOrDefault();
        actualUser.Should().BeEquivalentTo(user, options => options.Excluding(x => x.Club)
            .Excluding(x => x.Id)
            .Excluding(x => x.ModificationTime)
            .Excluding(x => x.CreationTime)
            .Excluding(x => x.ExternalId));
        actualUser.Id.Should().NotBe(default);
        actualUser.ModificationTime.Should().NotBe(default);
        actualUser.CreationTime.Should().NotBe(default);
        actualUser.ExternalId.Should().NotBe(Guid.Empty);
    }

    public void SaveNewUserTest_ByAlexandro()
    {
        //prepare
        //база пуста
        //
        //execute
        //создаем пользователя в оперативной памяти user
        //repository.Save(user);
        //assert
        //проверить что в базе создался пользак, поля равны expected
        //проверить, что базовые поля заполнились
    }

    [Test]
    public void UpdateUserTest()
    {
        //prepare
        using var context = DbContextFactory.CreateDbContext();
        var club = new ClubEntity()
        {
            Title = "My club",
            ExternalId = Guid.NewGuid()
        };
        context.Clubs.Add(club);
        context.SaveChanges();

        var user = new UserEntity()
        {
            Birthday = new DateTime(2000, 12, 1),
            ClubId = club.Id,
            ExternalId = Guid.NewGuid(),
            FirstName = "Test1",
            SecondName = "Test12",
            Patronymic = "Test123"
        };
        context.Users.Add(user);
        context.SaveChanges();

        //execute

        user.FirstName = "new name1";
        user.SecondName = "new name2";
        user.Patronymic = "new name3";
        var repository = new Repository<UserEntity>(DbContextFactory);
        repository.Save(user);

        //assert
        var actualUser = context.Users.SingleOrDefault();
        actualUser.Should().BeEquivalentTo(user, options => options.Excluding(x => x.Club));
    }

    [Test]
    public void UpdateUserTest_ByBoris()
    {
        //prepare
        //добавим User1 в базу (поля заполнены)
        //
        //execute
        //внутри теста User1(меняем значения)
        //repository.Save(User1);
        //assert
        //actual пользователь = expected
    }


    [Test]
    public void DeleteUserTest()
    {
        //prepare
        using var context = DbContextFactory.CreateDbContext();
        var club = new ClubEntity()
        {
            Title = "My club",
            ExternalId = Guid.NewGuid()
        };
        context.Clubs.Add(club);
        context.SaveChanges();

        var user = new UserEntity()
        {
            Birthday = new DateTime(2000, 12, 1),
            ClubId = club.Id,
            ExternalId = Guid.NewGuid(),
            FirstName = "Test1",
            SecondName = "Test12",
            Patronymic = "Test123"
        };
        context.Users.Add(user);
        context.SaveChanges();

        //execute

        var repository = new Repository<UserEntity>(DbContextFactory);
        repository.Delete(user);

        //assert
        context.Users.Count().Should().Be(0);
    }

    public void DeleteUserTest_ByAnastasia()
    {
        //база пуста
        //prepare
        //добавляем пользователя user
        //execute
        //repository.Delete(user)
        //assert
        //такого пользователя в базе нет
    }

    public void GetByIdTest_PositiveCase_ByGleb()
    {
        //база пуста
        //prepare
        //создаем несколько пользователей
        //добавляем в базу их
        //execute
        //вызываем GetById(int id)
        //assert
        //проверяем, что actual user = expected

        //execute
        //GetById(not exist)
        
        //assert
        //вернулось null
    }

    [SetUp]
    public void SetUp()
    {
        CleanUp();
    }

    [TearDown]
    public void TearDown()
    {
        CleanUp();
    }

    public void CleanUp()
    {
        using (var context = DbContextFactory.CreateDbContext())
        {
            context.Users.RemoveRange(context.Users);
            context.Clubs.RemoveRange(context.Clubs);
            context.SaveChanges();
        }
    }
}