# Introduction
Favorite Cakes - Built with:
https://get.asp.net/ ASP.NET Core and C# for cross-platform server-side code
https://angular.io/ Angular and TypeScript for client-side code
http://getbootstrap.com/ Bootstrap for layout and styling


# Getting Started
Angular CLI integration. In development mode, there's no need to run ng serve. It runs in the background automatically, so your client-side resources are dynamically built on demand and the page refreshes when you modify any file.
Efficient production builds. In production mode, development-time features are disabled, and your dotnet publish configuration automatically invokes ng build to produce minified, ahead-of-time compiled JavaScript files.
The ClientApp subdirectory is a standard Angular CLI application. If you open a command prompt in that directory, you can run any ng command (e.g.,ng test), or use npm to install extra packages into it.

- Install Node.js
- Open the ClientApp subdirectory in a command prompt then run npm install.
- You can then run the app in IIS Express via visual studio.

If you want to you can run Angular CLI server independently of asp.net core process to get rid of 10sec startup whenever stopping to change c# code:
From the ClientApp subdirectory run the command 'npm start'
In your Startup.cs class, replace the spa.UseAngularCliServer invocation with the following:
spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");