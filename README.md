> [!WARNING]
> This repository is AI-assisted and manually reviewed. It is currently a local-only deterministic rewrite in the next-20 autonomous sprint.

# vbnet-stakeholder

Visual Basic .NET deterministic `classic-six + modern-core` rewrite under stakeholder-circus.

## Status
- Implemented for the next-20 autonomous sprint.
- Local-only scaffold; no upstream tracking and no publication yet.
- Default branch remains `main`; active work happens on the repo-specific baseline branch.

## Role
- Deterministic full-parity target for the next-20 wave.
- First tranche target is implemented: `classic-six + modern-core` with grouped fallback for later families.
- Full live-provider/runtime support remains a required follow-on wave.

## Toolchain contract
- Toolchain source: `built-in-dotnet10`
- See [docs/toolchain.md](docs/toolchain.md) for exact prep commands.

## Current guardrail
- Missing behavior must fail fast and be recorded in `GAPS.md`.
- Deterministic CI remains provider-free.
- Standardize on .NET 10 or Docker; older host runtimes are not used.

## Documentation
- [STATUS.md](STATUS.md)
- [PARITY.md](PARITY.md)
- [GAPS.md](GAPS.md)
- [docs/remotes.md](docs/remotes.md)
- [docs/provenance.md](docs/provenance.md)
- [docs/toolchain.md](docs/toolchain.md)
- [docs/traceability/first-push-families.md](docs/traceability/first-push-families.md)
