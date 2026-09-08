---
name: code-review
description: Use for reviewing pull requests on Plugin.ByteArrays — checks conversion-method parity across byte[]/Span/Memory, position-tracking correctness, and bounds/null safety. Applies to any PR touching ByteArrayExtensions, ReadOnlySpanExtensions, ReadOnlyMemoryExtensions, or ByteArrayBuilder.
---

# Code Review — Plugin.ByteArrays

## Checklist for new or changed conversion methods

- [ ] **Throwing + `OrDefault` pair**: a new `ToType(...)` conversion should ship alongside its
      `ToTypeOrDefault(...)` safe variant (or an explanation of why one is intentionally omitted).
- [ ] **`byte[]` / `ReadOnlySpan<byte>` / `ReadOnlyMemory<byte>` parity**: a conversion added to
      `ByteArrayExtensions.*.cs` needs the matching `ReadOnlySpanExtensions.*.cs` variant (and
      `ReadOnlyMemoryExtensions` typically just delegates to the Span version) — and vice versa.
      Flag a PR that only adds one side without a stated reason.
- [ ] **Position tracking**: for any method taking `ref int position`, verify position advances
      by exactly the right byte count on every return path, including the exception path (it
      should generally *not* advance if the conversion throws).
- [ ] **Bounds checking**: null array, empty array, and "not enough bytes remaining" are all
      handled explicitly, not left to an unhandled `IndexOutOfRangeException`.
- [ ] **`BigEndian` variant**: if the type has a legitimate network-byte-order use case, check
      whether a `...BigEndian` counterpart is expected (existing conversions mostly come in
      pairs) — flag its absence rather than assume it doesn't apply.
- [ ] **XML docs**: new public members have accurate `<summary>`/`<param>`/`<returns>`/
      `<exception>` docs — an inaccurate doc comment is a review finding, not just a missing one.
- [ ] **README feature table**: a new conversion type or feature category should be reflected in
      the README's feature list.

## What to flag as a real risk, not a nit

- Manual byte manipulation or `BitConverter` calls that bypass the library's own extension
  methods within this same codebase (its own tests/samples should dogfood the API).
- Allocations in a hot conversion path where `Span<T>`/`stackalloc`/`ArrayPool<T>` would avoid
  one — this library's whole value proposition is allocation-conscious conversions.
