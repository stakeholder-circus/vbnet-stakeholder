#!/usr/bin/env bash
set -euo pipefail

DOTNET_BIN="${DOTNET_BIN:-dotnet run --configuration Release --no-build --project vbnet-stakeholder.vbproj --}"
TMPDIR="${TMPDIR:-/tmp}"

$DOTNET_BIN --list-values >"$TMPDIR/vbnet-list.json"
grep -q '"id": "code_analyzer"' "$TMPDIR/vbnet-list.json"
grep -q '"rendererKey": "modern-core.platform_engineering"' "$TMPDIR/vbnet-list.json"
grep -q '"registryId": "knowledge-retrieval"' "$TMPDIR/vbnet-list.json"

$DOTNET_BIN --output-format json --focus-family code_analyzer --seed 123 >"$TMPDIR/vbnet-code.json"
grep -q '"family": "code_analyzer"' "$TMPDIR/vbnet-code.json"
grep -q '"rendererKey": "classic-six.code_analyzer"' "$TMPDIR/vbnet-code.json"

$DOTNET_BIN --output-format json --focus-family platform-engineering --seed 456 >"$TMPDIR/vbnet-platform-a.json"
$DOTNET_BIN --output-format json --focus-family platform_engineering --seed 456 >"$TMPDIR/vbnet-platform-b.json"
diff -u "$TMPDIR/vbnet-platform-a.json" "$TMPDIR/vbnet-platform-b.json"

$DOTNET_BIN --output-format json --focus-family ai_inference_ops --seed 7 >"$TMPDIR/vbnet-fallback.json"
grep -q '"rendererKey": "fallback.ai_governance"' "$TMPDIR/vbnet-fallback.json"

if $DOTNET_BIN --experimental-provider local-demo >"$TMPDIR/vbnet-exp.out" 2>"$TMPDIR/vbnet-exp.err"; then
  echo "expected experimental-provider fail-fast" >&2
  exit 1
fi
grep -qi 'experimental provider' "$TMPDIR/vbnet-exp.err"
