# Visual Basic .NET Tooling

## Commands
- `python3 scripts/validate_scaffold.py`
- `dotnet build --configuration Release`
- `bash tests/test_cli.sh`
- `dotnet run --no-build --project vbnet-stakeholder.vbproj -- --list-values`
- `docker build -t vbnet-stakeholder .`
- `docker run --rm vbnet-stakeholder --list-values`

## Extended local checks
- Deterministic same-seed JSON diff for `platform_engineering`.
- Experimental-provider fail-fast smoke.
- .NET 10 build proof.

## Notes
- The Docker path is the reproducible Linux baseline.
- Native CI should still cover macOS, Linux, and Windows .NET semantics.
