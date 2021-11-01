Imports AdvantageFramework.Database.Entities
Imports AdvantageFramework.Security.Classes
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Data.Entity.Core.Objects
Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Data.Services.Providers
Imports System.Data.SqlClient
Imports System.IO
Imports System.ServiceModel.Web
Imports System.Threading
Imports System.Web

Namespace AdvantageMobile.DataService.Expense

    <System.Serializable()> Public Class Methods

#Region " Constants "
        Private Const AssignmentLink As String = "{0} here to view this assignment."
        Private Const AlertLink As String = "{0} here to view this alert."
        Private Const ReviewLink As String = "{0} here to view this review."


#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Public FileSizeMax As Integer = 0
        Public currentWindowsIdentity As System.Security.Principal.WindowsIdentity

#End Region

#Region " Properties "

        Private Property _DataEntities As DataEntities
        Private Property _DataServiceUser As DataServiceUser
        Private Property _ConnectionString As String = ""
        Private Property _UserCode As String = ""
        Private Property _Path As String = ""

        Private Property _UserDomain As String = ""
        Private Property _UserName As String = ""
        Private Property _UserPassword As String = ""

        Public ReadOnly Property WebvantageWithClientPortalAssignmentLinkVerbiage As String
            Get
                Return String.Format(AssignmentLink, "Webvantage users click")
            End Get
        End Property
        Public ReadOnly Property WebvantageAssignmentLinkVerbiage As String
            Get
                Return String.Format(AssignmentLink, "Click")
            End Get
        End Property
        Public ReadOnly Property ClientPortalAssignmentLinkVerbiage As String
            Get
                Return String.Format(AssignmentLink, "Client Portal users click")
            End Get
        End Property

        Public ReadOnly Property WebvantageWithClientPortalAlertLinkVerbiage As String
            Get
                Return String.Format(AlertLink, "Webvantage users click")
            End Get
        End Property
        Public ReadOnly Property WebvantageAlertLinkVerbiage As String
            Get
                Return String.Format(AlertLink, "Click")
            End Get
        End Property
        Public ReadOnly Property ClientPortalAlertLinkVerbiage As String
            Get
                Return String.Format(AlertLink, "Client Portal users click")
            End Get
        End Property

        Public ReadOnly Property WebvantageWithClientPortalReviewLinkVerbiage As String
            Get
                Return String.Format(ReviewLink, "Webvantage users click")
            End Get
        End Property
        Public ReadOnly Property WebvantageReviewLinkVerbiage As String
            Get
                Return String.Format(ReviewLink, "Click")
            End Get
        End Property
        Public ReadOnly Property ClientPortalReviewLinkVerbiage As String
            Get
                Return String.Format(ReviewLink, "Client Portal users click")
            End Get
        End Property

#Region " Email properties "

        'Private Property ConnectionString As String = String.Empty
        'Private Property UserCode As String = String.Empty
        Private Property Alert As AdvantageFramework.Database.Entities.Alert
        Private Property Subject As String = "[New Alert] "
        Private Property AppName As String = "Expense"
        Private Property SupervisorApprovalComment As String = String.Empty
        Private Property ExcludeAttachments As Boolean = False
        Private Property InsertEmailBodyAsAlertDescription As Boolean = False
        Private Property IsClientPortal As Boolean = False
        Private Property IncludeOriginator As Boolean = False
        Private Property WebvantageURL As String = String.Empty
        Private Property ClientPortalURL As String = String.Empty
        Private Property ErrorMessage As String = String.Empty

#End Region


#End Region

#Region " Classes "
        Public Class MimeTypes
            Public Shared contentTypes As Dictionary(Of String, String)

            Public Shared Sub InitializeMimeTypes()
                contentTypes = New Dictionary(Of String, String)
                With contentTypes
                    .Add("3dm", "x-world/x-3dmf")
                    .Add("3dmf", "x-world/x-3dmf")
                    .Add("a", "application/octet-stream")
                    .Add("aab", "application/x-authorware-bin")
                    .Add("aam", "application/x-authorware-map")
                    .Add("aas", "application/x-authorware-seg")
                    .Add("abc", "text/vnd.abc")
                    .Add("acgi", "text/html")
                    .Add("afl", "video/animaflex")
                    .Add("ai", "application/postscript")
                    .Add("aif", "audio/aiff")
                    .Add("aifc", "audio/aiff")
                    .Add("aiff", "audio/aiff")
                    .Add("aim", "application/x-aim")
                    .Add("aip", "text/x-audiosoft-intra")
                    .Add("ani", "application/x-navi-animation")
                    .Add("aos", "application/x-nokia-9000-communicator-add-on-software")
                    .Add("aps", "application/mime")
                    .Add("arc", "application/octet-stream")
                    .Add("arj", "application/arj")
                    .Add("art", "image/x-jg")
                    .Add("asf", "video/x-ms-asf")
                    .Add("asm", "text/x-asm")
                    .Add("asp", "text/asp")
                    .Add("asx", "application/x-mplayer2")
                    .Add("au", "audio/basic")
                    .Add("avi", "video/avi")
                    .Add("avs", "video/avs-video")
                    .Add("bcpio", "application/x-bcpio")
                    .Add("bin", "application/octet-stream")
                    .Add("bm", "image/bmp")
                    .Add("bmp", "image/bmp")
                    .Add("boo", "application/book")
                    .Add("book", "application/book")
                    .Add("boz", "application/x-bzip2")
                    .Add("bsh", "application/x-bsh")
                    .Add("bz", "application/x-bzip")
                    .Add("bz2", "application/x-bzip2")
                    .Add("c", "text/plain")
                    .Add("c++", "text/plain")
                    .Add("cat", "application/vnd.ms-pki.seccat")
                    .Add("cc", "text/plain")
                    .Add("ccad", "application/clariscad")
                    .Add("cco", "application/x-cocoa")
                    .Add("cdf", "application/cdf")
                    .Add("cer", "application/pkix-cert")
                    .Add("cha", "application/x-chat")
                    .Add("chat", "application/x-chat")
                    .Add("class", "application/java")
                    .Add("com", "application/octet-stream")
                    .Add("conf", "text/plain")
                    .Add("cpio", "application/x-cpio")
                    .Add("cpp", "text/x-c")
                    .Add("cpt", "application/x-cpt")
                    .Add("crl", "application/pkcs-crl")
                    .Add("css", "text/css")
                    .Add("def", "text/plain")
                    .Add("der", "application/x-x509-ca-cert")
                    .Add("dif", "video/x-dv")
                    .Add("dir", "application/x-director")
                    .Add("dl", "video/dl")
                    .Add("doc", "application/msword")
                    .Add("dot", "application/msword")
                    .Add("dp", "application/commonground")
                    .Add("drw", "application/drafting")
                    .Add("dump", "application/octet-stream")
                    .Add("dv", "video/x-dv")
                    .Add("dvi", "application/x-dvi")
                    .Add("dwf", "drawing/x-dwf (old)")
                    .Add("dwg", "application/acad")
                    .Add("dxf", "application/dxf")
                    .Add("eps", "application/postscript")
                    .Add("es", "application/x-esrehber")
                    .Add("etx", "text/x-setext")
                    .Add("evy", "application/envoy")
                    .Add("exe", "application/octet-stream")
                    .Add("f", "text/plain")
                    .Add("f90", "text/x-fortran")
                    .Add("fdf", "application/vnd.fdf")
                    .Add("fif", "image/fif")
                    .Add("fli", "video/fli")
                    .Add("for", "text/x-fortran")
                    .Add("fpx", "image/vnd.fpx")
                    .Add("g", "text/plain")
                    .Add("g3", "image/g3fax")
                    .Add("gif", "image/gif")
                    .Add("gl", "video/gl")
                    .Add("gsd", "audio/x-gsm")
                    .Add("gtar", "application/x-gtar")
                    .Add("gz", "application/x-compressed")
                    .Add("h", "text/plain")
                    .Add("help", "application/x-helpfile")
                    .Add("hgl", "application/vnd.hp-hpgl")
                    .Add("hh", "text/plain")
                    .Add("hlp", "application/x-winhelp")
                    .Add("htc", "text/x-component")
                    .Add("htm", "text/html")
                    .Add("html", "text/html")
                    .Add("htmls", "text/html")
                    .Add("htt", "text/webviewhtml")
                    .Add("htx", "text/html")
                    .Add("ice", "x-conference/x-cooltalk")
                    .Add("ico", "image/x-icon")
                    .Add("idc", "text/plain")
                    .Add("ief", "image/ief")
                    .Add("iefs", "image/ief")
                    .Add("iges", "application/iges")
                    .Add("igs", "application/iges")
                    .Add("ima", "application/x-ima")
                    .Add("imap", "application/x-httpd-imap")
                    .Add("inf", "application/inf")
                    .Add("ins", "application/x-internett-signup")
                    .Add("ip", "application/x-ip2")
                    .Add("isu", "video/x-isvideo")
                    .Add("it", "audio/it")
                    .Add("iv", "application/x-inventor")
                    .Add("ivr", "i-world/i-vrml")
                    .Add("ivy", "application/x-livescreen")
                    .Add("jam", "audio/x-jam")
                    .Add("jav", "text/plain")
                    .Add("java", "text/plain")
                    .Add("jcm", "application/x-java-commerce")
                    .Add("jfif", "image/jpeg")
                    .Add("jfif-tbnl", "image/jpeg")
                    .Add("jpe", "image/jpeg")
                    .Add("jpeg", "image/jpeg")
                    .Add("jpg", "image/jpeg")
                    .Add("jps", "image/x-jps")
                    .Add("js", "application/x-javascript")
                    .Add("jut", "image/jutvision")
                    .Add("kar", "audio/midi")
                    .Add("ksh", "application/x-ksh")
                    .Add("la", "audio/nspaudio")
                    .Add("lam", "audio/x-liveaudio")
                    .Add("latex", "application/x-latex")
                    .Add("lha", "application/lha")
                    .Add("lhx", "application/octet-stream")
                    .Add("list", "text/plain")
                    .Add("lma", "audio/nspaudio")
                    .Add("log", "text/plain")
                    .Add("lsp", "application/x-lisp")
                    .Add("lst", "text/plain")
                    .Add("lsx", "text/x-la-asf")
                    .Add("ltx", "application/x-latex")
                    .Add("lzh", "application/octet-stream")
                    .Add("lzx", "application/lzx")
                    .Add("m", "text/plain")
                    .Add("m1v", "video/mpeg")
                    .Add("m2a", "audio/mpeg")
                    .Add("m2v", "video/mpeg")
                    .Add("m3u", "audio/x-mpequrl")
                    .Add("man", "application/x-troff-man")
                    .Add("map", "application/x-navimap")
                    .Add("mar", "text/plain")
                    .Add("mbd", "application/mbedlet")
                    .Add("mc$", "application/x-magic-cap-package-1.0")
                    .Add("mcd", "application/mcad")
                    .Add("mcf", "image/vasa")
                    .Add("mcp", "application/netmc")
                    .Add("me", "application/x-troff-me")
                    .Add("mht", "message/rfc822")
                    .Add("mhtml", "message/rfc822")
                    .Add("mid", "audio/midi")
                    .Add("midi", "audio/midi")
                    .Add("mif", "application/x-frame")
                    .Add("mime", "message/rfc822")
                    .Add("mjf", "audio/x-vnd.audioexplosion.mjuicemediafile")
                    .Add("mjpg", "video/x-motion-jpeg")
                    .Add("mm", "application/base64")
                    .Add("mme", "application/base64")
                    .Add("mod", "audio/mod")
                    .Add("moov", "video/quicktime")
                    .Add("mov", "video/quicktime")
                    .Add("movie", "video/x-sgi-movie")
                    .Add("mp2", "audio/mpeg")
                    .Add("mp3", "audio/mpeg3")
                    .Add("mpa", "audio/mpeg")
                    .Add("mpc", "application/x-project")
                    .Add("mpe", "video/mpeg")
                    .Add("mpeg", "video/mpeg")
                    .Add("mpg", "video/mpeg")
                    .Add("mpga", "audio/mpeg")
                    .Add("mpp", "application/vnd.ms-project")
                    .Add("mpt", "application/x-project")
                    .Add("mpv", "application/x-project")
                    .Add("mpx", "application/x-project")
                    .Add("mrc", "application/marc")
                    .Add("ms", "application/x-troff-ms")
                    .Add("mv", "video/x-sgi-movie")
                    .Add("my", "audio/make")
                    .Add("mzz", "application/x-vnd.audioexplosion.mzz")
                    .Add("nap", "image/naplps")
                    .Add("naplps", "image/naplps")
                    .Add("nc", "application/x-netcdf")
                    .Add("ncm", "application/vnd.nokia.configuration-message")
                    .Add("nif", "image/x-niff")
                    .Add("niff", "image/x-niff")
                    .Add("nix", "application/x-mix-transfer")
                    .Add("nsc", "application/x-conference")
                    .Add("nvd", "application/x-navidoc")
                    .Add("o", "application/octet-stream")
                    .Add("oda", "application/oda")
                    .Add("omc", "application/x-omc")
                    .Add("omcd", "application/x-omcdatamaker")
                    .Add("omcr", "application/x-omcregerator")
                    .Add("p", "text/x-pascal")
                    .Add("p10", "application/pkcs10")
                    .Add("p12", "application/pkcs-12")
                    .Add("p7a", "application/x-pkcs7-signature")
                    .Add("p7c", "application/pkcs7-mime")
                    .Add("pas", "text/pascal")
                    .Add("pbm", "image/x-portable-bitmap")
                    .Add("pcl", "application/vnd.hp-pcl")
                    .Add("pct", "image/x-pict")
                    .Add("pcx", "image/x-pcx")
                    .Add("pdf", "application/pdf")
                    .Add("pfunk", "audio/make")
                    .Add("pgm", "image/x-portable-graymap")
                    .Add("pic", "image/pict")
                    .Add("pict", "image/pict")
                    .Add("pkg", "application/x-newton-compatible-pkg")
                    .Add("pko", "application/vnd.ms-pki.pko")
                    .Add("pl", "text/plain")
                    .Add("plx", "application/x-pixclscript")
                    .Add("pm", "image/x-xpixmap")
                    .Add("png", "image/png")
                    .Add("pnm", "application/x-portable-anymap")
                    .Add("pot", "application/mspowerpoint")
                    .Add("pov", "model/x-pov")
                    .Add("ppa", "application/vnd.ms-powerpoint")
                    .Add("ppm", "image/x-portable-pixmap")
                    .Add("pps", "application/mspowerpoint")
                    .Add("ppt", "application/mspowerpoint")
                    .Add("ppz", "application/mspowerpoint")
                    .Add("pre", "application/x-freelance")
                    .Add("prt", "application/pro_eng")
                    .Add("ps", "application/postscript")
                    .Add("psd", "application/octet-stream")
                    .Add("pvu", "paleovu/x-pv")
                    .Add("pwz", "application/vnd.ms-powerpoint")
                    .Add("py", "text/x-script.phyton")
                    .Add("pyc", "applicaiton/x-bytecode.python")
                    .Add("qcp", "audio/vnd.qcelp")
                    .Add("qd3", "x-world/x-3dmf")
                    .Add("qd3d", "x-world/x-3dmf")
                    .Add("qif", "image/x-quicktime")
                    .Add("qt", "video/quicktime")
                    .Add("qtc", "video/x-qtc")
                    .Add("qti", "image/x-quicktime")
                    .Add("qtif", "image/x-quicktime")
                    .Add("ra", "audio/x-pn-realaudio")
                    .Add("ram", "audio/x-pn-realaudio")
                    .Add("ras", "application/x-cmu-raster")
                    .Add("rast", "image/cmu-raster")
                    .Add("rexx", "text/x-script.rexx")
                    .Add("rf", "image/vnd.rn-realflash")
                    .Add("rgb", "image/x-rgb")
                    .Add("rm", "application/vnd.rn-realmedia")
                    .Add("rmi", "audio/mid")
                    .Add("rmm", "audio/x-pn-realaudio")
                    .Add("rmp", "audio/x-pn-realaudio")
                    .Add("rng", "application/ringing-tones")
                    .Add("rnx", "application/vnd.rn-realplayer")
                    .Add("roff", "application/x-troff")
                    .Add("rp", "image/vnd.rn-realpix")
                    .Add("rpm", "audio/x-pn-realaudio-plugin")
                    .Add("rt", "text/richtext")
                    .Add("rtf", "text/richtext")
                    .Add("rtx", "application/rtf")
                    .Add("rv", "video/vnd.rn-realvideo")
                    .Add("s", "text/x-asm")
                    .Add("s3m", "audio/s3m")
                    .Add("saveme", "application/octet-stream")
                    .Add("sbk", "application/x-tbook")
                    .Add("scm", "application/x-lotusscreencam")
                    .Add("sdml", "text/plain")
                    .Add("sdp", "application/sdp")
                    .Add("sdr", "application/sounder")
                    .Add("sea", "application/sea")
                    .Add("set", "application/set")
                    .Add("sgm", "text/sgml")
                    .Add("sgml", "text/sgml")
                    .Add("sh", "application/x-bsh")
                    .Add("shtml", "text/html")
                    .Add("sid", "audio/x-psid")
                    .Add("sit", "application/x-sit")
                    .Add("skd", "application/x-koan")
                    .Add("skm", "application/x-koan")
                    .Add("skp", "application/x-koan")
                    .Add("skt", "application/x-koan")
                    .Add("sl", "application/x-seelogo")
                    .Add("smi", "application/smil")
                    .Add("smil", "application/smil")
                    .Add("snd", "audio/basic")
                    .Add("sol", "application/solids")
                    .Add("spc", "application/x-pkcs7-certificates")
                    .Add("spl", "application/futuresplash")
                    .Add("spr", "application/x-sprite")
                    .Add("sprite", "application/x-sprite")
                    .Add("src", "application/x-wais-source")
                    .Add("ssi", "text/x-server-parsed-html")
                    .Add("ssm", "application/streamingmedia")
                    .Add("sst", "application/vnd.ms-pki.certstore")
                    .Add("step", "application/step")
                    .Add("stl", "application/sla")
                    .Add("stp", "application/step")
                    .Add("sv4cpio", "application/x-sv4cpio")
                    .Add("sv4crc", "application/x-sv4crc")
                    .Add("svf", "image/vnd.dwg")
                    .Add("svr", "application/x-world")
                    .Add("swf", "application/x-shockwave-flash")
                    .Add("t", "application/x-troff")
                    .Add("talk", "text/x-speech")
                    .Add("tar", "application/x-tar")
                    .Add("tbk", "application/toolbook")
                    .Add("tcl", "application/x-tcl")
                    .Add("tcsh", "text/x-script.tcsh")
                    .Add("tex", "application/x-tex")
                    .Add("texi", "application/x-texinfo")
                    .Add("texinfo", "application/x-texinfo")
                    .Add("text", "text/plain")
                    .Add("tgz", "application/x-compressed")
                    .Add("tif", "image/tiff")
                    .Add("tr", "application/x-troff")
                    .Add("tsi", "audio/tsp-audio")
                    .Add("tsp", "audio/tsplayer")
                    .Add("tsv", "text/tab-separated-values")
                    .Add("turbot", "image/florian")
                    .Add("txt", "text/plain")
                    .Add("uil", "text/x-uil")
                    .Add("uni", "text/uri-list")
                    .Add("unis", "text/uri-list")
                    .Add("unv", "application/i-deas")
                    .Add("uri", "text/uri-list")
                    .Add("uris", "text/uri-list")
                    .Add("ustar", "application/x-ustar")
                    .Add("uu", "application/octet-stream")
                    .Add("vcd", "application/x-cdlink")
                    .Add("vcs", "text/x-vcalendar")
                    .Add("vda", "application/vda")
                    .Add("vdo", "video/vdo")
                    .Add("vew", "application/groupwise")
                    .Add("viv", "video/vivo")
                    .Add("vivo", "video/vivo")
                    .Add("vmd", "application/vocaltec-media-desc")
                    .Add("vmf", "application/vocaltec-media-file")
                    .Add("voc", "audio/voc")
                    .Add("vos", "video/vosaic")
                    .Add("vox", "audio/voxware")
                    .Add("vqe", "audio/x-twinvq-plugin")
                    .Add("vqf", "audio/x-twinvq")
                    .Add("vql", "audio/x-twinvq-plugin")
                    .Add("vrml", "application/x-vrml")
                    .Add("vrt", "x-world/x-vrt")
                    .Add("vsd", "application/x-visio")
                    .Add("vst", "application/x-visio")
                    .Add("vsw", "application/x-visio")
                    .Add("w60", "application/wordperfect6.0")
                    .Add("w61", "application/wordperfect6.1")
                    .Add("w6w", "application/msword")
                    .Add("wav", "audio/wav")
                    .Add("wb1", "application/x-qpro")
                    .Add("wbmp", "image/vnd.wap.wbmp")
                    .Add("web", "application/vnd.xara")
                    .Add("wiz", "application/msword")
                    .Add("wk1", "application/x-123")
                    .Add("wmf", "windows/metafile")
                    .Add("wml", "text/vnd.wap.wml")
                    .Add("wmlc", "application/vnd.wap.wmlc")
                    .Add("wmls", "text/vnd.wap.wmlscript")
                    .Add("wmlsc", "application/vnd.wap.wmlscriptc")
                    .Add("word", "application/msword")
                    .Add("wp", "application/wordperfect")
                    .Add("wp5", "application/wordperfect")
                    .Add("wp6", "application/wordperfect")
                    .Add("wpd", "application/wordperfect")
                    .Add("wq1", "application/x-lotus")
                    .Add("wri", "application/mswrite")
                    .Add("wrl", "application/x-world")
                    .Add("wrz", "model/vrml")
                    .Add("wsc", "text/scriplet")
                    .Add("wsrc", "application/x-wais-source")
                    .Add("wtk", "application/x-wintalk")
                    .Add("xbm", "image/x-xbitmap")
                    .Add("xdr", "video/x-amt-demorun")
                    .Add("xgz", "xgl/drawing")
                    .Add("xif", "image/vnd.xiff")
                    .Add("xl", "application/excel")
                    .Add("xla", "application/excel")
                    .Add("xlb", "application/excel")
                    .Add("xlc", "application/excel")
                    .Add("xld", "application/excel")
                    .Add("xlk", "application/excel")
                    .Add("xll", "application/excel")
                    .Add("xlm", "application/excel")
                    .Add("xls", "application/excel")
                    .Add("xlt", "application/excel")
                    .Add("xlv", "application/excel")
                    .Add("xlw", "application/excel")
                    .Add("xm", "audio/xm")
                    .Add("xml", "text/xml")
                    .Add("xmz", "xgl/movie")
                    .Add("xpix", "application/x-vnd.ls-xpix")
                    .Add("xpm", "image/x-xpixmap")
                    .Add("x-png", "image/png")
                    .Add("xsr", "video/x-amt-showrun")
                    .Add("xwd", "image/x-xwd")
                    .Add("xyz", "chemical/x-pdb")
                    .Add("z", "application/x-compress")
                    .Add("zip", "application/x-compressed")
                    .Add("zoo", "application/octet-stream")
                    .Add("zsh", "text/x-script.zsh")
                    'office 2007+
                    .Add("docm", "application/vnd.ms-word.document.macroEnabled.12")
                    .Add("docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
                    .Add("dotm", "application/vnd.ms-word.template.macroEnabled.12")
                    .Add("dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template")
                    .Add("potm", "application/vnd.ms-powerpoint.template.macroEnabled.12")
                    .Add("potx", "application/vnd.openxmlformats-officedocument.presentationml.template")
                    .Add("ppam", "application/vnd.ms-powerpoint.addin.macroEnabled.12")
                    .Add("ppsm", "application/vnd.ms-powerpoint.slideshow.macroEnabled.12")
                    .Add("ppsx", "application/vnd.openxmlformats-officedocument.presentationml.slideshow")
                    .Add("pptm", "application/vnd.ms-powerpoint.presentation.macroEnabled.12")
                    .Add("pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation")
                    .Add("one", "application/onenote")
                    .Add("onepkg", "application/onenote")
                    .Add("onetmp", "application/onenote")
                    .Add("onetoc2", "application/onenote")
                    .Add("sldm", "application/vnd.ms-powerpoint.slide.macroEnabled.12")
                    .Add("sldx", "application/vnd.openxmlformats-officedocument.presentationml.slide")
                    .Add("thmx", "application/vnd.ms-officetheme")
                    .Add("xlam", "application/vnd.ms-excel.addin.macroEnabled.12")
                    .Add("xlsb", "application/vnd.ms-excel.sheet.binary.macroEnabled.12")
                    .Add("xlsm", "application/vnd.ms-excel.sheet.macroEnabled.12")
                    .Add("xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    .Add("xltm", "application/vnd.ms-excel.template.macroEnabled.12")
                    .Add("xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template")
                    .Add("xps", "application/vnd.ms-xpsdocument")
                    'Open Document Format standard
                    .Add("odt ", "application/vnd.oasis.opendocument.text ")
                    .Add("ott", "application/vnd.oasis.opendocument.text-template")
                    .Add("oth", "application/vnd.oasis.opendocument.text-web")
                    .Add("odm", "application/vnd.oasis.opendocument.text-master")
                    .Add("odg", "application/vnd.oasis.opendocument.graphics")
                    .Add("otg", "application/vnd.oasis.opendocument.graphics-template")
                    .Add("odp", "application/vnd.oasis.opendocument.presentation")
                    .Add("otp", "application/vnd.oasis.opendocument.presentation-template")
                    .Add("ods", "application/vnd.oasis.opendocument.spreadsheet")
                    .Add("ots", "application/vnd.oasis.opendocument.spreadsheet-template")
                    .Add("odc", "application/vnd.oasis.opendocument.chart")
                    .Add("odf", "application/vnd.oasis.opendocument.formula")
                    .Add("odb", "application/vnd.oasis.opendocument.database")
                    .Add("odi", "application/vnd.oasis.opendocument.image")
                    .Add("oxt", "application/vnd.openofficeorg.extension")
                End With
            End Sub

            Public Shared Function GetContentType(ByVal FileName As String, Optional ByVal PullExtensionFromFileName As Boolean = True) As String
                Try
                    If contentTypes Is Nothing OrElse Not (contentTypes.Count > 0) Then
                        InitializeMimeTypes()
                    End If

                    Dim extension As String = ""

                    If PullExtensionFromFileName = False Then
                        Dim fi = New FileInfo(FileName)
                        extension = fi.Extension.Replace(".", "")
                    Else
                        extension = ParseLast(FileName, ".")
                    End If

                    Dim contentType As String = ""
                    Dim FoundIt As Boolean = False
                    FoundIt = contentTypes.TryGetValue(extension.ToLower(), contentType)

                    If FoundIt = False OrElse String.IsNullOrEmpty(contentType) Then
                        contentType = "application/octet-stream"
                    End If

                    Return contentType
                Catch ex As Exception
                    Application.ErrorToEventLog(ex)
                    Return "application/octet-stream"
                End Try
            End Function
            Public Shared Function ParseLast(ByVal buf As String, ByVal Delimiter As String) As String
                Dim bufs(), ans As String

                If buf.IndexOf(Delimiter) > 0 Then
                    bufs = buf.Split(Delimiter)
                    ans = bufs(UBound(bufs))
                Else
                    ans = buf
                End If

                Return ans
            End Function
            Public Sub New()

            End Sub

        End Class
#End Region
#Region " Methods "

        Public Function GetExpenseReportOptions(ByVal InvoiceNumber As Integer) As ExpenseReportSubmitOptions

            Dim SubmitOptions As New ExpenseReportSubmitOptions
            Dim Options As New AdvantageFramework.ViewModels.Employee.ExpenseReport.ExpenseReportOptionsViewModel
            Dim s As New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage,
                                                             Me._DataServiceUser.ConnectionString,
                                                             Me._DataServiceUser.UserCode, 0, Me._DataServiceUser.ConnectionString)

            If s IsNot Nothing Then

                Dim x As New AdvantageFramework.Controller.Employee.ExpenseReportController(s)

                Options = x.LoadExpenseReportOptionsByInvoiceNumber(InvoiceNumber, False)

                If Options IsNot Nothing Then

                    SubmitOptions.InvoiceNumber = Options.InvoiceNumber
                    SubmitOptions.EmployeeCode = Options.EmployeeCode
                    SubmitOptions.EmployeeFullName = Options.EmployeeFullName
                    SubmitOptions.EmployeeSupervisorApprovalRequired = Options.EmployeeSupervisorApprovalRequired
                    SubmitOptions.SupervisorEmployeeCode = Options.SupervisorEmployeeCode
                    SubmitOptions.SupervisorEmployeeFullName = Options.SupervisorEmployeeFullName
                    SubmitOptions.AlternateEmployeeCode = Options.AlternateApproverEmployeeCode
                    SubmitOptions.AlternateEmployeeFullName = Options.AlternateApproverEmployeeFullName
                    SubmitOptions.IncludeReceiptsInEmailAndAlert = Options.IncludeReceiptsInEmailAndAlert

                    s.User.EmployeeCode = Options.EmployeeCode

                End If

            End If

            Return SubmitOptions

        End Function

        Public Function GetApprover(ByVal EmployeeCode As String) As AvailableApprover

            Dim Approver As New AvailableApprover

            If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                'Using DbContext = New AdvantageFramework.Database.DbContext(Me._DataServiceUser.ConnectionString, Me._DataServiceUser.UserCode)

                '    Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

                '    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                '    If Employee IsNot Nothing Then

                '        Approver.EmployeeCode = Employee.Code
                '        Approver.EmployeeFullName = Employee.ToString

                '    End If

                'End Using
                Dim emp As New Global.AdvantageMobile.Employee

                emp = (From Employee In Me._DataEntities.Employees
                       Where Employee.Code = EmployeeCode).FirstOrDefault()

                If emp IsNot Nothing Then

                    Approver.EmployeeCode = emp.Code
                    Approver.EmployeeFullName = emp.FirstName &
                                                If(String.IsNullOrWhiteSpace(emp.MiddleInitial) = True, " ", " " & emp.MiddleInitial & ". ") &
                                                emp.LastName

                End If

            End If

            Return Approver

        End Function
        Public Function GetApproverList(ByVal EmployeeCode As String,
                                        ByVal SearchValue As String,
                                        ByVal Skip As Integer, ByVal Take As Integer) As Generic.List(Of AvailableApprover)

            Dim Approvers As New Generic.List(Of AvailableApprover)
            Dim ReturnList As New Generic.List(Of AvailableApprover)
            Dim EmpEntity As AdvantageFramework.Database.Views.Employee = Nothing
            Dim s As New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage,
                                                             Me._DataServiceUser.ConnectionString,
                                                             Me._DataServiceUser.UserCode, 0, Me._DataServiceUser.ConnectionString)
            If s IsNot Nothing Then

                SearchValue = SearchValue.Trim().ToUpper()
                s.User.EmployeeCode = EmployeeCode

                Using DbContext = New AdvantageFramework.Database.DbContext(Me._DataServiceUser.ConnectionString, Me._DataServiceUser.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me._DataServiceUser.ConnectionString, Me._DataServiceUser.UserCode)

                        Try

                            Dim Approver As AvailableApprover = Nothing
                            Dim Emps As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
                            Dim Add As Boolean = False
                            Dim SupervisorCode As String = String.Empty
                            Dim AlternateCode As String = String.Empty
                            Dim Approvee As New Global.AdvantageMobile.Employee

                            Approvee = (From Employee In Me._DataEntities.Employees
                                        Where Employee.Code = EmployeeCode).FirstOrDefault()

                            If Approvee IsNot Nothing Then

                                SupervisorCode = Approvee.SupervisorEmployeeCode
                                AlternateCode = Approvee.EXP_RPT_APPROVER ' DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(EXP_RPT_APPROVER, '') FROM EMPLOYEE E WITH(NOLOCK) WHERE E.EMP_CODE = '{0}';", EmployeeCode)).SingleOrDefault

                            End If

                            Emps = AdvantageFramework.ExpenseReports.LoadAvailableApprovers(s, DbContext, SecurityDbContext, EmployeeCode)

                            If Emps IsNot Nothing Then

                                Dim SupervisorFound As Boolean = False
                                Dim AlternateFound As Boolean = False

                                For Each Emp As AdvantageFramework.Database.Views.Employee In Emps

                                    Add = False

                                    If String.IsNullOrWhiteSpace(SearchValue) = True Then

                                        Add = True

                                    Else

                                        If Emp.Code.ToUpper.Contains(SearchValue) OrElse
                                            Emp.ToString.ToUpper.Contains(SearchValue) Then

                                            Add = True

                                        End If

                                    End If
                                    If Add = True Then

                                        Approver = New AvailableApprover

                                        Approver.EmployeeCode = Emp.Code

                                        If Emp.Code = SupervisorCode Then

                                            Approver.EmployeeFullName = Emp.ToString & " *"
                                            SupervisorFound = True

                                        ElseIf Emp.Code = AlternateCode Then

                                            Approver.EmployeeFullName = Emp.ToString & " **"
                                            AlternateFound = True

                                        Else

                                            Approver.EmployeeFullName = Emp.ToString

                                        End If

                                        Approvers.Add(Approver)

                                        Approver = Nothing

                                    End If

                                Next

                                If String.IsNullOrWhiteSpace(SupervisorCode) = False AndAlso SupervisorFound = False Then

                                    EmpEntity = Nothing
                                    EmpEntity = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, SupervisorCode)

                                    If EmpEntity IsNot Nothing Then

                                        SupervisorFound = True

                                        Approver = Nothing
                                        Approver = New AvailableApprover

                                        Approver.EmployeeCode = EmpEntity.Code
                                        Approver.EmployeeFullName = EmpEntity.ToString & "*"

                                        Approvers.Add(Approver)

                                        Approver = Nothing

                                    End If

                                End If
                                If String.IsNullOrWhiteSpace(AlternateCode) = False AndAlso AlternateFound = False Then

                                    EmpEntity = Nothing
                                    EmpEntity = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, AlternateCode)

                                    If EmpEntity IsNot Nothing Then

                                        AlternateFound = True

                                        Approver = Nothing
                                        Approver = New AvailableApprover

                                        Approver.EmployeeCode = EmpEntity.Code
                                        Approver.EmployeeFullName = EmpEntity.ToString & "**"

                                        Approvers.Add(Approver)

                                        Approver = Nothing

                                    End If

                                End If

                            End If

                        Catch ex As Exception
                        End Try

                    End Using

                End Using

            End If

            ReturnList = (From Entity In Approvers
                          Order By Entity.EmployeeFullName
                          Select Entity).ToList

            Return ReturnList.Skip(Skip).Take(Take).ToList

        End Function

        Public Function GetExpenses(ByVal EmployeeCode As String) As IQueryable(Of Global.AdvantageMobile.Expense)

            Dim StartDate As Date = DateSerial(Today.Year, Today.Month, 1)
            Dim EndDate As Date = DateSerial(Today.Year, Today.Month + 1, 0)

            GetExpenses = (From Exp In Me._DataEntities.Expenses
                           Where Exp.EmployeeCode = EmployeeCode _
                           And Exp.Status <> 2
                           Select Exp
                           Order By Exp.InvoiceDate Descending)

        End Function

        Public Function GetExpenseReport(ByVal InvoiceNumber As String) As IQueryable(Of Global.AdvantageMobile.Expense)

            GetExpenseReport = (From Exp In Me._DataEntities.Expenses
                                Where Exp.InvoiceNumber = InvoiceNumber
                                Select Exp)


        End Function

        Public Function GetExpensesOpen(ByVal EmployeeCode As String) As Nullable(Of Decimal)

            Dim sqlQuery As String = "SELECT ISNULL(SUM(TOTALEXPENSE),0) FROM V_EXPENSE_SUMMARY " &
                                     " WHERE EMP_CODE = @EMP_CODE AND ((STATUS = 0 OR STATUS IS NULL) AND SUBMITTED_FLAG = 0  AND APPROVED_FLAG = 0)"

            Dim paramEmployeeCode As SqlParameter = New SqlParameter()
            paramEmployeeCode.ParameterName = "@EMP_CODE"
            paramEmployeeCode.SqlDbType = Data.SqlDbType.VarChar
            paramEmployeeCode.Value = EmployeeCode

            GetExpensesOpen = Me._DataEntities.Database.SqlQuery(Of System.Decimal)(sqlQuery, paramEmployeeCode).FirstOrDefault

        End Function
        Public Function GetExpensesDenied(ByVal EmployeeCode As String) As Nullable(Of Decimal)


            Dim sqlQuery As String = "SELECT ISNULL(SUM(TOTALEXPENSE-TOTALPAYABLE),0) FROM V_EXPENSE_SUMMARY " &
                                     " WHERE EMP_CODE = @EMP_CODE AND (" &
                                     " (STATUS = 1 AND SUBMITTED_FLAG = 1  AND APPROVED_FLAG = 1) OR " &
                                     " (STATUS = 5)) "

            Dim paramEmployeeCode As SqlParameter = New SqlParameter()
            paramEmployeeCode.ParameterName = "@EMP_CODE"
            paramEmployeeCode.SqlDbType = Data.SqlDbType.VarChar
            paramEmployeeCode.Value = EmployeeCode

            GetExpensesDenied = Me._DataEntities.Database.SqlQuery(Of System.Decimal)(sqlQuery, paramEmployeeCode).FirstOrDefault

        End Function

        Public Function GetFunctionRate(ByVal FunctionCode As String) As Nullable(Of Decimal)

            Dim sqlQuery As String = "SELECT [FNC_BILLING_RATE] FROM [FUNCTIONS] where [FNC_CODE] = @FNC_CODE"

            Dim paramEmployeeCode As SqlParameter = New SqlParameter()
            paramEmployeeCode.ParameterName = "@FNC_CODE"
            paramEmployeeCode.SqlDbType = Data.SqlDbType.VarChar
            paramEmployeeCode.Value = FunctionCode

            GetFunctionRate = Me._DataEntities.Database.SqlQuery(Of System.Decimal)(sqlQuery, paramEmployeeCode).FirstOrDefault
        End Function

        Public Function GetExpensesPending(ByVal EmployeeCode As String) As Nullable(Of Decimal)

            Dim sqlQuery As String = "SELECT ISNULL(SUM(TOTALEXPENSE),0) FROM V_EXPENSE_SUMMARY " &
                                     " WHERE EMP_CODE = @EMP_CODE AND (" &
                                     " (STATUS = 1 AND SUBMITTED_FLAG = 0  AND APPROVED_FLAG = 0) OR " &
                                     " (STATUS = 4) OR " &
                                     " (STATUS = 1 AND SUBMITTED_FLAG = 1  AND APPROVED_FLAG = 0) )"


            Dim paramEmployeeCode As SqlParameter = New SqlParameter()
            paramEmployeeCode.ParameterName = "@EMP_CODE"
            paramEmployeeCode.SqlDbType = Data.SqlDbType.VarChar
            paramEmployeeCode.Value = EmployeeCode



            GetExpensesPending = Me._DataEntities.Database.SqlQuery(Of System.Decimal)(sqlQuery, paramEmployeeCode).FirstOrDefault

        End Function

        Public Function GetExpenseDetail(ByVal ExpenseDetailID As Integer) As ExpenseDetail

            Try
                GetExpenseDetail = (From ExpenseItems In Me._DataEntities.ExpenseDetails
                                    Where ExpenseItems.ID = ExpenseDetailID AndAlso ExpenseItems.FunctionCode IsNot Nothing).FirstOrDefault()

            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function GetExpenseReportItems(ByVal InvoiceNumber As String) As List(Of Global.AdvantageMobile.ExpenseDetail)
            Dim expenseDetailItems As List(Of Global.AdvantageMobile.ExpenseDetail)

            expenseDetailItems = (From ExpenseItems In Me._DataEntities.ExpenseDetails
                                  Where ExpenseItems.InvoiceNumber = InvoiceNumber AndAlso ExpenseItems.FunctionCode IsNot Nothing
                                  Select ExpenseItems
                                  Order By ExpenseItems.ItemDate Descending).ToList

            For Each item As Global.AdvantageMobile.ExpenseDetail In expenseDetailItems
                Dim func As Global.AdvantageMobile.Function
                func = (From f In Me._DataEntities.Functions
                        Where f.Code = item.FunctionCode And f.EX_FLAG = 1).FirstOrDefault
                item.FunctionCode = func.Name
            Next
            GetExpenseReportItems = expenseDetailItems
        End Function
        Public Function GetTotalInvoiceAmount(ByVal InvoiceNumber As String) As Nullable(Of Decimal)

            Dim TotalAmount As Nullable(Of Decimal) = CType(0.0, Decimal)
            Dim TotalCreditCard As Nullable(Of Decimal) = CType(0.0, Decimal)
            Try



                TotalAmount = (From ExpenseItems In Me._DataEntities.ExpenseDetails
                               Where ExpenseItems.InvoiceNumber = InvoiceNumber And ExpenseItems.Description <> "System Generated"
                               Select ExpenseItems.Amount).Sum()

                TotalCreditCard = (From ExpenseReportItem In Me._DataEntities.ExpenseDetails
                                   Where ExpenseReportItem.InvoiceNumber = InvoiceNumber And ExpenseReportItem.CcFlag = True And ExpenseReportItem.Description <> "System Generated"
                                   Select ExpenseReportItem.Amount).Sum()


                If TotalAmount Is Nothing Then
                    TotalAmount = 0
                End If

                If TotalCreditCard Is Nothing Then
                    TotalCreditCard = 0
                End If
                TotalAmount = TotalAmount - TotalCreditCard
            Catch ex As Exception
                TotalAmount = 0

            End Try

            Return TotalAmount
        End Function
        Public Function GetTotalExpenseAmount(ByVal InvoiceNumber As String) As Nullable(Of Decimal)

            Dim TotalAmount As Nullable(Of Decimal) = CType(0.0, Decimal)
            Try

                TotalAmount = (From ExpenseItems In Me._DataEntities.ExpenseDetails
                               Where ExpenseItems.InvoiceNumber = InvoiceNumber And ExpenseItems.Description <> "System Generated"
                               Select ExpenseItems.Amount).Sum()

                If TotalAmount Is Nothing Then

                    TotalAmount = 0

                End If
            Catch ex As Exception
                TotalAmount = 0

            End Try

            Return TotalAmount
        End Function
        Public Function GetExpenseDocuments(ByVal InvoiceNumber As String) As IQueryable(Of Global.AdvantageMobile.ExpenseDocument)

            GetExpenseDocuments = (From ExpenseDocuments In Me._DataEntities.ExpenseDocuments
                                   Where ExpenseDocuments.InvoiceNumber = InvoiceNumber
                                   Select ExpenseDocuments)

        End Function
        Public Function GetDocumentsByInvoiceNumber(ByVal InvoiceNumber As String) As IQueryable(Of Global.AdvantageMobile.Document)

            GetDocumentsByInvoiceNumber = (From ExpenseDocuments In Me._DataEntities.ExpenseDocuments
                                           Join Documents In Me._DataEntities.Documents On ExpenseDocuments.DocumentID Equals Documents.ID
                                           Where ExpenseDocuments.InvoiceNumber = InvoiceNumber
                                           Select Documents)

        End Function
        Public Function GetExpenseDetailDocument(ByVal DocumentID As Integer, ByVal ExpenseDetailID As Integer) As ExpenseDetailDocument

            GetExpenseDetailDocument = (From ExpenseDetailDocuments In Me._DataEntities.ExpenseDetailDocuments
                                        Where ExpenseDetailDocuments.DocumentID = DocumentID And ExpenseDetailDocuments.ExpenseDetailID = ExpenseDetailID).FirstOrDefault()

        End Function
        Public Function GetDocumentsByExpenseDetailID(ByVal ExpenseDetailID As Integer) As IQueryable(Of Global.AdvantageMobile.Document)

            Dim list As Generic.List(Of Integer) = Nothing

            Try

                list = (From ExpenseDetailDocuments In Me._DataEntities.ExpenseDetailDocuments
                        Join Documents In Me._DataEntities.Documents On ExpenseDetailDocuments.DocumentID Equals Documents.ID
                        Where ExpenseDetailDocuments.ExpenseDetailID = ExpenseDetailID And Documents.THUMBNAIL Is Nothing
                        Select Documents.ID).ToList

            Catch ex As Exception
                list = Nothing
            End Try
            If list IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_DataServiceUser.ConnectionString, _DataServiceUser.UserCode)

                    Try

                        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        If Agency IsNot Nothing Then

                            For Each d As Integer In list

                                AdvantageFramework.DocumentManager.UpdateDocumentThumbnail(DbContext, Agency, d, Nothing)

                            Next

                        End If

                    Catch ex As Exception
                    End Try

                End Using

            End If

            GetDocumentsByExpenseDetailID = (From ExpenseDetailDocuments In Me._DataEntities.ExpenseDetailDocuments
                                             Join Documents In Me._DataEntities.Documents On ExpenseDetailDocuments.DocumentID Equals Documents.ID
                                             Where ExpenseDetailDocuments.ExpenseDetailID = ExpenseDetailID
                                             Select Documents)

        End Function
        Public Function GetDocumentFromDatabase(ByVal DocumentID As Integer) As Document

            GetDocumentFromDatabase = (From Documents In Me._DataEntities.Documents
                                       Where Documents.ID = DocumentID).FirstOrDefault()

        End Function
        Public Function GetDocuments(ByVal DocumentID As Integer) As IQueryable(Of Global.AdvantageMobile.Document)

            GetDocuments = (From Documents In Me._DataEntities.Documents
                            Where Documents.ID = DocumentID
                            Select Documents)

        End Function

        Public Function GetOpenReports(ByVal EmployeeCode As String) As IQueryable(Of Global.AdvantageMobile.Expense)

            Dim StartDate As Date = DateSerial(Today.Year, Today.Month, 1)
            Dim EndDate As Date = DateSerial(Today.Year, Today.Month + 1, 0)

            GetOpenReports = (From Exp In Me._DataEntities.Expenses
                              Where Exp.EmployeeCode = EmployeeCode _
                              And (Exp.Status = 0 Or Exp.Status Is Nothing)
                              Select Exp
                              Order By Exp.InvoiceDate Descending)

        End Function

        Public Function HasVendorAssociation(ByVal EmployeeCode As String) As Boolean

            Dim VendorAssociationExists As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me._DataServiceUser.ConnectionString, Me._DataServiceUser.UserCode)

                    Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                    If Employee IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Employee.EmployeeVendorCode) = False Then

                        VendorAssociationExists = True

                    End If

                End Using

            Catch ex As Exception
                VendorAssociationExists = False
            End Try

            Return VendorAssociationExists

        End Function

        Public Function InsertExpenseHeader(ByVal EmployeeCode As String,
                                         ByVal ExpenseDate As String,
                                         ByVal Description As String,
                                         ByVal Details As String
                                         ) As Integer

            Dim Inserted As Boolean = False

            Dim DateExpenseDate As Nullable(Of Date)

            DateExpenseDate = Nothing
            'Wouldn't work when trying to pass date datatype to service, but works as string
            If IsDate(ExpenseDate) = True Then
                DateExpenseDate = CDate(CDate(ExpenseDate).ToShortDateString())
            Else
                InsertExpenseHeader = 0
            End If

            Dim paramEmployeeCode As SqlParameter = New SqlParameter()
            paramEmployeeCode.ParameterName = "@EMP_CODE"
            paramEmployeeCode.SqlDbType = Data.SqlDbType.VarChar
            paramEmployeeCode.Value = EmployeeCode

            Dim paramInvoiceDate As SqlParameter = New SqlParameter()
            paramInvoiceDate.ParameterName = "@INV_DATE"
            paramInvoiceDate.SqlDbType = Data.SqlDbType.VarChar
            paramInvoiceDate.Value = DateExpenseDate

            Dim paramInvoiceDescription As SqlParameter = New SqlParameter()
            paramInvoiceDescription.ParameterName = "@EXP_DESC"
            paramInvoiceDescription.SqlDbType = Data.SqlDbType.VarChar
            paramInvoiceDescription.Value = Description

            Dim paramInvoiceDetails As SqlParameter = New SqlParameter()
            paramInvoiceDetails.ParameterName = "@DTL_DESC"
            paramInvoiceDetails.SqlDbType = Data.SqlDbType.VarChar
            paramInvoiceDetails.Value = Details

            Dim paramCreateUserID As SqlParameter = New SqlParameter()
            paramCreateUserID.ParameterName = "@CREATE_USER_ID"
            paramCreateUserID.SqlDbType = Data.SqlDbType.VarChar
            paramCreateUserID.Value = Me._UserCode


            InsertExpenseHeader = Me._DataEntities.Database.SqlQuery(Of System.Decimal)("usp_wv_exp_InsertEXPENSE_HEADER @EMP_CODE, @INV_DATE, @EXP_DESC, @DTL_DESC, @CREATE_USER_ID",
                                                paramEmployeeCode,
                                                paramInvoiceDate,
                                                paramInvoiceDescription,
                                                paramInvoiceDetails,
                                                paramCreateUserID).FirstOrDefault


        End Function
        Public Function UpdateExpenseHeader(ByVal InvoiceNumber As Integer,
                                  ByVal ExpenseDate As String,
                                  ByVal Description As String,
                                  ByVal Details As String
                                  ) As Integer

            Dim returnValue As Integer
            Dim paramInvoiceNumber As SqlParameter = New SqlParameter()
            paramInvoiceNumber.ParameterName = "@INV_NBR"
            paramInvoiceNumber.SqlDbType = Data.SqlDbType.Int
            paramInvoiceNumber.Value = InvoiceNumber

            Dim paramInvoiceDate As SqlParameter = New SqlParameter()
            paramInvoiceDate.ParameterName = "@INV_DATE"
            paramInvoiceDate.SqlDbType = Data.SqlDbType.VarChar
            paramInvoiceDate.Value = ExpenseDate

            Dim paramInvoiceDescription As SqlParameter = New SqlParameter()
            paramInvoiceDescription.ParameterName = "@EXP_DESC"
            paramInvoiceDescription.SqlDbType = Data.SqlDbType.VarChar
            paramInvoiceDescription.Value = Description

            Dim paramInvoiceDetails As SqlParameter = New SqlParameter()
            paramInvoiceDetails.ParameterName = "@DTL_DESC"
            paramInvoiceDetails.SqlDbType = Data.SqlDbType.VarChar
            paramInvoiceDetails.Value = Details

            Dim paramModifyUser As SqlParameter = New SqlParameter()
            paramModifyUser.ParameterName = "@MOD_USER_ID"
            paramModifyUser.SqlDbType = Data.SqlDbType.VarChar
            paramModifyUser.Value = Me._UserCode


            Dim paramModifyDate As SqlParameter = New SqlParameter()
            paramModifyDate.ParameterName = "@MOD_DATE"
            paramModifyDate.SqlDbType = Data.SqlDbType.VarChar
            paramModifyDate.Value = DateTime.Now

            returnValue = Me._DataEntities.Database.ExecuteSqlCommand("usp_wv_exp_UpdateEXPENSE_HEADER @INV_NBR, @INV_DATE, @EXP_DESC, @DTL_DESC, @MOD_USER_ID, @MOD_DATE",
                                                   paramInvoiceNumber,
                                                   paramInvoiceDate,
                                                   paramInvoiceDescription,
                                                   paramInvoiceDetails,
                                                   paramModifyUser,
                                                   paramModifyDate
                                                   )


            UpdateExpenseHeader = returnValue

        End Function
        Public Function DeleteExpenseHeader(ByVal InvoiceNumber As Integer
                          ) As Integer

            Dim docs As List(Of Global.AdvantageMobile.Document)
            Dim expDoc As Global.AdvantageMobile.ExpenseDocument
            Dim expDetDoc As Global.AdvantageMobile.ExpenseDetailDocument

            Dim ErrorText As String = String.Empty

            docs = (From document In Me._DataEntities.Documents
                    Join expDocuments In Me._DataEntities.ExpenseDocuments On expDocuments.DocumentID Equals document.ID
                    Where expDocuments.InvoiceNumber = InvoiceNumber
                    Select document).ToList()
            If docs IsNot Nothing Then
                For Each doc As Global.AdvantageMobile.Document In docs
                    'Delete document from repository
                    DeleteDocumentFromRepository(doc.ID, doc.RepositoryFilename)
                    expDoc = (From expensedocument In Me._DataEntities.ExpenseDocuments
                              Where expensedocument.DocumentID = doc.ID
                              Select expensedocument).FirstOrDefault

                    expDetDoc = (From expensedetaildocument In Me._DataEntities.ExpenseDetailDocuments
                                 Where expensedetaildocument.DocumentID = doc.ID
                                 Select expensedetaildocument).FirstOrDefault
                    'Remove entry for expense document
                    If expDoc IsNot Nothing Then
                        Me._DataEntities.ExpenseDocuments.Remove(expDoc)
                    End If
                    'Reemove entry for expense detail document
                    If expDetDoc IsNot Nothing Then
                        Me._DataEntities.ExpenseDetailDocuments.Remove(expDetDoc)
                    End If
                    'Remove the document
                    Me._DataEntities.Documents.Remove(doc)

                    Me._DataEntities.SaveChanges()

                Next
            End If

            Dim returnValue As Integer
            Dim paramInvoiceNumber As SqlParameter = New SqlParameter()
            paramInvoiceNumber.ParameterName = "@INV_NBR"
            paramInvoiceNumber.SqlDbType = Data.SqlDbType.Int
            paramInvoiceNumber.Value = InvoiceNumber

            returnValue = Me._DataEntities.Database.ExecuteSqlCommand("usp_wv_exp_DeleteEXPENSE_HEADER @INV_NBR",
                                               paramInvoiceNumber
                                               )
            DeleteExpenseHeader = returnValue

        End Function
        Public Function CopyExpenseReport(ByVal InvoiceNumber As Integer, ByVal EmployeeCode As String,
                                      ByVal ReportDate As System.DateTime, ByVal Description As String, ByVal Details As String) As Integer

            Dim DateExpenseDate As Nullable(Of Date)

            DateExpenseDate = Nothing
            'Wouldn't work when trying to pass date datatype to service, but works as string
            If IsDate(ReportDate) = True Then
                DateExpenseDate = CDate(CDate(ReportDate).ToShortDateString())
            Else
                CopyExpenseReport = 0
            End If

            Dim paramInvoiceNumber As New SqlParameter("@INV_NBR", SqlDbType.VarChar, 25)
            paramInvoiceNumber.Value = InvoiceNumber

            Dim paramEmployeeCode As SqlParameter = New SqlParameter()
            paramEmployeeCode.ParameterName = "@EMP_CODE"
            paramEmployeeCode.SqlDbType = Data.SqlDbType.VarChar
            paramEmployeeCode.Value = EmployeeCode

            Dim paramInvoiceDate As SqlParameter = New SqlParameter()
            paramInvoiceDate.ParameterName = "@INV_DATE"
            paramInvoiceDate.SqlDbType = Data.SqlDbType.VarChar
            paramInvoiceDate.Value = DateExpenseDate

            Dim paramInvoiceDescription As SqlParameter = New SqlParameter()
            paramInvoiceDescription.ParameterName = "@EXP_DESC"
            paramInvoiceDescription.SqlDbType = Data.SqlDbType.VarChar
            paramInvoiceDescription.Value = Description

            Dim paramInvoiceDetails As SqlParameter = New SqlParameter()
            paramInvoiceDetails.ParameterName = "@DTL_DESC"
            paramInvoiceDetails.SqlDbType = Data.SqlDbType.VarChar
            paramInvoiceDetails.Value = Details


            Dim paramCREATE_USER_ID As New SqlParameter("@CREATE_USER_ID", SqlDbType.VarChar, 100)
            paramCREATE_USER_ID.Value = Me._UserCode

            CopyExpenseReport = Me._DataEntities.Database.SqlQuery(Of System.Int32)("usp_wv_exp_CopyEXPENSE_HEADERandDETAIL @INV_NBR, @EMP_CODE, @INV_DATE, @EXP_DESC, @DTL_DESC, @CREATE_USER_ID",
                                                paramInvoiceNumber,
                                                paramEmployeeCode,
                                                paramInvoiceDate,
                                                paramInvoiceDescription,
                                                paramInvoiceDetails,
                                                paramCREATE_USER_ID).FirstOrDefault


        End Function
        Public Function CopyExpenseReportDetail(ByVal ExpenseDetailID As Integer, ByVal InvoiceNumber As Integer, ByVal EmployeeCode As String) As String


            Dim paramEXPDETAILID As New SqlParameter("@EXPDETAILID", SqlDbType.Int, 0)
            paramEXPDETAILID.Value = ExpenseDetailID

            Dim paramInvoiceNumber As New SqlParameter("@INV_NBR", SqlDbType.VarChar, 25)
            paramInvoiceNumber.Value = InvoiceNumber

            Dim paramEmployeeCode As SqlParameter = New SqlParameter()
            paramEmployeeCode.ParameterName = "@EMP_CODE"
            paramEmployeeCode.SqlDbType = Data.SqlDbType.VarChar
            paramEmployeeCode.Value = EmployeeCode

            Dim paramCREATE_USER_ID As New SqlParameter("@CREATE_USER_ID", SqlDbType.VarChar, 100)
            paramCREATE_USER_ID.Value = Me._UserCode

            Me._DataEntities.Database.ExecuteSqlCommand("usp_wv_exp_CopyEXPENSEDETAIL @EXPDETAILID, @INV_NBR, @EMP_CODE, @CREATE_USER_ID",
                                                paramEXPDETAILID,
                                                paramInvoiceNumber,
                                                paramEmployeeCode,
                                                paramCREATE_USER_ID)

            Return String.Empty


        End Function

        Public Function InsertExpenseDetail(ByVal pExpenseDetail As ExpenseDetail) As Integer

            Dim Inserted As Boolean = False
            Dim oldID As Decimal = 0
            Dim newID As Integer = 0
            Dim invoiceNumber As Integer = 0

            If (pExpenseDetail.InvoiceNumber = 0) Then

                invoiceNumber = InsertExpenseHeader(pExpenseDetail.CreatedBy, pExpenseDetail.ItemDate, "New Report", "New Report")
                pExpenseDetail.InvoiceNumber = invoiceNumber

            End If

            If (pExpenseDetail.ID > 0) Then

                oldID = pExpenseDetail.ID

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me._DataServiceUser.ConnectionString, Me._DataServiceUser.UserCode)

                Dim ExpenseDetail As New AdvantageFramework.Database.Entities.ExpenseReportDetail
                Dim HasClient As Boolean = False
                Dim HasDivision As Boolean = False
                Dim HasProduct As Boolean = False
                Dim HasJob As Boolean = False

                ExpenseDetail.InvoiceNumber = pExpenseDetail.InvoiceNumber

                If String.IsNullOrWhiteSpace(pExpenseDetail.ApComment) = False Then
                    ExpenseDetail.APComment = Nothing
                Else
                    ExpenseDetail.APComment = pExpenseDetail.ApComment
                End If

                If pExpenseDetail.CcAmount Is Nothing OrElse pExpenseDetail.CcAmount = 0 Then
                    ExpenseDetail.CreditCardAmount = Nothing
                Else
                    ExpenseDetail.CreditCardAmount = CType(pExpenseDetail.CcAmount, Decimal)
                End If

                If pExpenseDetail.CcFlag Is Nothing Then
                    ExpenseDetail.CreditCardFlag = False
                Else
                    ExpenseDetail.CreditCardFlag = pExpenseDetail.CcFlag
                End If

                If ExpenseDetail.CreditCardFlag = False Then
                    ExpenseDetail.PaymentType = 2 'cash
                Else
                    ExpenseDetail.PaymentType = 0 'corporate CC
                End If

                If pExpenseDetail.ClientCode = "0" OrElse String.IsNullOrWhiteSpace(pExpenseDetail.ClientCode) = True Then
                    ExpenseDetail.ClientCode = Nothing
                Else
                    ExpenseDetail.ClientCode = pExpenseDetail.ClientCode
                    HasClient = True
                End If
                If pExpenseDetail.DivisionCode = "0" OrElse String.IsNullOrWhiteSpace(pExpenseDetail.DivisionCode) = True Then
                    ExpenseDetail.DivisionCode = Nothing
                Else
                    ExpenseDetail.DivisionCode = pExpenseDetail.DivisionCode
                    HasDivision = True
                End If
                If pExpenseDetail.ProductCode = "0" OrElse String.IsNullOrWhiteSpace(pExpenseDetail.ProductCode) = True Then
                    ExpenseDetail.ProductCode = Nothing
                Else
                    ExpenseDetail.ProductCode = pExpenseDetail.ProductCode
                    HasProduct = True
                End If
                If pExpenseDetail.JobNumber Is Nothing OrElse pExpenseDetail.JobNumber = 0 Then
                    ExpenseDetail.JobNumber = Nothing
                Else
                    ExpenseDetail.JobNumber = pExpenseDetail.JobNumber
                    HasJob = True
                End If
                If (HasClient = False OrElse HasDivision = False OrElse HasProduct = False) AndAlso HasJob = True Then

                    Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, pExpenseDetail.JobNumber)

                    If Job IsNot Nothing Then

                        pExpenseDetail.ClientCode = Job.ClientCode
                        ExpenseDetail.ClientCode = Job.ClientCode
                        pExpenseDetail.DivisionCode = Job.DivisionCode
                        ExpenseDetail.DivisionCode = Job.DivisionCode
                        pExpenseDetail.ProductCode = Job.ProductCode
                        ExpenseDetail.ProductCode = Job.ProductCode

                    End If

                End If

                If HasJob = True AndAlso pExpenseDetail.JobNumber IsNot Nothing AndAlso pExpenseDetail.JobNumber > 0 Then

                    If pExpenseDetail.JobComponentNumber Is Nothing OrElse pExpenseDetail.JobComponentNumber = 0 Then

                        ExpenseDetail.JobComponentNumber = Nothing

                    Else

                        ExpenseDetail.JobComponentNumber = pExpenseDetail.JobComponentNumber

                    End If
                    If ExpenseDetail.JobComponentNumber Is Nothing AndAlso pExpenseDetail.JobNumber IsNot Nothing Then

                        Try

                            ExpenseDetail.JobComponentNumber = DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT TOP 1 JOB_COMPONENT_NBR FROM JOB_COMPONENT WHERE JOB_NUMBER = {0} AND JOB_PROCESS_CONTRL NOT IN (6, 12) ORDER BY JOB_COMPONENT_NBR;", pExpenseDetail.JobNumber)).SingleOrDefault

                        Catch ex As Exception
                            ExpenseDetail.JobComponentNumber = Nothing
                        End Try
                        If ExpenseDetail.JobComponentNumber IsNot Nothing AndAlso ExpenseDetail.JobComponentNumber = 0 Then

                            ExpenseDetail.JobComponentNumber = Nothing

                        End If
                        If ExpenseDetail.JobComponentNumber Is Nothing Then
                            Try

                                ExpenseDetail.JobComponentNumber = DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT TOP 1 JOB_COMPONENT_NBR FROM JOB_COMPONENT WHERE JOB_NUMBER = {0} ORDER BY JOB_COMPONENT_NBR DESC;", pExpenseDetail.JobNumber)).SingleOrDefault

                            Catch ex As Exception
                                ExpenseDetail.JobComponentNumber = Nothing
                            End Try
                        End If
                        If ExpenseDetail.JobComponentNumber IsNot Nothing AndAlso ExpenseDetail.JobComponentNumber > 0 Then

                            pExpenseDetail.JobComponentNumber = ExpenseDetail.JobComponentNumber

                        End If

                    End If

                End If

                If String.IsNullOrWhiteSpace(pExpenseDetail.FunctionCode) = True Then
                    ExpenseDetail.FunctionCode = Nothing
                Else
                    ExpenseDetail.FunctionCode = pExpenseDetail.FunctionCode
                End If

                If pExpenseDetail.Amount Is Nothing Then
                    ExpenseDetail.Amount = 0
                Else
                    ExpenseDetail.Amount = CType(pExpenseDetail.Amount, Decimal)
                End If

                If pExpenseDetail.ItemDate Is Nothing Then
                    ExpenseDetail.ItemDate = CType(Now, Date).ToShortDateString
                Else
                    ExpenseDetail.ItemDate = CType(pExpenseDetail.ItemDate, Date).ToShortDateString
                End If

                If String.IsNullOrWhiteSpace(pExpenseDetail.Description) = True Then
                    ExpenseDetail.Description = Nothing
                Else
                    ExpenseDetail.Description = pExpenseDetail.Description
                End If

                ExpenseDetail.CreatedBy = Me._UserCode

                If pExpenseDetail.Quantity Is Nothing OrElse pExpenseDetail.Quantity = 0 Then
                    ExpenseDetail.Quantity = Nothing
                Else
                    ExpenseDetail.Quantity = CType(pExpenseDetail.Quantity, Integer)
                End If

                If pExpenseDetail.Rate Is Nothing OrElse pExpenseDetail.Rate = 0 Then
                    ExpenseDetail.Rate = Nothing
                Else
                    ExpenseDetail.Rate = CType(pExpenseDetail.Rate, Decimal)
                End If

                Inserted = AdvantageFramework.Database.Procedures.ExpenseReportDetail.Insert(DbContext, ExpenseDetail)

                If Inserted = True AndAlso ExpenseDetail.ID > 0 Then

                    newID = ExpenseDetail.ID

                    'Logic for move item to new report.
                    If (oldID > 0 And newID > 0) Then
                        'Move the documents
                        Dim expDetailDocs As List(Of Global.AdvantageMobile.ExpenseDetailDocument)
                        expDetailDocs = (From detailDocs In Me._DataEntities.ExpenseDetailDocuments
                                         Where detailDocs.ExpenseDetailID = oldID
                                         Select detailDocs).ToList()

                        Dim expDoc As ExpenseDocument = Nothing
                        Dim newExpDoc As ExpenseDocument = Nothing
                        Dim newExpDetailDoc As ExpenseDetailDocument = Nothing

                        For Each expDetailDoc As ExpenseDetailDocument In expDetailDocs

                            expDoc = (From eDoc In Me._DataEntities.ExpenseDocuments
                                      Where eDoc.DocumentID = expDetailDoc.DocumentID
                                      Select eDoc).FirstOrDefault()

                            If expDoc IsNot Nothing Then

                                newExpDoc = New ExpenseDocument

                                newExpDoc.InvoiceNumber = invoiceNumber
                                newExpDoc.DocumentID = expDetailDoc.DocumentID

                                newExpDetailDoc = New ExpenseDetailDocument

                                newExpDetailDoc.DocumentID = expDetailDoc.DocumentID
                                newExpDetailDoc.ExpenseDetailID = newID

                                Me._DataEntities.ExpenseDocuments.Add(newExpDoc)
                                Me._DataEntities.ExpenseDocuments.Remove(expDoc)
                                Me._DataEntities.ExpenseDetailDocuments.Add(newExpDetailDoc)
                                Me._DataEntities.ExpenseDetailDocuments.Remove(expDetailDoc)

                                newExpDoc = Nothing
                                newExpDetailDoc = Nothing

                                Me._DataEntities.SaveChanges()

                                expDoc = Nothing

                            End If

                        Next

                    End If

                End If

            End Using

            InsertExpenseDetail = newID

        End Function
        Public Function UpdateExpenseDetail(ByVal pExpenseDetail As ExpenseDetail) As Integer

            Dim Updated As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me._DataServiceUser.ConnectionString, Me._DataServiceUser.UserCode)

                Dim ExpenseDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
                Dim HasClient As Boolean = False
                Dim HasDivision As Boolean = False
                Dim HasProduct As Boolean = False
                Dim HasJob As Boolean = False

                ExpenseDetail = AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByID(DbContext, pExpenseDetail.ID)

                If ExpenseDetail IsNot Nothing Then

                    If String.IsNullOrWhiteSpace(pExpenseDetail.ApComment) = False Then
                        ExpenseDetail.APComment = Nothing
                    Else
                        ExpenseDetail.APComment = pExpenseDetail.ApComment
                    End If

                    If pExpenseDetail.CcAmount Is Nothing OrElse pExpenseDetail.CcAmount = 0 Then
                        ExpenseDetail.CreditCardAmount = Nothing
                    Else
                        ExpenseDetail.CreditCardAmount = CType(pExpenseDetail.CcAmount, Decimal)
                    End If

                    If pExpenseDetail.CcFlag Is Nothing Then
                        ExpenseDetail.CreditCardFlag = False
                    Else
                        ExpenseDetail.CreditCardFlag = pExpenseDetail.CcFlag
                    End If

                    If ExpenseDetail.CreditCardFlag = False Then
                        ExpenseDetail.PaymentType = 2 'cash
                    Else
                        ExpenseDetail.PaymentType = 0 'corporate CC
                    End If

                    If pExpenseDetail.ClientCode = "0" OrElse String.IsNullOrWhiteSpace(pExpenseDetail.ClientCode) = True Then
                        ExpenseDetail.ClientCode = Nothing
                    Else
                        ExpenseDetail.ClientCode = pExpenseDetail.ClientCode
                        HasClient = True
                    End If
                    If pExpenseDetail.DivisionCode = "0" OrElse String.IsNullOrWhiteSpace(pExpenseDetail.DivisionCode) = True Then
                        ExpenseDetail.DivisionCode = Nothing
                    Else
                        ExpenseDetail.DivisionCode = pExpenseDetail.DivisionCode
                        HasDivision = True
                    End If
                    If pExpenseDetail.ProductCode = "0" OrElse String.IsNullOrWhiteSpace(pExpenseDetail.ProductCode) = True Then
                        ExpenseDetail.ProductCode = Nothing
                    Else
                        ExpenseDetail.ProductCode = pExpenseDetail.ProductCode
                        HasProduct = True
                    End If
                    If pExpenseDetail.JobNumber Is Nothing OrElse pExpenseDetail.JobNumber = 0 Then
                        ExpenseDetail.JobNumber = Nothing
                    Else
                        ExpenseDetail.JobNumber = pExpenseDetail.JobNumber
                        HasJob = True
                    End If
                    If (HasClient = False OrElse HasDivision = False OrElse HasProduct = False) AndAlso HasJob = True Then

                        Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
                        Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, pExpenseDetail.JobNumber)

                        If Job IsNot Nothing Then

                            pExpenseDetail.ClientCode = Job.ClientCode
                            ExpenseDetail.ClientCode = Job.ClientCode
                            pExpenseDetail.DivisionCode = Job.DivisionCode
                            ExpenseDetail.DivisionCode = Job.DivisionCode
                            pExpenseDetail.ProductCode = Job.ProductCode
                            ExpenseDetail.ProductCode = Job.ProductCode

                        End If

                    End If
                    If pExpenseDetail.JobComponentNumber Is Nothing OrElse pExpenseDetail.JobComponentNumber = 0 Then
                        ExpenseDetail.JobComponentNumber = Nothing
                    Else
                        ExpenseDetail.JobComponentNumber = pExpenseDetail.JobComponentNumber
                    End If
                    If ExpenseDetail.JobComponentNumber Is Nothing AndAlso pExpenseDetail.JobNumber IsNot Nothing Then

                        Try

                            ExpenseDetail.JobComponentNumber = DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT TOP 1 JOB_COMPONENT_NBR FROM JOB_COMPONENT WHERE JOB_NUMBER = {0} AND JOB_PROCESS_CONTRL NOT IN (6, 12) ORDER BY JOB_COMPONENT_NBR;", pExpenseDetail.JobNumber)).SingleOrDefault

                        Catch ex As Exception
                            ExpenseDetail.JobComponentNumber = Nothing
                        End Try
                        If ExpenseDetail.JobComponentNumber Is Nothing Then
                            Try

                                ExpenseDetail.JobComponentNumber = DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT TOP 1 JOB_COMPONENT_NBR FROM JOB_COMPONENT WHERE JOB_NUMBER = {0} ORDER BY JOB_COMPONENT_NBR DESC;", pExpenseDetail.JobNumber)).SingleOrDefault

                            Catch ex As Exception
                                ExpenseDetail.JobComponentNumber = Nothing
                            End Try
                        End If
                        If ExpenseDetail.JobComponentNumber IsNot Nothing Then

                            pExpenseDetail.JobComponentNumber = ExpenseDetail.JobComponentNumber

                        End If

                    End If

                    If String.IsNullOrWhiteSpace(pExpenseDetail.FunctionCode) = True Then
                        ExpenseDetail.FunctionCode = Nothing
                    Else
                        ExpenseDetail.FunctionCode = pExpenseDetail.FunctionCode
                    End If

                    If pExpenseDetail.Amount Is Nothing Then
                        ExpenseDetail.Amount = 0
                    Else
                        ExpenseDetail.Amount = CType(pExpenseDetail.Amount, Decimal)
                    End If

                    If pExpenseDetail.ItemDate Is Nothing Then
                        ExpenseDetail.ItemDate = CType(Now, Date).ToShortDateString
                    Else
                        ExpenseDetail.ItemDate = CType(pExpenseDetail.ItemDate, Date).ToShortDateString
                    End If

                    If String.IsNullOrWhiteSpace(pExpenseDetail.Description) = True Then
                        ExpenseDetail.Description = Nothing
                    Else
                        ExpenseDetail.Description = pExpenseDetail.Description
                    End If


                    ExpenseDetail.ModifiedDate = CType(Now, DateTime)

                    ExpenseDetail.ModifiedBy = Me._UserCode


                    If pExpenseDetail.Quantity Is Nothing OrElse pExpenseDetail.Quantity = 0 Then
                        ExpenseDetail.Quantity = Nothing
                    Else
                        ExpenseDetail.Quantity = CType(pExpenseDetail.Quantity, Integer)
                    End If

                    If pExpenseDetail.Rate Is Nothing OrElse pExpenseDetail.Rate = 0 Then
                        ExpenseDetail.Rate = Nothing
                    Else
                        ExpenseDetail.Rate = CType(pExpenseDetail.Rate, Decimal)
                    End If

                    Updated = AdvantageFramework.Database.Procedures.ExpenseReportDetail.Update(DbContext, ExpenseDetail)

                End If

            End Using

            Return 0

        End Function
        Public Function DeleteExpenseDetail(ByVal ExpenseDetailID As Integer) As Integer

            Dim docs As List(Of Global.AdvantageMobile.Document)
            Dim expDoc As Global.AdvantageMobile.ExpenseDocument
            Dim expDetDoc As Global.AdvantageMobile.ExpenseDetailDocument

            Dim ErrorText As String = String.Empty

            docs = (From document In Me._DataEntities.Documents
                    Join expDetailDocuments In Me._DataEntities.ExpenseDetailDocuments On expDetailDocuments.DocumentID Equals document.ID
                    Where expDetailDocuments.ExpenseDetailID = ExpenseDetailID
                    Select document).ToList()

            If docs IsNot Nothing Then

                For Each doc As Global.AdvantageMobile.Document In docs

                    'Delete document from repository
                    DeleteDocumentFromRepository(doc.ID, doc.RepositoryFilename)

                    expDoc = (From expensedocument In Me._DataEntities.ExpenseDocuments
                              Where expensedocument.DocumentID = doc.ID
                              Select expensedocument).FirstOrDefault

                    expDetDoc = (From expensedetaildocument In Me._DataEntities.ExpenseDetailDocuments
                                 Where expensedetaildocument.DocumentID = doc.ID
                                 Select expensedetaildocument).FirstOrDefault

                    'Remove entry for expense document
                    If expDoc IsNot Nothing Then

                        Me._DataEntities.ExpenseDocuments.Remove(expDoc)

                    End If

                    'Reemove entry for expense detail document
                    If expDetDoc IsNot Nothing Then

                        Me._DataEntities.ExpenseDetailDocuments.Remove(expDetDoc)

                    End If

                    'Remove the document
                    Me._DataEntities.Documents.Remove(doc)

                    Me._DataEntities.SaveChanges()

                Next

            End If

            Dim paramEXPDETAILID As New SqlParameter("@EXPDETAILID", SqlDbType.Int, 0)
            paramEXPDETAILID.Value = ExpenseDetailID

            Me._DataEntities.Database.ExecuteSqlCommand("usp_wv_exp_DeleteEXPENSE_DETAIL @EXPDETAILID",
                                                paramEXPDETAILID)

            Return 0

        End Function

        Public Function SubmitExpenseReport(ByVal EmployeeCode As String,
                                            ByVal InvoiceNumber As Integer,
                                            ByVal ApproverEmployeeCode As String,
                                            ByVal IncludeReceiptsInEmailAndAlert As Boolean) As String

            'objects
            Dim impersonateUser As Boolean
            Dim ErrorText As String = String.Empty
            Dim Submitted As Boolean = False
            Dim OkToSubmit As Boolean = True
            Dim SystemGeneratedExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
            Dim SqlParameterInvoiceNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Sent As Boolean = False
            Dim AlertID As Integer = 0
            Dim SendEmail As Boolean = True 'True = send through ADV, else send from mobile code;  NT Auth funk

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me._DataServiceUser.ConnectionString, Me._DataServiceUser.UserCode)

                    'Dim agency As Agency = _DataEntities.Agencies.FirstOrDefault()

                    'If agency IsNot Nothing Then

                    '    Me._UserDomain = agency.DOC_REPOSITORY_USER_DOMAIN
                    '    Me._UserName = agency.DOC_REPOSITORY_USER_NAME
                    '    Me._UserPassword = AdvantageFramework.StringUtilities.RijndaelSimpleDecrypt(agency.DOC_REPOSITORY_USER_PASSWORD)
                    '    Me._Path = agency.DOC_REPOSITORY_PATH

                    'End If

                    impersonateUser = Me._UserName <> ""

                    If impersonateUser = True Then

                        SendEmail = False

                    End If

                    'If impersonateUser Then

                    '    AliasAccount.BeginImpersonation(Me._UserName, Me._UserDomain, Me._UserPassword)

                    'End If

                    Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                    Dim currentWindowsIdentity As System.Security.Principal.WindowsIdentity
                    If impersonateUser Then

                        currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                        impersonationContext = currentWindowsIdentity.Impersonate()

                    End If

                    ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber)

                    If ExpenseReport IsNot Nothing Then

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.EmployeeCode)

                    End If

                    If impersonateUser Then

                        impersonationContext.Undo()

                    End If

                    If Employee IsNot Nothing AndAlso ExpenseReport IsNot Nothing Then

                        Dim s As New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage,
                                                             Me._DataServiceUser.ConnectionString,
                                                             Me._DataServiceUser.UserCode, 0, Me._DataServiceUser.ConnectionString)

                        If s IsNot Nothing Then

                            s.User.EmployeeCode = Employee.Code

                            If String.IsNullOrWhiteSpace(ApproverEmployeeCode) = False Then

                                ExpenseReport.SubmittedTo = ApproverEmployeeCode

                            Else

                                Dim x As New AdvantageFramework.Controller.Employee.ExpenseReportController(s)
                                Dim Options As New AdvantageFramework.ViewModels.Employee.ExpenseReport.ExpenseReportOptionsViewModel

                                Options = x.LoadExpenseReportOptionsByInvoiceNumber(InvoiceNumber, False)

                                If Options IsNot Nothing Then

                                    If String.IsNullOrWhiteSpace(Options.SupervisorEmployeeCode) = False Then

                                        ExpenseReport.SubmittedTo = Options.SupervisorEmployeeCode

                                    Else

                                        If String.IsNullOrWhiteSpace(Options.AlternateApproverEmployeeCode) = False Then

                                            ExpenseReport.SubmittedTo = Options.AlternateApproverEmployeeCode

                                        End If

                                    End If

                                End If

                            End If

                            SendEmail = False 'Always send from DataService instead of ADV 

                            Submitted = AdvantageFramework.ExpenseReports.SubmitExpenseReport(s,
                                                                                              ExpenseReport,
                                                                                              Employee,
                                                                                              IncludeReceiptsInEmailAndAlert,
                                                                                              ErrorText,
                                                                                              SendEmail,
                                                                                              AlertID)

                            If Submitted = True And SendEmail = False Then

                                'send email here to avoid impersontation issues with nt auth
                                If Alert Is Nothing Then

                                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                                End If
                                If Alert IsNot Nothing Then

                                    'BuildAndSendAlertEmail(Me._DataServiceUser.ConnectionString, Me._DataServiceUser.UserCode,
                                    '                       Alert, "[New Alert] ", Nothing, Nothing, "Expense", ErrorMessage:=ErrorText)

                                    Me.BuildAndSendAlertEmailOnSeparateThread()

                                End If

                            End If

                        End If

                    End If

                    'If impersonateUser Then

                    '    AliasAccount.EndImpersonation()

                    'End If

                End Using

            Catch ex As Exception
                Submitted = False
                AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
                ErrorText = "There was an error submitting the expense report. Please contact support."
            End Try

            Return ErrorText

        End Function
        Public Function UnSubmitExpenseReport(ByVal EmployeeCode As String, ByVal InvoiceNumber As Integer) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim UnSubmitted As Boolean = False
            Dim OkToUnSubmit As Boolean = True
            Dim CreditLineExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
            Dim SqlParameterInvoiceNumber As System.Data.SqlClient.SqlParameter = Nothing

            Dim expenseReport As Global.AdvantageMobile.Expense
            Dim emp As Global.AdvantageMobile.Employee

            Try
                emp = (From employee In Me._DataEntities.Employees
                       Where employee.Code = EmployeeCode
                       Select employee).FirstOrDefault

                expenseReport = (From expense In Me._DataEntities.Expenses
                                 Where expense.InvoiceNumber = InvoiceNumber
                                 Select expense).FirstOrDefault

                If emp IsNot Nothing AndAlso expenseReport IsNot Nothing Then
                    'ExpenseReportStatus.Approved, ExpenseReportStatus.ApprovedByApprover, ExpenseReportStatus.ApprovedInAccounting
                    If expenseReport.Status = 2 Or expenseReport.Status = 4 Or expenseReport.IsApproved = 2 Then

                        ErrorText = "Expense report has already been approved and cannot be modified."
                        OkToUnSubmit = False

                    End If

                    If OkToUnSubmit Then

                        If expenseReport.Status <> 5 Then

                            expenseReport.SubmittedTo = Nothing

                        End If

                        expenseReport.Status = 0 'ExpenseReportStatus.Open
                        expenseReport.IsApproved = CShort(0)
                        expenseReport.IsSubmitted = CShort(0)

                        'Mark entity as modified
                        Me._DataEntities.Entry(expenseReport).State = System.Data.Entity.EntityState.Modified

                        If Me._DataEntities.SaveChanges() > 0 Then

                            SqlParameterInvoiceNumber = New System.Data.SqlClient.SqlParameter("@InvoiceNBR", SqlDbType.Int)
                            SqlParameterInvoiceNumber.Value = expenseReport.InvoiceNumber

                            Me._DataEntities.Database.ExecuteSqlCommand("EXEC dbo.usp_wv_exp_delete_credit_line @InvoiceNBR", SqlParameterInvoiceNumber)

                        End If
                        ErrorText = "Successfully unsubmitted expense report."
                    Else

                        UnSubmitExpenseReport = ErrorText

                    End If
                End If
            Catch ex As Exception
                UnSubmitted = False
                ErrorText = "Failed trying to unsubmit. Please contact software support."
            Finally
                UnSubmitExpenseReport = ErrorText
            End Try

        End Function

        Sub New(ByVal DataSource As DataEntities, ByVal CurrentDataServiceUser As DataServiceUser)

            Me._DataEntities = DataSource
            Me._DataServiceUser = CurrentDataServiceUser
            Me._ConnectionString = CurrentDataServiceUser.ConnectionString
            Me._UserCode = Me._DataServiceUser.UserCode

        End Sub

#End Region
#Region " Alerts "

        Public Function BuildAndSendAlertEmailOnSeparateThread() As Boolean

            Dim EmailThreadStart As New ParameterizedThreadStart(AddressOf BuildAndSendAlertEmail)
            Dim EmailThread As New Thread(EmailThreadStart)

            EmailThread.Start()

        End Function

        Private Function BuildAndSendAlertEmail() As Boolean

            Dim Completed As Boolean = False

            Try

                Dim _ImpersonationContext As System.Security.Principal.WindowsImpersonationContext
                Dim _CurrentWindowsIdentity As System.Security.Principal.WindowsIdentity

                If AdvantageFramework.Security.Impersonate.CheckNTAuthentication = True Then

                    Try
                        _CurrentWindowsIdentity = CType(System.Web.HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                    Catch ex As Exception
                        _CurrentWindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
                    End Try

                    _ImpersonationContext = _CurrentWindowsIdentity.Impersonate()

                    Using _ImpersonationContext

                        Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(_ConnectionString, _UserCode)

                            Using DbContext = New AdvantageFramework.Database.DbContext(_ConnectionString, _UserCode)

                                Completed = BuildAndSendAlertEmail(SecurityDbContext, DbContext, Alert, Subject,
                                                   "", "",
                                                   AppName, SupervisorApprovalComment, ExcludeAttachments,
                                                   InsertEmailBodyAsAlertDescription, IsClientPortal,
                                                   IncludeOriginator, WebvantageURL,
                                                   ClientPortalURL, ErrorMessage)
                            End Using

                        End Using

                    End Using

                    _ImpersonationContext.Undo()

                Else

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(_ConnectionString, _UserCode)

                        Using DbContext = New AdvantageFramework.Database.DbContext(_ConnectionString, _UserCode)

                            Completed = BuildAndSendAlertEmail(SecurityDbContext, DbContext, Alert, Subject,
                                                   "", "",
                                                   AppName, SupervisorApprovalComment, ExcludeAttachments,
                                                   InsertEmailBodyAsAlertDescription, IsClientPortal,
                                                   IncludeOriginator, WebvantageURL,
                                                   ClientPortalURL, ErrorMessage)
                        End Using

                    End Using

                End If


            Catch ex As Exception
                Completed = False
            Finally
                BuildAndSendAlertEmail = Completed
            End Try

        End Function
        Private Function BuildAndSendAlertEmail(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                 ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal Alert As AdvantageFramework.Database.Entities.Alert, ByVal Subject As String,
                                                 Optional ByVal EmployeeCodesToSendEmailTo As String = "", Optional ByVal ClientPortalEmailAddressessToSendTo As String = "",
                                                 Optional ByVal AppName As String = "", Optional ByVal SupervisorApprovalComment As String = "", Optional ByVal ExcludeAttachments As Boolean = False,
                                                 Optional ByVal InsertEmailBodyAsAlertDescription As Boolean = False, Optional ByVal IsClientPortal As Boolean = False,
                                                 Optional ByVal IncludeOriginator As Boolean = False, Optional ByVal WebvantageURL As String = "",
                                                 Optional ByVal ClientPortalURL As String = "", Optional ByRef ErrorMessage As String = "") As Boolean

            Dim Completed As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim HTMLEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
            Dim AlertEmailRecipients As Generic.List(Of AdvantageFramework.Database.Classes.AlertEmailRecipient) = Nothing
            Dim ClientPortalAlertEmailRecipients As Generic.List(Of AdvantageFramework.Database.Classes.ClientPortalAlertEmailRecipient) = Nothing
            Dim IsAlertAssignment As Boolean = False
            Dim OriginatorEmployeeCode As String = Nothing
            Dim CurrentAssigneeEmployeeCode As String = Nothing
            Dim AlertAttachmentViews As Generic.List(Of AdvantageFramework.Database.Views.AlertAttachmentView) = Nothing
            Dim AlertComments As Generic.List(Of AdvantageFramework.Database.Classes.AlertComment) = Nothing
            Dim Comment As String = Nothing
            Dim AlertDetails As IEnumerable = Nothing
            Dim EmployeeEmailList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
            Dim HasLinksHeader As Boolean = False
            Dim AttachmentFiles As Generic.List(Of String) = Nothing
            Dim SaveToLocation As String = ""
            Dim FileName As String = ""
            Dim FinalEmailBody As String = ""
            Dim EmployeeCodesToEmail As Generic.List(Of String) = Nothing
            Dim EmailToString As String = ""
            Dim EmailCcString As String = ""
            Dim ExceptionMessage As String = ""
            Dim ClickLinkText As String = ""
            Dim PageName As String = "Alert_View"
            Dim IsConceptShareReview As Boolean = False
            Dim ConceptShareProjectID As Integer = 0
            Dim ConceptShareReviewID As Integer = 0
            Dim IsSingleReviewEmailToClientPortalUser As Boolean = False
            Dim IsSingleReviewEmailToInternalReviewer As Boolean = False

            Dim CurrentWindowsIdentity As System.Security.Principal.WindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
            Dim ImpersonationContext As System.Security.Principal.WindowsImpersonationContext = Nothing
            Dim ImpersonateRepositoryUser As Boolean

            Try

                ImpersonateRepositoryUser = Me._UserName <> ""
                'If AdvantageFramework.Security.Impersonate.CheckNTAuthentication = True Then

                '    Try
                '        CurrentWindowsIdentity = CType(System.Web.HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                '    Catch ex As Exception
                '        CurrentWindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
                '    End Try

                '    ImpersonationContext = CurrentWindowsIdentity.Impersonate()

                'End If

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency IsNot Nothing Then

                    Me._UserDomain = Agency.FileSystemDomain
                    Me._UserName = Agency.FileSystemUserName
                    Me._UserPassword = AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword)
                    Me._Path = Agency.FileSystemDirectory

                End If

                'If ImpersonateRepositoryUser Then
                '    AliasAccount.BeginImpersonation(Me._UserName, Me._UserDomain, Me._UserPassword)
                'End If


                AlertEmailRecipients = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.AlertEmailRecipient)(String.Format("exec dbo.usp_Get_Alert_EmailRecipients {0}", Alert.ID)).ToList

                ClientPortalAlertEmailRecipients = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.ClientPortalAlertEmailRecipient)(String.Format("exec dbo.usp_cp_Get_Alert_EmailRecipients {0}", Alert.ID)).ToList

                IsAlertAssignment = IsAlertAnAlertAssignment(Alert)

                If IsAlertAssignment Then

                    CurrentAssigneeEmployeeCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT EMP_CODE FROM dbo.ALERT_RCPT WITH(ROWLOCK) WHERE ALERT_ID = {0} AND CURRENT_NOTIFY = 1", Alert.ID)).FirstOrDefault()
                    UpdateAssignmentRecipient(DbContext, Alert.ID)

                    If CurrentAssigneeEmployeeCode IsNot Nothing OrElse String.IsNullOrEmpty(CurrentAssigneeEmployeeCode) = False Then

                        EmployeeCodesToSendEmailTo = CurrentAssigneeEmployeeCode

                    End If

                    If IncludeOriginator = True Then

                        EmployeeCodesToSendEmailTo &= "," & Alert.EmployeeCode

                    End If

                    ClientPortalEmailAddressessToSendTo = ""

                    Subject = Subject.Replace("[Alert", "[Assignment")
                    Subject = Subject.Replace("Alert]", "Assignment]")

                Else

                    Try

                        If Alert IsNot Nothing AndAlso Alert.IsConceptShareReview IsNot Nothing AndAlso Alert.IsConceptShareReview = True Then

                            IsConceptShareReview = True
                            ConceptShareProjectID = Alert.ConceptShareProjectID
                            ConceptShareReviewID = Alert.ConceptShareReviewID
                            PageName = "Alert_DigitalAssetReview"
                            Subject = Subject.Replace("Alert]", "Review]")
                            Subject = Subject.Replace("[Alert", "[Review")

                            'ClientPortalAlertEmailRecipients = Nothing

                        End If

                    Catch ex As Exception
                    End Try

                End If

                If EmployeeCodesToSendEmailTo Is Nothing OrElse EmployeeCodesToSendEmailTo = Nothing Then

                    EmployeeCodesToSendEmailTo = ""

                End If

                If (AlertEmailRecipients Is Nothing OrElse AlertEmailRecipients.Count = 0) AndAlso
                   (ClientPortalAlertEmailRecipients Is Nothing OrElse ClientPortalAlertEmailRecipients.Count = 0) AndAlso
                   String.IsNullOrWhiteSpace(EmployeeCodesToSendEmailTo) = True AndAlso String.IsNullOrWhiteSpace(ClientPortalEmailAddressessToSendTo) = True Then

                    ErrorMessage = ""
                    Completed = True

                Else

                    HTMLEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False)

                    ''
                    If IsConceptShareReview = True Then

                        If String.IsNullOrWhiteSpace(EmployeeCodesToSendEmailTo) = True AndAlso String.IsNullOrWhiteSpace(ClientPortalEmailAddressessToSendTo) = True Then
                        ElseIf String.IsNullOrWhiteSpace(EmployeeCodesToSendEmailTo) = True AndAlso String.IsNullOrWhiteSpace(ClientPortalEmailAddressessToSendTo) = False Then
                            IsSingleReviewEmailToClientPortalUser = True
                        ElseIf String.IsNullOrWhiteSpace(EmployeeCodesToSendEmailTo) = False AndAlso String.IsNullOrWhiteSpace(ClientPortalEmailAddressessToSendTo) = True Then
                        ElseIf String.IsNullOrWhiteSpace(EmployeeCodesToSendEmailTo) = False AndAlso String.IsNullOrWhiteSpace(ClientPortalEmailAddressessToSendTo) = False Then
                        End If

                        If String.IsNullOrWhiteSpace(EmployeeCodesToSendEmailTo) = False AndAlso EmployeeCodesToSendEmailTo.Contains(",") = False Then

                            IsSingleReviewEmailToInternalReviewer = True

                        End If

                    End If

                    If IsSingleReviewEmailToInternalReviewer = True Then

                        Try

                            If ClientPortalAlertEmailRecipients IsNot Nothing Then

                                ClientPortalAlertEmailRecipients.Clear()

                            End If

                        Catch ex As Exception
                        End Try

                    End If

                    ''
                    If ClientPortalAlertEmailRecipients IsNot Nothing AndAlso ClientPortalAlertEmailRecipients.Count > 0 Then

                        If IsSingleReviewEmailToClientPortalUser = False AndAlso ((AlertEmailRecipients IsNot Nothing AndAlso AlertEmailRecipients.Count > 0) OrElse
                            (EmployeeCodesToEmail IsNot Nothing AndAlso EmployeeCodesToEmail.Count > 0) OrElse
                            String.IsNullOrWhiteSpace(EmployeeCodesToSendEmailTo) = False) Then

                            If IsAlertAssignment = True Then

                                ClickLinkText = WebvantageWithClientPortalAssignmentLinkVerbiage

                            ElseIf IsConceptShareReview = True Then

                                ClickLinkText = WebvantageWithClientPortalReviewLinkVerbiage

                            Else

                                ClickLinkText = WebvantageWithClientPortalAlertLinkVerbiage

                            End If

                            HTMLEmail.AddHyperlinkRow(String.Format("{0}/{1}.aspx?alert={2}&a={2}&cspid={3}&csrid={4}", Agency.WebvantageURL, PageName, Alert.ID.ToString, ConceptShareProjectID.ToString, ConceptShareReviewID.ToString), ClickLinkText)

                        End If

                        If IsAlertAssignment = True Then

                            ClickLinkText = ClientPortalAssignmentLinkVerbiage

                        ElseIf IsConceptShareReview = True Then

                            ClickLinkText = ClientPortalReviewLinkVerbiage

                        Else

                            ClickLinkText = ClientPortalAlertLinkVerbiage

                        End If

                        If Agency.ClientPortalURL IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Agency.ClientPortalURL) = False AndAlso IsSingleReviewEmailToInternalReviewer = False Then

                            HTMLEmail.AddHyperlinkRow(String.Format("{0}/{1}.aspx?alert={2}&a={2}&cspid={3}&csrid={4}", Agency.ClientPortalURL, PageName, Alert.ID.ToString, ConceptShareProjectID.ToString, ConceptShareReviewID.ToString), ClickLinkText)

                        End If

                    Else

                        Dim HyperLinkRowSet As Boolean = False

                        If IsAlertAssignment = True Then

                            ClickLinkText = WebvantageAssignmentLinkVerbiage

                        ElseIf IsConceptShareReview = True Then

                            ClickLinkText = WebvantageReviewLinkVerbiage

                        Else

                            ClickLinkText = WebvantageAlertLinkVerbiage

                        End If

                        If EmployeeCodesToEmail Is Nothing AndAlso String.IsNullOrWhiteSpace(EmployeeCodesToSendEmailTo) = True Then

                            If ClientPortalAlertEmailRecipients Is Nothing AndAlso String.IsNullOrWhiteSpace(ClientPortalEmailAddressessToSendTo) = False Then

                                If Agency.ClientPortalURL IsNot Nothing AndAlso Agency.ClientPortalURL <> "" AndAlso IsSingleReviewEmailToInternalReviewer = False Then

                                    HTMLEmail.AddHyperlinkRow(String.Format("{0}/{1}.aspx?alert={2}&a={2}&cspid={3}&csrid={4}", Agency.ClientPortalURL, PageName, Alert.ID.ToString, ConceptShareProjectID.ToString, ConceptShareReviewID.ToString), ClickLinkText)

                                End If

                            End If

                        End If

                        If HyperLinkRowSet = False Then

                            HTMLEmail.AddHyperlinkRow(String.Format("{0}/{1}.aspx?alert={2}&a={2}&cspid={3}&csrid={4}", Agency.WebvantageURL, PageName, Alert.ID.ToString, ConceptShareProjectID.ToString, ConceptShareReviewID.ToString), ClickLinkText)

                        End If

                    End If

                    '1. Comments

                    Try

                        Dim Offset As Decimal = 0.0

                        If IsConceptShareReview = False Then

                            Offset = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, String.Empty)

                        Else

                            Offset = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployeeForceUtcZero(DbContext, String.Empty)

                        End If

                        AlertComments = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.AlertComment)(String.Format("EXEC [dbo].[usp_wv_ALERT_GET_COMMENTS] {0}, NULL, {1};", Alert.ID, Offset)).ToList

                        If AlertComments IsNot Nothing AndAlso AlertComments.Count > 0 Then

                            HTMLEmail.AddHeaderRow("Comments")

                            For Each AlertComment In AlertComments

                                If String.IsNullOrEmpty(AlertComment.Comment) = False Then

                                    Comment = AlertComment.Comment

                                    Try

                                        Comment = Comment.Replace(Environment.NewLine, "<br/>")

                                    Catch ex As Exception
                                    End Try

                                    Try

                                        If Comment.Substring((Comment.Length) - 4, 4) = "<br>" Then

                                            Comment = Comment.Substring(0, (Comment.Length) - 4)

                                        End If

                                    Catch ex As Exception
                                    End Try

                                    UrlToHtmlLink(Comment, Agency.WebvantageURL, Agency.ClientPortalURL)
                                    'Comment = System.Web.HttpUtility.HtmlEncode(Comment)

                                Else

                                    Comment = "[No comment left]"

                                End If

                                Comment &= "<br /><b>"

                                If String.IsNullOrEmpty(AlertComment.EmployeeFullName) = False Then

                                    Comment &= "&nbsp;&nbsp;-&nbsp;"
                                    Comment &= AlertComment.EmployeeFullName
                                    Comment &= ", "

                                Else

                                    If String.IsNullOrEmpty(AlertComment.UserCode) = False Then

                                        Comment &= "&nbsp;&nbsp;-&nbsp;"
                                        Comment &= AlertComment.UserCode
                                        Comment &= ", "

                                    End If

                                End If

                                If AlertComment.GeneratedDate.HasValue Then

                                    Comment &= String.Format("{0:G}", AlertComment.GeneratedDate)

                                End If

                                Comment &= "</b><br /><br />"

                                HTMLEmail.AddCustomRow(Comment)
                                'HTMLEmail.AddSeparatorLineRow(Email.Classes.HtmlEmail.SeparatorLineType.Dashed)

                            Next

                        End If

                    Catch ex As Exception

                    End Try

                    ' 2. Details
                    HTMLEmail.AddHeaderRow(Subject)
                    HTMLEmail.AddKeyValueRow("Subject", If(String.IsNullOrEmpty(Alert.Subject), "", Alert.Subject))

                    Dim EmailBody As String = Alert.EmailBody

                    UrlToHtmlLink(EmailBody, Agency.WebvantageURL, Agency.ClientPortalURL)

                    HTMLEmail.AddKeyValueRow("Description", EmailBody)
                    HTMLEmail.AddBlankRow()

                    If AppName = "SupervisorApproval" Then

                        HTMLEmail.AddKeyValueRow("Comments", SupervisorApprovalComment)

                    End If

                    HTMLEmail.AddBlankRow()

                    ' 3. General Info
                    HTMLEmail.AddCustomRow(GeneralInformation(DbContext, Alert))
                    HTMLEmail.AddBlankRow()

                    '4. Details Section
                    If IsClientPortal Then

                        AlertDetails = (From Entity In AdvantageFramework.Database.Procedures.ClientPortalAlertView.Load(DbContext)
                                        Where Entity.AlertID = Alert.ID
                                        Select Entity).ToList

                    Else

                        AlertDetails = (From Entity In AdvantageFramework.Database.Procedures.AlertView.Load(DbContext)
                                        Where Entity.AlertID = Alert.ID
                                        Select Entity).ToList

                    End If

                    If AppName <> "SupervisorApproval" AndAlso AppName <> "Timesheet" AndAlso AppName <> "Expense" AndAlso AppName <> "APVendorMediaInvoiceApproval" Then

                        LoadAlertDetailsInTable(DbContext, AlertDetails, HTMLEmail)

                    End If

                    AttachmentFiles = New Generic.List(Of String)

                    If Convert.ToBoolean(Agency.IncludeAttachmentsWithAlerts.GetValueOrDefault(0)) = 0 AndAlso ExcludeAttachments = False Then 'The property should be renamed to "ExcludeFromEmail" or "IncludeAttachmentsWithAlertsOnly"

                        AlertAttachmentViews = (From Entity In AdvantageFramework.Database.Procedures.AlertAttachmentView.LoadByAlertID(DbContext, Alert.ID)
                                                Where Entity.EmailSent = Nothing OrElse Entity.EmailSent = False
                                                Select Entity).ToList()

                        'If AdvantageFramework.Security.Impersonate.CheckNTAuthentication = True Then

                        '    ImpersonationContext.Undo()

                        'End If

                        HTMLEmail.AddKeyValueRow("Attachments", AlertAttachmentViews.Count.ToString())

                        For Each AlertAttachmentView In AlertAttachmentViews

                            If AlertAttachmentView.MimeType = "URL" Then

                                If HasLinksHeader = False Then

                                    HTMLEmail.AddHeaderRow("Attached Links")
                                    HasLinksHeader = True

                                End If

                                HTMLEmail.AddHyperlinkRow(AlertAttachmentView.RepositoryFilename, AlertAttachmentView.RealFileName)

                            Else

                                If Agency.IsASP.GetValueOrDefault(0) = 1 Then

                                    SaveToLocation = AdvantageFramework.FileSystem.LoadHostedClientDownloadLocation(Agency)

                                ElseIf Agency.FileSystemDirectory = "" Then

                                    SaveToLocation = My.Application.Info.DirectoryPath & "\"

                                Else

                                    SaveToLocation = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\")

                                End If

                                If AdvantageFramework.FileSystem.Download(Agency, AlertAttachmentView, SaveToLocation, FileName) Then

                                    AttachmentFiles.Add(FileName)

                                    If AdvantageFramework.Security.Impersonate.CheckNTAuthentication = True Then

                                        CurrentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                        ImpersonationContext = CurrentWindowsIdentity.Impersonate()

                                    End If

                                    UpdateAlertAttachment(DbContext, AlertAttachmentView.AlertID, AlertAttachmentView.AttachmentID)

                                    If AdvantageFramework.Security.Impersonate.CheckNTAuthentication = True Then

                                        ImpersonationContext.Undo()

                                    End If

                                End If

                            End If

                        Next

                    End If

                    'Finalize the body
                    'Don't modify body after this!!
                    If ClientPortalAlertEmailRecipients IsNot Nothing AndAlso ClientPortalAlertEmailRecipients.Count > 0 Then

                        If IsSingleReviewEmailToClientPortalUser = False AndAlso ((AlertEmailRecipients IsNot Nothing AndAlso AlertEmailRecipients.Count > 0) OrElse
                            (EmployeeCodesToEmail IsNot Nothing AndAlso EmployeeCodesToEmail.Count > 0) OrElse
                            String.IsNullOrWhiteSpace(EmployeeCodesToSendEmailTo) = False) Then

                            If IsAlertAssignment = True Then

                                ClickLinkText = WebvantageWithClientPortalAssignmentLinkVerbiage

                            ElseIf IsConceptShareReview = True Then

                                ClickLinkText = WebvantageWithClientPortalReviewLinkVerbiage

                            Else

                                ClickLinkText = WebvantageWithClientPortalAlertLinkVerbiage

                            End If

                            HTMLEmail.AddHyperlinkRow(String.Format("{0}/{1}.aspx?alert={2}&a={2}&cspid={3}&csrid={4}", Agency.WebvantageURL, PageName, Alert.ID.ToString, ConceptShareProjectID.ToString, ConceptShareReviewID.ToString), ClickLinkText)

                        End If

                        If IsAlertAssignment = True Then

                            ClickLinkText = ClientPortalAssignmentLinkVerbiage

                        ElseIf IsConceptShareReview = True Then

                            ClickLinkText = ClientPortalReviewLinkVerbiage

                        Else

                            ClickLinkText = ClientPortalAlertLinkVerbiage

                        End If

                        If Agency.ClientPortalURL IsNot Nothing AndAlso Agency.ClientPortalURL <> "" AndAlso IsSingleReviewEmailToInternalReviewer = False Then

                            HTMLEmail.AddHyperlinkRow(String.Format("{0}/{1}.aspx?alert={2}&a={2}&cspid={3}&csrid={4}", Agency.ClientPortalURL, PageName, Alert.ID.ToString, ConceptShareProjectID.ToString, ConceptShareReviewID.ToString), ClickLinkText)

                        End If


                    Else

                        Dim HyperLinkRowSet As Boolean = False

                        If IsAlertAssignment = True Then

                            ClickLinkText = WebvantageAssignmentLinkVerbiage

                        ElseIf IsConceptShareReview = True Then

                            ClickLinkText = WebvantageReviewLinkVerbiage

                        Else

                            ClickLinkText = WebvantageAlertLinkVerbiage

                        End If

                        If EmployeeCodesToEmail Is Nothing AndAlso String.IsNullOrWhiteSpace(EmployeeCodesToSendEmailTo) = True Then

                            If ClientPortalAlertEmailRecipients Is Nothing AndAlso String.IsNullOrWhiteSpace(ClientPortalEmailAddressessToSendTo) = False Then

                                If Agency.ClientPortalURL IsNot Nothing AndAlso Agency.ClientPortalURL <> "" AndAlso IsSingleReviewEmailToInternalReviewer = False Then

                                    HTMLEmail.AddHyperlinkRow(String.Format("{0}/{1}.aspx?alert={2}&a={2}&cspid={3}&csrid={4}", Agency.ClientPortalURL, PageName, Alert.ID.ToString, ConceptShareProjectID.ToString, ConceptShareReviewID.ToString), ClickLinkText)

                                End If

                            End If

                        End If

                        If HyperLinkRowSet = False Then

                            HTMLEmail.AddHyperlinkRow(String.Format("{0}/{1}.aspx?alert={2}&a={2}&cspid={3}&csrid={4}", Agency.WebvantageURL, PageName, Alert.ID.ToString, ConceptShareProjectID.ToString, ConceptShareReviewID.ToString), ClickLinkText)

                        End If

                    End If

                    HTMLEmail.Finish()

                    FinalEmailBody = HTMLEmail.ToString(Alert.ID)

                    If InsertEmailBodyAsAlertDescription = True AndAlso IsAlertAssignment = False Then

                        Alert.EmailBody = FinalEmailBody

                        AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)

                    End If

                    If String.IsNullOrWhiteSpace(Subject) = True Then

                        If String.IsNullOrEmpty(Alert.Subject) = False Then

                            Subject = Alert.Subject

                        End If

                    Else

                        If String.IsNullOrEmpty(Alert.Subject) = False AndAlso Subject.Contains(Alert.Subject) = False Then

                            Subject = Subject & " " & Alert.Subject

                        End If

                    End If

                    EmployeeCodesToEmail = New Generic.List(Of String)

                    If String.IsNullOrWhiteSpace(EmployeeCodesToSendEmailTo) = False Then

                        Try

                            For Each EmployeeCode In EmployeeCodesToSendEmailTo.Split(",")

                                EmployeeCodesToEmail.Add(EmployeeCode)

                            Next

                        Catch ex As Exception
                        End Try

                    End If
                    Try

                        If AlertEmailRecipients IsNot Nothing Then

                            For Each AlertEmailRecipient In AlertEmailRecipients

                                EmployeeCodesToEmail.Add(AlertEmailRecipient.EmployeeCode)

                            Next

                        End If

                    Catch ex As Exception
                    End Try

                    Dim EmpEmailString As String = ""
                    Dim CurrentEmployee As AdvantageFramework.Database.Views.Employee

                    If AdvantageFramework.Security.Impersonate.CheckNTAuthentication = True Then

                        CurrentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                        ImpersonationContext = CurrentWindowsIdentity.Impersonate()

                    End If

                    For Each EmployeeCode In EmployeeCodesToEmail.Distinct

                        CurrentEmployee = Nothing
                        EmpEmailString = ""

                        CurrentEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                        If CurrentEmployee IsNot Nothing Then

                            If CurrentEmployee.AlertNotificationType IsNot Nothing AndAlso CurrentEmployee.AlertNotificationType = 3 _
                               AndAlso CurrentEmployee.Email IsNot Nothing AndAlso CurrentEmployee.Email.Trim() <> "" _
                               AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(CurrentEmployee.Email) = True Then

                                EmpEmailString = AdvantageFramework.EmployeeUtilities.LoadEmailWithEmployeeName(CurrentEmployee)

                            End If

                            If EmpEmailString <> "" Then

                                Try
                                    If IsAlertAssignment = False Then

                                        EmailToString &= EmpEmailString & ";"

                                    Else

                                        If EmployeeCode = CurrentAssigneeEmployeeCode Then

                                            EmailToString &= EmpEmailString & ";"

                                        Else

                                            EmailCcString &= EmpEmailString & ";"

                                        End If

                                    End If

                                Catch ex As Exception

                                End Try

                            End If

                        End If

                    Next

                    If ClientPortalAlertEmailRecipients IsNot Nothing Then

                        For Each ClientPortalAlertEmailRecipient In ClientPortalAlertEmailRecipients

                            Try
                                If IsAlertAssignment = False Then

                                    EmailToString &= ClientPortalAlertEmailRecipient.MailBeeTitle & ";"

                                Else

                                    EmailCcString &= ClientPortalAlertEmailRecipient.MailBeeTitle & ";"

                                End If

                            Catch ex As Exception
                            End Try

                        Next

                    End If

                    EmailToString = AdvantageFramework.StringUtilities.CleanStringForSplit(EmailToString, ";", False)
                    EmailCcString = AdvantageFramework.StringUtilities.CleanStringForSplit(EmailCcString, ";", False)

                    EmailToString = AdvantageFramework.StringUtilities.CleanStringForSplit(EmailToString, ",", False)
                    EmailCcString = AdvantageFramework.StringUtilities.CleanStringForSplit(EmailCcString, ",", False)

                    If EmailToString.Trim() = "" And EmailCcString.Trim() = "" Then

                        Completed = True

                    Else

                        'UrlToHtmlLink(FinalEmailBody, Agency.WebvantageURL, Agency.ClientPortalURL)
                        Completed = AdvantageFramework.Email.Send(DbContext, SecurityDbContext, EmailToString, Subject, FinalEmailBody, Alert.PriorityLevel, AttachmentFiles.ToArray, SendingEmailStatus, ExceptionMessage, EmailCcString)

                    End If

                    If AdvantageFramework.Security.Impersonate.CheckNTAuthentication = True Then

                        ImpersonationContext.Undo()

                    End If

                    ErrorMessage = AdvantageFramework.Email.LoadEmailErrorMessage(SendingEmailStatus)

                    If SendingEmailStatus <> AdvantageFramework.Email.SendingEmailStatus.EmailSent AndAlso ExceptionMessage <> "" Then

                        ErrorMessage &= Environment.NewLine & ExceptionMessage

                    End If

                    If AttachmentFiles IsNot Nothing Then

                        For Each AttachmentFile In AttachmentFiles

                            If AdvantageFramework.FileSystem.Delete(Agency, AttachmentFile) = False Then

                                If System.IO.File.Exists(AttachmentFile) Then

                                    System.IO.File.Delete(AttachmentFile)

                                End If

                            End If

                        Next

                    End If

                End If

                'If impersonateUser Then
                '    AliasAccount.EndImpersonation()
                'End If

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Completed = False
            Finally
                BuildAndSendAlertEmail = Completed
            End Try

        End Function


        Private Function CreateExpenseApprovalAlert(
                                                 ByVal ExpenseReport As Global.AdvantageMobile.Expense,
                                                 ByVal Employee As Global.AdvantageMobile.Employee,
                                                 ByRef Alert As AdvantageFramework.Database.Entities.Alert,
                                                 ByVal IncludeReceiptsInEmailAndAlert As Boolean) As Boolean

            'objects
            Dim Created As Boolean = False
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim Supervisor As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing
            'Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
            Dim GeneratedDate As Date = Nothing
            Dim WebvantageURL As String = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me._ConnectionString, Me._UserCode)



                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, "Approvals")

                        'AlertCategory = (From Entity In AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeID(DbContext, AlertType.ID)
                        '                 Where Entity.Description = "Expense Report Approval Request"
                        '                 Select Entity).FirstOrDefault
                        Dim AlertCategoryID As Integer = 0
                        AlertCategoryID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ALERT_CAT_ID FROM dbo.ALERT_CATEGORY WITH(ROWLOCK) WHERE ALERT_TYPE_ID = {0} AND ALERT_DESC = 'Expense Report Approval Request'", AlertType.ID)).FirstOrDefault()

                        Alert = New AdvantageFramework.Database.Entities.Alert

                        WebvantageURL = Agency.WebvantageURL

                        If Not [String].IsNullOrWhiteSpace(Agency.WebvantageURL) Then

                            WebvantageURL = New UriBuilder(Agency.WebvantageURL).ToString

                        Else

                            WebvantageURL = ""

                        End If

                        Dim EmployeeFullName As String = String.Empty
                        If Employee.MiddleInitial IsNot Nothing AndAlso Employee.MiddleInitial.Trim <> "" Then

                            EmployeeFullName = Employee.FirstName & " " & Employee.MiddleInitial & ". " & Employee.LastName

                        Else

                            EmployeeFullName = Employee.FirstName & " " & Employee.LastName

                        End If


                        Alert.AlertTypeID = AlertType.ID
                        Alert.AlertCategoryID = AlertCategoryID
                        Alert.Subject = "Expense Report Approval Request for " & EmployeeFullName
                        Alert.Body = "<a href='" & WebvantageURL & "/SupervisorApproval_Expense.aspx?&sedate=" & System.DateTime.Today & "&empcode=" & ExpenseReport.EmployeeCode & "'> Click here to navigate to Expense Approval. </a>"
                        Alert.GeneratedDate = System.DateTime.Now
                        Alert.PriorityLevel = AdvantageFramework.AlertSystem.PriorityLevels.High
                        Alert.EmployeeCode = Employee.Code
                        Alert.AlertLevel = ""
                        Alert.UserCode = Me._UserCode
                        Alert.DbContext = DbContext

                        Dim insertAlert As New Global.AdvantageMobile.Alert

                        insertAlert.ID = (From Entity In Me._DataEntities.Alerts
                                          Select Entity.ID).Max + 1
                        insertAlert.AlertTypeID = AlertType.ID
                        insertAlert.AlertCategoryID = AlertCategoryID
                        insertAlert.Subject = "Expense Report Approval Request for " & EmployeeFullName
                        insertAlert.Body = "<a href='" & WebvantageURL & "/SupervisorApproval_Expense.aspx?&sedate=" & System.DateTime.Today & "&empcode=" & ExpenseReport.EmployeeCode & "'> Click here to navigate to Expense Approval. </a>"
                        insertAlert.GeneratedDate = System.DateTime.Now
                        insertAlert.Priority = AdvantageFramework.AlertSystem.PriorityLevels.High
                        insertAlert.EmployeeCode = Employee.Code
                        insertAlert.AlertLevel = ""
                        insertAlert.UserCode = Me._UserCode
                        Me._DataEntities.Alerts.Add(insertAlert)

                        'If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then
                        If Me._DataEntities.SaveChanges() > 0 Then
                            Alert.ID = insertAlert.ID
                            Supervisor = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Employee.SupervisorEmployeeCode)

                            If Supervisor IsNot Nothing Then

                                If AdvantageFramework.AlertSystem.CheckEmployeeAlertNotification(Supervisor) Then

                                    AlertRecipient = New AdvantageFramework.Database.Entities.AlertRecipient

                                    AlertRecipient.AlertID = Alert.ID
                                    AlertRecipient.EmployeeCode = Employee.SupervisorEmployeeCode
                                    AlertRecipient.EmployeeEmail = AdvantageFramework.Email.LoadEmployeeEmail(DbContext, Employee.SupervisorEmployeeCode, True, False)

                                    Created = AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRecipient)

                                End If

                            End If

                            If IncludeReceiptsInEmailAndAlert = True Then

                                GeneratedDate = System.DateTime.Now

                                For Each ExpenseDocument In AdvantageFramework.Database.Procedures.ExpenseReportDocument.LoadByInvoiceNumber(DbContext, ExpenseReport.InvoiceNumber).ToList

                                    Try

                                        AlertAttachment = New AdvantageFramework.Database.Entities.AlertAttachment

                                        AlertAttachment.AlertID = Alert.ID
                                        AlertAttachment.DocumentID = ExpenseDocument.DocumentID
                                        AlertAttachment.UserCode = DbContext.UserCode
                                        AlertAttachment.HasEmailBeenSent = False
                                        AlertAttachment.GeneratedDate = GeneratedDate
                                        AlertAttachment.DbContext = DbContext

                                        AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, AlertAttachment)

                                    Catch ex As Exception

                                    End Try

                                Next

                            End If

                        End If

                    End If
                End Using
            Catch ex As Exception
                Created = False
            Finally
                CreateExpenseApprovalAlert = Created
            End Try

        End Function
        Public Function UpdateAssignmentRecipient(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer) As Boolean

            'objects
            Dim Updated As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.ALERT_RCPT WITH(ROWLOCK) SET PROCESSED = NULL, NEW_ALERT = NULL, READ_ALERT = NULL WHERE ALERT_ID = {0} AND CURRENT_NOTIFY = 1", AlertID))

            Catch ex As Exception
                Updated = False
            Finally
                UpdateAssignmentRecipient = Updated
            End Try

        End Function
        Public Function IsAlertAnAlertAssignment(ByVal Alert As AdvantageFramework.Database.Entities.Alert) As Boolean

            'objects
            Dim IsAnAlertAssignment As Boolean = False

            If Alert IsNot Nothing Then

                If Alert.AlertStateID > 0 AndAlso Alert.AlertAssignmentTemplateID > 0 Then

                    IsAnAlertAssignment = True

                End If

            End If

            IsAlertAnAlertAssignment = IsAnAlertAssignment

        End Function
        Public Function GeneralInformation(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Alert As AdvantageFramework.Database.Entities.Alert) As String

            'objects
            Dim GeneralInfo As String = ""
            Dim AlertViews As Generic.List(Of AdvantageFramework.Database.Views.AlertView) = Nothing
            Dim AlertView As AdvantageFramework.Database.Views.AlertView = Nothing
            Dim AlternateAlertID As Integer = Nothing
            Dim HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing

            Try

                AlertViews = (From Entity In AdvantageFramework.Database.Procedures.AlertView.Load(DbContext)
                              Where Entity.AlertID = Alert.ID
                              Select Entity).ToList

                AlertView = AlertViews.FirstOrDefault

                Try

                    AlternateAlertID = CInt((From Entity In AlertViews
                                             Where Entity.AlertSequenceNumber IsNot Nothing
                                             Select Entity.AlertSequenceNumber.GetValueOrDefault(0)).FirstOrDefault)

                Catch ex As Exception
                    AlternateAlertID = 0
                End Try

                If AlternateAlertID = 0 Then

                    AlternateAlertID = Alert.ID

                End If

                HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False)

                HtmlEmail.AddHeaderRow("General Information")
                HtmlEmail.AddKeyValueRow("ID", AlternateAlertID.ToString)

                If Convert.ToBoolean(AlertView.ClientPortalAlert.GetValueOrDefault(0)) = True Then

                    HtmlEmail.AddKeyValueRow("Type", "Client Portal Alert")

                Else

                    HtmlEmail.AddKeyValueRow("Type", "Webvantage Alert")

                End If

                HtmlEmail.AddKeyValueRow("Generated", String.Format("{0:G}", LocalDate(DbContext, Alert.GeneratedDate)))

                If Convert.ToBoolean(AlertView.ClientPortalAlert.GetValueOrDefault(0)) = True Then

                    HtmlEmail.AddKeyValueRow("By", AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(DbContext, Alert.UserCode).ToString)

                Else

                    HtmlEmail.AddKeyValueRow("By", Alert.UserCode)

                End If

                Try

                    If Alert.PriorityLevel IsNot Nothing Then

                        HtmlEmail.AddKeyValueRow("Priority", [Enum].GetName(GetType(AdvantageFramework.AlertSystem.PriorityLevels), Alert.PriorityLevel))

                    End If

                Catch ex As Exception

                End Try

                Try

                    If Alert.AlertCategoryID <> Nothing Then

                        HtmlEmail.AddKeyValueRow("Category", AdvantageFramework.Database.Procedures.AlertCategory.LoadByID(DbContext, Alert.AlertCategoryID).Description)

                    End If

                Catch ex As Exception

                End Try

                Try

                    If Alert.DueDate.HasValue Then

                        HtmlEmail.AddKeyValueRow("Due Date", String.Format("{0:d}", Alert.DueDate))

                    End If

                Catch ex As Exception

                End Try

                Try

                    If String.IsNullOrEmpty(Alert.TimeDue) = False Then

                        HtmlEmail.AddKeyValueRow("Time Due", Alert.TimeDue)

                    End If

                Catch ex As Exception

                End Try

                Try

                    If String.IsNullOrEmpty(AlertView.Version) = False Then

                        HtmlEmail.AddKeyValueRow("Version", AlertView.Version)

                    End If

                Catch ex As Exception

                End Try

                Try

                    If String.IsNullOrEmpty(AlertView.Build) = False Then

                        HtmlEmail.AddKeyValueRow("Build", AlertView.Build)

                    End If

                Catch ex As Exception

                End Try

                HtmlEmail.Finish()

                GeneralInfo = HtmlEmail.ToString

            Catch ex As Exception
                GeneralInfo = ""
            Finally
                GeneralInformation = GeneralInfo
            End Try

        End Function
        Public Function LocalDate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal [Date] As Date) As Date

            Dim NewDate As Date = [Date]

            Try

                Dim DatabaseGMT As Decimal = 0.0
                Dim AgencyGMT As Decimal = 0.0

                LoadGMT(DbContext, AgencyGMT, DatabaseGMT)

                If DatabaseGMT <> AgencyGMT Then

                    NewDate = LocalDate(DatabaseGMT, AgencyGMT, [Date])

                End If

            Catch ex As Exception

                NewDate = [Date]

            Finally

                LocalDate = NewDate

            End Try

        End Function
        Public Function LocalDate(ByVal DatabaseGMTHours As Decimal, ByVal AgencyGMTHours As Decimal, ByVal [Date] As DateTime) As DateTime

            Dim NewDate As DateTime = [Date]

            Try

                If DatabaseGMTHours <> AgencyGMTHours Then

                    NewDate = GetOffsetDateTime(AgencyGMTHours - DatabaseGMTHours, [Date])

                End If

            Catch ex As Exception
                NewDate = [Date]
            Finally
                LocalDate = NewDate
            End Try

        End Function
        Public Function GetOffsetDateTime(ByVal OffSet As Decimal, ByVal [Date] As DateTime) As DateTime

            Return DateAdd(DateInterval.Minute, (CType(OffSet, Integer) * 60) + (OffSet - CType(OffSet, Integer)), [Date])

        End Function
        Public Sub LoadGMT(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef AgencyGMT As Double, ByRef DatabaseGMT As Double)

            AgencyGMT = 0.0
            DatabaseGMT = 0.0

            Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                DatabaseGMT = AdvantageFramework.Database.Procedures.Generic.LoadSQLHoursOffset(DataContext)
                AgencyGMT = AdvantageFramework.Database.Procedures.Generic.LoadAgencyHoursOffset(DataContext)

            End Using

        End Sub
        Public Function UrlToHtmlLink(ByRef TextString As String, ByVal WebvantageURL As String, ByVal ClientPortalURL As String) As Boolean

            If String.IsNullOrWhiteSpace(TextString) = True OrElse
                    TextString.Contains("<img") = True OrElse
                    TextString.Contains("data:image") = True OrElse
                    TextString.Contains("Click here to navigate") = True Then

                Return False

            Else

                Dim HasWebvantageLink As Boolean = False
                Dim FixedBodyText As String = String.Empty
                Dim Splitter As String = "aspx?dl="
                Dim URL As String = String.Empty
                Dim MatchCollection As System.Text.RegularExpressions.MatchCollection = Nothing
                Dim HrefLink As String = String.Empty
                Dim Counter As Integer = 0

                Try

                    FixedBodyText = TextString


                    MatchCollection = GetUrlMatchCollection(FixedBodyText, WebvantageURL, ClientPortalURL)

                    If MatchCollection IsNot Nothing Then

                        Dim ProcessedURLs As New Generic.List(Of String)

                        For Each Match In MatchCollection.OfType(Of System.Text.RegularExpressions.Match).Where(Function(m) m.Success = True)

                            HrefLink = String.Empty

                            Try

                                URL = Match.Value

                            Catch ex As Exception
                                URL = String.Empty
                            End Try

                            If String.IsNullOrWhiteSpace(URL) = False AndAlso ProcessedURLs.Contains(URL) = False Then

                                HrefLink = String.Format("<a style=""overflow-wrap: break-word;word-break:break-all;-ms-word-break: break-all;word-wrap: break-word;"" href=""{0}"">{0}</a>", URL)
                                ProcessedURLs.Add(URL)
                                HasWebvantageLink = True
                                FixedBodyText = FixedBodyText.Replace(URL, HrefLink)

                            End If

                        Next

                        TextString = FixedBodyText

                    End If

                Catch ex As Exception
                End Try

                Return HasWebvantageLink

            End If

        End Function
        Public Function GetUrlMatchCollection(ByRef TextString As String, ByVal WebvantageURL As String, ByVal ClientPortalURL As String) As Text.RegularExpressions.MatchCollection

            Dim Matches As Text.RegularExpressions.MatchCollection = Nothing

            If TextHasInternalLinks(TextString, WebvantageURL, ClientPortalURL) = True Then

                Dim Pattern As String = "\b([\d\w\.\/\+\-\?\:]*)((ht|f)tp(s|)\:\/\/|[\d\d\d|\d\d]\.[\d\d\d|\d\d]\.|www\.|\.tv|\.ac|\.com|\.edu|\.gov|\.int|\.mil|\.net|\.org|\.biz|\.info|\.name|\.pro|\.museum|\.co|\.ca)([\d\w\.\/\%\+\-\=\&amp;\?\:\\\&quot;\'\,\|\~\;]*)\b([=,@,+,!,%,&,*,-])*"
                Dim AllMatches As System.Text.RegularExpressions.MatchCollection = Nothing

                Try

                    Matches = System.Text.RegularExpressions.Regex.Matches(TextString, Pattern, Text.RegularExpressions.RegexOptions.IgnoreCase)

                Catch ex As Exception
                    Matches = Nothing
                End Try

            End If

            Return Matches

        End Function
        Public Function TextHasInternalLinks(ByVal TextString As String, ByVal WebvantageURL As String, ByVal ClientPortalURL As String) As Boolean

            If TextString.Contains(WebvantageURL) OrElse TextString.Contains(ClientPortalURL) OrElse TextString.ToLower.Contains("default.aspx?dl=") Then

                Return True

            Else

                Return False

            End If

        End Function
        Private Sub UpdateAlertAttachment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal AlertAttachmentID As Integer)

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.ALERT_ATTACHMENT WITH(ROWLOCK) SET EMAILSENT = 1 WHERE ATTACHMENT_ID = {0} AND ALERT_ID = {1}", AlertAttachmentID, AlertID))

            Catch ex As Exception

            End Try

        End Sub
        Private Sub LoadAlertDetailsInTable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertDetails As IEnumerable, ByRef HTMLEmail As AdvantageFramework.Email.Classes.HtmlEmail)

            If HTMLEmail IsNot Nothing AndAlso AlertDetails IsNot Nothing Then

                If TypeOf AlertDetails Is IEnumerable(Of AdvantageFramework.Database.Views.AlertView) Then

                    LoadAlertDetailsInTable(DbContext, DirectCast(AlertDetails, IEnumerable(Of AdvantageFramework.Database.Views.AlertView)), HTMLEmail)

                ElseIf TypeOf AlertDetails Is IEnumerable(Of AdvantageFramework.Database.Views.ClientPortalAlertView) Then

                    LoadAlertDetailsInTable(DirectCast(AlertDetails, IEnumerable(Of AdvantageFramework.Database.Views.ClientPortalAlertView)), HTMLEmail)

                End If

            End If

        End Sub
        Private Sub LoadAlertDetailsInTable(ByVal ClientPortalAlertViews As IEnumerable(Of AdvantageFramework.Database.Views.ClientPortalAlertView), HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail)

            'objects
            Dim ClientPortalAlertView As AdvantageFramework.Database.Views.ClientPortalAlertView = Nothing
            Dim TaskDescription As String = ""

            ClientPortalAlertView = ClientPortalAlertViews.FirstOrDefault

            HtmlEmail.AddHeaderRow("Alert Details")

            Try

                If String.IsNullOrEmpty(ClientPortalAlertView.OfficeName) = False Then

                    HtmlEmail.AddKeyValueRow("Office", ClientPortalAlertView.OfficeName)

                End If

            Catch ex As Exception
                Application.ErrorToEventLog(ex)
            End Try

            Try

                If String.IsNullOrEmpty(ClientPortalAlertView.ClientName) = False Then

                    HtmlEmail.AddKeyValueRow("Client", ClientPortalAlertView.ClientName)

                End If

            Catch ex As Exception
                Application.ErrorToEventLog(ex)
            End Try

            Try

                If String.IsNullOrEmpty(ClientPortalAlertView.DivisionName) = False Then

                    HtmlEmail.AddKeyValueRow("Division", ClientPortalAlertView.DivisionName)

                End If

            Catch ex As Exception
                Application.ErrorToEventLog(ex)
            End Try

            Try

                If String.IsNullOrEmpty(ClientPortalAlertView.ProductDescription) = False Then

                    HtmlEmail.AddKeyValueRow("Product", ClientPortalAlertView.ProductDescription)

                End If

            Catch ex As Exception
                Application.ErrorToEventLog(ex)
            End Try

            Try

                If String.IsNullOrEmpty(ClientPortalAlertView.CampaignName) = False Then

                    HtmlEmail.AddKeyValueRow("Campaign", ClientPortalAlertView.CampaignName)

                End If

            Catch ex As Exception
                Application.ErrorToEventLog(ex)
            End Try

            Try

                If String.IsNullOrEmpty(ClientPortalAlertView.JobDescription) = False Then

                    HtmlEmail.AddKeyValueRow("Job", ClientPortalAlertView.JobNumber.ToString().PadLeft(6, "0") & " - " & ClientPortalAlertView.JobDescription)

                End If

            Catch ex As Exception
                Application.ErrorToEventLog(ex)
            End Try

            Try

                If String.IsNullOrEmpty(ClientPortalAlertView.JobComponentDescription) = False Then

                    HtmlEmail.AddKeyValueRow("Component", ClientPortalAlertView.JobComponentNumber.ToString().PadLeft(2, "0") & " - " & ClientPortalAlertView.JobComponentDescription)

                End If

            Catch ex As Exception
                Application.ErrorToEventLog(ex)
            End Try

            HtmlEmail.AddBlankRow()

        End Sub
        Private Sub LoadAlertDetailsInTable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertViews As IEnumerable(Of AdvantageFramework.Database.Views.AlertView), HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail)

            'objects
            Dim AlertView As AdvantageFramework.Database.Views.AlertView = Nothing
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim TaskDescription As String = ""

            AlertView = AlertViews.FirstOrDefault

            HtmlEmail.AddHeaderRow("Alert Details")

            Try

                If String.IsNullOrEmpty(AlertView.OfficeName) = False Then

                    HtmlEmail.AddKeyValueRow("Office", AlertView.OfficeName)

                End If

            Catch ex As Exception
                Application.ErrorToEventLog(ex)
            End Try

            Try

                If String.IsNullOrEmpty(AlertView.ClientName) = False Then

                    HtmlEmail.AddKeyValueRow("Client", AlertView.ClientName)

                End If

            Catch ex As Exception
                Application.ErrorToEventLog(ex)
            End Try

            Try

                If String.IsNullOrEmpty(AlertView.DivisionName) = False Then

                    HtmlEmail.AddKeyValueRow("Division", AlertView.DivisionName)

                End If

            Catch ex As Exception
                Application.ErrorToEventLog(ex)
            End Try

            Try

                If String.IsNullOrEmpty(AlertView.ProductDescription) = False Then

                    HtmlEmail.AddKeyValueRow("Product", AlertView.ProductDescription)

                End If

            Catch ex As Exception
                Application.ErrorToEventLog(ex)
            End Try

            Try

                If String.IsNullOrEmpty(AlertView.CampaignName) = False Then

                    HtmlEmail.AddKeyValueRow("Campaign", AlertView.CampaignName)

                End If

            Catch ex As Exception
                Application.ErrorToEventLog(ex)
            End Try

            Try

                If String.IsNullOrEmpty(AlertView.JobDescription) = False Then

                    HtmlEmail.AddKeyValueRow("Job", AlertView.JobNumber.ToString().PadLeft(6, "0") & " - " & AlertView.JobDescription)

                End If

            Catch ex As Exception
                Application.ErrorToEventLog(ex)
            End Try

            Try

                If String.IsNullOrEmpty(AlertView.JobComponentDescription) = False Then

                    HtmlEmail.AddKeyValueRow("Component", AlertView.JobComponentNumber.ToString().PadLeft(2, "0") & " - " & AlertView.JobComponentDescription)

                End If

            Catch ex As Exception
                Application.ErrorToEventLog(ex)
            End Try

            Try

                If String.IsNullOrEmpty(AlertView.TaskFunctionCode) AndAlso String.IsNullOrEmpty(AlertView.TaskFunctionDescription) = False Then

                    TaskDescription = AlertView.TaskFunctionDescription

                ElseIf String.IsNullOrEmpty(AlertView.TaskFunctionCode) = False AndAlso String.IsNullOrEmpty(AlertView.TaskFunctionDescription) Then

                    TaskDescription = AlertView.TaskFunctionCode

                ElseIf String.IsNullOrEmpty(AlertView.TaskFunctionCode) = False AndAlso String.IsNullOrEmpty(AlertView.TaskFunctionDescription) = False Then

                    TaskDescription = AlertView.TaskFunctionCode & " - " & AlertView.TaskFunctionDescription

                Else

                    TaskDescription = ""

                End If

                If String.IsNullOrEmpty(TaskDescription) = False Then

                    HtmlEmail.AddKeyValueRow("Task", TaskDescription)

                End If

            Catch ex As Exception

            End Try

            If AlertView.AlertLevel = "PST" Then

                Try

                    JobComponentTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, AlertView.JobNumber, AlertView.JobComponentNumber, AlertView.TaskSequenceNumber)

                Catch ex As Exception
                    Application.ErrorToEventLog(ex)
                    JobComponentTask = Nothing
                End Try

                If JobComponentTask IsNot Nothing Then

                    If JobComponentTask.StartDate.HasValue Then

                        HtmlEmail.AddKeyValueRow("Start Date", JobComponentTask.StartDate.Value.ToShortDateString)

                    End If

                    If JobComponentTask.DueDate.HasValue Then

                        HtmlEmail.AddKeyValueRow("Due Date", JobComponentTask.DueDate.Value.ToShortDateString)

                    End If

                End If

            End If

            HtmlEmail.AddBlankRow()

        End Sub

#End Region
#Region " Documents "

        Public Function AddDocument(ByVal EmployeeCode As String, ByVal InvoiceNumber As String, ByVal ExpenseDetailID As Integer, ByVal RowID As Integer, ByVal filename As String, ByVal bytes() As Byte,
                                    ByVal fileType As String, ByVal description As String, ByVal keywords As String, ByVal authorName As String, Optional ByVal FinalLevelID As String = "",
                                    Optional ByVal FinalLevelDescript As String = "", Optional ByVal FilePrefix As String = "", Optional ByVal Repository_FileName As String = "") As String

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_DataServiceUser.ConnectionString, _DataServiceUser.UserCode)

                    Dim documentID As Integer = 0
                    Dim realFilename As String = String.Empty 'Uploaded file name
                    Dim repositoryFilename As String = String.Empty 'Uploaded file name
                    Dim MimeType As String = String.Empty
                    Dim Extension As String = String.Empty
                    Dim FileLength As Integer = bytes.Length
                    Dim UserCode As String = String.Empty
                    Dim privateFlag As Integer = 0
                    Dim DocumentType As String = String.Empty
                    Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        Me._UserDomain = Agency.FileSystemDomain
                        Me._UserName = Agency.FileSystemUserName
                        Me._UserPassword = AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword)
                        Me._Path = Agency.FileSystemDirectory

                        'data:image/png;base64
                        MimeType = fileType.Replace("data:image/", "").Replace(";base64", "").ToLower
                        Extension = MimeType

                        If MimeType.StartsWith("image/") = False Then

                            MimeType = "image/" & MimeType

                        End If

                        'AddDocumentToRepository
                        repositoryFilename = AddDocumentToRepository(InvoiceNumber, filename, bytes, fileType, description, keywords, authorName, FinalLevelID, FinalLevelDescript, "d_", Repository_FileName)

                        If (filename.ToLower().Contains("camera")) Then

                            realFilename = FilePrefix & Guid.NewGuid.ToString() + "." + Extension

                        Else

                            realFilename = filename

                        End If

                        If repositoryFilename.StartsWith("d_") = False Then repositoryFilename = "d_" & repositoryFilename

                        'AddDocumentToDatabase
                        documentID = AddDocumentToDatabase(DbContext, EmployeeCode, realFilename, MimeType, repositoryFilename, FileLength, bytes)

                        If documentID > 0 Then

                            'Update thumbnail
                            'AdvantageFramework.DocumentManager.UpdateDocumentThumbnail(DbContext, Agency, documentID, bytes)

                            'AddExpenseDocument
                            AddExpenseDocument(documentID, InvoiceNumber)

                            'AddExpenseDetailDocument
                            AddExpenseDetailDocument(documentID, InvoiceNumber, ExpenseDetailID, RowID)

                        End If

                        Return realFilename

                    Else

                        Return "Settings not found in the database."

                    End If

                End Using

            Catch ex As Exception
                Application.DebugMessageToEventLog("Error in ExpenseMethods.vb\AddDocument")
                Application.ErrorToEventLog(ex)
            End Try

        End Function
        Public Function AddDocumentToRepository(ByVal InvoiceNumber As String, ByVal filename As String, ByVal bytes() As Byte, ByVal filetype As String,
                                                ByVal description As String, ByVal keywords As String, ByVal authorName As String, Optional ByVal FinalLevelID As String = "",
                                                Optional ByVal FinalLevelDescript As String = "", Optional ByVal FilePrefix As String = "",
                                                Optional ByVal Repository_FileName As String = "") As String
            Try

                Dim impersonateUser As Boolean
                Dim IndexDocument As New System.Xml.XmlDocument
                Dim TemplateXML As New System.Text.StringBuilder
                Dim RepositoryFilename As String = "" ' FilePrefix & Guid.NewGuid.ToString
                Dim IndexDocumentText As String = ""
                Dim fileExt As String = ""
                Dim documentRepository As New MobileDocumentRepository(_ConnectionString, True)

                If String.IsNullOrWhiteSpace(Me._Path) = True Then

                    Dim agency As Agency = _DataEntities.Agencies.FirstOrDefault()
                    If agency IsNot Nothing Then

                        Me._UserDomain = agency.DOC_REPOSITORY_USER_DOMAIN
                        Me._UserName = agency.DOC_REPOSITORY_USER_NAME
                        Me._UserPassword = AdvantageFramework.Security.Encryption.Decrypt(agency.DOC_REPOSITORY_USER_PASSWORD)
                        Me._Path = agency.DOC_REPOSITORY_PATH

                    End If

                End If

                documentRepository.UserDomain = Me._UserDomain
                documentRepository.UserName = Me._UserName
                documentRepository.UserPassword = AdvantageFramework.Security.Encryption.Decrypt(Me._UserPassword)
                documentRepository.Path = Me._Path

                If documentRepository.IsRepositoryLimitFeatureEnabled = True Then

                    Dim ThisFC As New MobileDocumentRepository.FileCompare
                    Dim FileLength As Integer = bytes.Length

                    ThisFC.FileByteLength = CType(FileLength, Long)

                    If documentRepository.IsOverFileSizeLimit(ThisFC) = True Then

                        Throw New Exception(ThisFC.ReturnMessageJS)

                    End If

                End If

                fileExt = filetype.Replace("data:image/", "").Replace(";base64", "")

                If String.IsNullOrWhiteSpace(RepositoryFilename) = True Then

                    RepositoryFilename = FilePrefix & Guid.NewGuid.ToString()

                Else

                    RepositoryFilename = Repository_FileName

                End If

                If RepositoryFilename.StartsWith(FilePrefix) = False Then RepositoryFilename = FilePrefix & RepositoryFilename

                TemplateXML.AppendLine("<?xml version=""1.0"" encoding=""utf-8"" ?>")
                TemplateXML.AppendLine("<documents>")
                TemplateXML.AppendLine("<document filename="""" realfilename=""""  description="""" keywords="""" author="""" finallevel="""" finalleveldetail="""" ></document>")
                TemplateXML.AppendLine("</documents>")

                IndexDocument.LoadXml(TemplateXML.ToString())

                IndexDocument.SelectSingleNode("//documents/document").Attributes("filename").Value = RepositoryFilename
                IndexDocument.SelectSingleNode("//documents/document").Attributes("realfilename").Value = filename
                IndexDocument.SelectSingleNode("//documents/document").Attributes("description").Value = description
                IndexDocument.SelectSingleNode("//documents/document").Attributes("author").Value = authorName
                IndexDocument.SelectSingleNode("//documents/document").Attributes("keywords").Value = keywords
                IndexDocument.SelectSingleNode("//documents/document").Attributes("finallevel").Value = FinalLevelID
                IndexDocument.SelectSingleNode("//documents/document").Attributes("finalleveldetail").Value = FinalLevelDescript

                IndexDocumentText = IndexDocument.OuterXml

                Dim encoding As New System.Text.ASCIIEncoding()
                Dim IndexBytes() As Byte = encoding.GetBytes(IndexDocumentText)

                impersonateUser = Me._UserName <> ""

                If impersonateUser = True Then

                    AliasAccount.BeginImpersonation(Me._UserName, Me._UserDomain, Me._UserPassword)

                End If

                Dim newFileStream As New FileStream(Me._Path & "\" & RepositoryFilename, FileMode.OpenOrCreate, FileAccess.Write)
                newFileStream.Write(bytes, 0, bytes.Length)
                newFileStream.Close()
                newFileStream.Dispose()

                Dim newIndexFileStream As New FileStream(Me._Path & "\" & RepositoryFilename & ".index.xml", FileMode.OpenOrCreate, FileAccess.Write)
                newIndexFileStream.Write(IndexBytes, 0, IndexBytes.Length)
                newIndexFileStream.Close()
                newIndexFileStream.Dispose()

                If impersonateUser = True Then

                    AliasAccount.EndImpersonation()

                End If

                Return RepositoryFilename

            Catch ex As Exception
                Application.DebugMessageToEventLog("Error in ExpenseMethods.vb\AddDocumentToRepository")
                Application.ErrorToEventLog(ex)
                Throw New Exception("There was a problem saving to the Repository; please make sure the Repository Settings are correct." & ex.Message.ToString(), ex)
            End Try

        End Function
        Public Function AddDocumentToDatabase(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal EmployeeCode As String, ByVal filename As String,
                                              ByVal mimeType As String, ByVal repositoryFilename As String, ByVal fileSize As Integer, ByVal FileBytes As Byte()) As Integer

            Dim DocumentID As Integer = 0
            Dim NewDocument As New AdvantageFramework.Database.Entities.Document

            Try

                'Dim impersonationContext1 As System.Security.Principal.WindowsImpersonationContext = Nothing

                'If MiscFN.IsNTAuth = True Then

                '    Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                '    impersonationContext1 = Me.currentWindowsIdentity.Impersonate()

                'End If

                NewDocument.FileName = filename
                NewDocument.FileSystemFileName = repositoryFilename
                NewDocument.MIMEType = mimeType
                NewDocument.Description = filename
                NewDocument.UploadedDate = Date.Now
                NewDocument.UserCode = Me._UserCode
                NewDocument.FileSize = fileSize
                NewDocument.IsPrivate = False
                NewDocument.DocumentTypeID = 3

                Try

                    If FileBytes IsNot Nothing AndAlso FileBytes.Length > 0 Then

                        NewDocument.Thumbnail = AdvantageFramework.DocumentManager.ImageToThumnbnailBytes(FileBytes, filename)

                    End If

                Catch ex As Exception
                    Application.DebugMessageToEventLog("Error in ExpenseMethods.vb\AddDocumentToDatabase")
                    Application.ErrorToEventLog(ex)
                End Try

                If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, NewDocument) = True Then

                    DocumentID = NewDocument.ID

                End If

                Return DocumentID

            Catch ex As Exception
                Application.DebugMessageToEventLog("Error in ExpenseMethods.vb\AddDocumentToDatabase")
                Application.ErrorToEventLog(ex)
                Return -1
            End Try
        End Function

        Public Function DeleteHeaderDocument(ByVal InvoiceNumber As String, ByVal DocumentID As String) As String
            Dim doc As Global.AdvantageMobile.Document
            Dim ErrorText As String = String.Empty
            Try
                doc = (From document In Me._DataEntities.Documents
                       Where document.ID = DocumentID
                       Select document).FirstOrDefault

                DeleteDocumentFromRepository(DocumentID, doc.RepositoryFilename)
                DeleteExpenseDocument(DocumentID, InvoiceNumber)

                DeleteHeaderDocument = "Success deleting the document."

            Catch ex As Exception
                Application.ErrorToEventLog(ex)
                ErrorText = "Failed trying to delete document. Please contact software support."
                'Finally
                DeleteHeaderDocument = ErrorText
            End Try
        End Function
        Public Function DeleteDetailDocument(ByVal DocumentID As String) As String
            Dim doc As Global.AdvantageMobile.Document
            Dim expDoc As Global.AdvantageMobile.ExpenseDocument
            Dim expDetDoc As Global.AdvantageMobile.ExpenseDetailDocument

            Dim ErrorText As String = String.Empty
            Try
                doc = (From document In Me._DataEntities.Documents
                       Where document.ID = DocumentID
                       Select document).FirstOrDefault


                expDoc = (From expensedocument In Me._DataEntities.ExpenseDocuments
                          Where expensedocument.DocumentID = DocumentID
                          Select expensedocument).FirstOrDefault

                expDetDoc = (From expensedetaildocument In Me._DataEntities.ExpenseDetailDocuments
                             Where expensedetaildocument.DocumentID = DocumentID
                             Select expensedetaildocument).FirstOrDefault
                If doc IsNot Nothing AndAlso expDoc IsNot Nothing AndAlso expDetDoc IsNot Nothing Then
                    DeleteExpenseDetailDocument(DocumentID, expDoc.InvoiceNumber, expDetDoc.ExpenseDetailID, expDetDoc.ID)
                    DeleteDocumentFromRepository(DocumentID, doc.RepositoryFilename)

                End If
                DeleteDetailDocument = "Success deleting the document."

            Catch ex As Exception
                Application.ErrorToEventLog(ex)
                ErrorText = "Failed trying to delete document. Please contact software support."
                'Finally
                DeleteDetailDocument = ErrorText
            End Try

        End Function

        Public Overloads Function GetDocumentFromRepository(ByVal repositoryFilename As String) As Byte()
            Dim impersonateUser As Boolean

            Try
                Dim agency As Agency = _DataEntities.Agencies.FirstOrDefault()
                If agency IsNot Nothing Then
                    Me._UserDomain = agency.DOC_REPOSITORY_USER_DOMAIN
                    Me._UserName = agency.DOC_REPOSITORY_USER_NAME
                    Me._UserPassword = AdvantageFramework.Security.Encryption.Decrypt(agency.DOC_REPOSITORY_USER_PASSWORD)
                    Me._Path = agency.DOC_REPOSITORY_PATH
                End If
                impersonateUser = Me._UserName <> ""
                If impersonateUser Then
                    AliasAccount.BeginImpersonation(Me._UserName, Me._UserDomain, Me._UserPassword)
                End If

                Using newFileStream As New FileStream(Me._Path & "\" & repositoryFilename, FileMode.OpenOrCreate, FileAccess.Read)
                    ' Insert code to work with resource.  
                    Dim FileBytes(newFileStream.Length) As Byte
                    ' Load the file into our byte array
                    newFileStream.Read(FileBytes, 0, newFileStream.Length)
                    newFileStream.Close()
                    If impersonateUser Then
                        AliasAccount.EndImpersonation()
                    End If
                    Return FileBytes
                End Using
            Catch ex As Exception
                Application.ErrorToEventLog(ex)
                Throw New Exception("An error occured while trying to retrieve this document to the Webvantage document repository. Ensure that the document repository settings are correct.", ex)
            End Try
        End Function
        Public Function DeleteDocumentFromRepository(ByVal documentId As Integer, ByVal repositoryfilename As String) As Boolean
            Dim impersonateUser As Boolean
            'Dim DocumentName As String = Me.GetDocumentRepositoryFileName(documentId)
            Try
                Dim agency As Agency = _DataEntities.Agencies.FirstOrDefault()
                If agency IsNot Nothing Then
                    Me._UserDomain = agency.DOC_REPOSITORY_USER_DOMAIN
                    Me._UserName = agency.DOC_REPOSITORY_USER_NAME
                    Me._UserPassword = AdvantageFramework.Security.Encryption.Decrypt(agency.DOC_REPOSITORY_USER_PASSWORD)
                    Me._Path = agency.DOC_REPOSITORY_PATH
                End If

                impersonateUser = Me._UserName <> ""
                If impersonateUser Then
                    AliasAccount.BeginImpersonation(Me._UserName, Me._UserDomain, Me._UserPassword)
                End If

                If File.Exists(Me._Path & "\" & repositoryfilename) Then
                    File.Delete(Me._Path & "\" & repositoryfilename)
                End If
                Dim XMLFile As String = repositoryfilename & ".index.xml"
                If File.Exists(Me._Path & "\" & XMLFile) Then
                    File.Delete(Me._Path & "\" & XMLFile)
                End If
                If impersonateUser Then
                    AliasAccount.EndImpersonation()
                End If
                Return True
            Catch ex As Exception
                Application.ErrorToEventLog(ex)
                Throw New Exception("An error occured while trying to delete this document to the Webvantage document repository. Ensure that the document repository settings are correct.", ex)
            End Try
        End Function
        'Public Sub UpdateDocumentThumbnailByID(ByVal DocumentID As Integer)

        '    Try
        '        If DocumentID > 0 Then

        '            Dim doc As Document = (From d In Me._DataEntities.Documents
        '                                   Where d.ID = DocumentID
        '                                   Select d).SingleOrDefault

        '            UpdateDocumentThumbnail(doc)

        '        End If
        '    Catch ex As Exception
        '    End Try

        'End Sub
        'Public Sub UpdateDocumentThumbnail(ByVal Doc As Document)
        '    If Doc IsNot Nothing Then
        '        Try

        '            If String.IsNullOrWhiteSpace(Me._Path) = True Then

        '                Dim agency As Agency = _DataEntities.Agencies.FirstOrDefault()

        '                If agency IsNot Nothing Then

        '                    Me._UserDomain = agency.DOC_REPOSITORY_USER_DOMAIN
        '                    Me._UserName = agency.DOC_REPOSITORY_USER_NAME
        '                    Me._UserPassword = AdvantageFramework.StringUtilities.RijndaelSimpleDecrypt(agency.DOC_REPOSITORY_USER_PASSWORD)
        '                    Me._Path = agency.DOC_REPOSITORY_PATH

        '                End If

        '            End If

        '            Dim file As String = Me._Path & "\" & Doc.RepositoryFilename

        '            If System.IO.File.Exists(file) = False Then

        '                file = file & "." & AdvantageFramework.StringUtilities.ParseLastDot(Doc.FileName)

        '            End If

        '            If System.IO.File.Exists(file) Then

        '                Using OriginalImage As System.Drawing.Image = System.Drawing.Image.FromFile(file)

        '                    If OriginalImage IsNot Nothing Then

        '                        Dim X As Integer = OriginalImage.Width
        '                        Dim Y As Integer = OriginalImage.Height
        '                        Dim Width As Integer = 100
        '                        Dim Height As Integer = CInt((Width * Y) / X)
        '                        Dim DummyCallBack As New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ResizeAbort)

        '                        Using ThumbnailImage As System.Drawing.Image = OriginalImage.GetThumbnailImage(Width, Height, DummyCallBack, IntPtr.Zero)

        '                            If ThumbnailImage IsNot Nothing Then

        '                                Using MemoryStream As System.IO.MemoryStream = New IO.MemoryStream

        '                                    ThumbnailImage.Save(MemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg)

        '                                    Dim ByteImage As Byte()
        '                                    ByteImage = MemoryStream.ToArray()

        '                                    If ByteImage IsNot Nothing AndAlso ByteImage.Length > 0 Then

        '                                        Doc.THUMBNAIL = ByteImage
        '                                        Me._DataEntities.Entry(Doc).State = System.Data.Entity.EntityState.Modified
        '                                        Me._DataEntities.SaveChanges()

        '                                    End If

        '                                End Using

        '                            End If

        '                        End Using

        '                    End If

        '                End Using

        '            End If

        '        Catch ex As Exception
        '        End Try
        '    End If
        'End Sub

        Private Function ResizeAbort() As Boolean

            Return False

        End Function
        Public Function AddExpenseDocument(ByVal documentid As Integer, ByVal inv_nbr As Integer)
            Try

                Dim paramDOCUMENT_ID As New SqlParameter("@DOCUMENT_ID", SqlDbType.Int)

                If documentid = 0 Then

                    paramDOCUMENT_ID.Value = DBNull.Value

                Else

                    paramDOCUMENT_ID.Value = documentid

                End If

                Dim paramINV_NBR As New SqlParameter("@INV_NBR", SqlDbType.Int)
                paramINV_NBR.Value = inv_nbr

                Me._DataEntities.Database.ExecuteSqlCommand("usp_wv_DocumentManager_AddExpenseDocument @DOCUMENT_ID, @INV_NBR",
                                               paramDOCUMENT_ID,
                                               paramINV_NBR
                                               )
                Return True
            Catch ex As Exception
                Application.ErrorToEventLog(ex)
                Return False
            End Try
        End Function
        Public Function DeleteExpenseDocument(ByVal documentid As Integer, ByVal inv_nbr As Integer)
            Try



                Dim paramDOCUMENT_ID As New SqlParameter("@DOCUMENT_ID", SqlDbType.Int)
                If documentid = 0 Then
                    paramDOCUMENT_ID.Value = DBNull.Value
                Else
                    paramDOCUMENT_ID.Value = documentid
                End If


                Dim paramINV_NBR As New SqlParameter("@INV_NBR", SqlDbType.Int)
                paramINV_NBR.Value = inv_nbr

                Me._DataEntities.Database.ExecuteSqlCommand("usp_wv_DocumentManager_DeleteExpenseDocument @DOCUMENT_ID, @INV_NBR",
                                 paramDOCUMENT_ID,
                                 paramINV_NBR
                                 )

                Return True
            Catch ex As Exception
                Application.ErrorToEventLog(ex)
                Return False
            End Try
        End Function
        Public Function AddExpenseDetailDocument(ByVal documentid As Integer, ByVal inv_nbr As Integer, ByVal ExpenseDetailID As Integer, ByVal RowID As Integer)
            Try

                Dim docExpDetail As New ExpenseDetailDocument
                docExpDetail.DocumentID = documentid
                docExpDetail.ExpenseDetailID = ExpenseDetailID
                docExpDetail.ID = RowID
                Me._DataEntities.ExpenseDetailDocuments.Add(docExpDetail)
                Me._DataEntities.SaveChanges()

                Return True
            Catch ex As Exception
                Application.ErrorToEventLog(ex)
                Return False
            End Try
        End Function
        Public Function DeleteExpenseDetailDocument(ByVal documentid As Integer, ByVal InvoiceNumber As Integer, ByVal ExpenseDetailID As Integer, ByVal RowID As Integer)
            Try
                Dim ErrorText As String = String.Empty

                Dim paramDOCUMENT_ID As New SqlParameter("@DOCUMENT_ID", SqlDbType.Int)
                If documentid = 0 Then
                    paramDOCUMENT_ID.Value = DBNull.Value
                Else
                    paramDOCUMENT_ID.Value = documentid
                End If

                Dim paramINV_NBR As New SqlParameter("@INV_NBR", SqlDbType.Int)
                If InvoiceNumber = 0 Then
                    paramINV_NBR.Value = DBNull.Value
                Else
                    paramINV_NBR.Value = InvoiceNumber
                End If

                Dim paramEXPDETAILID As New SqlParameter("@EXPDETAILID", SqlDbType.Int)
                If ExpenseDetailID = 0 Then
                    paramEXPDETAILID.Value = DBNull.Value
                Else
                    paramEXPDETAILID.Value = ExpenseDetailID
                End If

                Dim paramROWID As New SqlParameter("@ROWID", SqlDbType.Int)
                If RowID = 0 Then
                    paramROWID.Value = DBNull.Value
                Else
                    paramROWID.Value = RowID
                End If

                Me._DataEntities.Database.ExecuteSqlCommand("usp_wv_DocumentManager_DeleteExpenseDetailDocument @DOCUMENT_ID, @INV_NBR, @EXPDETAILID, @ROWID",
                                 paramDOCUMENT_ID, paramINV_NBR, paramEXPDETAILID, paramROWID)

                Return True
            Catch ex As Exception
                Application.ErrorToEventLog(ex)
                Return False
            End Try
        End Function

#End Region

    End Class

End Namespace
