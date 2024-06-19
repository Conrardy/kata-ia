import { createLogger, format, transports } from 'winston';
import { IAssertionActionService } from './IAssertionActionService';
export interface AssertionConsumerServiceRequest {
    isClaimsRequired: boolean;
}

export interface ClaimsInfos {
    email?: string | null;
    userName?: string | null;
    firstName?: string | null;
    lastName?: string | null;
    [key: string]: string | null | undefined;
}

enum AssertionActionStatus {
    Success = "Success",
    Error = "Error"
}

export interface AssertionActionResponse {
    status: AssertionActionStatus;
    message?: string;
}

export class AssertionActionService implements IAssertionActionService {
    private logger = createLogger({
        level: 'warn',
        format: format.combine(format.timestamp(), format.json()),
        transports: [
            new transports.File({ filename: 'error.log', level: 'warn' })
        ]
    });

    public getAssertionActionResponse(assertionConsumerServiceRequest: AssertionConsumerServiceRequest, claimsInfos: ClaimsInfos, requestedEmail: string): AssertionActionResponse {
        if (assertionConsumerServiceRequest.isClaimsRequired && this.isAnyMandatoryClaimMissing(claimsInfos, requestedEmail)) {
            return {
                status: AssertionActionStatus.Error,
                message: "The mandatory claims are not correctly configured in the identity provider"
            };
        }

        return {
            status: AssertionActionStatus.Success
        };
    }

    private isAnyMandatoryClaimMissing(claimsInfos: ClaimsInfos, requestedEmail: string): boolean {
        const mandatoryClaims = ['email', 'userName', 'firstName', 'lastName'];
        let isMissingClaim = false;

        for (const claim of mandatoryClaims) {
            if (!claimsInfos[claim]) {
                this.logger.warn(`The claim ${claim} is not correctly configured in the identity provider for this user ${requestedEmail}`);
                isMissingClaim = true;
            }
        }

        return isMissingClaim;
    }
}
