# Analytics Setup Instructions

## Overview
This guide provides step-by-step instructions for setting up tracking on the **Portfolio Management Advice Launch – JSE Research Tool** landing page and associated channels. The goal is to measure sign-ups, sheet downloads, click-through rates (CTR), and GitHub repository star activity. All tracking aligns with the campaign objectives: driving engagement from retail investors, wealth managers, and financial bloggers.

---

## KPIs & Conversion Goals
| KPI | Definition | Conversion Goal |
|-----|------------|-----------------|
| **Sign-ups** | Number of users who complete the registration form on the landing page. | ≥ 200 sign-ups in two weeks |
| **Sheet Downloads** | Clicks on the “Download Research Sheet” button (PDF/Excel). | ≥ 150 downloads |
| **Click-Through Rate (CTR)** | Ratio of clicks on campaign links (LinkedIn/Twitter/GitHub) to impressions. | ≥ 3% CTR |
| **GitHub Repo Stars** | Number of users who star the open‑source repository. | ≥ 50 stars during campaign |

**Primary Funnel:** Landing Page → Sign‑up/Download → GitHub Star → (optional) Email sign‑up for nurture.

---

## 1. Google Analytics 4 (GA4) – Landing Page Tracking

### 1.1 Create a GA4 Property
1. Go to [Google Analytics](https://analytics.google.com/) and sign in.
2. Click **Admin** → **Create Property**.
3. Enter property name: **“JSE Research Tool Campaign”**.
4. Select reporting time zone and currency (USD).
5. Choose industry category: **Finance**.
6. Click **Create** and complete setup.

### 1.2 Install the GA4 Tracking Tag
**Option A – Google Tag Manager (recommended):**
- Create a new GTM container for the landing page.
- Add a **Google Analytics: GA4 Configuration** tag with your Measurement ID (`G-XXXXXXXX`).
- Deploy the container on the landing page.

**Option B – Direct Tag (without GTM):**
- Copy the global site tag from the GA4 admin panel.
- Paste it immediately after the `<head>` tag on every page of your landing site.

### 1.3 Set Up Key Events
In GA4, define the following custom events:

| Event Name | Trigger |
|------------|---------|
| `sign_up` | Form submission on the registration page |
| `download_sheet` | Click on the download button for the research sheet |
| `visit_github` | Click on the external link to the GitHub repository |
| `cta_click` | Any primary call‑to‑action button click |

**Implementation Example (Google Tag Manager):**
- Create a new Tag → **GA4 Event**.
- Set event name to `sign_up`.
- Trigger: **Form Submission** → target the sign‑up form ID.
- Repeat for other events using **Click – All Elements** triggers with CSS selectors.

### 1.4 Configure Conversions
1. In GA4, go to **Admin** → **Events**.
2. Mark the following events as conversions:
   - `sign_up`
   - `download_sheet`
3. (Optional) Enable enhanced measurement for page scrolls, outbound clicks, and site search.

---

## 2. LinkedIn Insight Tag – B2B Advertising Tracking

### 2.1 Obtain the Insight Tag
1. Log in to your [LinkedIn Campaign Manager](https://www.linkedin.com/campaignmanager/).
2. Go to **Account Assets** → **Insight Tag** → **Add New Tag**.
3. Copy the tag code (a `<script>` snippet ending with `<noscript>`).

### 2.2 Install the Tag
- **Using Google Tag Manager:**  
  Add a **Custom HTML** tag with the LinkedIn Insight Tag code. Set trigger to **All Pages**.
- **Directly:** Paste the code just before the closing `</head>` tag on every page.

### 2.3 Create Conversion Tracking
1. In Campaign Manager, go to **Conversion Tracking** → **Create Conversion**.
2. Define the following actions:
   - **Sign‑up** (URL contains `/thank-you` or event `sign_up` – use LinkedIn’s event API for deeper tracking).
   - **Download** (URL contains `/download`).
3. Assign conversion values (e.g., $1 per sign‑up, $0.50 per download) to estimate ROI.

### 2.4 Verify Tag Installation
Use LinkedIn’s **Tag Help** or the **Audience Insights** tab to confirm the tag fires correctly.

---

## 3. Twitter Pixel – Community Engagement Tracking

### 3.1 Create the Pixel
1. Go to **Twitter Ads** → **Tools** → **Conversion Tracking**.
2. Click **Create Pixel**.
3. Name the pixel: **“JSE Research Campaign”**.
4. Copy the JavaScript snippet.

### 3.2 Install the Pixel
- **GTM:** Add as a **Custom HTML** tag firing on **All Pages**.
- **Direct:** Insert the pixel code in the `<head>` section.

### 3.3 Set Up Events
Using Twitter’s event tag, add the following:

| Event | Code Snippet (example) |
|-------|------------------------|
| Sign‑up | `twq('event', 'SignUp', { conversion_id: 'xxxxx' });` |
| Download | `twq('event', 'Download', { conversion_id: 'yyyyy' });` |

Place these in the page’s `<script>` block after the pixel fires. For GTM, use a **Custom HTML** tag with the event code on the respective pages.

### 3.4 Attribution Settings
In Twitter Ads, set conversion window to **7‑day click** and **1‑day view** to fit the campaign timeline.

---

## 4. GitHub Repo Stars Tracking

### 4.1 Why Track Stars?
Stars indicate community interest and open‑source credibility. They are a leading indicator for future contributors and users.

### 4.2 Tracking via GitHub API (Server‑Side)
1. Use GitHub’s public API endpoint:  
   `GET https://api.github.com/repos/OWNER/REPO`
2. Parse the `stargazers_count` field.
3. Schedule a cron job (every hour or daily) to record the count in your analytics database.

### 4.3 Tracking via Webhook (Real‑Time)
1. Go to your GitHub repository **Settings** → **Webhooks**.
2. Add a webhook URL that points to a small server endpoint.
3. Subscribe to **Watch** events (which include starring).
4. On each event, log the action and update your dashboard.

### 4.4 Display Stars on Landing Page
Embed a badge using HTML:  
`<a href="https://github.com/OWNER/REPO"><img src="https://img.shields.io/github/stars/OWNER/REPO?style=social" alt="GitHub stars"></a>`  
This badge automatically updates and encourages clicks.

---

## 5. Integration & Dashboard

1. **Centralized Dashboard:**  
   Use Google Data Studio (Looker Studio) or a simple spreadsheet to combine GA4 metrics, LinkedIn conversions, Twitter pixel data, and GitHub star counts.

2. **UTM Parameters:**  
   Append `?utm_source={linkedin|twitter|github}&utm_medium=social&utm_campaign=jse_research_tool` to all campaign links. GA4 will automatically capture these.

3. **A/B Testing:**  
   Run two landing page variants in Week 2 (e.g., different button copy). Track conversions via GA4 experiments or a third‑party tool.

---

## 6. Validation Checklist

- [ ] GA4 tag fires on all pages (check via GA4 DebugView)
- [ ] LinkedIn Insight Tag verified via LinkedIn Tag Help
- [ ] Twitter Pixel test event appears in Twitter Ads
- [ ] GitHub star badge renders correctly
- [ ] All UTM parameters are correctly appended
- [ ] Sign‑up form fires GA4 and LinkedIn events on submission
- [ ] Download button triggers GA4 and Twitter events
- [ ] Dashboard shows real‑time data for each KPI

---

## 7. Troubleshooting

- **Missing events:** Check browser console for JavaScript errors. Verify trigger conditions in GTM.
- **LinkedIn tag not firing:** Ensure the noscript `<img>` tag is included for browsers with JavaScript disabled.
- **GitHub API rate limits:** Use OAuth tokens for higher limits; cache results for at least 5 minutes.
- **Twitter Pixel duplicates:** Avoid firing the pixel twice – use a single GTM tag for the base pixel.

---

## 8. Next Steps

After setup:
- Run the campaign for one week, collect baseline data, then adjust ad spend and messaging.
- After two weeks, compile a final report comparing actuals against the KPIs.
- Use insights to refine the next launch (e.g., for other JSE stocks or asset classes).

---

**Last updated:** [Current Date]  
**Maintained by:** Marketing & Analytics Team – AIGON Enterprise AI