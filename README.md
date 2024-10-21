# MAUI Core API

This project is a .NET MAUI application that integrates with a Core API backend. It is designed to work across multiple platforms, including Android, iOS, macOS, and Windows, providing a modern UI with cross-platform support.

## Table of Contents
- [Features](#features)
- [Requirements](#requirements)
- [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Screenshots](#Screenshots)
- [License](#license)

## Features
- Cross-platform mobile and desktop support with .NET MAUI.
- Core API integration to handle backend services.
- Responsive and adaptive UI.
- Secure API calls with token-based authentication (optional).
- Modular architecture for easy code maintainability.

## Requirements
- .NET SDK 6.0 or later
- .NET MAUI workload installed
- Visual Studio 2022 (version 17.3 or higher) with the MAUI workload
- Platforms: Android, iOS, Windows, macOS

## Installation

1. **Install dependencies**:
   Open the solution file `MAUI_CoreAPI.sln` in Visual Studio and allow it to restore the necessary NuGet packages.

2. **Platform-specific setup**:
   - **Android**: Ensure you have an Android SDK installed.
   - **iOS**: You will need a macOS device with Xcode installed.
   - **Windows**: Windows SDK should be installed by default.
   - **macOS**: Ensure macOS SDK and related tools are installed.

3. **Set up API keys** (if required):
   If your Core API requires API keys, place them in the appropriate configuration files, such as `appsettings.json` or environment variables.

## Usage

1. Open the project in Visual Studio 2022.
2. Choose the target platform (Android, iOS, Windows, macOS) from the toolbar.
3. Build and run the project.
4. The app should now be running on your chosen platform, making calls to the Core API as per the app's functionality.

## API Endpoints

Below are examples of how to use the Core API endpoints in your app. You can replace these with the actual API endpoints used in your project.

### Example GET request
```csharp
HttpClient client = new HttpClient();
var response = await client.GetAsync("https://api.example.com/endpoint");
```

### Example POST request
```csharp
HttpClient client = new HttpClient();
var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
var response = await client.PostAsync("https://api.example.com/endpoint", content);
```

## Screenshots
![Screenshot (54)](https://github.com/user-attachments/assets/88cba90f-e627-491b-a770-4ca4f96a9926)
![Screenshot (55)1](https://github.com/user-attachments/assets/3f71344f-2e6a-4c12-84ed-8b6fc764ade9)
![Screenshot (56)](https://github.com/user-attachments/assets/2ca53dd8-1762-4b8e-8298-7176c34c33de)



![Screenshot (59)](https://github.com/user-attachments/assets/6c5bd8aa-9da3-44b5-8116-b8219801004b)


## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.




