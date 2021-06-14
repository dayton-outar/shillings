# Web Scraper

...

## Requirements

 * [Node](https://nodejs.org/en/) 14.15 or greater

### Highlighted Packages

 * [Puppeteer](https://www.npmjs.com/package/puppeteer)
 * [MS SQL](https://www.npmjs.com/package/mssql)

## Installation

```bash
npm install
```

## Usage

```bash
node o8$ 2021-02-01 ++
```
### Cron Job

| Description | Crontab Syntax |
| :--- | :--- |
| Hourly | `0 * * * *` |
| Dailly | `0 0 * * *` |
| Weekly | `0 0 * * 0` |
| Monthly | `0 0 1 * *` |
| Annually | `0 0 1 1 *` |
| Everyday at 12 PM for the first 6 months of the year | `0 11 * 1-6 *` |

Grant _scraper.sh_ executable permissions
```bash
chmod +x [host directory]/scripts/scraper.sh
```

## Contributions



## Further Reading

1. [How to Set Up a Cron Job in Linux](https://phoenixnap.com/kb/set-up-cron-job-linux)