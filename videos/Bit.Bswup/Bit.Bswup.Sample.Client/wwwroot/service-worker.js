self.assetsInclude = [];

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
    /\/jobs\//,
    /\/core\//,
    /\/healthchecks-ui/,
    /\/healthz/,
    /\/swagger/,
    /\/signin-/,
    /\/.well-known/,
    /\/sitemap.xml/
];

self.prerenderMode = 'initial';    // Demo: https://todo.bitplatform.dev/       (Pre-Render on first site visit + No pre-rendering for the next times with offline support)
// self.prerenderMode = 'none';    // Demo: https://adminpanel.bitplatform.dev/ (No-Prerendering + Offline support)
// self.prerenderMode = 'always';  // Demo: https://sales.bitplatform.dev/      (Always pre-rendering without offline support. )

self.enableIntegrityCheck = false;

self.importScripts('_content/Bit.Bswup/bit-bswup.sw.js');