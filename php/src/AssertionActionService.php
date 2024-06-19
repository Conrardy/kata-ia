<?php

namespace App;

use Monolog\Logger;
use Monolog\Handler\StreamHandler;

class AssertionActionService implements IAssertionActionService
{
    private $logger;

    public function __construct()
    {
        $this->logger = new Logger('assertionLogger');
        $this->logger->pushHandler(new StreamHandler('path/to/your/logs.log', Logger::WARNING));
    }

    public function getAssertionActionResponse($assertionConsumerServiceRequest, $claimsInfos, $requestedEmail)
    {
        if ($assertionConsumerServiceRequest->isClaimsRequired && $this->hasNullOrEmptyMandatoryClaims($claimsInfos, $requestedEmail)) {
            return [
                'status' => 'Error',
                'message' => 'The mandatory claims are not correctly configured in the identity provider'
            ];
        }

        return [
            'status' => 'Success'
        ];
    }

    private function hasNullOrEmptyMandatoryClaims($claimsInfos, $requestedEmail)
    {
        $mandatoryClaims = [
            'email' => $claimsInfos->email,
            'userName' => $claimsInfos->userName,
            'firstName' => $claimsInfos->firstName,
            'lastName' => $claimsInfos->lastName,
        ];

        foreach ($mandatoryClaims as $claimName => $claimValue) {
            if (empty($claimValue)) {
                $this->logger->warning("The claim {$claimName} is not correctly configured in the identity provider for this user {$requestedEmail}");
                return true;
            }
        }

        return false;
    }
}
