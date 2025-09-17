self.assetsInclude = [];
self.assetsExclude = [];
self.externalAssets = [
    {
        "url": "/"
    },
    {
        url: "_framework/blazor.web.js"
    },
    {
        url: "Bit.Bswup.Sample.styles.css"
    },
    {
        url: "Bit.Bswup.Sample.Client.bundle.scp.css"
    }
];

self.serverHandledUrls = [
    /\/api\//,
    /\/odata\//,
    /\/core\//,
    /\/hangfire/,
    /\/healthchecks-ui/,
    /\/healthz/,
    /\/swagger/,
    /\/signin-/,
    /\/.well-known/,
    /\/sitemap.xml/,
    /\/sitemap_index.xml/
];

// self.mode = 'FullOffline'; // Traditional PWA app that **first** downloads all assets and **then** runs the app.
// This ensures the app won't break if network connectivity is lost and the user navigates to a new page requiring lazy-loaded JS/WASM/image files.
// Recommended if the app primarily uses PWA for offline support and has local/offline database such as IndexedeDB or SQLite (Checkout Bit.Besql)
// Demo: https://todo-offline.bitplatform.cc/offline-database-demo

self.mode = 'NoPrerender'; // Modern PWA app that **starts immediately** and lazy-loads assets as needed.
// If network connectivity is lost and the user navigates to a new page requiring lazy-loaded JS/WASM/image files, the app might break.
// Recommended if the app uses PWA for benefits other than offline support, such as installability, push notifications, etc.
// Demo: https://adminpanel.bitplatform.dev/

// self.mode = 'InitialPrerender'; // If pre-rendering is enabled in the `Server.Web` configuration, this mode fetches the site's document only on the first load of the app.
// Useful for SEO-friendly apps, and to display content on the initial visit while files download. Subsequent visits avoid server pressure from pre-rendering.
// Demo: https://todo.bitplatform.dev/

// self.mode = 'AlwaysPrerender'; // If pre-rendering is enabled in the Server.Web configuration, this mode fetches the site's document on every load of the app.
// The reason behind fetching the document on every app load is that Blazor WebAssembly's runtime might takes some time to kick in on low-end mobile devices,
// so if the user refreshes the page or visits a new page, it shows the pre-rendered document while the Blazor WebAssembly runtime is loading.
// Downside: Increases server load due to frequent pre-rendering.
// Demo: https://sales.bitplatform.dev/

self.enableIntegrityCheck = false;

self.importScripts('_content/Bit.Bswup/bit-bswup.sw.js');