# kata-ia

contain project used to craft our skills using IADD

## Exercices

- Improve readability : Remove negation in conditional, rename method and refactor function
- Improve maintability : Add missing unit tests or rewrite test suit

## Specifications

- **Identity Provider (IdP)**: A system that creates, maintains, and manages identity information for principals while providing authentication services to relying applications within a federation or distributed network.

- **Service Provider (SP)**: An entity that relies on a trusted IdP for authentication and authorization in the single sign-on (SSO) process. The SP provides Web services.

- **Claims**: Pieces of information about a user that are packaged into a token issued by the IdP and are used by the SP for authentication and authorization.

- **Claims Validation**: When claims are required, the system checks that the mandatory claims (email, username, firstname, lastname) are present. If any of these claims are missing, an error is returned indicating that the mandatory claims are not correctly configured in the identity provider.
