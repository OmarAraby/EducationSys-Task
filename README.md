
# 🎓 EducationSys API

A lightweight educational management system built using **.NET 9**, following **Clean Architecture** principles, and powered by **FastEndpoints** for fast, minimal API development.  
The system manages Students, Classes, Enrollments, and Marks — all stored **in-memory** for simplicity.

---

## 🧱 Project Architecture

  

```

EducationSys.API
├─ EducationSys.API
│  ├─ appsettings.Development.json
│  ├─ appsettings.json
│  ├─ EducationSys.API.csproj
│  ├─ EducationSys.API.http
│  ├─ EndPoints
│  │  ├─ Classes
│  │  │  ├─ AvgMarkClassEndPoint.cs
│  │  │  ├─ CreateClassEndpoint.cs
│  │  │  ├─ DeleteClassEndpoint.cs
│  │  │  └─ GetAllClassesEndPoint.cs
│  │  ├─ Enrollments
│  │  │  └─ CreateEnrollmentEndPoint.cs
│  │  ├─ Marks
│  │  │  └─ CreateRecordMarkEndPoint.cs
│  │  └─ Students
│  │     ├─ CreateStudentEndpoint.cs
│  │     ├─ DeleteStudentEndpoint.cs
│  │     ├─ GetAllStudentsEndpoint.cs
│  │     ├─ RequestsDtos
│  │     │  └─ UpdateStudentRequest.cs
│  │     └─ UpdateStudentEndpoint.cs
│  ├─ Program.cs
│  └─ Properties
│     └─ launchSettings.json
├─ EducationSys.API.sln
├─ EducationSys.Application
│  ├─ DependencyInjection
│  │  └─ ApplicationDependencyInjection.cs
│  ├─ DTOs
│  │  ├─ Class
│  │  │  ├─ ClassDto.cs
│  │  │  ├─ CreateClassDto.cs
│  │  │  └─ UpdateClassDto.cs
│  │  ├─ Enrollment
│  │  │  └─ CreateEnrollmentDto.cs
│  │  ├─ Mark
│  │  │  ├─ ClassAverageDto.cs
│  │  │  ├─ CreateMarkDto.cs
│  │  │  └─ MarkDto.cs
│  │  └─ Student
│  │     ├─ CreateStudentDto.cs
│  │     ├─ StudentDto.cs
│  │     └─ UpdateStudentDto.cs
│  ├─ EducationSys.Application.csproj
│  ├─ Helpers
│  │  ├─ GeneralResult
│  │  │  └─ ApiResponse.cs
│  │  └─ Pagination
│  │     ├─ Pagination.cs
│  │     └─ QueryParams.cs
│  ├─ Interfaces
│  │  ├─ IClassService.cs
│  │  ├─ IEnrollmentService.cs
│  │  ├─ IMarkService.cs
│  │  └─ IStudentService.cs
│  ├─ Services
│  │  ├─ ClassService.cs
│  │  ├─ EnrollmentService.cs
│  │  ├─ MarkService.cs
│  │  └─ StudentService.cs
│  └─ Validators
│     ├─ Class
│     │  ├─ CreateClassDtoValidator.cs
│     │  └─ UpdateClassDtoValidator.cs
│     ├─ Enrollment
│     │  └─ CreateEnrollmentDtoValidator.cs
│     ├─ Mark
│     │  └─ CreateMarkDtoValidator.cs
│     └─ Student
│        ├─ CreateStudentDtoValidator.cs
│        ├─ StudentDtoValidator.cs
│        └─ UpdateStudentDtoValidator.cs
├─ EducationSys.Domain
│  ├─ EducationSys.Domain.csproj
│  ├─ Entities
│  │  ├─ Class.cs
│  │  ├─ Enrollment.cs
│  │  ├─ Mark.cs
│  │  └─ Student.cs
│  └─ Interfaces
│     └─ Repositories
│        ├─ IClassRepository.cs
│        ├─ IEnrollmentRepository.cs
│        ├─ IMarkRepository.cs
│        └─ IStudentRepository.cs
└─ EducationSys.Infrastructure
   ├─ DependencyInjection
   │  └─ InfrastructureDependencyInjection.cs
   ├─ EducationSys.Infrastructure.csproj
   └─ Repositories
      └─ InMemory
         ├─ ClassRepository.cs
         ├─ EnrollmentRepository.cs
         ├─ MarkRepository.cs
         └─ StudentRepository.cs

  

```

### 🧠 Layers Description

| Layer | Responsibility |
|-------|----------------|
| **Domain** | Contains the core entities (`Student`, `Class`, `Enrollment`, `Mark`) and repository interfaces. |
| **Application** | Implements services, DTOs, pagination helpers, and FluentValidation validators. |
| **Infrastructure** | Provides in-memory repository implementations using `ConcurrentDictionary`. |
| **API** | Defines the FastEndpoints endpoints and configures DI, routing, and OpenAPI via Scalar UI. |

---

## ⚙️ Tech Stack

- **.NET 9**
- **FastEndpoints** (Minimal API framework)
- **FluentValidation**
- **Scalar.AspNetCore** (for API documentation)
- **C# 12**
- **In-Memory Repositories** (no external database)

---

## 🧩 Main Features

### 🧑‍🎓 Students
- Create, Update, Delete, Retrieve students.
- Pagination + search support.
- Validation with `FluentValidation`.

### 🏫 Classes
- Manage class information (Name, Teacher, Description).
- Retrieve paginated list.
- Calculate average marks per class.

### 🧾 Enrollments
- Enroll a student in a class (`POST /api/enrollments`).
- Validation:
  - Student and Class must exist.
  - Prevent duplicate enrollments.

### 🧮 Marks
- Record student marks (`POST /api/marks`).
- Ensure student is enrolled before recording marks.
- Prevent duplicate marks.
- Compute class average (`GET /api/classes/{classId}/average-marks`).

---

## 🧭 API Endpoints Overview

| Feature | Method | Endpoint | Description |
|----------|---------|-----------|--------------|
| **Students** | `GET` | `/api/students` | Get paginated list of students |
|  | `POST` | `/api/students` | Create new student |
|  | `PUT` | `/api/students/{id}` | Update student info |
|  | `DELETE` | `/api/students/{id}` | Delete student |
| **Classes** | `GET` | `/api/classes` | Get all classes |
|  | `POST` | `/api/classes` | Create new class |
|  | `DELETE` | `/api/classes/{id}` | Delete class |
|  | `GET` | `/api/classes/{id}/average-marks` | Calculate class average marks |
| **Enrollments** | `POST` | `/api/enrollments` | Enroll student in class |
| **Marks** | `POST` | `/api/marks` | Record marks for a student in class |

---

## 🧪 Example Request/Response

### ➕ Enroll Student
**POST** `/api/enrollments`
```json
{
  "studentId": 1,
  "classId": 3
}
````

✅ **Response:**

```json
{
  "statusCode": 200,
  "message": "Student enrolled successfully"
}
```

---

### 🧮 Record Mark

**POST** `/api/marks`

```json
{
  "studentId": 1,
  "classId": 3,
  "examMark": 85,
  "assignmentMark": 90
}
```

✅ **Response:**

```json
{
  "statusCode": 200,
  "message": "Mark recorded successfully."
}
```

---

### 📊 Get Class Average

**GET** `/api/classes/3/average-marks`

✅ **Response:**

```json
{
  "statusCode": 200,
  "message": "Average marks calculated successfully.",
  "data": {
    "classId": 3,
    "averageMark": 87.5,
    "studentsCount": 10
  }
}
```

---

## 🧰 Setup Instructions

1. Clone the repo:
    
    ```bash
    git clone https://github.com/OmarAraby/EducationSys.git
    cd EducationSys
    ```
    
2. Restore dependencies:
    
    ```bash
    dotnet restore
    ```
    
3. Build and run:
    
    ```bash
    dotnet run --project EducationSys.API
    ```
    
4. Open Scalar API Docs:
    
    ```
    https://localhost:5001/scalar/v1
    ```
    
    (or whatever port your app runs on)
    

---

## 🧩 Dependency Injection

Services and Repositories are registered in:

- `ApplicationDependencyInjection.cs`
    
- `InfrastructureDependencyInjection.cs`
    

Example:

```csharp
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
```

---

## 🧠 Validation

All input DTOs are validated using **FluentValidation**:

- `CreateStudentDtoValidator`
    
- `UpdateStudentDtoValidator`
    
- `CreateClassDtoValidator`
    
- `CreateEnrollmentDtoValidator`
    
- `CreateMarkDtoValidator`
    

Each validator enforces required fields, ranges, and logical validation.

---

## 🧹 Future Improvements

- Add persistence layer (SQL or MongoDB)
    
- Add authentication & authorization
    
- Add unit tests
    
- Add Swagger or API versioning
    

---

## 👨‍💻 Author

**Omar Mohamed Araby**  
💼 Software Engineer – .NET & Full Stack Developer  
