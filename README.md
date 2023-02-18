# DaartAds C# library
You can use this library to access the DaartAds APIs.

## Requirements
- NewtonSoft JSON [NewtonSoft](https://json.net)

## Installation

#### You may install this library using the NuGet Package installer.

 #### Manual installation:
 - Download ```DaartAds.dll``` from the most recent release (current [```1.0.1```](https://github.com/daart-agency/DaartAds-CS/releases/tag/1.0.1)).
 - Go to your project > Dependencies > Add Project Reference > Browse > Browse Button (Bottom right corner).
 - Add ```DaartAds.dll``` to your project.
## Usage
```cs
using Javadi.DaartAgency;

var ads = new DaartAds(YOUR_API_KEY);

// For get ads:
ads.GetAds() /* It will then return a list with Ad Details. */
```