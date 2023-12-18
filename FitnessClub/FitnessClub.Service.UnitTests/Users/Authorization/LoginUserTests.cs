using System.Net;
using FitnessClub.BL.Auth.Entities;
using FitnessClub.DataAccess;
using FitnessClub.DataAccess.Entities;
using FluentAssertions;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace FitnessClub.Service.UnitTests.Users.Authorization;

public class LoginUserTests : FitnessClubServiceTestsBaseClass
{
    [Test]
    public async Task SuccessFullResult()
    {
        // prepare: create new user (login, password) => execute (try to login) => assert (Success : access token, refresh token)
        //prepare
        var user = new UserEntity()
        {
            Email = "test@test",
            UserName = "test@test",
            FirstName = "test",
            SecondName = "test",
            Patronymic = "test",
            ClubId = TestClubId
        };
        var password = "Password1@";

        using var scope = GetService<IServiceScopeFactory>().CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();
        var result = await userManager.CreateAsync(user, password);

        //execute
        var query = $"?email={user.UserName}&password={password}";
        var requestUri =
            FitnessClubApiEndpoints.AuthorizeUserEndpoint + query; // /auth/login?login=test@test&password=password
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        var client = TestHttpClient;
        var response = await client.SendAsync(request);

        //assert
        //response.StatusCode.Should().Be(HttpStatusCode.OK);
        var responseContentJson = await response.Content.ReadAsStringAsync();
        var content = JsonConvert.DeserializeObject<TokensResponse>(responseContentJson);

        content.Should().NotBeNull();
        content.AccessToken.Should().NotBeNull();
        content.RefreshToken.Should().NotBeNull();

        //check that access token is valid

        var requestToGetAllTrainers =
            new HttpRequestMessage(HttpMethod.Get, FitnessClubApiEndpoints.GetAllTrainersEndpoint);

        var clientWithToken = TestHttpClient;
        client.SetBearerToken(content.AccessToken);
        var getAllUsersResponse = await client.SendAsync(requestToGetAllTrainers);

        getAllUsersResponse.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public async Task BadRequestUserNotFoundResultTest()
    {
        // prepare: (imagine_login, imagine_password) => execute (try to login) => assert (BadRequest user not found)
        //prepare
        var login = "not_existing@mail.ru";
        using var scope = GetService<IServiceScopeFactory>().CreateScope();
        var userRepository = scope.ServiceProvider.GetRequiredService<IRepository<UserEntity>>();
        var user = userRepository.GetAll().FirstOrDefault(x => x.UserName.ToLower() == login.ToLower());
        if (user != null)
        {
            userRepository.Delete(user);
        }

        var password = "password";
        //100% confidence
        //execute
        var query = $"?email={login}&password={password}";
        var requestUri =
            FitnessClubApiEndpoints.AuthorizeUserEndpoint + query; // /auth/login?login=test@test&password=password
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        var response = await TestHttpClient.SendAsync(request);

        //assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Test]
    public async Task PasswordIsIncorrectResultTest()
    {
        // prepare: create new user (login, password) => execute (try to login with wrong password) => assert (BadRequest password is incorrect)

        //prepare
        var user = new UserEntity()
        {
            Email = "test@test",
            UserName = "test@test",
        };
        var password = "password";

        using var scope = GetService<IServiceScopeFactory>().CreateScope();
        var userManager = scope.ServiceProvider.GetService<UserManager<UserEntity>>();
        await userManager.CreateAsync(user, password);

        var incorrect_password = "kvhdbkvhbk";

        //execute
        var query = $"?email={user.UserName}&password={incorrect_password}";
        var requestUri =
            FitnessClubApiEndpoints.AuthorizeUserEndpoint + query; // /auth/login?login=test@test&password=kvhdbkvhbk
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        var client = TestHttpClient;
        var response = await client.SendAsync(request);

        //assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest); // with some message
    }

    [Test]
    [TestCase("", "")]
    [TestCase("qwe", "")]
    [TestCase("test@test", "")]
    [TestCase("", "password")]
    public async Task LoginOrPasswordAreInvalidResultTest(string login, string password)
    {
        //execute
        var query = $"?login={login}&password={password}";
        var requestUri =
            FitnessClubApiEndpoints.AuthorizeUserEndpoint + query; // /auth/login?login=test@test&password=kvhdbkvhbk
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        var client = TestHttpClient;
        var response = await client.SendAsync(request);

        //assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest); // with some message
    }


    // (login, password) => 
    // identification => то что пользователя определяет - login | email | phone | passport
    // authentication => то что подтвержает, что пользователь является тем кем он представляется - (login, password)
    // authorization => то что определяет, может пользователь получить доступ - access rights, permissions
    // access token => jwt (json web token) Header: Authorization: "Bearer jngzijdvnlifxnldzsmvzlkmjfnbjgkjnzdkLKMczsl;m lskmcl;skmv" => есть доступ
    // как получить access token? (login, password) => access token  === LogIn 

    // TestCase
    // prepare: (imagine_login, imagine_password) => execute (try to login) => assert (BadRequest user not found)
    // prepare: create new user (login, password) => execute (try to login) => assert (Success : access token, refresh token)
    // prepare: create new user (login, password) => execute (try to login with wrong password) => assert (BadRequest password is incorrect)
    // prepare: (wrong_login, wrong_password ("", ""), ("1", "1") according to validation => execute => assert (BadRequest according to input data)
}

// минус - тяжело делать, занимает много времени
// на своей машине минус - среда может влиять
// плюс гонять на тестовом стенде - на бою тестируем - максимально приближено к реальности
// через webApplicationFactory
//

//write test cases and tests for registration