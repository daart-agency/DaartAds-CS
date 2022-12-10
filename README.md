# DaartAds C# library
You can use this library to access the DaartAds APIs.

## Requirements
- NewtonSoft JSON [NewtonSoft](https://json.net)

## Installation

#### You may install this library using the NuGet Package installer.

 #### Manual installation:
 - To your project, clone the ```DaartAds.dll``` file.
 - Dependencies > Add Project Reference > Browse > Browse Button (Bottom right corner) 
## Usage
```cs
using Javadi.DaartAgency;

var ads = new DaartAds(YOUR_API_KEY);

// For get ads:
ads.GetAds(SIZE_ID) /* It will then return a list with Ad Details. */

// For Make CallBack Url
ads.GetAdCallBack(CLICK_ID,YOUR_ID,CHOSEN_AD_Size)
```

## AdSize
| SizeID | Width * Height |
|--|--|
| 1  | 720*480 |
| 2  | 728*90  |
| 3  | 480*320 |
| 4  | 492*328 |
| 5  | 468*60  |
| 6  | 360*240 |
| 7  | 320*100 |
| 8  | 320*50  |
| 9  | 300*250 |
| 10 | 295*98  |
| 11 | 160*600 |
