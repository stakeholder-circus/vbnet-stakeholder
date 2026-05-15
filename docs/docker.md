# Visual Basic .NET Docker

## Build and test
- `docker build -t vbnet-stakeholder .`
- `docker run --rm vbnet-stakeholder --list-values`
- `docker run --rm vbnet-stakeholder --output-format json --focus-family code_analyzer --seed 123`

## Rationale
- The builder stage restores, builds, and runs contract tests before publishing the VB.NET runtime.
- Docker is the reproducible Linux gate; host checks still cover local .NET behavior.
