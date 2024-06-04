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
        // change rename to AnyRequiredClaimsAreNullOrEmpty and remove negation to make it more readable
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

    //Change: transform if to loop
    private bool AnyRequiredClaimsAreNullOrEmpty(ClaimsInfos claimsInfos, string requestedEmail)
    {
        var claimsRequired = new List<(string Name, bool IsNullOrEmpty)>
        {
            (nameof(claimsInfos.Email), string.IsNullOrEmpty(claimsInfos.Email)),
            (nameof(claimsInfos.UserName), string.IsNullOrEmpty(claimsInfos.UserName)),
            (nameof(claimsInfos.FirstName), string.IsNullOrEmpty(claimsInfos.FirstName)),
            (nameof(claimsInfos.LastName), string.IsNullOrEmpty(claimsInfos.LastName))
        };

        foreach (var claim in claimsRequired)
        {
            if (claim.IsNullOrEmpty)
            {
                _logger.LogWarning($"The claim {claim.Name} is not correctly configured in the identity provider for this user {requestedEmail}");
            }
        }

        return claimsRequired.Any(claim => claim.IsNullOrEmpty);
    }
}