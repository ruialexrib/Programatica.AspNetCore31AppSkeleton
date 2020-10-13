[![Build Status](https://programaticasoftware.visualstudio.com/Programatica.AspNetCore31AppSkeleton/_apis/build/status/ruialexrib.Programatica.AspNetCore31AppSkeleton?branchName=main)](https://programaticasoftware.visualstudio.com/Programatica.AspNetCore31AppSkeleton/_build/latest?definitionId=20&branchName=main) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

# Programatica.AspNetCore31AppSkeleton
A solid skeleton for building out real features with asp.net core, adminlte, repository pattern, entity-framework migrations and syncfusion components.

:rocket: **Sky Rocket your new app !!!** :rocket:

<img src="https://github.com/ruialexrib/Programatica.AspNetCore31AppSkeleton/blob/main/logo.png?raw=true" width="500">

### Migrations

##### Create migration
```
Add-Migration InitialCreate -StartupProject Programatica.AspNetCore31AppSkeleton.Data.Migrations.Bootstrap -Project Programatica.AspNetCore31AppSkeleton.Data.Migrations -Verbose
```
##### Update database
```
Update-Database -StartupProject Programatica.AspNetCore31AppSkeleton.Data.Migrations.Bootstrap -Project Programatica.AspNetCore31AppSkeleton.Data.Migrations -Verbose
```

### Demo

[Im running inside a docker, hosted in a raspberrypi4, connected to an azure database... how cool is that ?!](http://ruialexrib.ddns.net:8088)
