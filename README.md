# ITPerformance.GenericDto

**ITPerformance.GenericDto** is a lightweight and flexible NuGet package that provides generic DTO classes and interfaces to simplify request and response models in .NET applications. It's ideal for clean API design, pagination, and standardized data transfer.

## ✨ Features

- `PagedResultRequestDto`: For paginated requests (e.g., page number and size)
- `LimitedResultRequestDto`: For requests with a maximum result count
- `PagedResultDto<T>`: Standardized response wrapper for paged data
- `IEntityDto<TKey>`: Interface for DTOs with a unique identifier

## 📦 Installation

Install via NuGet:

```bash
dotnet add package ITPerformance.GenericDto
```

Or using the Package Manager:
```bash
Install-Package ITPerformance.GenericDto
```

🚀 Usage Example
```csharp
public class Car : PagedResultRequestDto, IEntityDto<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Make { get; set; }
}

public class Boat : LimitedResultRequestDto, IEntityDto<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Make { get; set; }
}
```

Usage:
📁 API Controller
```csharp
[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarRepository _carRepository;

    public CarsController(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResultDto<Car>>> GetCars([FromQuery] PagedResultRequestDto input)
    {
        var result = await _carRepository.GetPagedCarsAsync(input);
        return Ok(result);
    }
}
```

🔄 Pagination Utilities
To streamline the implementation of paging logic, this package includes the PaginationHelper class and a set of extension methods under PaginationExtentions.

📌 PaginationHelper.ApplyPaging
PaginationHelper.ApplyPaging automatically applies either full paging (Skip + Take) or simple limiting (Take) based on the request type:

✅ Example Usage in Repository
```csharp
public async Task<PagedResultDto<Car>> GetPagedCarsAsync(PagedResultRequestDto inputDto)
{
    var query = _cars.AsQueryable(); // "cars" can be a database or whatever returns a List of a type

    // Apply paging using the helper
    var pagedQuery = PaginationHelper.ApplyPaging(query, inputDto);

    return new PagedResultDto<Car>
    {
        TotalCount = query.Count(),
        Items = pagedQuery.ToList()
    };
}
```

📄 Interfaces and Base Classes

| Name                      | Description                                                       |
| ------------------------- | ----------------------------------------------------------------- |
| `IEntityDto<TKey>`        | Marker interface for DTOs with an ID                              |
| `PagedResultRequestDto`   | Contains `PageNumber` and `PageSize` for paginated requests       |
| `LimitedResultRequestDto` | Contains `MaxResultCount` for limiting result count               |
| `PagedResultDto<T>`       | Contains `TotalCount` and `Items` for paginated response payloads |

🛠 Purpose
This package helps you standardize and streamline typical API patterns like pagination and entity identification in your .NET applications. Designed to be simple, consistent, and easy to extend.
