# Laws of UX Transcription Plan

## Goal

Convert every PDF in `docs/EXPERIENCE/laws/book/` into a clean Markdown chapter file. The output should read like modern, intuitive study material while preserving the book's structure, tables, figure references, and math.

## Source Files

Each source PDF is a chapter file. The chapter number is the numeric suffix at the end of the filename.

| Chapter | Source PDF | Output Markdown |
| --- | --- | --- |
| 1 | `book/Laws.of.UX-2024-1.pdf` | `JAKOBS.LAW.md` |
| 2 | `book/Laws.of.UX-2024-2.pdf` | `FITTSS.LAW.md` |
| 3 | `book/Laws.of.UX-2024-3.pdf` | `MILLERS.LAW.md` |
| 4 | `book/Laws.of.UX-2024-4.pdf` | `HICKS.LAW.md` |
| 5 | `book/Laws.of.UX-2024-5.pdf` | `POSTELS.LAW.md` |
| 6 | `book/Laws.of.UX-2024-6.pdf` | `PEAK.END.RULE.md` |
| 7 | `book/Laws.of.UX-2024-7.pdf` | `AESTHETIC.USABILITY.EFFECT.md` |
| 8 | `book/Laws.of.UX-2024-8.pdf` | `VON.RESTORFF.EFFECT.md` |
| 9 | `book/Laws.of.UX-2024-9.pdf` | `TESLERS.LAW.md` |
| 10 | `book/Laws.of.UX-2024-10.pdf` | `DOHERTY.THRESHOLD.md` |
| 11 | `book/Laws.of.UX-2024-11.pdf` | `APPLYING.PSYCHOLOGICAL.PRINCIPLES.IN.DESIGN.md` |

## Output Location

Write the Markdown files directly in `docs/EXPERIENCE/laws/`.

Expected final structure:

```text
docs/EXPERIENCE/laws/
  README.md
  TRANSCRIPTION_PLAN.md
  JAKOBS.LAW.md
  FITTSS.LAW.md
  MILLERS.LAW.md
  HICKS.LAW.md
  POSTELS.LAW.md
  PEAK.END.RULE.md
  AESTHETIC.USABILITY.EFFECT.md
  VON.RESTORFF.EFFECT.md
  TESLERS.LAW.md
  DOHERTY.THRESHOLD.md
  APPLYING.PSYCHOLOGICAL.PRINCIPLES.IN.DESIGN.md
  book/
    Laws.of.UX-2024-1.pdf
    ...
```

## Filename Rules

- Make each chapter filename uppercase.
- Use dot notation based on the chapter name.
- Remove apostrophes and punctuation that do not work cleanly in filenames.
- Replace spaces, hyphens, and dashes with dots.
- Keep the Markdown extension as `.md`.
- Example: `Jakob's Law` -> `JAKOBS.LAW.md`.

## Formatting Rules

- Use one top-level `#` heading per chapter.
- Use `##` and `###` headings for the chapter's internal sections.
- Modernize the language so it is clear, direct, and intuitive.
- Preserve the original meaning and technical claims.
- Ignore sections titled `Key Takeaways`, `Conclusion`, `Conclusions`, or equivalent summary wrap-up sections.
- Remove page headers, page footers, repeated navigation text, and page numbers.
- Keep lists as Markdown lists.
- Extract tables as Markdown tables and preserve their original columns and row content.
- Replace each image or diagram with a placeholder that references the figure number.
- Format placeholders as:

```markdown
> [!figure]
> Figure X.X placeholder: image/diagram from the source PDF.
```

- If a figure has a caption, keep the caption after the placeholder.
- If a figure number is missing, use the nearest visible caption or page reference:

```markdown
> [!figure]
> Figure placeholder, source page N: image/diagram from the source PDF.
```

## Math Rules

- Use LaTeX for all formulas.
- Use large text math formatting with `$\large{...}$`.
- Inline formulas should use:

```markdown
$\large{formula}$
```

- Display formulas should use:

```markdown
$$
\large{formula}
$$
```

- Preserve variables, operators, units, and equation numbering when present.

## Workflow

1. Sort source PDFs by numeric suffix, not alphabetically.
2. Extract raw text from each PDF.
3. Check reading order against the PDF page layout.
4. Identify and remove ignored summary sections.
5. Rewrite the chapter in modern, intuitive prose while preserving meaning.
6. Convert headings, lists, tables, figures, and formulas to the required Markdown format.
7. Save the chapter with an uppercase dot-notation filename based on the chapter title.
8. Review the generated Markdown against the source PDF.
9. Confirm that every table, figure placeholder, and formula is accounted for.

## Chapter Checklist

- [x] Chapter 1: `Laws.of.UX-2024-1.pdf` -> `JAKOBS.LAW.md`
- [x] Chapter 2: `Laws.of.UX-2024-2.pdf` -> `FITTSS.LAW.md`
- [x] Chapter 3: `Laws.of.UX-2024-3.pdf` -> `MILLERS.LAW.md`
- [x] Chapter 4: `Laws.of.UX-2024-4.pdf` -> `HICKS.LAW.md`
- [x] Chapter 5: `Laws.of.UX-2024-5.pdf` -> `POSTELS.LAW.md`
- [x] Chapter 6: `Laws.of.UX-2024-6.pdf` -> `PEAK.END.RULE.md`
- [x] Chapter 7: `Laws.of.UX-2024-7.pdf` -> `AESTHETIC.USABILITY.EFFECT.md`
- [x] Chapter 8: `Laws.of.UX-2024-8.pdf` -> `VON.RESTORFF.EFFECT.md`
- [x] Chapter 9: `Laws.of.UX-2024-9.pdf` -> `TESLERS.LAW.md`
- [x] Chapter 10: `Laws.of.UX-2024-10.pdf` -> `DOHERTY.THRESHOLD.md`
- [x] Chapter 11: `Laws.of.UX-2024-11.pdf` -> `APPLYING.PSYCHOLOGICAL.PRINCIPLES.IN.DESIGN.md`

## Quality Checks

- [ ] Output filenames are uppercase and use dot notation based on the chapter names.
- [ ] No key takeaway or conclusion sections remain.
- [ ] Tables render correctly in Markdown.
- [ ] Figure placeholders include figure numbers where available.
- [ ] All math uses LaTeX and `\large`.
- [ ] Chapter prose is clear, modern, and easy to scan.
- [ ] Markdown headings form a clean outline.
- [ ] No PDF extraction artifacts remain.
