# Contributing

## Branching

Work off a short-lived feature branch cut from `main`. Open a PR early and mark it as a Draft
if it's still in progress.

## Commit convention

This repo uses [Conventional Commits](https://www.conventionalcommits.org/): `type(scope): subject`,
imperative mood, <= 72 characters. Common types: `feat`, `fix`, `docs`, `style`, `refactor`,
`perf`, `test`, `chore`. Scope is optional but recommended (e.g. `extensions`, `builder`, `tests`).

## Pull requests

Fill out the PR template. Keep each PR scoped to one logical change. CI must pass before merge.

## Code style

Follow this repo's `.editorconfig`. Prefer clarity over cleverness; avoid unnecessary abstraction
— this is a firm preference, not a suggestion. A conversion added to the `byte[]` extensions
should get a matching `ReadOnlySpan<byte>` variant (and vice versa) where it makes sense — see
`.github/copilot-instructions.md` for the existing conventions.

## Testing

All new functionality needs xUnit tests in `Plugin.ByteArrays.Tests`, using FluentAssertions for
assertions. Test both success and failure paths, boundary conditions (null, empty, exact size,
too small), and position advancement for methods that take `ref int position`.

## Documentation

Public APIs need XML doc comments (`<summary>`, `<param>`, `<returns>`, `<exception>`). If you
add a new conversion type or feature category, update the README's feature table too.
