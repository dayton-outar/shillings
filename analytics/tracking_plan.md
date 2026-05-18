# Event Tracking Plan – Portfolio Clarity Campaign

## Overview

This document defines the event tracking strategy for the **Portfolio Clarity: Smart Allocation for Jamaican Investors** campaign. The plan covers all phases (Awareness, Engagement, Conversion) across LinkedIn, Facebook, email, and local business forums. Primary objective: generate qualified leads for portfolio management advisory services. Budget: $81.73 (spent primarily on LinkedIn ads and Facebook boosted posts).

## Event Taxonomy

All events follow a consistent naming convention: `[channel]_[action]_[content_type]` (e.g., `linkedin_ad_view`, `email_click_cta`, `facebook_post_engagement`). Events are grouped into three categories:

| Category       | Prefix      | Examples                                                                 |
|----------------|-------------|--------------------------------------------------------------------------|
| Ad Engagement  | `ad_`       | ad_impression, ad_click, ad_video_view                                   |
| Email          | `email_`    | email_open, email_click, email_unsubscribe                               |
| Conversion     | `conv_`     | conv_form_submit, conv_consultation_booked, conv_discount_claimed        |

## Tracking Implementation

### Platforms & Tools
- **LinkedIn Ads** – LinkedIn Insight Tag (conversion tracking, event-specific pixels)
- **Facebook Ads** – Meta Pixel with standard and custom events
- **Email (via Mailchimp or similar)** – UTM parameters + platform open/click tracking; redirects through tracking domain for server-side logging
- **Forums (e.g., Loop, local finance groups)** – UTM parameters on shared links; manual engagement counting via URL shorteners (e.g., Bitly)

### Data Layer & Parameters
Every tracked link includes:
- `utm_source` (linkedin, facebook, email, forum)
- `utm_medium` (cpc, email, social, referral)
- `utm_campaign` (portfolio_clarity_jamaica)
- `utm_content` (ad_creative_id / email_variant / post_id)
- `utm_term` (targeting keyword or audience segment)

## Events to Track

### 1. Conversion Events (Primary Goals)

| Event Name               | Trigger | Notes |
|--------------------------|---------|-------|
| `conv_form_submit`       | User submits the “Free Portfolio Review” landing page form | Fields: name, email, phone, investment range, primary goal |
| `conv_consultation_booked` | User completes Calendly appointment for a 15-minute advisory call | Use Calendly webhook to fire event to analytics endpoint |
| `conv_discount_claimed`  | User applies coupon code “CLARITY20” on first session payment | Track via payment gateway webhook (e.g., Stripe) |
| `conv_email_signup`      | User subscribes to the educational email series from a social post | Via embedded signup form; distinct from existing email list |

### 2. Email Events

| Event Name               | Trigger | Notes |
|--------------------------|---------|-------|
| `email_open`             | Email is opened | Use platform open tracking (e.g., Mailchimp) |
| `email_click`            | Any link clicked inside an email | Capture link URL and `utm_content` |
| `email_click_cta`        | CTA button “Book Your Free Call” clicked | Can be a separate event for deeper funnel analysis |
| `email_unsubscribe`      | User opts out | Track reason if provided (e.g., “not interested”) |

### 3. Ad Engagement Events (LinkedIn & Facebook)

| Event Name               | Trigger | Notes |
|--------------------------|---------|-------|
| `ad_impression`          | Ad is served | Standard platform metric |
| `ad_click`               | User clicks ad | Redirect with UTM parameters |
| `ad_video_view_25`       | 25% of video watched | For video ads (both platforms) |
| `ad_video_view_50`       | 50% | Same |
| `ad_video_view_75`       | 75% | Same |
| `ad_video_complete`      | 100% | Same |
| `ad_lead_form_open`      | User clicks into LinkedIn lead gen form | Only if using LinkedIn Lead Gen Forms |
| `ad_lead_form_submit`    | User submits lead gen form | Counts as conversion if form is “Free Guide” |

### 4. Forum / Community Events (Manual)

| Event Name               | Trigger | Notes |
|--------------------------|---------|-------|
| `forum_post_view`        | User views a forum post with campaign UTM link | Track via referral analytics (Google Analytics) |
| `forum_comment`          | User comments on the educational post | Capture username and sentiment (positive/neutral/negative) |
| `forum_link_click`       | User clicks the link to the land page | Using UTM-shortened URL |

## Phase-Specific Tracking

### Awareness Phase (Days 1–5)
- Focus on `ad_impression`, `ad_click`, `ad_video_view`, `forum_link_click`
- No conversion events expected; but monitor for early `ad_lead_form_submit` if LinkedIn Lead Gen is used
- Track email signups from social posts as early conversion

### Engagement Phase (Days 6–12)
- Monitor `email_open`, `email_click_cta` (first email introduces P/E & P/B concepts)
- Track `ad_click` to webinar/live Q&A landing page
- Webinar registration and attendance tracked via Zoom/Google Meet integration

### Conversion Phase (Days 13–15)
- Focus on `conv_form_submit`, `conv_consultation_booked`, `conv_discount_claimed`
- Retarget users who opened email (clicked) but didn’t convert – via LinkedIn Matched Audiences (upload email hash list)

## Attribution & Budget Considerations

With a total budget of **$81.73**, only a limited number of paid clicks are possible. Therefore:
- **Last‑click attribution** is used for simplicity (platform defaults)
- **UTM override** for email conversions to credit the email touchpoint
- **Manual deduplication** for users converting via both email and ad (use user ID or hashed email)

### Sample Cost per Event (Estimated)

| Event                | Estimated Cost per Event | Notes |
|----------------------|--------------------------|-------|
| ad_click (LinkedIn)  | ~$1.50                   | Averaged from industry benchmarks |
| ad_click (Facebook)  | ~$0.50                   | |
| email_open           | $0                       | Platform cost only |
| conv_form_submit     | $10–15                   | Assumes 3–5 clicks per form submit |

## Naming Conventions & Data Layer Schema

All custom events sent to analytics platform (GA4 / Mixpanel / internal) must include the following parameters in the `event_params` object:

| Parameter       | Type   | Example                         |
|-----------------|--------|---------------------------------|
| campaign_name   | string | Portfolio Clarity Jamaica       |
| campaign_phase  | string | Awareness                       |
| channel         | string | linkedin                        |
| medium          | string | cpc                             |
| content         | string | ad_video_v1                     |
| ad_id           | string | linkedin_ad_873492              |
| landing_page    | string | /portfolio-review               |
| user_id         | string | user_hashed_email or anon ID    |
| timestamp       | string | ISO 8601                        |

## Testing & QA

- **UTM link checker**: Validate all campaign URLs before launch (e.g., with Google Campaign URL Builder)
- **Event fire test**: Use browser developer tools (network tab) or platform test events (e.g., Facebook Pixel Helper) to confirm events fire on landing pages
- **Email tracking test**: Send test email, verify open pixel loads and click redirects

## Reporting Dashboard

Ultimate success is measured by:

1. Number of consultations booked (primary KPI)
2. Form submit rate (conversion rate from landing page visitors)
3. Email sequence open & click rates (engagement health)
4. Ad CTR and CPA (efficiency within budget)

A live dashboard (Google Looker Studio or internal) will refresh daily.

---

**Version:** 1.0  
**Owner:** Marketing Analytics Team  
**Last Updated:** 2025-04-01