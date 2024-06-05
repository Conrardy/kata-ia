import { AssertionActionService } from '../AssertionActionService';
import { AssertionConsumerServiceRequest, ClaimsInfos } from '../AssertionActionService';

describe('AssertionActionService', () => {
    let service: AssertionActionService;

    beforeEach(() => {
        service = new AssertionActionService();
    });

    describe('getAssertionActionResponse', () => {
        it('should return success when claims are not required', () => {
            const request: AssertionConsumerServiceRequest = {
                isClaimsRequired: false,
            };
            const claimsInfos: ClaimsInfos = {};
            const requestedEmail = '';

            const response = service.getAssertionActionResponse(request, claimsInfos, requestedEmail);

            expect(response.status).toBe('Success');
        });

        it('should return error when claims are required but not configured correctly', () => {
            const request: AssertionConsumerServiceRequest = {
                isClaimsRequired: true,
            };
            const claimsInfos: ClaimsInfos = {};
            const requestedEmail = 'test@example.com';

            const response = service.getAssertionActionResponse(request, claimsInfos, requestedEmail);

            expect(response.status).toBe('Error');
            expect(response.message).toBe('The mandatory claims are not correctly configured in the identity provider');
        });

        it('should return success when claims are required and configured correctly', () => {
            const request: AssertionConsumerServiceRequest = {
                isClaimsRequired: true,
            };
            const claimsInfos: ClaimsInfos = {
                email: 'test@example.com',
                userName: 'test',
                firstName: 'test',
                lastName: 'test'
            };
            const requestedEmail = 'test@example.com';

            const response = service.getAssertionActionResponse(request, claimsInfos, requestedEmail);

            expect(response.status).toBe('Success');
        });
    });
});
