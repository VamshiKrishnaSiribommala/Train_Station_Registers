<div align="center">

# 🚆 Train Station Digital Registers System

**Smart Digital Solution for Railway Register Management**

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](#)
[![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](#)
[![SQL Server](https://img.shields.io/badge/SQLServer-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](#)
[![Windows Forms](https://img.shields.io/badge/Windows_Forms-0078D4?style=for-the-badge&logo=windows&logoColor=white)](#)

*A comprehensive desktop application designed to digitize and maintain 41 distinct operational registers for modern train stations.*

</div>

<br>

<div align="center">
  <img src="https://via.placeholder.com/800x450/1e1e1e/ffffff?text=Application+Screenshot+Here" alt="Application Interface" width="100%" style="border-radius: 10px; box-shadow: 0 4px 8px rgba(0,0,0,0.2);">
  <br><br>
  <i>(👉 Tip: Replace the placeholder image above with an actual screenshot of your application interface)</i>
</div>

<br>

## ✨ System Modules (41 Registers)

<p align="center">
  <i>Indian Railways - Station Registers Management</i>
</p>

<table>
  <tr>
    <td align="center" width="50%" style="padding: 20px;">
      <h3>🔵 OPERATIONAL LIST</h3>
      <p><b>(14 Registers)</b></p>
      <p>Complete management of daily operations, staff, and train movements.</p>
    </td>
    <td align="center" width="50%" style="padding: 20px;">
      <h3>🟢 MAINTENANCE SUB</h3>
      <p><b>(13 Registers)</b></p>
      <p>Tracking of regular upkeep, scheduled servicing, and asset care.</p>
    </td>
  </tr>
  <tr>
    <td align="center" style="padding: 20px;">
      <h3>🟠 INFRASTRUCTURE SUB</h3>
      <p><b>(6 Registers)</b></p>
      <p>Logs for physical station assets, repairs, and structural tracking.</p>
    </td>
    <td align="center" style="padding: 20px;">
      <h3>🔴 SAFETY LIST</h3>
      <p><b>(7 Registers)</b></p>
      <p>Critical tracking of safety standards, incidents, and security rules.</p>
    </td>
  </tr>
</table>

## 🚀 Setup Instructions

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/VamshiKrishnaSiribommala/Train_Station_Registers.git
```

### 2️⃣ Prerequisites

- **Visual Studio** (2019 or later recommended)
- **SQL Server** (Express edition is sufficient)
- **SSMS** (SQL Server Management Studio) for database management

### 3️⃣ Setup the Database

> **📥 Request Database Backup (.bak):**
> **[👉 Click Here to Request Database Access](https://github.com/VamshiKrishnaSiribommala/Train_Station_Registers/issues/new?title=Database+Access+Request&body=Hello!%0A%0AI+would+like+to+request+access+to+the+database+backup+(.bak)+file+for+the+Train+Station+Registers+project.%0A%0AThank+you!)**
> *(This will open an automatic access request that notifies the author)*

**Restore Instructions:**
1. Open SQL Server Management Studio (SSMS).
2. Right-click **Databases** ➔ **Restore Database...**
3. Select **Device** ➔ Browse and select the downloaded `.bak` file.
4. Click **OK** to restore.

### 4️⃣ Configure Connection Details

Update the database connection string. Open your configuration/`App.config` and ensure the string aligns with your local setup:

```xml
Data Source=localhost\SQLEXPRESS;
Initial Catalog=TMS_2024_New;
Integrated Security=True;
TrustServerCertificate=True;
```

### 5️⃣ Run the Application

1. Open `TMSfinal1.sln` or `TMSfinal1.slnx` in Visual Studio.
2. Press <kbd>F5</kbd> to build and run the application.

## 📁 Project Architecture

```plaintext
📦 Train_Station_Registers
 ┣ 📂 TMSfinal1
 ┃ ┣ 📂 Forms             # UI forms for all 41 registers
 ┃ ┣ 📂 Resources         # Application assets & icons
 ┃ ┣ 📄 ThemeManager.cs   # UI Themes (Dark mode, flicker-free rendering)
 ┃ ┗ 📄 App.config        # Configuration and Connection Strings
 ┗ 📄 TMSfinal1.sln       # Visual Studio Solution File
```

<details>
<summary><b>⚠️ Important Build Notes</b></summary>
<br>
Note that the directories <code>bin/</code>, <code>obj/</code>, and <code>.vs/</code> are excluded from version control. They will be auto-generated locally upon your first build. Ensure your SQL Server is running before executing!
</details>

## 🔮 Future Enhancements

- [ ] 🌐 **Web-based Portal** for remote access
- [ ] 📱 **Mobile Application** integration for staff on the go
- [ ] 🔐 **Role-based Authentication** system
- [ ] ☁️ **Cloud Database Support** (Azure/AWS)


