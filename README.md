# Log4Net Azure Benchmark

A small and quick project that makes benchmarks between Azure assets for logging.
Tests log storage performances on console, file system, Azure Storage Blob, Azure Storage blob with append, Azure Storage Tables.
The program launch a series of fake exceptions and log them into Log4Net.
Log4Net appenders store into filesystem, console, Azure storage blob or tables and log timers for benchmarking.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

.Net Core 2.2 Runtime with Visual Studio, Rider or anything else.
Azure assets : Azure Storage account for appender tests.

```
Blob Storage
Azure Tables
File System
```

### Installing

Load solution with SLN with Rider or Visual Studio.
Restore nugets-packages for third party libraries.

Configure Log4Net roots appender
```
<root>
        <level value="ALL" />
        <appender-ref ref="console" />
       <!-- <appender-ref ref="file" /> -->
       <!--  <appender-ref ref="AzureBlobAppender" /> -->
       <!--  <appender-ref ref="AzureAppendBlobAppender" /> -->
       <!--  <appender-ref ref="AzureTableAppender" /> -->
</root>
```
Replace [CONNECTION_STRING] with the real connection string provided by Azure Storage (see on Azure Portal).
<!-- Azure Blob -->
    <appender name="AzureBlobAppender" type="log4net.Appender.Azure.Core.AzureBlobAppender, log4net.Appender.Azure.Core">
        <param name="ContainerName" value="logs"/>
        <param name="DirectoryName" value="append"/>
        <!-- You can either specify a connection string or use the ConnectionStringName property instead -->
        <param name="ConnectionString" value="[CONNECTION_STRING]"/>
    </appender>
    <appender name="AzureAppendBlobAppender" type="log4net.Appender.Azure.Core.AzureAppendBlobAppender, log4net.Appender.Azure.Core">
        <param name="ContainerName" value="logs"/>
        <param name="DirectoryName" value="logs"/>
        <!-- You can either specify a connection string or use the ConnectionStringName property instead -->
        <param name="ConnectionString" value="[CONNECTION_STRING]"/>
    </appender>
    <!-- Azure Table -->
    <appender name="AzureTableAppender" type="log4net.Appender.Azure.Core.AzureTableAppender, log4net.Appender.Azure.Core">
        <param name="TableName" value="logsTable"/>
        <param name="ConnectionString" value="[CONNECTION_STRING]"/>
        <!-- You can specify this to make each LogProperty as separate Column in TableStorage, 
         Default: all Custom Properties were logged into one single field -->
        <param name="PropAsColumn" value="true" />
        <param name="PartitionKeyType" value="LoggerName" />
    </appender>

Launch CLI program.

The program simulate many Exeptions and log them into Log4Net and resitute executions times.

## Running the tests

A simple test launch a small exception and log in Log4Net to test all appenders.
It can be launch from VSTest or Rider Test execution.

## Deployment

Can be execute on a local workstation or a Windows / Mac / Linux servers thank to .Net Core runtime.
A azure storage account is mandatory to run appenders benchmarks.

## Built With

* [Apache Log4Net](https://logging.apache.org/log4net/) - The logging library
* [Log4Net.Azure.Core](https://github.com/GrzegorzBlok/log4net.Azure.Core) - Log4Net Appender for Azure storage
* [AzureStorage](https://www.nuget.org/packages/WindowsAzure.Storage/) - Azure Storage SDK
* [.Net Core](https://docs.microsoft.com/fr-fr/dotnet/core/) - Runtime and librairies
* [JetBrains Rider](https://www.jetbrains.com/fr-fr/rider/) - .Net Core IDE

## Versioning

We use [SemVer](http://semver.org/) for versioning.

## Authors

* **Alexandre JULIEN** - *Initial work* - [Peppermint Consulting](https://github.com/alexandrejulien)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

