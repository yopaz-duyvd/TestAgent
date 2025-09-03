# Coding Style Rules (.NET 8 / C# 12)

- Prefer C# 12 features when appropriate:
  - Primary constructors for immutable classes or value objects.
  - Collection expressions like `[..items]` or `[1, 2, ..moreItems]`.
  - `required` properties for mandatory init-only members.
- Use `var` when the type is clear from context; avoid it for complex generics or delegates.
- Favor expression-bodied members for simple methods or properties.
- Keep one class, interface, or record per file.
- Place interfaces in `Interfaces/`, `Abstractions/`, or `Contracts/` folders.
- Keep controllers thin:
  - No business logic inside controllers.
  - Delegate requests to the Application layer (e.g., via CQRS handlers).
  - For Minimal APIs, place route handlers in `Endpoints/`.
- Use file-scoped namespaces.
- Order members as: fields → constructors → public methods → protected methods → private methods.
- Comment only when business logic isn't obvious or has side effects; prefer self-explanatory code.
- Use clear naming: PascalCase for types/methods and camelCase for variables.
- Keep methods under 20 lines; avoid more than four parameters per method (use an object if necessary).
- Prevent infrastructure concerns from leaking into the Domain or Application layers.
