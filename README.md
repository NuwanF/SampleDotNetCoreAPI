# SampleDotNetCoreAPI
A Swimming Club Management System using Dot Net Core API

## Setup
* Download the SampleDotNetCoreAPI sollution which contains two projects
* Change database connection strings in SampleDotNetCoreAPI -> appsettings.json file and SampleDotNetCoreAPI_Test -> appsettings.test.json file
* Run below script in Package Manager Console to generate database with data
```bash
"update-database"
```
* Run ParkwaylabsExercise2 project and you will find a Swagger UI, where you will find the required endpoints
* Run test in Test Explorer and you will find the result of the test cases

In Test Explorer, some sample test cases are added against all three endpoints

## Implementation and Best Practices
* **Generic Repository Pattern** is used to minimize the repetition and have single base repository work for all type of data
* **Unit of Work** is used to maintain a single transaction that involves multiple CRUD operations
* **Code First** approach is used to generate database
* A **Three-tire Architecture** including Repository Layer, Business Logic Layer and Controller Layer is used to structure the project
* **Dependency Injection** is used to maintain loose coupling between each layer and inject low level classes in to high level classes
* **XUnit-Test** is added to maintain unit testing by including sample test cases

## Reference
https://www.c-sharpcorner.com/UploadFile/b1df45/unit-of-work-in-repository-pattern/
https://github.com/NuwanF/SampleDotNetCoreMVCWithEF

