Imports System
Imports System.Globalization
Imports System.Linq
Imports System.Text

Module Program
    Private ReadOnly ClassicSix As String() = {
        "code_analyzer",
        "data_processing",
        "jargon",
        "metrics",
        "network_activity",
        "system_monitoring"
    }

    Private ReadOnly ModernCore As String() = {
        "agent_workflows",
        "platform_engineering",
        "observability_ai_runtime",
        "delivery_preview_ops",
        "supply_chain_security"
    }

    Private ReadOnly AiGovernance As String() = {
        "ai_inference_ops",
        "evaluation_and_guardrails",
        "knowledge_retrieval",
        "edge_client_runtime",
        "identity_and_trust",
        "aibom_provenance",
        "agent_boundary_security",
        "embedded_agentic_pipeline",
        "data_governance_compliance",
        "finops_capacity"
    }

    Private ReadOnly SecurityBlockchain As String() = {
        "blockchain_protocol_ops",
        "cross_chain_interop",
        "proof_and_sequencer_ops"
    }

    Private ReadOnly OverlayQuantum As String() = {
        "hybrid_runtime_ops",
        "capacity_cost_controller",
        "batch_execution_tuner",
        "compiler_maintainer",
        "interop_adapter_engineer",
        "preflight_capacity_planner",
        "simulator_performance_engineer"
    }

    Private ReadOnly HealthProtocol As String() = {
        "fhir_profile_generator",
        "smart_launch_oauth",
        "bulk_fhir_population_ops",
        "hl7v2_feed_ops",
        "clinical_workflow_events",
        "dicomweb_imaging_ops",
        "openehr_semantic_record_ops",
        "device_telemetry_clinical",
        "emr_vendor_adapter",
        "ocpp_chargepoint_ops",
        "ocpi_roaming_ops",
        "mcp_a2a_ops",
        "streaming_bus_ops",
        "service_mesh_rpc_ops"
    }

    Private Structure Metadata
        Public Sub New(renderer As String, tranche As String, contextKey As String, contextValue As String)
            Me.Renderer = renderer
            Me.Tranche = tranche
            Me.ContextKey = contextKey
            Me.ContextValue = contextValue
        End Sub

        Public Property Renderer As String
        Public Property Tranche As String
        Public Property ContextKey As String
        Public Property ContextValue As String
    End Structure

    Function Main(args As String()) As Integer
        Dim focusFamily As String = ""
        Dim seed As String = "default-seed"
        Dim outputFormat As String = "text"
        Dim listValues As Boolean = False

        Dim i As Integer = 0
        While i < args.Length
            Dim arg = args(i)
            If arg = "--list-values" Then
                listValues = True
            ElseIf arg = "--focus-family" Then
                i += 1
                If i >= args.Length Then
                    Return Fail("missing value for --focus-family")
                End If
                focusFamily = NormalizeFamily(args(i))
                If focusFamily = "" Then
                    Return Fail("invalid --focus-family: " & args(i))
                End If
            ElseIf arg = "--seed" Then
                i += 1
                If i >= args.Length Then
                    Return Fail("missing value for --seed")
                End If
                seed = args(i)
            ElseIf arg = "--output-format" Then
                i += 1
                If i >= args.Length Then
                    Return Fail("missing value for --output-format")
                End If
                outputFormat = args(i)
                If outputFormat <> "text" AndAlso outputFormat <> "json" Then
                    Return Fail("invalid --output-format: " & outputFormat)
                End If
            ElseIf arg = "--experimental-provider" Then
                i += 1
                If i >= args.Length Then
                    Return Fail("missing value for --experimental-provider")
                End If
                Return Fail("experimental provider '" & args(i) & "' is not enabled in the deterministic first tranche")
            ElseIf arg.StartsWith("--experimental-", StringComparison.Ordinal) Then
                Return Fail("experimental flags require --experimental-provider")
            Else
                Return Fail("unknown argument: " & arg)
            End If
            i += 1
        End While

        If listValues Then
            Console.Write(ListValuesJson())
            Return 0
        End If

        If focusFamily = "" Then
            Return Fail("focus-family is required and must be a known generator family")
        End If

        If outputFormat = "json" Then
            Console.Write(PayloadJson(focusFamily, seed, outputFormat))
        Else
            PrintTextPayload(focusFamily, seed)
        End If
        Return 0
    End Function

    Private Function AllFamilies() As String()
        Return ClassicSix.Concat(ModernCore).Concat(AiGovernance).Concat(SecurityBlockchain).Concat(OverlayQuantum).Concat(HealthProtocol).ToArray()
    End Function

    Private Function RegistryId(value As String) As String
        Return value.Replace("_", "-", StringComparison.Ordinal)
    End Function

    Private Function NormalizeFamily(value As String) As String
        Dim normalized = value.Trim().ToLowerInvariant().Replace("-", "_", StringComparison.Ordinal)
        If AllFamilies().Contains(normalized) Then
            Return normalized
        End If
        Return ""
    End Function

    Private Function FallbackGroup(family As String) As String
        If AiGovernance.Contains(family) Then
            Return "ai_governance"
        End If
        If SecurityBlockchain.Contains(family) Then
            Return "security_blockchain"
        End If
        If OverlayQuantum.Contains(family) Then
            Return "overlay_quantum"
        End If
        Return "health_protocol"
    End Function

    Private Function MetadataFor(family As String) As Metadata
        Select Case family
            Case "code_analyzer"
                Return New Metadata("classic-six.code_analyzer", "classic-six", "analysisFocus", "vbnet-contract-audit")
            Case "data_processing"
                Return New Metadata("classic-six.data_processing", "classic-six", "dataWindow", "linq-record-reconciliation")
            Case "jargon"
                Return New Metadata("classic-six.jargon", "classic-six", "languagePolicy", "dotnet-visual-basic-glossary")
            Case "metrics"
                Return New Metadata("classic-six.metrics", "classic-six", "signalBlend", "latency-error-throughput")
            Case "network_activity"
                Return New Metadata("classic-six.network_activity", "classic-six", "transportMix", "http-grpc-socket")
            Case "system_monitoring"
                Return New Metadata("classic-six.system_monitoring", "classic-six", "telemetryScope", "process-runtime-host")
            Case "agent_workflows"
                Return New Metadata("modern-core.agent_workflows", "modern-core", "coordinationMode", "workflow-command-handoff")
            Case "platform_engineering"
                Return New Metadata("modern-core.platform_engineering", "modern-core", "platformSurface", "dotnet-release-lane")
            Case "observability_ai_runtime"
                Return New Metadata("modern-core.observability_ai_runtime", "modern-core", "runtimeSignals", "logs-metrics-traces")
            Case "delivery_preview_ops"
                Return New Metadata("modern-core.delivery_preview_ops", "modern-core", "deliveryGuardrail", "preview-publish-checkpoints")
            Case "supply_chain_security"
                Return New Metadata("modern-core.supply_chain_security", "modern-core", "supplyChainPosture", "assembly-package-attestation")
            Case Else
                Dim group = FallbackGroup(family)
                Return New Metadata("fallback." & group, "fallback-" & group, "fallbackFamily", group)
        End Select
    End Function

    Private Function JsonString(value As String) As String
        Dim builder As New StringBuilder("""")
        For Each ch In value
            Select Case ch
                Case """"c
                    builder.Append("\""")
                Case "\"c
                    builder.Append("\\")
                Case ControlChars.Lf
                    builder.Append("\n")
                Case ControlChars.Cr
                    builder.Append("\r")
                Case ControlChars.Tab
                    builder.Append("\t")
                Case Else
                    builder.Append(ch)
            End Select
        Next
        builder.Append(""""c)
        Return builder.ToString()
    End Function

    Private Function JsonArray(values As IEnumerable(Of String)) As String
        Return "[" & String.Join(", ", values.Select(Function(v) JsonString(v))) & "]"
    End Function

    Private Function ListValuesJson() As String
        Dim builder As New StringBuilder()
        builder.AppendLine("{")
        builder.AppendLine("  ""outputFormats"": [""text"", ""json""],")
        builder.AppendLine("  ""flags"": [""list-values"", ""focus-family"", ""output-format"", ""seed"", ""experimental-provider""],")
        builder.AppendLine("  ""generatorFamilies"": [")
        Dim families = AllFamilies()
        For index = 0 To families.Length - 1
            Dim family = families(index)
            Dim meta = MetadataFor(family)
            builder.Append("    {""id"": ").Append(JsonString(family)).
                Append(", ""registryId"": ").Append(JsonString(RegistryId(family))).
                Append(", ""rendererKey"": ").Append(JsonString(meta.Renderer)).
                Append(", ""tranche"": ").Append(JsonString(meta.Tranche)).Append("}")
            If index < families.Length - 1 Then
                builder.Append(","c)
            End If
            builder.AppendLine()
        Next
        builder.AppendLine("  ],")
        builder.AppendLine("  ""classicSix"": " & JsonArray(ClassicSix.Select(Function(v) RegistryId(v))) & ",")
        builder.AppendLine("  ""modernCore"": " & JsonArray(ModernCore.Select(Function(v) RegistryId(v))) & ",")
        builder.AppendLine("  ""fallbackFamilies"": " & JsonArray(AiGovernance.Concat(SecurityBlockchain).Concat(OverlayQuantum).Concat(HealthProtocol).Select(Function(v) RegistryId(v))) & ",")
        builder.AppendLine("  ""implementationMode"": ""family-focus-deterministic""")
        builder.AppendLine("}")
        Return builder.ToString()
    End Function

    Private Function DeterministicHash(value As String) As UInteger
        Dim hash As UInteger = 2166136261UI
        For Each b In Encoding.UTF8.GetBytes(value)
            hash = hash Xor b
            hash = CUInt((CULng(hash) * 16777619UL) And &HFFFFFFFFUL)
        Next
        Return hash
    End Function

    Private Function TimestampFor(hash As UInteger) As String
        Dim seconds = CInt(hash Mod 86400UI)
        Dim stamp = New DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(seconds)
        Return stamp.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture)
    End Function

    Private Function PayloadJson(family As String, seed As String, outputFormat As String) As String
        Dim meta = MetadataFor(family)
        Dim hash = DeterministicHash(seed & "::" & family)
        Dim sequence = 1000UI + (hash Mod 9000UI)
        Dim builder As New StringBuilder()
        builder.AppendLine("{")
        builder.AppendLine("  ""eventType"": ""stakeholder.generator.output"",")
        builder.AppendLine("  ""sequence"": " & sequence.ToString(CultureInfo.InvariantCulture) & ",")
        builder.AppendLine("  ""family"": " & JsonString(family) & ",")
        builder.AppendLine("  ""message"": " & JsonString("Deterministic vbnet tranche for " & family) & ",")
        builder.AppendLine("  ""timestamp"": " & JsonString(TimestampFor(hash)) & ",")
        builder.AppendLine("  ""context"": {")
        builder.AppendLine("    ""rendererKey"": " & JsonString(meta.Renderer) & ",")
        builder.AppendLine("    " & JsonString(meta.ContextKey) & ": " & JsonString(meta.ContextValue) & ",")
        builder.AppendLine("    ""seedFingerprint"": " & JsonString(RegistryId(family) & "-" & hash.ToString("x", CultureInfo.InvariantCulture)) & ",")
        builder.AppendLine("    ""tranche"": " & JsonString(meta.Tranche) & ",")
        builder.AppendLine("    ""vbnetProfile"": ""next-20-deterministic-foundation""")
        builder.AppendLine("  },")
        builder.AppendLine("  ""generationProvenance"": {")
        builder.AppendLine("    ""sourceRepo"": ""vbnet-stakeholder"",")
        builder.AppendLine("    ""baseline"": ""next20-family-focus"",")
        builder.AppendLine("    ""experimental"": false,")
        builder.AppendLine("    ""adapterType"": ""static-catalog"",")
        builder.AppendLine("    ""promptVersion"": null")
        builder.AppendLine("  },")
        builder.AppendLine("  ""outputFormat"": " & JsonString(outputFormat))
        builder.AppendLine("}")
        Return builder.ToString()
    End Function

    Private Sub PrintTextPayload(family As String, seed As String)
        Dim meta = MetadataFor(family)
        Dim hash = DeterministicHash(seed & "::" & family)
        Console.WriteLine("family: " & family)
        Console.WriteLine("renderer: " & meta.Renderer)
        Console.WriteLine("tranche: " & meta.Tranche)
        Console.WriteLine("sequence: " & (1000UI + (hash Mod 9000UI)).ToString(CultureInfo.InvariantCulture))
        Console.WriteLine("timestamp: " & TimestampFor(hash))
        Console.WriteLine("message: Deterministic vbnet tranche for " & family)
    End Sub

    Private Function Fail(message As String) As Integer
        Console.Error.WriteLine(message)
        Return 2
    End Function
End Module
