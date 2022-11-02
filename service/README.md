# Web Scraper

This application performs a web scrape by searching for a particular report on the [Jamaica Stock Exchange](https://www.jamstockex.com/) web site and reading the information from that report to store in a database.

## Requirements

 * [Node](https://nodejs.org/en/) 14.15 or greater

### Highlighted Packages

 * [Puppeteer](https://www.npmjs.com/package/puppeteer)
 * [MS SQL](https://www.npmjs.com/package/mssql)

## Installation

In order to set up the development environment. Given that the version of node mentioned in requirements is installed on the host machine, perform the following command within this folder on the command line,

```bash
npm install
```

## Usage

Perform the command below to scrape stock trades for current date and store in the database.

```bash
node o8$
```

The command below to scrapes and stores stock trades between February 1, 2021 and February 7, 2021. (This is an example of how to scrape and store trades for a date range)

```bash
node o8$ 2021-02-01 2021-02-07
```

Another way of scraping and storing for a range of dates is to scrape and store from a previous date up until the current date (or, better yet, the date of the host machine). So, to scrape up until a current date you put `++` for the end date. For example, the command below scrapes and stores from February 1, 2021 up until the current date (of the machine it is running on).

```bash
node o8$ 2021-02-01 ++
```

### Cron Job

This application is a perfect candidate for a scheduled job. So, _crontab_ can be used to make calls to this node script to run at a regular interval.

Below is syntax that can be used to set the interval for a cronjob.

| Description | Crontab Syntax |
| :--- | :--- |
| Hourly | `0 * * * *` |
| Dailly | `0 0 * * *` |
| Weekly | `0 0 * * 0` |
| Monthly | `0 0 1 * *` |
| Annually | `0 0 1 1 *` |
| Everyday at 12 PM for the first 6 months of the year | `0 11 * 1-6 *` |

The [scripts](../scripts) folder contains the Bash script that can be called by a cronjob.

Before any script can be called, the required permissions must be granted.

To grant _scraper.sh_ executable permissions, perform the following,

```bash
chmod +x [host directory]/scripts/scraper.sh
```

An example of a crobjob can be shown below,

```bash
## Scraping the JSE Daily Market Summary at 10 PM each night
0 19 * * * /bin/bash /home/dayton/Documents/Projects/octopussimizer/scripts/scraper.sh >> /home/dayton/Documents/Projects/octopussimizer/service/scraper-logs.log
```

The cronjob could have called node directly but the purpose of using the Bash script was to export credentials needed to store the stock trades into the database. Credentials are best kept secret and stored in host environment variables or in some restricted storage that can later be retrieved when the program is ready to communicate with the database.

The variables expected by this program are `MSSQLUSER` and `MSSQLPWD`

Here's an idea of what a Bash script should look like when being called by a cronjob.

```bash
export O8DBHOST=localhost
export MSSQLPORT=1401
export MSSQLUSER=susy
export MSSQLPWD=1c3Cr3amC0ne$

/usr/local/bin/node /home/dayton/Documents/Projects/octopussimizer/service/o8$.js
```

## Contributions

This is a NodeJS application. All developers seeking to contribute to this project, is expected to follow the latest [NodeJS Guide](https://nodejs.org/en/docs/guides/).

All features of the latest ECMAScript (JavaScript) are welcome.

The founder of this application enjoys the use of certain new features as you will observe from reading the code. Some include the use of templated strings with the back tick, \`, instead of concatenating string with the `+` sign. Using `const` and `let` instead of `var`. Certain liberties can be taken in this application because it is expected to run directly on a host machine rather than within a browser.

There is a simple design pattern that achieves the motives of the overall plan (which is to gather information). Please follow the motto of **KISS** (Keep it Straightforward and Simple). A sophisticated design pattern is only needed when the application is required to scale up to meet more needs for various use cases. Currently, this is a simple use case.

### To-Do Notes

Remember to upgrade [puppeteer](https://github.com/puppeteer/puppeteer/releases?page=8)

## Further Reading

1. [How to Set Up a Cron Job in Linux](https://phoenixnap.com/kb/set-up-cron-job-linux)
2. [Load node.js module from string in memory](https://stackoverflow.com/questions/17581830/load-node-js-module-from-string-in-memory) <sup><a href="https://github.com/floatdrop/require-from-string" target="_blank">Github</a></sup>

## Tutorial Videos

1. [The power of Headless Chrome and browser automation](https://youtu.be/lhZOFUY1weo)