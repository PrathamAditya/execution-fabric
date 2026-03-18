# Execution Fabric

> A general-purpose execution runtime for heterogeneous task environments.

---

## What is Execution Fabric?

Execution Fabric is a low-level execution runtime.

Its purpose is to provide a single, unified system for running tasks — regardless of what those tasks are or where they run.

Modern software systems execute many types of work: local functions, API calls, shell commands, AI tool invocations, distributed jobs, workflow steps. Yet execution logic is almost always fragmented — spread across frameworks, ad-hoc runners, and application-specific glue code.

Execution Fabric explores a different model: one runtime, one abstraction, all execution types.

---

## Core Model

```
Task → Executor → Result
```

| Primitive          | Responsibility                                      |
|--------------------|-----------------------------------------------------|
| `ITask`            | Describes what work should be done                  |
| `IExecutor`        | Knows how to perform a specific category of work    |
| `ExecutionEngine`  | Coordinates dispatch, lifecycle, and result routing |
| `ExecutionResult`  | Uniform output shape — errors are data, not throws  |

The runtime separates **execution** from **orchestration**. Higher-level concerns — workflows, scheduling, agents — build on top of it.

---

## Why

Most systems conflate execution with the thing being executed.

Workflow engines carry their own runners. AI frameworks implement custom tool dispatch. Distributed systems build isolated execution layers. The result is fragmentation: each system reinvents execution for its own context.

Execution Fabric isolates the execution layer as infrastructure — something that can be reasoned about, extended, and composed independently of what runs on top of it.

---

## Executor Model

Executors are domain-scoped execution units. Each executor handles one category of work.

```
LocalFunctionExecutor   →  in-process function calls
ShellExecutor           →  shell / CLI commands
HttpExecutor            →  REST and API calls
WorkflowExecutor        →  composed execution graphs
DistributedExecutor     →  remote worker dispatch
OpenAIExecutor          →  LLM tool invocations
SemanticKernelExecutor  →  SK-based agent tooling
DockerExecutor          →  containerized workloads
```

New executors plug into the runtime without modifying the core.

External systems — including AI frameworks — are treated as **execution targets**, not core dependencies.

---

## Roadmap

Execution Fabric is designed to evolve incrementally.

**Phase 1 — Local Execution Runtime**
Minimal runtime: `ITask`, `IExecutor`, `ExecutionResult`, `ExecutionEngine`. Everything executes locally.

**Phase 2 — Executor Plugin System**
Executor registry, plugin discovery, dependency injection support, dynamic routing.

**Phase 3 — Distributed Execution**
Remote executors, worker nodes, message-based task distribution, execution coordination across machines.

**Phase 4 — Workflow / DAG Execution**
Execution graphs, dependency resolution, parallel execution, DAG-based pipelines.

**Phase 5 — LLM / Agent Integration**
LLM executors, tool execution, agent pipelines, semantic workflows. AI systems as execution targets.

---

## Design Principles

- **Execution separated from orchestration** — the runtime coordinates; it does not decide what runs
- **Errors are data** — executors return results, they do not throw
- **Extensibility by design** — new executors plug in without touching the core
- **Incremental complexity** — the system grows in layers; each phase builds on the last
- **Observable** — tracing and logging are first-class concerns, not afterthoughts

---

## Status

Early development. Currently in **Phase 1**.

Stack: C# / .NET

---

## Contributing

This project is in active early design. Contributions, ideas, and feedback are welcome.

---

## License

MIT
