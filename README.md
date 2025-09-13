# Soft2-LargeSystemsDev-OLA3

## GitHub Link

[https://github.com/Peter537/Soft2-LargeSystemsDev-OLA3](https://github.com/Peter537/Soft2-LargeSystemsDev-OLA3)

## Group

- Oskar (Ossi-1337, cph-oo221)
- Peter (Peter537, cph-pa153)
- Yusuf (StylizedAce, cph-ya56)

## CI Pipeline

Vores CI-pipeline er i [.github/workflows/ci.yml](.github/workflows/ci.yml)

Vores pipeline gør dette:

- Lint + statisk analyse: StyleCop Analyzers (config i [CoreMoviePlayer/stylecop.json](CoreMoviePlayer/stylecop.json)) kører som en del af buildet.
- Build: `dotnet restore` + `dotnet build` for [CoreMoviePlayer/CoreMoviePlayer.csproj](CoreMoviePlayer/CoreMoviePlayer.csproj).
- Unit tests + coverage: xUnit-tests i [`CoreMoviePlayer.Tests.UnitTests`](CoreMoviePlayer.Tests/UnitTests.cs) køres med `dotnet test`. Coverage eksporteres til OpenCover XML og fejler pipelinen hvis under 80% line coverage eksisterer.
- SBOM: Der genereres en SBOM og uploades som artifact (bom.json).
- Artefakter: Build-output, testresultater, coverage og SBOM uploades som GitHub Actions artifacts.
- Docker: Der bygges et image ud fra [Dockerfile](Dockerfile).
  - På pull_request: Kode verificeres, men intet pushes.
  - På push til main: Image bliver oprettet og pushes til GitHub Container Registry som er `ghcr.io/peter537/soft2-largesystemsdev-ola3:(latest/<sha>)`.

Triggers:

- Pull Requests mod main: Hurtig feedback (build, tests, kvalitetstjek). Intet publiceres.
- Push til main: Samme checks + docker build og publicering til GHCR.

Artefakter du kan hente fra workflow-kørsler:
- CoreMoviePlayer (publicerede binærer fra `dotnet publish`) i `CoreMoviePlayer\bin\Release\net8.0\*`.
- Coverage og Coverage Report: `CoreMoviePlayer.Tests/coverage.opencover.xml` og `CoreMoviePlayer.Tests\TestResults\CoverageReport\index.html`
- SBOM: `bom.json`.
- Statisk analyse: `static-analysis-report.txt`

Branch protection
- Main er beskyttet med krav om grønne CI-checks og review før merge. PR'er kan ikke merges før alle checks passerer.

## Pull Request Demonstration
- PR med rød/grøn demonstration: [https://github.com/Peter537/Soft2-LargeSystemsDev-OLA3/pull/1](https://github.com/Peter537/Soft2-LargeSystemsDev-OLA3/pull/1)

I PR'en blev der med vilje introduceret en fejl, så CI fejlede (rød). Efter et fix blev alle checks grønne, og merge blev tilladt, som bevis på, at branch protection håndhæver kvaliteten.
