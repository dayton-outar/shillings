# Web Performance in Action Transcription Plan

## Goal

Convert every PDF in `docs/EXPERIENCE/performance/` into a clean Markdown chapter file. The output should read like modern, intuitive study material while preserving the book's structure, tables, figure references, code examples, commands, URLs, and technical claims.

## Table of Contents

The chapter number is the numeric suffix at the end of each PDF filename. Sort by that suffix, not alphabetically.

| Chapter | Chapter Title | Source PDF | Output Markdown |
| --- | --- | --- | --- |
| 1 | Understanding web performance | `Web.Performance.in.Action-2017-1.pdf` | `UNDERSTANDING.WEB.PERFORMANCE.md` |
| 2 | Using assessment tools | `Web.Performance.in.Action-2017-2.pdf` | `USING.ASSESSMENT.TOOLS.md` |
| 3 | Optimizing CSS | `Web.Performance.in.Action-2017-3.pdf` | `OPTIMIZING.CSS.md` |
| 4 | Understanding critical CSS | `Web.Performance.in.Action-2017-4.pdf` | `UNDERSTANDING.CRITICAL.CSS.md` |
| 5 | Making images responsive | `Web.Performance.in.Action-2017-5.pdf` | `MAKING.IMAGES.RESPONSIVE.md` |
| 6 | Going further with images | `Web.Performance.in.Action-2017-6.pdf` | `GOING.FURTHER.WITH.IMAGES.md` |
| 7 | Faster fonts | `Web.Performance.in.Action-2017-7.pdf` | `FASTER.FONTS.md` |
| 8 | Keeping JavaScript lean and fast | `Web.Performance.in.Action-2017-8.pdf` | `KEEPING.JAVASCRIPT.LEAN.AND.FAST.md` |
| 9 | Boosting performance with service workers | `Web.Performance.in.Action-2017-9.pdf` | `BOOSTING.PERFORMANCE.WITH.SERVICE.WORKERS.md` |
| 10 | Fine-tuning asset delivery | `Web.Performance.in.Action-2017-10.pdf` | `FINE.TUNING.ASSET.DELIVERY.md` |
| 11 | Looking to the future with HTTP/2 | `Web.Performance.in.Action-2017-11.pdf` | `LOOKING.TO.THE.FUTURE.WITH.HTTP2.md` |
| 12 | Automating optimization with gulp | `Web.Performance.in.Action-2017-12.pdf` | `AUTOMATING.OPTIMIZATION.WITH.GULP.md` |

## Output Location

Write the Markdown files directly in `docs/EXPERIENCE/performance/`.

Expected final structure:

```text
docs/EXPERIENCE/performance/
  TRANSCRIPTION_PLAN.md
  UNDERSTANDING.WEB.PERFORMANCE.md
  USING.ASSESSMENT.TOOLS.md
  OPTIMIZING.CSS.md
  UNDERSTANDING.CRITICAL.CSS.md
  MAKING.IMAGES.RESPONSIVE.md
  GOING.FURTHER.WITH.IMAGES.md
  FASTER.FONTS.md
  KEEPING.JAVASCRIPT.LEAN.AND.FAST.md
  BOOSTING.PERFORMANCE.WITH.SERVICE.WORKERS.md
  FINE.TUNING.ASSET.DELIVERY.md
  LOOKING.TO.THE.FUTURE.WITH.HTTP2.md
  AUTOMATING.OPTIMIZATION.WITH.GULP.md
  Web.Performance.in.Action-2017-1.pdf
  ...
  Web.Performance.in.Action-2017-12.pdf
```

## Filename Rules

- Make each chapter filename uppercase.
- Use dot notation based on the chapter title.
- Remove punctuation that does not work cleanly in filenames.
- Replace spaces, hyphens, en dashes, and em dashes with dots.
- Preserve known technical terms in compact filename form where clearer, such as `HTTP2`.
- Keep the Markdown extension as `.md`.
- Example: `Looking to the future with HTTP/2` -> `LOOKING.TO.THE.FUTURE.WITH.HTTP2.md`.

## Formatting Rules

- Use one top-level `#` heading per chapter.
- Use `##` and `###` headings for the chapter's internal sections.
- Keep the opening "This chapter covers" material as a short bullet list near the top of each chapter.
- Modernize the language so it is clear, direct, and intuitive.
- Preserve the original meaning, examples, measurements, commands, API names, browser behavior, and technical claims.
- Ignore sections titled `Summary`, `Conclusion`, `Conclusions`, or equivalent wrap-up sections.
- Remove page headers, page footers, repeated navigation text, and page numbers.
- Keep lists as Markdown lists.
- Extract tables as Markdown tables and preserve their original columns and row content.
- Preserve code snippets and shell commands as fenced code blocks with the most accurate language tag available.
- Preserve URLs, package names, file paths, CSS properties, HTML elements, JavaScript APIs, HTTP headers, and HTTP methods as inline code where appropriate.
- Replace each image, chart, screenshot, or diagram with a placeholder that references the figure number.
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

## Technical Content Rules

- Preserve command sequences in their original order.
- Preserve benchmark values, byte sizes, percentages, timings, browser names, protocol names, and version references.
- Preserve HTTP request and response examples in fenced code blocks.
- Preserve HTML, CSS, JavaScript, JSON, and server configuration examples in fenced code blocks.
- Use LaTeX for formulas if any appear.
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

## Workflow

1. Sort source PDFs by numeric suffix, not alphabetically.
2. Extract raw text from each PDF.
3. Check reading order against the PDF page layout, especially around figures, tables, sidebars, and code listings.
4. Identify the chapter title, "This chapter covers" bullets, numbered sections, figures, tables, and code examples.
5. Identify and remove ignored summary or conclusion sections.
6. Rewrite the chapter in modern, intuitive prose while preserving meaning.
7. Convert headings, lists, tables, figures, commands, code, URLs, and formulas to the required Markdown format.
8. Save the chapter with the mapped uppercase dot-notation filename.
9. Review the generated Markdown against the source PDF.
10. Confirm that every table, figure placeholder, code listing, command block, URL, and formula is accounted for.

## Chapter Checklist

- [x] Chapter 1: `Web.Performance.in.Action-2017-1.pdf` -> `UNDERSTANDING.WEB.PERFORMANCE.md`
- [x] Chapter 2: `Web.Performance.in.Action-2017-2.pdf` -> `USING.ASSESSMENT.TOOLS.md`
- [x] Chapter 3: `Web.Performance.in.Action-2017-3.pdf` -> `OPTIMIZING.CSS.md`
- [x] Chapter 4: `Web.Performance.in.Action-2017-4.pdf` -> `UNDERSTANDING.CRITICAL.CSS.md`
- [x] Chapter 5: `Web.Performance.in.Action-2017-5.pdf` -> `MAKING.IMAGES.RESPONSIVE.md`
- [x] Chapter 6: `Web.Performance.in.Action-2017-6.pdf` -> `GOING.FURTHER.WITH.IMAGES.md`
- [x] Chapter 7: `Web.Performance.in.Action-2017-7.pdf` -> `FASTER.FONTS.md`
- [x] Chapter 8: `Web.Performance.in.Action-2017-8.pdf` -> `KEEPING.JAVASCRIPT.LEAN.AND.FAST.md`
- [x] Chapter 9: `Web.Performance.in.Action-2017-9.pdf` -> `BOOSTING.PERFORMANCE.WITH.SERVICE.WORKERS.md`
- [x] Chapter 10: `Web.Performance.in.Action-2017-10.pdf` -> `FINE.TUNING.ASSET.DELIVERY.md`
- [x] Chapter 11: `Web.Performance.in.Action-2017-11.pdf` -> `LOOKING.TO.THE.FUTURE.WITH.HTTP2.md`
- [x] Chapter 12: `Web.Performance.in.Action-2017-12.pdf` -> `AUTOMATING.OPTIMIZATION.WITH.GULP.md`

## Quality Checks

- [ ] Output filenames are uppercase and use dot notation based on the chapter titles.
- [ ] PDFs are processed in numeric suffix order.
- [ ] No summary or conclusion sections remain.
- [ ] Tables render correctly in Markdown.
- [ ] Figure placeholders include figure numbers where available.
- [ ] Code blocks, commands, URLs, HTTP examples, and API names are preserved.
- [ ] All math uses LaTeX and `\large` if formulas appear.
- [ ] Chapter prose is clear, modern, and easy to scan.
- [ ] Markdown headings form a clean outline.
- [ ] No PDF extraction artifacts remain.
