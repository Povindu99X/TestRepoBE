# TestRepoBE

Minimal ASP.NET Core (.NET 10) API with in-memory mock data. Data resets on restart.

## Run

```bash
dotnet run
```

Listens on http://localhost:5219. CORS allows the frontend at http://localhost:5173.

## Endpoints

| Method | Route                          | Description                      |
|--------|--------------------------------|----------------------------------|
| GET    | `/api/health`                  | Health check                     |
| GET    | `/api/products?category=...`   | List products, optional filter   |
| GET    | `/api/products/{id}`           | Get a product                    |
| POST   | `/api/products`                | Create a product                 |
| DELETE | `/api/products/{id}`           | Delete a product                 |
| GET    | `/api/users`                   | List users                       |

Sample requests are in `TestRepoBE.http`.
