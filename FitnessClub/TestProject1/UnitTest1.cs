using FluentAssertions;
namespace TestProject1;

public class Tests
{
    [SetUp] //settings up каждый раз перед запуском теста
    public void Initialize()
    {
        //создаем "базу данных" заново 
        // очистка базы данных, очистка
    }
    
    [OneTimeSetUp] //settings up один раз перед запуском всех тестов В ЭТОМ КЛАССЕ
    public void OneTimeSetup()
    {
        // подключаем сервисы
        // настраиваем маппер 
        // базу инициализировать
        // создаем тестового пользователя
        // создаем WebAppFactory
        // создаем httpclient / other client
    }
    
    [TearDown] //очистка после запуска КАЖДОГО теста
    public void Cleanup()
    {
        // dispose
        // close connection
    }
    
    [OneTimeTearDown] //очистка один раз после ВСЕХ тестов В ЭТОМ КЛАССЕ
    public void OneTimeCleanup()
    {
        // dispose
        // close connection
    }

    [Test]
    public void Test1()
    {
        //настраиваем моки
        // создаем модели
        // выполняем команды
        // валидируем результат
        var array = new int[] { 1, 2, 3 };
        var array2 = new int[] { 1, 2, 3 };
        
        Assert.That(array, Is.EquivalentTo(array));

        array.Should().BeEquivalentTo(array2, condition => condition.WithStrictOrdering());
    }
}