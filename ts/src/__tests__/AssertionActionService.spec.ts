import { AssertionActionService } from '../AssertionActionService';
import { AssertionConsumerServiceRequest, ClaimsInfos } from '../AssertionActionService';

describe('AssertionActionService', () => {
    let service: AssertionActionService;
    let mockLoggerWarn: jest.SpyInstance;

    beforeEach(() => {
        service = new AssertionActionService();
        mockLoggerWarn = jest.spyOn(service['logger'], 'warn');
    });

    afterEach(() => {
        // Restore the original implementation
        mockLoggerWarn.mockRestore();
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

        it('should log warnings for missing mandatory claims', () => {
            const claimsInfos: ClaimsInfos = {}; // Empty claims to trigger warnings
            const assertionConsumerServiceRequest: AssertionConsumerServiceRequest = {
                isClaimsRequired: true
            };
            const requestedEmail = 'test@example.com';
    
            service.getAssertionActionResponse(assertionConsumerServiceRequest, claimsInfos, requestedEmail);
    
            // Verify that logger.warn was called for each missing claim
            expect(mockLoggerWarn).toHaveBeenCalledWith(expect.stringContaining('email is not correctly configured'));
            expect(mockLoggerWarn).toHaveBeenCalledWith(expect.stringContaining('userName is not correctly configured'));
            expect(mockLoggerWarn).toHaveBeenCalledWith(expect.stringContaining('firstName is not correctly configured'));
            expect(mockLoggerWarn).toHaveBeenCalledWith(expect.stringContaining('lastName is not correctly configured'));
        });
    });
});
