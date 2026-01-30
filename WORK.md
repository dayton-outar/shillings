# Request for Quote — Portfolio Tracker

Date: 2026-01-30
Requested by: Portfolio Tracker / Dayton Outar


## Purpose

Request for commercial proposals to deliver a production-ready Portfolio Tracker consisting of a public API (the product's web surface) and a native-quality mobile application. Proposals should include firm pricing, a milestone schedule, and any assumptions. The sections below describe required scope, deliverables, acceptance criteria and submission instructions.


## Scope
- Deliver a public API that exposes the product surface and persists data to a central database; the API is the product's web-accessible interface.
- Deliver a mobile application (iOS and Android) from a single shared codebase that consumes the API; mobile users must be able to sign in with Google to access a personalized portfolio.
- Minimum data model and API operations (required):
  - Stock record: ticker (string), date (ISO yyyy-mm-dd), price (decimal). Support create, bulk import, and query by ticker + date range.
  - User profile: id, name, email (basic profile and authentication linkage).
  - Holdings / tracked list: associate users with owned and tracked stocks; include quantity, acquisition timestamp, and a tracked/owned flag.
  - Operations: create/read/query for stocks, users, and holdings; authentication endpoints for token exchange (including Google ID token exchange).
- Provide automated testing (unit, contract, integration, E2E) and an automated build/deploy pipeline that runs on every change.
- Deliver deployable artifacts and manifests for dev/staging/production, migration scripts for the central database, and an operational runbook (deploy, backup/restore, rollback).
- Validate migrations and functionality in staging using a provided production-like snapshot.
## Deliverables
1. Source code and developer documentation (quickstart, setup, and a short architectural overview).
2. API specification (OpenAPI or equivalent), DB schema, and automated contract tests demonstrating the public contract.
3. Implemented API endpoints for managing stock records, users, and holdings, plus example queries and sample data.
4. Automated test suites and CI configuration that run on pull requests and enforce quality gates.
5. Deployable artifacts and deployment manifests for dev/staging/production, plus migration scripts for the central database.
6. Mobile deliverables: source for a single shared iOS/Android codebase, signed build artifacts suitable for app-store submission, Google Sign‑In integration, and mobile E2E/security test results.
7. Operational runbooks: deploy, rollback, backup & restore, incident checklist, and a smoke-test checklist for cutover.
8. A 30-day post-deployment support window and an optional ongoing support proposal.
## Acceptance Criteria
- The API and mobile app workflows function end‑to‑end in a staging environment equivalent to production.
- Data storage & retrieval: automated tests (included in CI) must demonstrate the API can create and return stock records, user profiles, and holdings/track lists.
- Mobile authentication: Google Sign‑In must authenticate a user, exchange the provider token for an API token, and allow the mobile client to retrieve the authenticated user's portfolio.
- Migration & rollback: migration scripts run successfully in staging and are reversible without data loss.
- Performance & security: vendor provides measurable performance targets and automated test evidence; no secrets in code and secure token/storage handling demonstrated for mobile.

Required test examples (vendors must provide automated equivalents):
- POST /api/stocks  --> store { ticker, date, price } and assert 201 + stored values.
- GET /api/stocks?ticker={T}&from={YYYY-MM-DD}&to={YYYY-MM-DD} --> returns records in range.
- POST /api/users  --> create user; GET /api/users/{id} returns profile.
- POST /api/users/{userId}/holdings --> add holding (ticker, quantity, acquiredAt, tracked); GET /api/users/{userId}/holdings returns it.
- POST /api/auth/google { idToken } --> returns access token; GET /api/users/me with token returns profile + holdings.

Vendors may use different endpoint names or payload shapes but must submit an OpenAPI (or equivalent) specification and automated contract tests that demonstrate equivalence to the above behaviors.
## Schedule
- Recommended baseline (for quoting purposes): 6–9 calendar weeks for an MVP release, plus 1–2 weeks for hardening and cutover.
- Vendor should provide a milestone-based timeline with deliverable-linked acceptance criteria and an estimated team allocation.

## Proposal Requirements
- Outline estimated effort per milestone and provide the hourly rate (currency, unit rate).

## Constraints and Assumptions
- The API is the project's web-accessible surface; vendors may recommend the API style but must document the public contract and any phased changes.
- [Recommendation: evaluate .NET for the API implementation to support strong concurrency control and future real-time broadcasting requirements.]
- Portfolio Tracker will provide a production-like database snapshot and required credentials for migration testing.
- Mobile constraint: deliver a single shared codebase for iOS and Android that delivers native‑like performance and secure local storage; vendor should maximize safe code reuse between mobile and API clients.
- Mobile authentication: Google Sign‑In is required for personalized portfolios; vendor responsible for secure implementation and app‑store compliance.
- Security scans and automated dependency checks are expected as part of the work.

## Pricing and payment
- Fixed-price by milestone is required. **All proposals must include hourly rates per role and a blended hourly rate** so Portfolio Tracker can extract and compare contractor rates.
- Simplified payment schedule (example): 30% kickoff, 40% staging acceptance, 30% production acceptance. Vendors may propose alternative milestone schedules but must link payments to deliverable acceptance.

## Response Format and Deadline
- Response document (PDF or Markdown) with: executive summary, detailed proposal, itemized pricing, schedule, assumptions, and signed commercial terms.
- Submission deadline: 2026-02-13 (two weeks from request date).
- Send proposals and questions to: dayton@localhost (or create a PR against this repository and tag @dayton-outar).

## Optional line items (price separately)
- Migration dry‑run and rollback rehearsal in production-like environment.
- Accessibility audit and remediation (WCAG 2.1 AA).
- Performance tuning and a signed SLA for uptime/response.
- Mobile app store submission and post-release maintenance (iOS App Store / Google Play).
- Push notifications and mobile-specific features (permission model, deep links).
- Extended support / SRE onboarding (monthly retainer).

