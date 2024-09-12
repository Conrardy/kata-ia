# To-Do List for Adding a use case

## Step 0: Define the use case

## Step 1: Create Frontend

- Add a new page.
- Add the route with use case name
- commit

## Step 2: Backend Integration

- In `app.js`, map the needed data from the backend endpoint. (do not forget that all response is wrapped in a `data` key)
- Add an endpoint that returns a fake DTO model <name-of-use-case>DTO.
- Add HTTP tests to test the endpoint.
- commit

## Step 3: Develop Frontend

- Bind the data to the frontend using fake DTO model.
- Update the dto model if needed and repeat step 2.
- commit

## Step 4: Replace Fake DTO

- Remove the fake DTO model.
- Add a use case application injected in controller.
- Add tests (integraiton and unit) for the use case and unit tests for domain entities and value objects.
  - commit per integration and unit tests.
- Use a memory repository with fake data. (update configurationPersistence)
- Never pass a domain model to the controller we should always map it to a DTO. use case application returns a DTO.
- commit

## Step 5: Database Integration

- Add migration and seeding for memoryDb and PosgresSQL
- Start using an in-memory database.
- Add the repository.
