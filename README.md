# WpfDesigner
The WPF Designer from SharpDevelop

##Overview

 WpfDesigner is a set of Assemblys wich can be included in your Project to implement a XAML GUI Editor.
 
## Project Build Status

Branch | Status
--- | ---
*master* (Development) | [![Build status](https://ci.appveyor.com/api/projects/status/iqxeo16r8ff9qv66/branch/master?svg=true)](https://ci.appveyor.com/project/icsharpcode/WpfDesigner/branch/master) 


##System Requirements (running #Develop)

 - [.NET 4.5](http://www.microsoft.com/en-au/download/details.aspx?id=30653)

##Libraries and Integrated tools:

For Sample App:
* [Avalon Dock](http://avalondock.codeplex.com/)
* [Avalon Edit](https://github.com/icsharpcode/AvalonEdit)

##Download

[NuGet](https://www.nuget.org/packages/ICSharpCode.WpfDesigner/)

##Sample App
![Sample App](/screenshot.png?raw=true "Sample App")

##Infos for Pull Requests:

Please be aware, that we will not accept Pull Requests wich introduce new Dependecys (to UI DLLs) to the WPF Designer, because with them is not possible to Edit XAML Screens wich use these DLLs, when they for Example have different Versions!

######Copyright 2015 AlphaSierraPapa for the SharpDevelop team. SharpDevelop is distributed under the MIT license.
