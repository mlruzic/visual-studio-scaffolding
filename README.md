# Scaffolder
Simple scaffolder written as a Visual Studio extension to speed up some mudane tasks in a daily life :)

## Usage
After installing extension a new item, "Scaffold new table", will become available in context menu on a modules in solution explorer.

Result of the sacffolding a new "Hit" table:

```
Scaffolding started...
Creating file: Api\Hit\HitIo.cs
Creating file: Api\Hit\HitController.cs
Creating file: DataAccess\HitSqlProvider.cs
Creating file: DataAccess\IHitProvider.cs
Creating file: DataAccess\SqlScripts\Create.Procedure.HitDelete.sql
Creating file: DataAccess\SqlScripts\Create.Procedure.HitGet.sql
Creating file: DataAccess\SqlScripts\Create.Procedure.HitInsert.sql
Creating file: DataAccess\SqlScripts\Create.Procedure.HitUpdate.sql
Creating file: DataAccess\SqlScripts\Create.Schema.Analytics.sql
Creating file: DataAccess\SqlScripts\Create.Table.Hit.sql
Creating file: Models\HitModel.cs
Creating file: Service\Hit\Hit.cs
Creating file: Service\Hit\HitRepository.cs
Creating file: Service\Hit\IHitRepository.cs
Creating file: AnalyticsModule.cs
Successfully scaffolded 15 files
```

You can modify or create new templates in `Tools -> Options -> Scaffolder`
