using Kata_IA_refactoring.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;

namespace Kata_IA_refactoringTests.Services;

public class AssertionActionServiceTests
{
    private readonly Mock<ILogger<AssertionActionService>> _mockLogger;
    private readonly AssertionActionService _service;

    public AssertionActionServiceTests()
    {
        _mockLogger = new Mock<ILogger<AssertionActionService>>();
        _service = new AssertionActionService(_mockLogger.Object);
    }

    public static IEnumerable<object[]> TestCases =>
    new List<object[]>
    {
        new object[] { new TestCase { Email = "", UserName = "test", FirstName = "test", LastName = "test", IsClaimsRequired = true, ExpectedStatus = AssertionActionStatus.Error, ExpectedWarnings = 1 } }, // Email missing, claims required
        new object[] { new TestCase { Email = "test@test.fr", UserName = "", FirstName = "test", LastName = "test", IsClaimsRequired = true, ExpectedStatus = AssertionActionStatus.Error, ExpectedWarnings = 1 } }, // UserName missing, claims required
        new object[] { new TestCase { Email = "test@test.fr", UserName = "test", FirstName = "", LastName = "test", IsClaimsRequired = true, ExpectedStatus = AssertionActionStatus.Error, ExpectedWarnings = 1 } }, // FirstName missing, claims required
        new object[] { new TestCase { Email = "test@test.fr", UserName = "test", FirstName = "test", LastName = "", IsClaimsRequired = true, ExpectedStatus = AssertionActionStatus.Error, ExpectedWarnings = 1 } }, // LastName missing, claims required
        new object[] { new TestCase { Email = "", UserName = "", FirstName = "test", LastName = "test", IsClaimsRequired = true, ExpectedStatus = AssertionActionStatus.Error, ExpectedWarnings = 2 } }, // Email and UserName missing, claims required
        new object[] { new TestCase { Email = "test@test.fr", UserName = "test", FirstName = "test", LastName = "test", IsClaimsRequired = true, ExpectedStatus = AssertionActionStatus.Success, ExpectedWarnings = 0 } }, // All claims present, claims required
        new object[] { new TestCase { Email = "", UserName = "test", FirstName = "test", LastName = "test", IsClaimsRequired = false, ExpectedStatus = AssertionActionStatus.Success, ExpectedWarnings = 0 } }, // Email missing, claims not required
        new object[] { new TestCase { Email = "test@test.fr", UserName = "", FirstName = "test", LastName = "test", IsClaimsRequired = false, ExpectedStatus = AssertionActionStatus.Success, ExpectedWarnings = 0 } }, // UserName missing, claims not required
        new object[] { new TestCase { Email = "test@test.fr", UserName = "test", FirstName = "", LastName = "test", IsClaimsRequired = false, ExpectedStatus = AssertionActionStatus.Success, ExpectedWarnings = 0 } }, // FirstName missing, claims not required
        new object[] { new TestCase { Email = "test@test.fr", UserName = "test", FirstName = "test", LastName = "", IsClaimsRequired = false, ExpectedStatus = AssertionActionStatus.Success, ExpectedWarnings = 0 } }, // LastName missing, claims not required
        new object[] { new TestCase { Email = "", UserName = "", FirstName = "test", LastName = "test", IsClaimsRequired = false, ExpectedStatus = AssertionActionStatus.Success, ExpectedWarnings = 0 } } // Email and UserName missing, claims not required
    };

    [Theory]
    [MemberData(nameof(TestCases))]
    public void ValidateMandatoryClaims_WithVariousClaims(TestCase testCase)
    {
        var claimsInfos = SetupClaimsInfos(testCase.Email, testCase.UserName, testCase.FirstName, testCase.LastName);
        var request = new AssertionConsumerServiceRequest { IsClaimsRequired = testCase.IsClaimsRequired };

        var response = _service.GetAssertionActionResponse(request, claimsInfos, "test@test.fr");

        Assert.Equal(testCase.ExpectedStatus, response.Status);

        _mockLogger.Verify(
            x => x.Log(
                It.IsAny<LogLevel>(),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("is not correctly configured in the identity provider for this user test@test.fr")),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
            Times.Exactly(testCase.ExpectedWarnings));
    }

    private ClaimsInfos SetupClaimsInfos(string email, string userName, string firstName, string lastName)
    {
        return new ClaimsInfos
        {
            Email = email,
            UserName = userName,
            FirstName = firstName,
            LastName = lastName
        };
    }
}

public class TestCase
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsClaimsRequired { get; set; }
    public AssertionActionStatus ExpectedStatus { get; set; }
    public int ExpectedWarnings { get; set; }
}

public class AssertionActionServiceTestsOld
{
    [Fact]
    public void Instanciate_AssertionActionService()
    {
        _ = new AssertionActionService(NullLogger<AssertionActionService>.Instance);
    }

    [Fact]
    public void ValidAssertion_WithClaimsRequired()
    {
        var service = new AssertionActionService(NullLogger<AssertionActionService>.Instance);
        var request = new AssertionConsumerServiceRequest { IsClaimsRequired = true };
        var claimsInfos = new ClaimsInfos
        {
            Email = "test@test.fr",
            UserName = "test",
            FirstName = "test",
            LastName = "test"
        };

        var response = service.GetAssertionActionResponse(request, claimsInfos, "test@test.fr");

        Assert.Equal(AssertionActionStatus.Success, response.Status);
    }

    [Fact]
    public void InvalidAssertion_WithClaimsRequired()
    {
        var service = new AssertionActionService(NullLogger<AssertionActionService>.Instance);
        var request = new AssertionConsumerServiceRequest { IsClaimsRequired = true };
        var claimsInfos = new ClaimsInfos
        {
            Email = "",
            UserName = "",
            FirstName = "",
            LastName = ""
        };

        var response = service.GetAssertionActionResponse(request, claimsInfos, "test@test.fr");

        Assert.Equal(AssertionActionStatus.Error, response.Status);
    }

    [Fact]
    public void ValidAssertion_WithClaimsInfos_Empty_But_ClaimsNotRequired()
    {
        var service = new AssertionActionService(NullLogger<AssertionActionService>.Instance);
        var request = new AssertionConsumerServiceRequest { IsClaimsRequired = false };
        var claimsInfos = new ClaimsInfos
        {
            Email = "",
            UserName = "",
            FirstName = "",
            LastName = ""
        };

        var response = service.GetAssertionActionResponse(request, claimsInfos, "test@test.fr");

        Assert.Equal(AssertionActionStatus.Success, response.Status);
    }


}
