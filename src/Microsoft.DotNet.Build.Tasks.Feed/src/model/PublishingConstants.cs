// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.DotNet.Build.Tasks.Feed.Model;
using Microsoft.DotNet.VersionTools.BuildManifest.Model;
using System.Collections.Generic;

namespace Microsoft.DotNet.Build.Tasks.Feed.Model
{
    public class PublishingConstants
    {
        public static readonly string LegacyDotNetBlobFeedURL = "https://dotnetfeed.blob.core.windows.net/dotnet-core/index.json";
        public static readonly string ExpectedFeedUrlSuffix = "index.json";

        // Matches package feeds like
        // https://dotnet-feed-internal.azurewebsites.net/container/dotnet-core-internal/sig/dsdfasdfasdf234234s/se/2020-02-02/darc-int-dotnet-arcade-services-babababababe-08/index.json
        public static readonly string AzureStorageProxyFeedPattern =
            @"(?<feedURL>https://([a-z-]+).azurewebsites.net/container/(?<container>[^/]+)/sig/\w+/se/([0-9]{4}-[0-9]{2}-[0-9]{2})/(?<baseFeedName>darc-(?<type>int|pub)-(?<repository>.+?)-(?<sha>[A-Fa-f0-9]{7,40})-?(?<subversion>\d*)/))index.json";

        // Matches package feeds like the one below. Special case for static internal proxy-backed feed
        // https://dotnet-feed-internal.azurewebsites.net/container/dotnet-core-internal/sig/dsdfasdfasdf234234s/se/2020-02-02/darc-int-dotnet-arcade-services-babababababe-08/index.json
        public static readonly string AzureStorageProxyFeedStaticPattern =
            @"(?<feedURL>https://([a-z-]+).azurewebsites.net/container/(?<container>[^/]+)/sig/\w+/se/([0-9]{4}-[0-9]{2}-[0-9]{2})/(?<baseFeedName>[^/]+/))index.json";

        // Matches package feeds like
        // https://dotnetfeed.blob.core.windows.net/dotnet-core/index.json
        public static readonly string AzureStorageStaticBlobFeedPattern =
            @"https://([a-z-]+).blob.core.windows.net/[^/]+/index.json";

        // Matches package feeds like
        // https://pkgs.dev.azure.com/dnceng/public/_packaging/public-feed-name/nuget/v3/index.json
        // or https://pkgs.dev.azure.com/dnceng/_packaging/internal-feed-name/nuget/v3/index.json
        public static readonly string AzDoNuGetFeedPattern =
            @"https://pkgs.dev.azure.com/(?<account>[a-zA-Z0-9]+)/(?<visibility>[a-zA-Z0-9-]+/)?_packaging/(?<feed>.+)/nuget/v3/index.json";

        #region Target Channel Configs
        private const string FeedForChecksums = "https://dotnetclichecksums.blob.core.windows.net/dotnet/index.json";
        private const string FeedForInstallers = "https://dotnetcli.blob.core.windows.net/dotnet/index.json";

        private const string FeedInternalForChecksums = "https://dotnetclichecksumsmsrc.blob.core.windows.net/dotnet/index.json";
        private const string FeedInternalForInstallers = "https://dotnetclimsrc.blob.core.windows.net/dotnet/index.json";

        private const string FeedGeneralTesting = "https://pkgs.dev.azure.com/dnceng/public/_packaging/general-testing/nuget/v3/index.json";
        private const string FeedGeneralTestingSymbols = "https://pkgs.dev.azure.com/dnceng/public/_packaging/general-testing-symbols/nuget/v3/index.json";

        private const string FeedDotNetExperimental = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-experimental/nuget/v3/index.json";
        private const string FeedDotNetExperimentalSymbols = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-experimental-symbols/nuget/v3/index.json";

        private const string FeedDotNetEngShipping = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-eng/nuget/v3/index.json";
        private const string FeedDotNetEngTransport = FeedDotNetEngShipping;
        private const string FeedDotNetEngSymbols = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-eng-symbols/nuget/v3/index.json";

        private const string FeedDotNetToolsShipping = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json";
        private const string FeedDotNetToolsTransport = FeedDotNetToolsShipping;
        private const string FeedDotNetToolsSymbols = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools-symbols/nuget/v3/index.json";

        private const string FeedDotNetToolsInternalShipping = "https://pkgs.dev.azure.com/dnceng/internal/_packaging/dotnet-tools-internal/nuget/v3/index.json";
        private const string FeedDotNetToolsInternalTransport = FeedDotNetToolsInternalShipping;
        private const string FeedDotNetToolsInternalSymbols = "https://pkgs.dev.azure.com/dnceng/internal/_packaging/dotnet-tools-internal-symbols/nuget/v3/index.json";

        private const string FeedDotNet31Shipping = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet3.1/nuget/v3/index.json";
        private const string FeedDotNet31Transport = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet3.1-transport/nuget/v3/index.json";
        private const string FeedDotNet31Symbols = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet3.1-symbols/nuget/v3/index.json";

        private const string FeedDotNet31InternalShipping = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet3.1-internal/nuget/v3/index.json";
        private const string FeedDotNet31InternalTransport = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet3.1-internal-transport/nuget/v3/index.json";
        private const string FeedDotNet31InternalSymbols = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet3.1-internal-symbols/nuget/v3/index.json";

        private const string FeedDotNet31BlazorShipping = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet3.1-blazor/nuget/v3/index.json";
        private const string FeedDotNet31BlazorTransport = FeedDotNet31BlazorShipping;
        private const string FeedDotNet31BlazorSymbols = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet3.1-blazor-symbols/nuget/v3/index.json";

        private const string FeedDotNet5Shipping = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5/nuget/v3/index.json";
        private const string FeedDotNet5Transport = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5-transport/nuget/v3/index.json";
        private const string FeedDotNet5Symbols = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5-symbols/nuget/v3/index.json";

        private const string FeedDotNet6Shipping = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet6/nuget/v3/index.json";
        private const string FeedDotNet6Transport = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet6-transport/nuget/v3/index.json";
        private const string FeedDotNet6Symbols = "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet6-symbols/nuget/v3/index.json";

        private const string FeedDotNet5InternalShipping = "https://pkgs.dev.azure.com/dnceng/internal/_packaging/dotnet5-internal/nuget/v3/index.json";
        private const string FeedDotNet5InternalTransport = "https://pkgs.dev.azure.com/dnceng/internal/_packaging/dotnet5-internal-transport/nuget/v3/index.json";
        private const string FeedDotNet5InternalSymbols = "https://pkgs.dev.azure.com/dnceng/internal/_packaging/dotnet5-internal-symbols/nuget/v3/index.json";

        public static readonly List<TargetChannelConfig> ChannelInfos = new List<TargetChannelConfig>() {
            // ".NET 5 Dev",
            new TargetChannelConfig(
                131,
                PublishingInfraVersion.All,
                "net5/dev",
                FeedDotNet5Shipping,
                FeedDotNet5Transport,
                FeedDotNet5Symbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET 6 Dev",
            new TargetChannelConfig(
                1296,
                PublishingInfraVersion.All,
                "net6/dev",
                FeedDotNet6Shipping,
                FeedDotNet6Transport,
                FeedDotNet6Symbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET 5" (public),
            new TargetChannelConfig(
                1299,
                PublishingInfraVersion.Next,
                akaMSChannelName: "net5",
                FeedDotNet5Shipping,
                FeedDotNet5Transport,
                FeedDotNet5Symbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET 5 Internal" (internal),
            new TargetChannelConfig(
                1300,
                PublishingInfraVersion.Next,
                akaMSChannelName: string.Empty,
                FeedDotNet5InternalShipping,
                FeedDotNet5InternalTransport,
                FeedDotNet5InternalSymbols,
                FeedInternalForChecksums,
                FeedInternalForInstallers,
                true),

            // ".NET 5 SDK 5.0.1xx" (public),
            new TargetChannelConfig(
                1297,
                PublishingInfraVersion.Next,
                akaMSChannelName: "net5/5.0.1xx/daily",
                FeedDotNet5Shipping,
                FeedDotNet5Transport,
                FeedDotNet5Symbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET 5 SDK 5.0.1xx Internal" (internal),
            new TargetChannelConfig(
                1298,
                PublishingInfraVersion.Next,
                akaMSChannelName: string.Empty,
                FeedDotNet5InternalShipping,
                FeedDotNet5InternalTransport,
                FeedDotNet5InternalSymbols,
                FeedInternalForChecksums,
                FeedInternalForInstallers,
                true),

            // ".NET 5 SDK 5.0.2xx" (public),
            new TargetChannelConfig(
                1518,
                PublishingInfraVersion.Next,
                akaMSChannelName: "net5/5.0.2xx/daily",
                FeedDotNet5Shipping,
                FeedDotNet5Transport,
                FeedDotNet5Symbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET 5 SDK 5.0.2xx Internal" (internal),
            new TargetChannelConfig(
                1519,
                PublishingInfraVersion.Next,
                akaMSChannelName: string.Empty,
                FeedDotNet5InternalShipping,
                FeedDotNet5InternalTransport,
                FeedDotNet5InternalSymbols,
                FeedInternalForChecksums,
                FeedInternalForInstallers,
                true),

            // ".NET Eng - Latest",
            new TargetChannelConfig(
                2,
                PublishingInfraVersion.All,
                "eng/daily",
                FeedDotNetEngShipping,
                FeedDotNetEngTransport,
                FeedDotNetEngSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET 5 Eng",
            new TargetChannelConfig(
                1495,
                PublishingInfraVersion.Next,
                "eng/net5",
                FeedDotNetEngShipping,
                FeedDotNetEngTransport,
                FeedDotNetEngSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET Eng - Validation",
            new TargetChannelConfig(
                9,
                PublishingInfraVersion.All,
                "eng/validation",
                FeedDotNetEngShipping,
                FeedDotNetEngTransport,
                FeedDotNetEngSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET 5 Eng - Validation",
            new TargetChannelConfig(
                1496,
                PublishingInfraVersion.Next,
                "eng/net5validation",
                FeedDotNetEngShipping,
                FeedDotNetEngTransport,
                FeedDotNetEngSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // "General Testing",
            new TargetChannelConfig(
                529,
                PublishingInfraVersion.All,
                "generaltesting",
                FeedGeneralTesting,
                FeedGeneralTesting,
                FeedGeneralTestingSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET Core Tooling Dev",
            new TargetChannelConfig(
                548,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNetToolsShipping,
                FeedDotNetToolsTransport,
                FeedDotNetToolsSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET Core Tooling Release",
            new TargetChannelConfig(
                549,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNetToolsShipping,
                FeedDotNetToolsTransport,
                FeedDotNetToolsSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET Internal Tooling",
            new TargetChannelConfig(
                551,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNetToolsInternalShipping,
                FeedDotNetToolsInternalTransport,
                FeedDotNetToolsInternalSymbols,
                FeedInternalForChecksums,
                FeedInternalForInstallers,
                true),

            // ".NET Core Experimental",
            new TargetChannelConfig(
                562,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNetExperimental,
                FeedDotNetExperimental,
                FeedDotNetExperimentalSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET Eng Services - Int",
            new TargetChannelConfig(
                678,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNetEngShipping,
                FeedDotNetEngTransport,
                FeedDotNetEngSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET Eng Services - Prod",
            new TargetChannelConfig(
                679,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNetEngShipping,
                FeedDotNetEngTransport,
                FeedDotNetEngSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET Core SDK 3.1.4xx",
            new TargetChannelConfig(
                921,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNet31Shipping,
                FeedDotNet31Transport,
                FeedDotNet31Symbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET Core SDK 3.1.4xx Internal",
            new TargetChannelConfig(
                922,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNet31InternalShipping,
                FeedDotNet31InternalTransport,
                FeedDotNet31InternalSymbols,
                FeedInternalForChecksums,
                FeedInternalForInstallers,
                true),

            // ".NET Core SDK 3.1.3xx",
            new TargetChannelConfig(
                759,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNet31Shipping,
                FeedDotNet31Transport,
                FeedDotNet31Symbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET Core SDK 3.1.3xx Internal",
            new TargetChannelConfig(
                760,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNet31InternalShipping,
                FeedDotNet31InternalTransport,
                FeedDotNet31InternalSymbols,
                FeedForChecksums,
                FeedForInstallers,
                true),

            // ".NET 3 Tools",
            new TargetChannelConfig(
                344,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNetEngShipping,
                FeedDotNetEngTransport,
                FeedDotNetEngSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET 3 Tools - Validation",
            new TargetChannelConfig(
                390,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNetEngShipping,
                FeedDotNetEngTransport,
                FeedDotNetEngSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET Core Tooling Dev",
            new TargetChannelConfig(
                548,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNetToolsShipping,
                FeedDotNetToolsTransport,
                FeedDotNetToolsSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET Core Tooling Release",
            new TargetChannelConfig(
                549,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNetToolsShipping,
                FeedDotNetToolsTransport,
                FeedDotNetToolsSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET Core 3.1 Dev",
            new TargetChannelConfig(
                128,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNet31Shipping,
                FeedDotNet31Transport,
                FeedDotNet31Symbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET Core 3.1 Release",
            new TargetChannelConfig(
                129,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNet31Shipping,
                FeedDotNet31Transport,
                FeedDotNet31Symbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET Core SDK 3.1.2xx",
            new TargetChannelConfig(
                558,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNet31Shipping,
                FeedDotNet31Transport,
                FeedDotNet31Symbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // "NET Core SDK 3.1.1xx",
            new TargetChannelConfig(
                560,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNet31Shipping,
                FeedDotNet31Transport,
                FeedDotNet31Symbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET Core SDK 3.1.3xx",
            new TargetChannelConfig(
                759,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNet31Shipping,
                FeedDotNet31Transport,
                FeedDotNet31Symbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET Core SDK 3.1.4xx",
            new TargetChannelConfig(
                921,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNet31Shipping,
                FeedDotNet31Transport,
                FeedDotNet31Symbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // ".NET Core SDK 3.1.3xx Internal",
            new TargetChannelConfig(
                760,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNet31InternalShipping,
                FeedDotNet31InternalTransport,
                FeedDotNet31InternalSymbols,
                FeedForChecksums,
                FeedForInstallers,
                true),

            // ".NET Core 3.1 Internal Servicing",
            new TargetChannelConfig(
                550,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNet31InternalShipping,
                FeedDotNet31InternalTransport,
                FeedDotNet31InternalSymbols,
                FeedForChecksums,
                FeedForInstallers,
                true),

            // ".NET Core SDK 3.1.2xx Internal",
            new TargetChannelConfig(
                557,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNet31InternalShipping,
                FeedDotNet31InternalTransport,
                FeedDotNet31InternalSymbols,
                FeedForChecksums,
                FeedForInstallers,
                true),

            // ".NET Core SDK 3.1.1xx Internal",
            new TargetChannelConfig(
                559,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNet31InternalShipping,
                FeedDotNet31InternalTransport,
                FeedDotNet31InternalSymbols,
                FeedForChecksums,
                FeedForInstallers,
                true),

            // ".NET Core SDK 3.1.4xx Internal",
            new TargetChannelConfig(
                922,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNet31InternalShipping,
                FeedDotNet31InternalTransport,
                FeedDotNet31InternalSymbols,
                FeedForChecksums,
                FeedForInstallers,
                true),

            // ".NET Core 3.1 Blazor Features",
            new TargetChannelConfig(
                531,
                PublishingInfraVersion.All,
                akaMSChannelName: string.Empty,
                FeedDotNet31BlazorShipping,
                FeedDotNet31BlazorTransport,
                FeedDotNet31BlazorSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // "VS 16.6",
            new TargetChannelConfig(
                1010,
                PublishingInfraVersion.All,
                string.Empty,
                FeedDotNetToolsShipping,
                FeedDotNetToolsTransport,
                FeedDotNetToolsSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // "VS 16.7",
            new TargetChannelConfig(
                1011,
                PublishingInfraVersion.All,
                string.Empty,
                FeedDotNetToolsShipping,
                FeedDotNetToolsTransport,
                FeedDotNetToolsSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // "VS 16.8",
            new TargetChannelConfig(
                1154,
                PublishingInfraVersion.All,
                string.Empty,
                FeedDotNetToolsShipping,
                FeedDotNetToolsTransport,
                FeedDotNetToolsSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // "VS 16.9",
            new TargetChannelConfig(
                1473,
                PublishingInfraVersion.All,
                string.Empty,
                FeedDotNetToolsShipping,
                FeedDotNetToolsTransport,
                FeedDotNetToolsSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),

            // "VS Master",
            new TargetChannelConfig(
                1012,
                PublishingInfraVersion.All,
                string.Empty,
                FeedDotNetToolsShipping,
                FeedDotNetToolsTransport,
                FeedDotNetToolsSymbols,
                FeedForChecksums,
                FeedForInstallers,
                false),
        };
        #endregion
    }
}
