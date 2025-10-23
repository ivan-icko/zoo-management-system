# Zoo Management System

End-to-end Windows desktop solution for managing zoo animals, visitor packages, and registrations. The stack combines a TCP server with modular system operations, a WinForms client, shared domain models, and extensive automated testing.

## Table of Contents
- [Overview](#overview)
- [Key Features](#key-features)
- [Architecture](#architecture)
- [Solution Layout](#solution-layout)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Running the System](#running-the-system)
- [Database Setup](#database-setup)
- [Testing & Quality](#testing--quality)
- [Tooling](#tooling)
- [Notable Design Choices](#notable-design-choices)
- [Extensibility Ideas](#extensibility-ideas)

## Overview
The application models day-to-day zoo operations:
- employees authenticate with the server and operate through a WinForms client,
- the client issues binary-serialized commands over TCP,
- the server executes transactional system operations against a SQL Server database,
- responses flow back with rich feedback for the user interface.

Domain entities (animals, packages, visitors, registrations, and employees) live in a shared library so both server and client stay in sync. Unit-tested business rules protect data correctness before it ever reaches the database.

## Key Features
- CRUD management for animals, including validation and duplicate detection for species identifiers.
- Package builder that bundles animals into themed visitor experiences, tracks capacity, and exposes per-package visitor rosters.
- Visitor registration workflows linking people to packages with automatic availability checks.
- Real-time staff session tracking on the server to prevent duplicate logins.
- Optional WPF dashboard that surfaces XKCD comics to demonstrate reusable infrastructure for auxiliary tooling.
- Extensive unit tests covering domain validation and server system operations.

## Architecture
### Domain & Shared Contracts
- `ZooloskiVrt.Common.Domen` exposes serializable entities plus guard methods for input validation.
- `ZooloskiVrt.Common.Komunikacija` defines the TCP contract (`Zahtev`, `Odgovor`, `Operacija`) and the `CommunicationHelper` binary serializer.

### Server
- `ZooloskiVrt.Server.Main` is a WinForms host that starts/stops the TCP listener (`Server` and `ClientHandler`).
- `ZooloskiVrt.Server.AplikacionaLogika.Controller` orchestrates use cases by delegating to transactional system operation classes.
- `ZooloskiVrt.Server.SistemskeOperacije` implements the Template Method pattern: every operation extends `OpstaSistemskaOperacija`, opening a transaction, executing work, and committing or rolling back as needed.
- `ZooloskiVrt.Server.Repozitorujum` offers a generic repository on top of `Broker` (SQL Server LocalDB connection), keeping data access logic centralized.
- `ZooloskiVrt.Server.BrokerBazePodataka` encapsulates raw ADO.NET connection and transaction management.

### Client
- `ZooloskiVrt.Klijent.Forme` is a WinForms client that hosts module-specific user controls for animals, packages, and visitors.
- GUI controllers (for example `GUIController/Zivotinje/ZivotinjeKontroler.cs`) wire user events to communication calls and enforce client-side validation.
- `Komunikacija.Instance` maintains the socket, translating GUI requests into `Operacija` commands.

### Optional Utilities
- `WpfApp1` (also launched from the server shell) demonstrates reuse of the infrastructure to call external APIs—in this case loading XKCD comics with a simple WPF navigation shell.
- Domain projects ship with DocFX configuration for generating API-style documentation (`ZooloskiVrt.Common.Domen/docfx.json`).

## Solution Layout
```
ZooloskiVrt.sln
├── ZooloskiVrt.Common.Domen/            # Domain entities and guards
├── ZooloskiVrt.Common.Komunikacija/     # TCP request/response contracts
├── ZooloskiVrt.Server.Main/             # WinForms server host and TCP listener
├── ZooloskiVrt.Server.AplikacionaLogika/# Controller facade
├── ZooloskiVrt.Server.SistemskeOperacije/ # Transactional use-case classes
├── ZooloskiVrt.Server.Repozitorujum/    # Generic repository abstraction
├── ZooloskiVrt.Server.BrokerBazePodataka/# SQL Server connection broker
├── ZooloskiVrt.Klijent.Forme/           # WinForms client and GUI controllers
├── WpfApp1/                             # Optional XKCD viewer
├── ZooloskiVrt.Common.Domen.Tests/      # Domain-level xUnit specs
└── ZooVrt.Common.AplicationLogic.Tests/ # System operation unit tests
```

## Prerequisites
- Windows with Visual Studio 2019 or newer (supports .NET Framework 4.7.2 projects).
- SQL Server LocalDB (installs with recent Visual Studio editions) or a reachable SQL Server instance.
- .NET SDK (optional) if you prefer running `dotnet` CLI commands.

## Getting Started
1. **Clone** the repository.
2. **Restore NuGet packages** via Visual Studio (`Right click solution > Restore NuGet Packages`) or `nuget restore`.
3. **Open `ZooloskiVrt.sln`** in Visual Studio.
4. **Build** the solution; make sure the projects compile without errors.

## Running the System
1. **Prepare the database** (see [Database Setup](#database-setup)) and confirm sample data (employees, animals, packages) is available.
2. **Start the server**: set `ZooloskiVrt.Server.Main` as the startup project, press F5, then click **Pokreni** in the server form to open the TCP listener on `127.0.0.1:9999`.
3. (Optional) From the same form you can launch the XKCD WPF viewer to verify auxiliary tooling.
4. **Start the client**: run `ZooloskiVrt.Klijent.Forme`, sign in using credentials stored in the `Zaposleni` table, and navigate modules via the top menu (`Zivotinje`, `Paketi`, `Posetioci`).
5. **Shut down gracefully**: close the client, then click **Zaustavi** on the server UI to stop the listener and active sessions.

## Database Setup
- Default connection string lives in `ZooloskiVrt.Server.BrokerBazePodataka/Broker.cs` and targets `Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ZooloskiVrt;...`.
- If you need a different instance, adjust the connection string or move it into configuration before building.
- Required tables (based on domain entities) include: `Zivotinja`, `Paket`, `PaketZivotinja`, `Posetilac`, `Prijava`, `PosetilacPrijava`, `Zaposleni`. Ensure primary keys and foreign keys align with the domain properties.
- Seed initial data:
  - at least one `Zaposleni` with valid `KorisnickoIme` and `Sifra` so you can log into the client,
  - sample animals and packages so the UI modules can demonstrate CRUD flows.

## Testing & Quality
- Domain validation and repository interactions are covered with xUnit:
  - Run via Visual Studio Test Explorer, or execute `dotnet test ZooloskiVrt.sln` from the solution root.
  - `ZooloskiVrt.Common.Domen.Tests` ensures guard clauses throw for invalid data before reaching persistence.
  - `ZooVrt.Common.AplicationLogic.Tests` focuses on system operations (save, update, delete, search) using mocks for repository dependencies.
- Code style and documentation:
  - DocFX configuration in the domain project can generate API reference docs (`docfx docfx.json`).
  - Domain classes include XML documentation comments that feed both DocFX and IntelliSense.

## Tooling
- **WinForms & WPF** for desktop client/server shells.
- **ADO.NET** via a reusable broker for SQL Server access.
- **Custom TCP binary protocol** (`CommunicationHelper`) for client-server messaging.
- **xUnit + Moq + Autofac** for unit testing.
- **DocFX** for optional documentation generation.
- **LocalDB** as the default development database.

## Notable Design Choices
- **Template Method Pattern**: every system operation encapsulates its transaction lifecycle (`OpstaSistemskaOperacija`), ensuring consistent commit/rollback handling.
- **Generic Repository**: SQL statements are constructed from domain-provided metadata (`NazivTabele`, `Kolone`, `Uslov`), which keeps persistence concerns out of business logic.
- **Shared Domain Library**: both client and server rely on identical serializable entities and enums, eliminating drift across the TCP boundary.
- **Session Management**: the server tracks logged-in employees to prevent duplicate sessions, improving operational safety.
- **Extensible Client Controllers**: GUI controllers separate WinForms plumbing from feature behaviour, making it easier to evolve or unit test individual screens.

## Extensibility Ideas
- Externalize configuration (connection strings, ports) into config files or environment variables instead of hard-coded values.
- Introduce integration tests that hit a real database using ephemeral data for greater coverage.
- Replace binary serialization with a message contract (for example JSON over SignalR) if cross-platform clients become a requirement.
- Surface the existing DocFX documentation via pipeline automation or GitHub Pages.
- Wrap the WPF utility into a broader administration dashboard, reusing the existing API helper pattern.
