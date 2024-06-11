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
        if (assertionConsumerServiceRequest.IsClaimsRequired && AnyRequiredClaimsNullOrEmpty(claimsInfos, requestedEmail))
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

    private bool AnyRequiredClaimsNullOrEmpty(ClaimsInfos claimsInfos, string requestedEmail)
    {
        return claimsInfos
            .Required()
            .NullOrEmpty()
            .LogWarning(_logger, requestedEmail)
            .Any();
    }
}

public static class ClaimsExtensions
{
    public static IEnumerable<KeyValuePair<string, string>> Required(this ClaimsInfos claimsInfos)
    {
        return new Dictionary<string, string>
        {
            { nameof(claimsInfos.Email), claimsInfos.Email },
            { nameof(claimsInfos.UserName), claimsInfos.UserName },
            { nameof(claimsInfos.FirstName), claimsInfos.FirstName },
            { nameof(claimsInfos.LastName), claimsInfos.LastName }
        };
    }

    public static IEnumerable<KeyValuePair<string, string>> NullOrEmpty(this IEnumerable<KeyValuePair<string, string>> claims)
    {
        return claims.Where(claim => string.IsNullOrEmpty(claim.Value));
    }

    public static IEnumerable<KeyValuePair<string, string>> LogWarning(this IEnumerable<KeyValuePair<string, string>> claims, ILogger logger, string requestedEmail)
    {
        foreach (var claim in claims)
        {
            logger.LogWarning($"The claim {claim.Key} is not correctly configured in the identity provider for this user {requestedEmail}");
        }

        return claims;
    }
}