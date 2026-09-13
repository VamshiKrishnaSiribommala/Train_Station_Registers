<div align="center">

# 🚆 INDIAN RAILWAYS — TRAIN MANAGEMENT SYSTEM (TMS)

### 🇮🇳 *Smart Digital Solution for Railway Station Registers & Centralized Operational Control*

<br/>

<!-- Animated Typing Banner -->
<a href="#">
  <img src="https://readme-typing-svg.demolab.com?font=Outfit&weight=700&size=26&duration=2500&pause=1000&color=00D2FF&center=true&vCenter=true&width=850&height=55&lines=Centralized+Digital+Train+Management;Safely+Monitor+%26+Control+Train+Movements;30+Station+Registers+%2B+22+Authorities+Digitized;Instant+Cross-Register+Dynamic+Audit+Reports" alt="TMS Animated Header" />
</a>

<br/>

<!-- Technology Badges -->
<p align="center">
  <img src="https://img.shields.io/badge/Platform-Cross--Platform%20Desktop%20(Windows%20%7C%20Linux)-0078D4?style=for-the-badge&logo=windows&logoColor=white" alt="Platform" />
  <img src="https://img.shields.io/badge/Framework-.NET%208.0%20(LTS)-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET" />
  <img src="https://img.shields.io/badge/UI%20Toolkit-Avalonia%20UI%2011-8B5CF6?style=for-the-badge&logo=avalonia&logoColor=white" alt="Avalonia" />
  <img src="https://img.shields.io/badge/Language-C%23%2012-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/Database-MS%20SQL%20Server%202025%20(Docker)-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" alt="Database" />
  <img src="https://img.shields.io/badge/Reports-PDF%20%7C%20Excel%20%7C%20CSV-FF6F00?style=for-the-badge&logo=adobeacrobatreader&logoColor=white" alt="Reports" />
</p>

<br/>

---

</div>

# 🎯 Aim & Main Objective of the Project

The main objective of the **Train Management System (TMS)** is to safely monitor, control, and manage train movements by replacing manual railway registers and paper train working authorities with a centralized digital system.

The system stores train movement information, captures operational records, manages railway station registers, and generates reports for:

- 🚆 **Train Operations & Movements**
- 🛡️ **Safety & Interlocking Monitoring**
- 🚦 **Train Working Authority Dispatch (T/369-3b, Caution Orders, Shunting, etc.)**
- 🔍 **Audits and Official Inspections**
- 📊 **Dynamic Management Reporting (PDF, Excel, CSV)**

> **The goal is simple: Replace manual paperwork with a centralized, searchable, secure, and efficient digital railway management system.**

---

# 🌟 Why Train Management System (TMS)?

Traditional railway station operations depend on multiple physical paper registers and handwritten memo forms maintained manually by Station Masters, Traffic Inspectors, and Signal & Telecom Maintainers.

The **Train Management System (TMS)** transforms this manual process into a centralized digital platform.

<table>
<tr>

<td width="48%" valign="top">

## 🛑 Traditional Paper System

❌ **Separate physical registers & paper memos**

❌ Risk of damaged, torn, or misplaced records

❌ Manual shift handovers with no audit trail

❌ Time-consuming inspection preparation

❌ Difficult to search historical records

❌ Hundreds of pages must be checked manually

❌ Manual compilation of audit reports

</td>

<td width="4%" align="center">

# ➜

</td>

<td width="48%" valign="top">

## ⚡ Centralized Digital TMS

✅ **One centralized cross-platform system (.NET 8 + Avalonia UI)**

✅ Permanent records stored in Microsoft SQL Server

✅ Digital shift handovers with timestamps & audit logs

✅ Instant inspection and audit preparation

✅ Real-time search across registers & train authorities

✅ Touchpad & mouse drag scrolling across all tables

✅ Instant PDF, Excel, and CSV export reports

</td>

</tr>
</table>

---

> ## 🚀 Result
>
> **Instead of managing dozens of separate paper registers, railway staff can manage all station operations and train working authorities through one centralized Train Management System.**

---

# 🏛️ System Architecture Workflow

```mermaid
flowchart TD

    A[👥 Station Master / Inspector / Administrator]
    A --> B[🔐 Login & Session Authentication]

    B --> C[🎛️ Centralized TMS Dashboard]

    C --> D1[🔵 Station Operations & Traffic (14 Registers)]
    C --> D2[🟢 Signal & Telecom Maintenance (8 Registers)]
    C --> D3[🟠 Infrastructure & Electrical Power (4 Registers)]
    C --> D4[🔴 Safety & Audit Engine (4 Registers)]
    C --> D5[🚦 Train Working Authorities Hub (22 Authorities)]

    D1 --> E[(🗄️ Centralized SQL Server Database)]
    D2 --> E
    D3 --> E
    D4 --> E
    D5 --> E

    E --> F[📊 Centralized Dynamic Reports Engine]

    F --> G1[📄 PDF Reports with Railway Headers]
    F --> G2[📊 Excel Export .xlsx]
    F --> G3[📋 CSV Export .csv]
    F --> G4[🖨️ Direct Print Layouts]
```

---

# 📋 Operational Modules Breakdown

The Train Management System digitizes **30 Station Operational Registers** and **22 Train Working Authorities**, organized into five key modules:

| Module | Count | Main Purpose |
|---|:---:|---|
| 🔵 Station Operations & Traffic | 14 Registers | Train movements, signal records, attendance, relief diary, private number exchange |
| 🟢 Signal & Telecom Maintenance | 8 Registers | Point machines, block failures, crank handles, disconnections, emergency keys |
| 🟠 Infrastructure & Electrical Power | 4 Registers | Sidings, traffic/power blocks, petty repairs, DG generator fuel logs |
| 🔴 Safety & Audit Engine | 4 Registers | Fog signalmen, night inspections, officer observations, safety meetings |
| 🚦 Train Working Authorities Hub | 22 Authorities | Official Indian Railways operating forms (T/369-3b, T/409, T/509, T/806, etc.) |
| **TOTAL** | **52 Digital Assets** | **Comprehensive Railway Station Management** |

---

# 🔵 1. Station Operations & Traffic Registers (14 Registers)

| Register Code | Register Name | Operational Scope & Tracked Information |
|---|---|---|
| `REG-001` | **Station Master's Diary** | Daily operational log, train events narrative, weather, and handover details. |
| `REG-002` | **Train Signal Register** | Train number, UP/DOWN direction, platform/line, arrival, departure, and passed times. |
| `REG-003` | **SWR Acknowledgment** | Station Working Rules acknowledgment, staff ID, rule version, and verification date. |
| `REG-004` | **Caution Order Register** | Speed restrictions, engineering reasons, affected section, and validity period. |
| `REG-007` | **Bio-Metric Attendance** | Staff duty presence, shift classification, and attendance verification. |
| `REG-008` | **Stabled Load Register** | Stabled rakes, line numbers, handbrake securing checks, and safety confirmation. |
| `REG-011` | **Public Complaints** | Passenger grievances, PNR/ticket numbers, complaint category, and resolution notes. |
| `REG-012` | **Staff Grievances** | Employee complaints, priority category, and redressal status. |
| `REG-021` | **Complete Arrival Register** | Complete arrival verification, tail lamp/LV board checks, and guard confirmation. |
| `REG-022` | **Control Instructions** | Directives from Section Controller, directive ID, instruction type, and SM sign-off. |
| `REG-023` | **SM Relief Diary** | Shift relief records, ongoing trains, block conditions, and relieving staff signature. |
| `REG-028` | **Staff Biodata & Training** | Staff medical certification, PME/Refresher training dates, and competency records. |
| `REG-029` | **Assurance Register** | Safety circulars read and understood, staff signatures, and validity tracking. |
| `REG-030` | **Private Number (PN) Sheet** | Private number exchanges between stations and level crossing gates with train ID. |

---

# 🟢 2. Signal & Telecom (S&T) Maintenance Registers (8 Registers)

| Register Code | Register Name | Operational Scope & Tracked Information |
|---|---|---|
| `REG-005` | **Signal / Point / Block Failure** | Equipment failure logs, failure time, reporting staff, and technician restoration notes. |
| `REG-006` | **S&T Discon / Recon** | Disconnection memo notices, affected gears, maintainer acknowledgment, and reconnection. |
| `REG-014` | **Miscellaneous Counters** | Emergency route release, calling-on signal counters, and authorization numbers. |
| `REG-016` | **Crank Handle Register** | Crank handle box issue, key number, authorized staff, checkout and return timestamps. |
| `REG-017` | **Crank Handle Testing** | Periodic manual crank handle functionality testing and verification records. |
| `REG-018` | **Cross-Over Testing** | Point crossover locking tests, detection verification, and joint maintainer sign-off. |
| `REG-019` | **Signal Failure Register** | In-depth signal defect logs, root causes, aspect failures, and rectifications. |
| `REG-020` | **Emergency Key Register** | Emergency station key custody, checkout authorization, and seal restoration. |

---

# 🟠 3. Infrastructure & Electrical Power Registers (4 Registers)

| Register Code | Register Name | Operational Scope & Tracked Information |
|---|---|---|
| `REG-015` | **Siding Key Register** | Siding key custody, shunting movements, locking confirmation, and return timestamps. |
| `REG-024` | **Traffic / Power Block** | Overhead equipment (OHE) power blocks, track shadow blocks, and granting authority. |
| `REG-031` | **Petty Repairs** | Station physical infrastructure defects, water/electrical issues, and repair status. |
| `REG-035` | **Power Supply & DG Log** | Grid power availability, generator running hours, fuel consumption, and battery status. |

---

# 🔴 4. Safety & Inspection Engine (4 Registers)

| Register Code | Register Name | Operational Scope & Tracked Information |
|---|---|---|
| `REG-009` | **Fog Signalman Deployment** | Detonator placement, fog signalmen roster, visibility checks, and testing records. |
| `REG-010` | **Night Inspection Register** | Surprise night inspections by officers, staff alertness, and safety compliance checks. |
| `REG-013` | **Inspection & Observations** | Regulatory inspections, irregularities found, and corrective actions taken. |
| `REG-025` | **Safety Meeting Register** | Monthly safety council deliberations, agenda points, and staff attendance. |

---

# 🚦 5. Train Working Authorities Hub (22 Standardized Authorities)

The system includes dedicated digital generation and logging for all **22 Indian Railways operational authorities**:

| Authority Code | Standard Form | Operational Purpose |
|---|---|---|
| `AUTH-001` | **T/369-3b** | Advance Authority to Pass Defective Signal (Descriptive) |
| `AUTH-002` | **T/369-3b (ON)** | Authority to Pass Signal at 'ON' Position |
| `AUTH-003` | **T/409** | Caution Order (Speed Restrictions & Section Directives) |
| `AUTH-004` | **T/509** | Authority to Receive Train on Obstructed Line |
| `AUTH-005` | **T/510** | Authority to Receive Train on Non-Signalled Line |
| `AUTH-006` | **T/511** | Authority to Start Train from Non-Signalled Line |
| `AUTH-007` | **T/512** | Authority to Start Train from Line with Common Starter |
| `AUTH-008` | **T/A 602** | Authority for Relief Engine/Train to Enter Block Section |
| `AUTH-009` | **T/C 602** | Authority to Dispatch Train during Total Failure of Communications |
| `AUTH-010` | **TFC-1 / TFC-2** | Line Clear Inquiry during Communication Failure |
| `AUTH-011` | **T/D 602** | Authority for Temporary Single Line (TSL) Working on Double Line |
| `AUTH-012` | **T/806** | Shunting Order (Station Yard and Block Section Shunting) |
| `AUTH-013` | **Written Memo** | Authority to Pass Defective Starter Signal |
| `AUTH-014` | **T/C 912** | Authority to Proceed without Line Clear in Automatic Block Territory |
| `AUTH-015` | **T/A 912** | Relief Engine Authority into Automatic Block Section |
| `AUTH-016` | **T/D 912** | Prolonged Failure Authority in Automatic Block System |
| `AUTH-017` | **T/B 1425** | Line Clear Inquiry Reply Message |
| `AUTH-018` | **T/A 1425 / T/B 1425** | Paper Line Clear Ticket (UP / DOWN) |
| `AUTH-019` | **Track Notice** | Maintenance Trolley Notice |
| `AUTH-020` | **T/1518** | Motor Trolley Permit for Running in Block Section |
| `AUTH-021` | **S&T T/351** | S&T Disconnection and Reconnection Memo |
| `AUTH-022` | **Movement Log** | Train Movement Log (Live Event Tracking) |

---

# ⭐ Centralized Dynamic Reports Engine

The **Dynamic Reports Module** brings records from across all operational registers and authorities into a single, unified reporting interface:

- 🔍 **Real-Time Cross-Register Search**: Search by train number, staff ID, or keywords across all operational records.
- 📅 **Flexible Date Filtering**: Select today, the last 3 days, or custom operational date ranges.
- 📄 **Official PDF Export**: Multi-page formatted reports with railway headings and page numbers.
- 📊 **Excel Export (.xlsx)**: Spreadsheet-compatible data export for analysis and archiving.
- 📋 **CSV Export**: Standard comma-separated data format for external integrations.
- 🖨️ **Direct Printing**: Print reports directly from the application workspace.
- 🖱️ **Universal Touchpad & Mouse Drag Scrolling**: Effortlessly scroll wide data tables with touchpad horizontal gestures or mouse dragging.

---

# ⚡ Quick Start: How to Run the Application

> 📖 **For a detailed beginner guide on clean laptops, see [STEPS_TO_RUN.md](file:///c:/Users/Asus/Gamma/TMSfinal1/STEPS_TO_RUN.md).**

### 1. Prerequisites (Takes 2 Minutes)
Install the free **[.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)** on your laptop.

### 2. Database Setup (Docker or Local SQL Server)
- **Docker Desktop (Recommended)**:
  ```cmd
  docker compose up -d
  ```
  Then restore the database:
  ```powershell
  .\docker\database\restore_databases.ps1
  ```
- **Local SQL Server**:
  Restore the two `.bak` files from `docker\database\backups\` using SSMS.

### 3. Launch the Application
- **Method 1 (Double-Click)**: Double-click **`RUN-TMS.bat`** in the project folder.
- **Method 2 (Command Line)**:
  ```cmd
  dotnet run --project src\TMS.UI
  ```

---

# 🔑 Authenticated Login Credentials

The system includes pre-configured staff and administrative accounts:

### 🛡️ Administrator Portal (Admin Login Tab)
- **Username**: `admin`
- **Password**: `Admin@123`
*(Features: User account directory, activation/deactivation, password audit logs, security policies)*

### 🚆 Station Master / Operator Portal (User Login Tab)
| Staff Name | Username | Password | Operational Role |
|---|---|---|---|
| **Sashank** | `sas` | `sas123` | Station Master / Operating (Full Register & Authority Access) |
| **Varma** | `var` | `var123` | Station Master (Traffic Operations) |
| **Akshaya** | `akki` | `akki123` | Operations Controller |

*(Self-service password recovery is supported via the **Forgot Password** link with mobile verification).*

---

# 📁 Project Directory Structure

```text
📦 TMSfinal1
│
├── 📂 src
│   ├── 📂 TMS.Core                # Business models, SessionManager, PBKDF2 PasswordHasher
│   ├── 📂 TMS.Data                # Microsoft.Data.SqlClient, DatabaseHelper, AuthService, Repositories
│   └── 📂 TMS.UI                  # Avalonia UI 11 Desktop Suite (Views, ViewModels, Styles, Assets)
│       ├── 📂 Views
│       │   ├── 📂 Authorities     # 22 Train Working Authority Forms (AUTH-001 to AUTH-022)
│       │   ├── LoginFormView.axaml
│       │   ├── AdminDashboardView.axaml
│       │   ├── UserDashboardView.axaml
│       │   ├── MainView.axaml
│       │   └── TrainWorkingHubView.axaml
│       └── appsettings.json
│
├── 📂 docker                      # SQL Server container configurations & automated restore scripts
│   └── 📂 database
│       ├── 📂 backups             # Original .bak database files (TMS_2024_New.bak, TrainManagementDB.bak)
│       └── restore_databases.ps1
│
├── 📂 documentation               # MIGRATION_MATRIX.md and compliance docs
├── 📄 RUN-TMS.bat                 # 1-Click launcher script for Windows evaluators
├── 📄 STEPS_TO_RUN.md             # Simplified run instructions for clean laptops
├── 📄 docker-compose.yml          # Container configuration for Microsoft SQL Server
├── 📄 TMS.CrossPlatform.sln       # Visual Studio / .NET CLI solution file
└── 📄 README.md                   # Main documentation
```

---

# 🛠️ Technology Stack

| Technology | Purpose |
|---|---|
| **C# 12** | Core programming language |
| **.NET 8 (LTS)** | Cross-platform runtime and framework |
| **Avalonia UI 11** | Modern, hardware-accelerated cross-platform desktop UI framework |
| **Microsoft SQL Server 2025** | High-performance relational database (Docker / local) |
| **Microsoft.Data.SqlClient** | Secure parameterized database access layer |
| **PBKDF2 Cryptography** | Salted cryptographic password security (`Rfc2898DeriveBytes`) |
| **QuestPDF & EPPlus** | Native multi-page PDF generation & Excel spreadsheet engine |
| **Docker Compose** | Declarative database container management and automated restore |

---

<div align="center">

# 🚆 INDIAN RAILWAYS — TRAIN MANAGEMENT SYSTEM

### *Engineered for Operational Safety, Digital Record Management, and Centralized Governance.*

<br/>

**30 Station Registers • 22 Train Working Authorities • Centralized SQL Server • Dynamic Reports**

<br/>

© 2026 Indian Railways • All Rights Reserved

</div>
