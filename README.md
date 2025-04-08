# CQRSWithEvents
CQRS with domain events with no MediatR.

# CleanCQRS
A lightweight and clean implementation of CQRS in .NET Core using custom dispatcher logic.
This project demonstrates a domain-driven design approach that does not use external libraries like `MediatR`.

## Features
- Custom `Dispatcher` for handling:
  - Commands
  - Queries
  - Domain Events
- Separation of concern via layered architecture
- domain driven structure with Aggregates and Events
- Minimal and extensible. Perfect for learning or bootstrapping
- .NET Aspire for monitoring logs, traces, and metrics

# Upcoming updates
- EFCore implementation
- Custom API response
- Exception Handling
- Docker Containerization
- Fluent Migrations
- Broker Service (RabbitMQ)
- Unit Testing
