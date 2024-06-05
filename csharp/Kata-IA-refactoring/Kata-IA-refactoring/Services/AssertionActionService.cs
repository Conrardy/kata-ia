using Kata_IA_refactoring.Models;

namespace Kata_IA_refactoringTests;

public class AssertionActionService : IAssertionActionService
{
    private readonly ILogger<AssertionActionService> _logger;

    public AssertionActionService(ILogger<AssertionActionService> logger)
    {
        _logger = logger;
    }

    public AssertionActionResponse GetAssertionActionResponse(AssertionConsumerServiceRequest assertionConsumerServiceRequest, ClaimsInfos claimsInfos, string requestedEmail)
    {
        if (assertionConsumerServiceRequest.IsClaimsRequired && AnyRequiredClaimsAreNullOrEmpty(claimsInfos, requestedEmail))
        {
            return new AssertionActionResponse
            {
                Status = AssertionActionStatus.Error,
                Message = "The mandatory claims are not correctly configured in the identity provider"
            };
        }

        return new AssertionActionResponse
        {
            Status = AssertionActionStatus.Success
        };
    }

    //TODO: Refactor this method to remove duplication and improve readability to get close to natural language
    private bool AnyRequiredClaimsAreNullOrEmpty(ClaimsInfos claimsInfos, string requestedEmail)
    {
        var claims = new List<(string Name, string Value)>
        {
            (nameof(claimsInfos.Email), claimsInfos.Email),
            (nameof(claimsInfos.UserName), claimsInfos.UserName),
            (nameof(claimsInfos.FirstName), claimsInfos.FirstName),
            (nameof(claimsInfos.LastName), claimsInfos.LastName)
        };

        return claims
            .SelectClaimsNullOrEmpty()
            .LogWarning(_logger, requestedEmail)
            .Any();
    }
}

public static class ClaimsExtensions
{
    public static IEnumerable<(string Name, bool IsNullOrEmpty)> SelectClaimsNullOrEmpty(this IEnumerable<(string Name, string Value)> claims)
    {
        return claims
            .Where(claim => string.IsNullOrEmpty(claim.Value))
            .Select(claim => (claim.Name, true));
    }

    public static IEnumerable<(string Name, bool IsNullOrEmpty)> LogWarning(this IEnumerable<(string Name, bool IsNullOrEmpty)> claims, ILogger logger, string requestedEmail)
    {
        foreach (var claim in claims)
            logger.LogWarning($"The claim {claim.Name} is not correctly configured in the identity provider for this user {requestedEmail}");

        return claims;
    }
}