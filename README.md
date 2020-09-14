# iEployee

It's educational project for learning purposes to obtain knowledge about
* .NET Core Web API
* DDD (Domain Driven Design)
* CQRS (Command Query Responsibility Segregation)
* Swagger
* Entity Framework Core
* Repository Pattern
* Angular CLI & RXJS
* Specification Pattern
* Angular Material
* Angular Http Interceptor
* Value Object Pattern

Basically it's simple crud project that imitates real commercial user architecture.

## Conclusion
What's next? What can i do better?

## Built With

* [Angular CLI](https://angular.io/docs) - The web framework used
* [.NET Core web API](https://docs.microsoft.com/pl-pl/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio) - Backend API
* [Angular Material](https://material.angular.io/guides) - Frontend styling and controls



## To-Do
- [ ] Add Toaster for messages to frontend
- [ ] Refactor/ clear code to be somehow maintainable - weekend
- [ ] Repository should not use DTO only entities and simple types
- [ ] Add repository methods example "GetEmployeesWithManager" etc.
- [ ] Managers business logic
- [ ] Frontend - **Http Interceptor** and "Resolver" to lazy load instead of ngInit()
- [ ] Write some unit tests Backend/Frontend - weekend
- [x] Fix manager crud API operations.
- [x] Modify position changing form 
- [x] Add comments and documentation
- [x] Add Forms Validation and Messages/Popups what eva
- [x] Make Angular Component for validation errors and messages
- [x] Change all forms to reactive forms
- [x] Add Repository pattern to database access
- [x] Fix Specification pattern issue on "Select in select" thingy = Workaround by just creating wheres
- [x] Implement business logic in Entities (for example Assigning Employee to Project)
- [x] Create ViewModel for each Entity that it could be used in CQRS and Web API
- [x] In Web part separate components for modules
- [x] Use Reactive Forms in Angular
- [x] Turn off complex primary key on job histories because cannot add multiple ...
- [x] Fix angular model mapping from json to interfaces/classes

## Authors

* **Krystian Franciszek Zakryś** 

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* This project was mainly created to find out about DDD, CQRS, Angular, .NET Core WebAPI. The task was given by my employeer as intro to working on commercial project.

