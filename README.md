# Taller Code Challenge - .NET Core Web API

Welcome to the **Taller Code Challenge** repository! This project is a web API built using **.NET Core** and **C#**, designed to demonstrate best practices in API development, clean architecture, and problem-solving skills. Whether you're here to explore, contribute, or learn, we hope you find this repository useful and inspiring.

## About the Problem-Solving

The task consists to modernize a classic ASP application analizing the legacy code, indentifying vulnerabilities and implement a new code in ASP.NET Core.

## Potential Vulnerabilites in ASP Classic Code

- SQL Injection - this occurs when a attacker manipulates the input to execute arbitrary SQL Code, for example if the username parameter is not properly sanitized an attacker could input something like "DROP Table Users" to delete entire users table.
- Information disclosure - if the query is executed without proper error handling it migth expose sensitive information, return messages that reveal the structure of database making it easier for attacks.
- Connection String exposed - in the code we can see informations of database exploring the property CONN that execute a query in a ASP page


## About the Project

This repository contains a **.NET Core Web API** developed as part of the **Taller Code Challenge**. The API is designed to showcase:

- RESTful API design principles
- Clean architecture and separation of concerns
- Dependency injection and middleware usage
- Integration with databases or external services (if applicable)
- Unit and integration testing
- Web UI in Asp.NET Core 

## Getting Started

To get a local copy up and running, follow these steps.

### Prerequisites

Before you begin, ensure you have the following installed:

- [.NET Core SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/)

### Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/antunesbruno/taller-codechallenge.git
   ```

2. **Navigate to the project directory**

   ```bash
   cd taller-codechallenge
   ```

3. **Restore dependencies**

   ```bash
   dotnet restore
   ```

4. **Build the project**

   ```bash
   dotnet build
   ```

## Running the API

To run the API locally, use the following command:

```bash
dotnet run --project <ProjectName>
```

Replace `<ProjectName>` with the name of the main project file (e.g., `Taller.CodeChallenge.Api`).

The API will start and be accessible at `https://localhost:5001` or `http://localhost:5000` by default.

## API Endpoints

Below is a list of available endpoints and their functionality:

### Example Endpoints

- **GET /api/users**
  - Description: Retrieves a list of all users.
  - Example Request:
    ```bash
    curl -X GET https://localhost:5001/api/users
    ```
  - Example Response:
    ```json
    [
      {
        "id": 1,
        "name": "John Doe",
        "email": "john.doe@example.com"
      }
    ]
    ```

- **POST /api/users**
  - Description: Creates a new user.
  - Example Request:
    ```bash
    curl -X POST https://localhost:5001/api/users -H "Content-Type: application/json" -d '{"name": "Jane Doe", "email": "jane.doe@example.com"}'
    ```
  - Example Response:
    ```json
    {
      "id": 2,
      "name": "Jane Doe",
      "email": "jane.doe@example.com"
    }
    ```

For a complete list of endpoints and their documentation, refer to the **Swagger UI** by navigating to `https://localhost:5001/swagger` in your browser.

## Testing

This project includes unit and integration tests to ensure the reliability of the API. To run the tests, use the following command:

```bash
dotnet test
```

## Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

Distributed under the MIT License. See `LICENSE` for more information.

## Contact

Bruno Antunes - [GitHub Profile](https://github.com/antunesbruno)

Project Link: [https://github.com/antunesbruno/taller-codechallenge](https://github.com/antunesbruno/taller-codechallenge)

