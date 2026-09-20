# HomeTask

Automated tests for treatwell.es — UI tests with Playwright and API tests hitting the same site directly. .NET / NUnit.

## Structure

- `API` — request models and a small executor for calling treatwell.es endpoints
- `UI` — page objects for browser tests
- `Tests` — the actual test classes (`Tests/API`, `Tests/UI`) plus helpers

## Credentials

Test credentials live in `Tests/.env` (not committed). Set `ENVIRONMENT_NAME` plus a matching `EMAIL_<ENV>` / `PASSWORD_<ENV>` pair, e.g.:

```
ENVIRONMENT_NAME=DEV
EMAIL_DEV=your-email@example.com
PASSWORD_DEV=your-password
```

## Known issue

`LoginViaApi` sends credentials to `/api/v2/me/login` without a Cloudflare 
Turnstile token, which cannot be obtained from an automated client. The expected 
result is a 4xx rejection. The endpoint instead returns **500 Internal Server Error**

BookingApiTests will fail, because without proper login 
expected token can not be provided from the Login response.

`LoginTests` (UI) not expected to pass
The login form sits behind Cloudflare Turnstile, which blocks Playwright by design.
There is no right way to solve the challenge from an automated browser on Prod without CloudFlare login, so this
test is included to demonstrate the UI-level structure and approach rather than as a passing case.

