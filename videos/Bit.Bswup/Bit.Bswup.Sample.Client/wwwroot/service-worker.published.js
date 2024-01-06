self.assetsInclude = [];
self.assetsExclude = [
    /Bit\.Bswup\.Demo\.Client\.styles\.css$/ // .NET 8 assets issue
];

self.externalAssets = [
    {
        "url": "/"
    }
];

self.serverHandledUrls = [
    /\/api\//,
    /\/odata\//,
    /\/jobs\//,
    /\/core\//,
    /\/signalr\//,
    /\/healthchecks-ui/,
    /\/healthz/,
    /\/swagger/
];

self.defaultUrl = "/";
self.caseInsensitiveUrl = true;
self.noPrerenderQuery = 'no-prerender=true';
self.isPassive = self.disablePassiveFirstBoot = true;

self.importScripts('_content/Bit.Bswup/bit-bswup.sw.js');