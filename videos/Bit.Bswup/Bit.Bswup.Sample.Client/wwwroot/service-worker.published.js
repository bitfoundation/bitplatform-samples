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

self.prerenderMode = 'none'; // Demo: https://adminpanel.bitplatform.dev/ (No-Prerendering + Offline support)

// On apps with Prerendering enabled, to have the best experience for the end user un-comment one of the following lines:
// self.prerenderMode = 'always'; // Demo: https://sales.bitplatform.dev/ (Always show pre-render without offline support)
// self.prerenderMode = 'initial'; // Demo: https://todo.bitplatform.dev/ (Pre-Render on first site visit + Offline support)

self.enableIntegrityCheck = false;

self.importScripts('_content/Bit.Bswup/bit-bswup.sw.js');