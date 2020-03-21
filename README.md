# Clean Architecture Generator

CleanArchGen is a tool to generate a scaffolding .Net Core project based on the Clean Architecture style

[The Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) - *Uncle Bob*

Tired to run dotnet run command to scaffold projects? CleanArchGen will help you, see how in the Features section below.

## Features

    - Create solution file
    - Create src folder
    - Create Domain layer
    - Create Application layer
    - Create Infra layer
    - Create Api or Console layer
    - Add projects into solution
    - Reference projects
        - Application -> Domain
        - Infra -> Application
        - Infra -> Domain
        - Api or Console -> Application
        - Api or Console -> Domain
        - Api or Console -> Infra
    - Create tests folder
    - Create test pyramid folder
        - Create UnitTests project
        - Create IntegrationTests project
        - Create FunctionalTests project
        - Reference project into test projects
    - Create .gitignore file
    - Create README.md file
    - Build project

## Getting Started

TBD

### Prerequisites

.NET Core 3.1

### Installing

TBD

## Running the tests

```
TBD
```

## Deployment

Add additional notes about how to deploy this on a live system

## Built With

* [.NET Core](https://dotnet.microsoft.com/download)
* [Fluent Assertions](https://fluentassertions.com/)

## Versioning

TBD 

## Authors

* **Vinicius Pfeifer**

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

TBD