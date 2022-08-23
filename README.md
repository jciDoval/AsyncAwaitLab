# C# Async & Await - LAB

## Pre-requisites

- VS Code
- .Net 6.0 SDK -> [SDK 6.0.400](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [k6.io](https://k6.io/docs/getting-started/installation/) -> load testing  tool

## Verify .Net installation

Fist of all:
- Check .net is installed.
    - Open command line and execute -> dotnet --version
    - This command write the version of .net 6.0.X
- dotnet --list-sdks
    - Show the sdks installed on the machine.
- dotnet --list-runtimes
    - Show the runtimes installed on the machine.

## Create new Api Project

- Check all the different kinds of projects that we can create.
    - dotnet new --list

- Create a new API Project
    - dotnet new webapi -n AsyncAwaitLab

## VS Code Tunning Extensions

- C#
- C# Extensions
- Material Icon Theme

## Run the API

- Execute dotnet run inside the AsyncAwaitLab folder
- Press F5 in Vs Code.

## Load Test

- Move to test folder and execute:
    - k6 run .\AsyncStress.js -> Async way.
    - k6 run .\SyncStress.js -> Sync way.
- Analyze the difference between both solutions.
