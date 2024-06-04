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
        if (assertionConsumerServiceRequest.IsClaimsRequired && !ValidateMandatoryClaims(claimsInfos, requestedEmail))
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

    private bool ValidateMandatoryClaims(ClaimsInfos claimsInfos, string requestedEmail)
    {
        bool claimsIsValid = true;

        if (string.IsNullOrEmpty(claimsInfos.Email))
        {
            _logger.LogWarning($"The claim {nameof(claimsInfos.Email)} is not correctly configured in the identity provider for this user {requestedEmail}");
            claimsIsValid = false;
        }

        if (string.IsNullOrEmpty(claimsInfos.UserName))
        {
            _logger.LogWarning($"The claim {nameof(claimsInfos.UserName)} is not correctly configured in the identity provider for this user {requestedEmail}");
            claimsIsValid = false;
        }

        if (string.IsNullOrEmpty(claimsInfos.FirstName))
        {
            _logger.LogWarning($"The claim {nameof(claimsInfos.FirstName)} is not correctly configured in the identity provider for this user {requestedEmail}");
            claimsIsValid = false;
        }

        if (string.IsNullOrEmpty(claimsInfos.LastName))
        {
            _logger.LogWarning($"The claim {nameof(claimsInfos.LastName)} is not correctly configured in the identity provider for this user {requestedEmail}");
            claimsIsValid = false;
        }

        return claimsIsValid;
    }
}