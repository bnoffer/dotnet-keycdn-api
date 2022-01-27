using System;
namespace Com.KeyCDN.Api.Schemas
{
    public class Zone
    {
        public string id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string forcedownload { get; set; }
        public string cors { get; set; }
        public string gzip { get; set; }
        public string imgproc { get; set; }
        public string expire { get; set; }
        public string blockbadbots { get; set; }
        public string allowemptyreferrer { get; set; }
        public string blockreferrer { get; set; }
        public string securetoken { get; set; }
        public object securetokenkey { get; set; }
        public string securetokenip { get; set; }
        public string sslcert { get; set; }
        public object customsslkey { get; set; }
        public object customsslcert { get; set; }
        public string forcessl { get; set; }
        public string originurl { get; set; }
        public string cachemaxexpire { get; set; }
        public string cacheignorecachecontrol { get; set; }
        public string cacheignorequerystring { get; set; }
        public string cachehostheader { get; set; }
        public string cachekeyscheme { get; set; }
        public string cachekeyhost { get; set; }
        public object cachekeycookie { get; set; }
        public string cachekeydevice { get; set; }
        public string cachekeywebp { get; set; }
        public string cachebr { get; set; }
        public string cachecookies { get; set; }
        public string cachestripcookies { get; set; }
        public string cachexpullkey { get; set; }
        public string cachecanonical { get; set; }
        public string cacherobots { get; set; }
        public string cacheerrorpages { get; set; }
        public string dirlist { get; set; }
    }
}

