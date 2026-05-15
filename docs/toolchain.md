# Visual Basic .NET Toolchain

- State: deterministic-first local validation complete
- Toolchain source: `built-in-dotnet10`

## Native commands
- `dotnet --version`
- `dotnet --list-sdks`
- `dotnet --list-runtimes`
- `python3 scripts/validate_scaffold.py`
- `dotnet build --configuration Release`
- `bash tests/test_cli.sh`
- `dotnet run --no-build --project vbnet-stakeholder.vbproj -- --list-values`

## Docker commands
- `docker build -t vbnet-stakeholder .`
- `docker run --rm vbnet-stakeholder --list-values`
- `docker run --rm vbnet-stakeholder --output-format json --focus-family platform_engineering --seed 123`

## Nix
- `/nix/var/nix/profiles/default/bin/nix --extra-experimental-features 'nix-command flakes' flake lock`
- `/nix/var/nix/profiles/default/bin/nix --extra-experimental-features 'nix-command flakes' flake show`

## Current limitation
- Full live-provider/runtime support is deferred. The deterministic runtime fails fast for provider flags.
