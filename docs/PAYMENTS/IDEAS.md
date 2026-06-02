# Ideas

## Bill Payment Module

A data dictionary for bill payment module.

---

### 1) Core Entity: `credit_card_payment`

Represents a single payment transaction covering one or more bills.

| Field      | Type              | Description                                                     |
| ---------- | ----------------- | --------------------------------------------------------------- |
| txn_no     | string            | Unique transaction identifier (e.g. `2026032219021205819738BX`) |
| txn_date   | datetime          | Date/time of transaction                                        |
| auth_no    | string (nullable) | Authorization reference from processor                          |
| total_paid | decimal(10,2)     | Total payment amount (JMD)                                      |
| bill_count | integer           | Number of bills paid in this transaction                        |

---

### 2) Child Entity: `payment_allocation`

Breakdown of how a payment is applied to bills.

| Field          | Type          | Description                                       |
| -------------- | ------------- | ------------------------------------------------- |
| id             | string / uuid | Unique allocation ID                              |
| txn_no         | string (FK)   | Links to `credit_card_payment.txn_no`             |
| biller_name    | string        | e.g. "Digicel", "Jamaica Public Service Co. Ltd." |
| account_name   | string        | Customer name on bill                             |
| account_number | string        | Biller account/reference number                   |
| amount         | decimal(10,2) | Amount paid toward this bill                      |

---

### 3) Payment Record: `payment_method_entry`

Represents the actual payment instrument used.

| Field        | Type          | Description                                          |
| ------------ | ------------- | ---------------------------------------------------- |
| payment_id   | string        | Unique ID                                            |
| txn_no       | string (FK)   | Links to transaction                                 |
| payment_type | enum          | e.g. `"credit_card"`                                 |
| reference    | string        | Processor reference (e.g. `202603221902098512552FD`) |
| amount       | decimal(10,2) | Payment amount                                       |
| currency     | string        | `"JMD"`                                              |

---

### 4) Optional Supporting Entity: `biller`

Normalizing billers avoids duplication.

| Field               | Type    | Description            |
| ------------------- | ------- | ---------------------- |
| biller_id           | string  | Unique ID              |
| name                | string  | Biller name            |
| active              | boolean | activate               |
| category            | string  | Utility, telecom, etc. |

---

### 5) Relationships

* `credit_card_payment (1) → (many) payment_allocation`
* `credit_card_payment (1) → (1..many) payment_method_entry`
* `payment_allocation (many) → (1) biller` (optional normalization)

---

### 6) Example JSON (Normalized)

```json
{
  "txn_no": "2026032219021205819738BX",
  "txn_date": "2026-03-22T14:02:00",
  "total_paid": 21300.00,
  "bill_count": 2,
  "allocations": [
    {
      "biller_name": "Digicel",
      "account_name": "Dayton Outar",
      "account_number": "102000124757",
      "amount": 10800.00
    },
    {
      "biller_name": "JPS",
      "account_name": "Dayton Outar (Washington Court)",
      "account_number": "1096802400838",
      "amount": 10500.00
    }
  ],
  "payments": [
    {
      "payment_type": "credit_card",
      "reference": "202603221902098512552FD",
      "amount": 20000.00,
      "currency": "JMD"
    },
    {
      "payment_type": "loyalty_card",
      "reference": "202603221902098542532LY",
      "amount": 1300.00,
      "currency": "JMD"
    }
  ]
}
```

---

### What matters

* This is a **composite payment model** (one payment → many bills)
* The **allocation table is the core** — that’s where financial truth lives
* The top-level transaction is just a wrapper/summary

## Flutter Mobile App

### Security Best Practices

Here’s a concise summary of the **key security best practices** from the article *“Flutter Security Best Practices: Protecting Your App from Threats”* by Raj Salunkhe: ([Medium][1])

**1. Secure API communication**
• Use **HTTPS (TLS 1.2+)** for all server communication.
• Apply **SSL/TLS pinning** so your app only talks to trusted servers.
• Validate server certificates before trusting them. ([Medium][1])

**2. Secure data storage**
• Don’t store sensitive info (like passwords or API keys) in plain text or SharedPreferences.
• Use encrypted storage such as **flutter_secure_storage**.
• Hash passwords instead of storing them. ([Medium][1])

**3. Protect against reverse engineering**
• Enable code **obfuscation** to make decompiled code hard to understand.
• Use tools like **ProGuard/R8** to strip metadata and reduce attack surface. ([Medium][1])

**4. Strong authentication**
• Use secure authentication flows (e.g., **OAuth 2.0**, **Firebase Auth**).
• Implement **biometric authentication** (fingerprint, Face ID). ([Medium][1])

**5. Keep dependencies up to date**
• Regularly update Flutter packages and plugins.
• Remove unused or outdated dependencies to reduce risk. ([Medium][1])

**6. Secure WebView usage**
• Disable JavaScript unless needed.
• Don’t allow WebView to access local storage when unnecessary. ([Medium][1])

**7. Detect compromised devices**
• Use plugins to detect **rooted or jailbroken devices**; these environments can bypass OS-level protections. ([Medium][1])

**8. Monitor security events**
• Log and monitor events like failed logins to detect attacks early.
• Use tools like Sentry or Crashlytics for tracking. ([Medium][1])

**9. Data encryption**
• Encrypt sensitive data **at rest** (e.g., using AES).
• Also encrypt data **in transit** with HTTPS/TLS.
• Use cryptographic libraries such as `encrypt` for secure handling. ([Medium][1])

💡 *Security isn’t “set and forget”. It’s ongoing — updating dependencies, monitoring logs, and handling threats proactively helps protect users and build trust.* ([Medium][1])

[1]: https://medium.com/%40rajsalunkhe8055/flutter-security-best-practices-protecting-your-app-from-threats-b74da273a130 "Flutter Security Best Practices: Protecting Your App from Threats | by Raj Salunkhe | Medium"

---

Here’s the article as a practical checklist with **original code examples** you can copy/paste. ([Medium][1])

#### 1) Secure API communication (HTTPS + cert pinning)

* Use **HTTPS (TLS 1.2+)** and validate certificates. ([Medium][1])
* Add **TLS pinning** to reduce MITM risk. ([Medium][1])

```dart
import 'dart:io';
import 'package:dio/dio.dart';

Dio buildPinnedDio({
  required List<List<int>> trustedDerCerts, // DER-encoded cert bytes
}) {
  final dio = Dio(BaseOptions(
    baseUrl: 'https://api.example.com',
    connectTimeout: const Duration(seconds: 10),
    receiveTimeout: const Duration(seconds: 10),
  ));

  final httpClientAdapter = dio.httpClientAdapter;
  if (httpClientAdapter is DefaultHttpClientAdapter) {
    httpClientAdapter.onHttpClientCreate = (client) {
      final sc = SecurityContext(withTrustedRoots: false);
      for (final der in trustedDerCerts) {
        sc.setTrustedCertificatesBytes(der);
      }
      final pinned = HttpClient(context: sc);

      // Optional: extra hostname check
      pinned.badCertificateCallback = (cert, host, port) => false;

      return pinned;
    };
  }

  return dio;
}
```

#### 2) Secure data storage (don’t use SharedPreferences for secrets)

* Avoid storing tokens/API keys/passwords in plaintext; use **secure storage**. ([Medium][1])

```dart
import 'package:flutter_secure_storage/flutter_secure_storage.dart';

class TokenStore {
  static const _kToken = 'auth_token';
  final _storage = const FlutterSecureStorage();

  Future<void> saveToken(String token) => _storage.write(key: _kToken, value: token);
  Future<String?> readToken() => _storage.read(key: _kToken);
  Future<void> clear() => _storage.delete(key: _kToken);
}
```

#### 3) Protect against reverse engineering (obfuscation + minify)

* Enable **obfuscation** and shrink/minify for Android builds. ([Medium][1])

```bash
flutter build apk --release --obfuscate --split-debug-info=build/symbols
```

**Android (Gradle) minify/shrink example** (concept from article): ([Medium][1])

```gradle
buildTypes {
  release {
    minifyEnabled true
    shrinkResources true
    proguardFiles getDefaultProguardFile('proguard-android.txt'), 'proguard-rules.pro'
  }
}
```

#### 4) Strong authentication (OAuth/Firebase + biometrics)

* Prefer **OAuth2/Firebase Auth** and add **biometrics** for step-up auth. ([Medium][1])

```dart
import 'package:local_auth/local_auth.dart';

Future<bool> biometricGate() async {
  final auth = LocalAuthentication();
  final can = await auth.canCheckBiometrics;
  if (!can) return false;

  return auth.authenticate(
    localizedReason: 'Authenticate to continue',
    options: const AuthenticationOptions(biometricOnly: true),
  );
}
```

#### 5) Keep dependencies updated

* Regularly check outdated packages and upgrade. ([Medium][1])

```bash
flutter pub outdated
flutter pub upgrade
```

#### 6) Secure WebView usage (disable JS unless needed)

* WebViews are risky; **disable JavaScript** unless required. ([Medium][1])

```dart
import 'package:webview_flutter/webview_flutter.dart';

WebViewWidget secureWebView() {
  final controller = WebViewController()
    ..setJavaScriptMode(JavaScriptMode.disabled)
    ..loadRequest(Uri.parse('https://secure-website.com'));

  return WebViewWidget(controller: controller);
}
```

#### 7) Detect rooted/jailbroken devices

* Treat compromised devices as higher risk. ([Medium][1])

```dart
import 'package:flutter_jailbreak_detection/flutter_jailbreak_detection.dart';

Future<bool> isCompromisedDevice() async {
  final jailbroken = await FlutterJailbreakDetection.jailbroken;
  final devMode = await FlutterJailbreakDetection.developerMode;
  return jailbroken || devMode;
}
```

#### 8) Monitor & log security events

* Track things like failed logins; use Sentry/Crashlytics. ([Medium][1])

```dart
import 'package:sentry_flutter/sentry_flutter.dart';

Future<void> logFailedLogin({required String username}) async {
  await Sentry.captureMessage(
    'Failed login attempt',
    withScope: (scope) {
      scope.setTag('event', 'auth_failed');
      scope.setExtra('username', username);
    },
  );
}
```

#### 9) Encrypt sensitive data (at rest + in transit)

* Use AES for “data at rest” (and HTTPS for in transit). ([Medium][1])

```dart
import 'dart:convert';
import 'dart:math';
import 'package:encrypt/encrypt.dart';

class CryptoBox {
  // In real apps: derive/store key securely (e.g., from secure enclave/keystore)
  final Key key;

  CryptoBox(this.key);

  Encrypted encryptText(String plain) {
    final iv = IV.fromSecureRandom(16);
    final encrypter = Encrypter(AES(key, mode: AESMode.cbc));
    return encrypter.encrypt(plain, iv: iv);
  }
}
```

### Shipping Flutter App

Here’s the practical checklist to ship a Flutter app to the **Google Play Store**.

#### 1) Prep your app for release

* **Set app name / icon / package name** (package name can’t change later).
* **Update versioning** in `pubspec.yaml`:

  * `version: 1.0.0+1` (first is user-facing, `+` is build number)
* **Verify your Android manifest** basics:

  * Permissions you use (don’t request extra)
  * App ID / package correct

#### 2) Create a release signing key (do this once, store safely)

Google Play requires signing.

* Generate a **keystore** and keep backups (password + file).
* Decide signing approach:

  * **Recommended:** enable **Play App Signing** (Google manages the final signing key; you upload an upload-key signed AAB).

#### 3) Build a release bundle (AAB)

Google Play prefers **Android App Bundle (.aab)** over APK.

* In Flutter you’ll build the release bundle and sign it with your upload key.

#### 4) Create your Play Console app

* Create a **Google Play Developer account** (one-time fee).
* In **Play Console** → **Create app**

  * App name, default language, app/ game, free/paid

#### 5) Fill required store & policy info (most submissions fail here)

* **Store listing:** short description, full description, screenshots (phone required; tablet optional), high-res icon, feature graphic
* **App access:** if login required, explain / provide test credentials
* **Content rating questionnaire**
* **Target audience / Designed for Families** (if relevant)
* **Data Safety form:** what data you collect, share, encrypt, delete, etc.
* **Privacy policy URL** (required for most apps)
* **Ads declaration** (yes/no)
* **Permissions declaration** (location, SMS, call logs, etc. if used)

#### 6) Create a release in a track

Choose where to publish first:

* **Internal testing** (fastest, great for sanity checks)
* **Closed testing** (limited testers)
* **Open testing**
* **Production**

Upload your **.aab**, add release notes, and fix any Play warnings.

#### 7) Review & roll out

* Pass **pre-launch checks**
* Submit for review
* After approval, **roll out** (can do staged rollout %)

---

#### Common gotchas (avoid these)

* Package name mismatch / changed late
* Missing **privacy policy** and **Data Safety** inconsistencies
* Requesting permissions you don’t use
* No 64-bit native support (Flutter is fine, but watch native plugins)
* Using **debug keystore** by mistake

### Resources

1. [Flutter](https://flutter.dev/)
   - [Flutter Security](https://docs.flutter.dev/security)
2. [Bloc State Management Library](https://bloclibrary.dev/)
3. [Riverpod State Management Library](https://riverpod.dev/)
4. [Flutter Packages: action_slider](https://pub.dev/packages/action_slider)
5. [Flutter Packages: logger](https://pub.dev/packages/logger)
6. [Flutter Packages: expandable_page_view](https://pub.dev/packages/expandable_page_view)
7. [Flutter Packages: awesome_dialog](https://pub.dev/packages/awesome_dialog)
8. [Flutter Packages: once](https://pub.dev/packages/once)

### Further Reading

1. [How to Build Scalable and Performant Flutter Applications: A Handbook for Devs](https://www.freecodecamp.org/news/how-to-build-scalable-and-performant-flutter-applications-a-handbook-for-devs/) by Atuoha Anthony
2. [How to Manage Assets in Flutter using flutter_gen](https://www.freecodecamp.org/news/how-to-manage-assets-in-flutter-using-fluttergen/)

### Further Watching

1. [Chat/Messaging App Light and Dark Theme - Flutter UI - Speed Code](https://youtu.be/uiJF-ShOLyo?si=fBEw_vYDKqLW-8ta) - [The Flutter Way](https://www.youtube.com/@TheFlutterWay)
2. [Splash Screen Animation with Flutter](https://youtu.be/Uoseoozsuiw?si=fvYM9VuOrrvBHHee) - [The Flutter Way](https://www.youtube.com/@TheFlutterWay)
3. [Flutter Animation](https://www.youtube.com/playlist?list=PLxUBb2A_UUy9HKsPsmsWwgHRBC4XzFMu1) - [The Flutter Way](https://www.youtube.com/@TheFlutterWay)
4. [Let's clone a dribbble design using FLUTTER](https://youtu.be/eegl7of4g-o?si=9oyksjFF-qknlH2z) - [Mitch Koko](https://www.youtube.com/@createdbykoko)
5. [RESPONSIVE DESIGN • Flutter Tutorial](https://youtu.be/MrPJBAOzKTQ?si=Bxnt-6BKe606P5no) - [Mitch Koko](https://www.youtube.com/@createdbykoko)
6. [FULL Flutter Beginner Course • Programming Basics / Widgets / Navigation / User Input / UI](https://youtu.be/HQ_ytw58tC4?si=m23TgySIdd85Aivz) - [Mitch Koko](https://www.youtube.com/@createdbykoko)
7. [Flutter Tutorial for Beginners](https://www.youtube.com/playlist?list=PL4cUxeGkcC9jLYyp2Aoh6hcWuxFDX6PBJ) - [Net Ninja](https://www.youtube.com/@NetNinja)
8. [Flutter Animation Tutorial](https://www.youtube.com/playlist?list=PL4cUxeGkcC9gP1qg8yj-Jokef29VRCLt1) - [Net Ninja](https://www.youtube.com/@NetNinja)
9. [Flutter Animations Course](https://www.youtube.com/playlist?list=PL6yRaaP0WPkW3kwAerPeRqGBvJfO8O4S7) - [Vandad Nahavandipoor](https://www.youtube.com/@VandadNP)
10. [Flutter Bloc Tutorial For Beginners | BLoC Architecture/Pattern & State Management Explained](https://youtu.be/SDk_GldOtK8?si=x3zWY0OUC-jhxwAG) - [Rivan Ranawat](https://www.youtube.com/@RivaanRanawat)
11. [Build Spotify With Flutter - Bloc , Clean Architecture , Firebase , Figma](https://youtu.be/4TFbXepOjLI?si=nfd6l-NvRXhT3pzp) - [Flutter Guys](https://www.youtube.com/@flutterguys)
    - [Github Repo](https://github.com/mahdinazmi/Spotify-Clone-With-Flutter/tree/main)
12. [Flutter Riverpod Tutorial](https://www.youtube.com/playlist?list=PL4cUxeGkcC9i88WGZ9eIfQUWRgPstLFLp) - [Net Ninja](https://www.youtube.com/@NetNinja)
13. [How to Architect a Flutter App](https://www.youtube.com/playlist?list=PLdTodMosi-BwM4XkagNwe4KADOMWQS5X-) - [FilledStacks](https://www.youtube.com/@FilledStacks)
14. [Flutter Foundation](https://youtube.com/playlist?list=PLdTodMosi-BwEwlzjN6EyS1vwGXFo-UlK&si=joPGQmYWgnzQFIRy) - [FilledStacks](https://www.youtube.com/@FilledStacks)
15. [Avoid These 11 Costly BLoC Mistakes in Flutter Apps](https://youtu.be/FklNwVd__Zs?si=yl2gOvFr_VVqZnoN) - [AbedDev](https://www.youtube.com/@abed-dev)

#### Animations

1. [Frank's Larboratory](https://www.youtube.com/@Frankslaboratory)

[1]: https://medium.com/%40rajsalunkhe8055/flutter-security-best-practices-protecting-your-app-from-threats-b74da273a130 "Flutter Security Best Practices: Protecting Your App from Threats | by Raj Salunkhe | Medium"