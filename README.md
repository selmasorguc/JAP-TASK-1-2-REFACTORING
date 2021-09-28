# JAP MovieApp BACKEND
## Junior Accelerator Program Task 1-2 Movie Application after review REFACTORING

Technologies used:
 - ASP .NET Core API

# What is this project about?

This task is continuing on the original JAP Task 1. The goal is to fix implementation and architectural mistakes made. 

The solution is structured in 3 main parts:

### CORE
 Consists of:
  - Entities
  - DTOs
  - Services
  - Interfaces
  
### INFRASTRUCTURE
 Consists of:
  - Everything related to the database - Migration and Dataseed
  - Automapper
  - Repositories
  
### WEB
Is the main startup project that consists of
  - Controllers
  - Configuration and Startup
  


# How to run the project?
 - Install Microsoft SQL Server Management Studio and make sure you have the right connection string.
 Change the connection string in the appsettings.Development.json
 
 ![Screenshot_6](https://user-images.githubusercontent.com/89447689/134517032-5b65e267-5ed7-4efd-82c9-a8acf7f28f4a.png)
 
 Data will be seeded when you run the solution. In case you're in VS Code use dotnet watch run or dotnet run CLI command. For Visual Studio, simply run the solution with IIS Express.
 
 # How to make API calls when authentication is needed?
 To use API buying tickets features ​/api​/tickets​/buy, login or registration is necessary to obtain the token.
 One user is initially seeded
 username: selma
 password: selma1
 
 ![image](https://user-images.githubusercontent.com/89447689/135115965-cac041c4-acad-44a9-aad1-5bd93318daf6.png)

After you make the login API call, copy the token and click on the Authorize button. Type bearer and paste the token. ![image](https://user-images.githubusercontent.com/89447689/135116272-0a166743-9072-4c6d-bafc-eed8ccd3b2d8.png)

![image](https://user-images.githubusercontent.com/89447689/135116200-a651e5cd-0f19-48ef-90c7-bbf7ac0ff736.png)


![image](https://user-images.githubusercontent.com/89447689/135116392-aed98203-367b-4f9e-b323-e063bd1f713c.png)


#API calls

GET /api/media 
GET /api/ratings/average/{movieId}
POST ​/api​/ratings​/add

Just for stored procedures testing
/api/reports/rated
​/api​/reports​/screened
/api/reports/sold

POST ​/api​/tickets​/buy

POST /api/users/register
POST /api/users/login
