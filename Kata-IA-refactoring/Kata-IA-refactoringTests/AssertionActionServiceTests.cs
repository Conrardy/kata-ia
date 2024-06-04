using Kata_IA_refactoring.Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kata_IA_refactoringTests;

public class AssertionActionServiceTests
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
