  # Visual Basic .NET Toolchain

  - State: scaffold-only next-20 prep
  - Toolchain source: `built-in-dotnet10`

  ## Planned commands after promotion
    - `dotnet --version`
- `dotnet --list-sdks`
- `dotnet --list-runtimes`

  ## Scaffold-time checks
  - `python3 scripts/validate_scaffold.py`
  - `/nix/var/nix/profiles/default/bin/nix --extra-experimental-features 'nix-command flakes' flake lock`

  ## Current limitation
  - Standardize on .NET 10 or Docker; older host runtimes are not available.
