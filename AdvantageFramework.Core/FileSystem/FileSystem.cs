using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace AdvantageFramework.Core.FileSystem
{
    public enum FileFilters
    {
        Default,
        CSV,
        TXT,
        ADVLIC,
        PRNX,
        ZIP,
        REPX,
        INV,
        V51,
        XML,
        P12,
        PFX,
        MIT,
        DAT,
        BUY,
        BUYandDATandTXT,
        PDF,
        XMLandSCX,
        SCX,
        GIF
    }

    public enum FileTypes
    {
        Word,
        Powerpoint,
        Project,
        PDF,
        Excel,
        Image,
        Text,
        Photoshop,
        Illustrator,
        Zip,
        URL,
        Outlook,
        Generic
    }

    public enum DocumentSource
    {
        Default,
        DocumentUpload,
        Alert
    }


    public static class Methods
    {
        public const long KBInBytes = 1024;
        public const long MBInBytes = 1048576;
        public const long GBInBytes = 1073741824;

        public static bool IsValidImage(string File)
        {

            // objects
            bool IsValid = true;
            //System.Drawing.Image Image = null/* TODO Change to default(_) if this is not a reference type */;

            //try
            //{
            //    Image = System.Drawing.Image.FromFile(File);
            //}
            //catch (OutOfMemoryException)
            //{
            //    IsValid = false;
            //}

            return IsValid;
        }
        private static string LoadDocumentPrefix(AdvantageFramework.Core.FileSystem.DocumentSource DocumentSource)
        {
            string rc = "";
            switch (DocumentSource)
            {
                case DocumentSource.DocumentUpload:
                    {
                        rc = "d_";
                        break;
                    }

                case DocumentSource.Alert:
                    {
                        rc = "a_";
                        break;
                    }

                default:
                    {
                        rc = "";
                        break;
                    }
            }

            return rc;
        }
        public static bool IsFileInUse(string File)
        {

            // objects
            bool FileIsInUse = false;
            System.IO.FileStream FileStream = null;

            try
            {
                FileStream = System.IO.File.Open(File, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read, System.IO.FileShare.None);
            }
            catch (Exception ex)
            {
                FileIsInUse = true;
            }

            try
            {
                if (FileStream != null)
                {
                    FileStream.Close();
                    FileStream.Dispose();
                }
            }
            catch (Exception ex)
            {
            }

            finally
            {
                FileStream = null;
            }

            return FileIsInUse;
        }
        public static string LoadFileFilterString(FileFilters FileFilter)
        {

            // objects
            string FileFilterString = "";

            switch (FileFilter)
            {
                case FileFilters.Default:
                    {
                        FileFilterString = "All Files (*.*)|*.*";
                        break;
                    }

                case FileFilters.CSV:
                    {
                        FileFilterString = "CSV Files (*.csv)|*.csv";
                        break;
                    }

                case FileFilters.TXT:
                    {
                        FileFilterString = "Text Files (*.txt)|*.txt";
                        break;
                    }

                case FileFilters.ADVLIC:
                    {
                        FileFilterString = "Advantage License Files (*.advlic)|*.advlic";
                        break;
                    }

                case FileFilters.PRNX:
                    {
                        FileFilterString = "Printed Report Files (*.prnx)|*.prnx";
                        break;
                    }

                case FileFilters.ZIP:
                    {
                        FileFilterString = "Zip Files (*.zip)|*.zip";
                        break;
                    }

                case FileFilters.REPX:
                    {
                        FileFilterString = "DX Report Files (*.repx)|*.repx";
                        break;
                    }

                case FileFilters.INV:
                    {
                        FileFilterString = "Invoice Import Files (*.inv)|*.inv";
                        break;
                    }

                case FileFilters.V51:
                    {
                        FileFilterString = "Invoice Import Files (*.v51)|*.v51";
                        break;
                    }

                case FileFilters.XML:
                    {
                        FileFilterString = "XML Files (*.xml)|*.xml";
                        break;
                    }

                case FileFilters.DAT:
                    {
                        FileFilterString = "DAT Files (*.dat)|*.dat";
                        break;
                    }

                case FileFilters.BUY:
                    {
                        FileFilterString = "BUY Files (*.buy)|*.buy";
                        break;
                    }

                case FileFilters.BUYandDATandTXT:
                    {
                        FileFilterString = "BUY, DAT, & Text Files (*.buy, *.dat, *.txt)|*.buy;*.dat;*.txt";
                        break;
                    }

                case FileFilters.PDF:
                    {
                        FileFilterString = "PDF Files (*.pdf)|*.pdf";
                        break;
                    }

                case FileFilters.XMLandSCX:
                    {
                        FileFilterString = "XML, & SCX Files (*.xml, *.scx)|*.xml;*.scx";
                        break;
                    }
            }

            return FileFilterString;
        }
        public static string LoadFileFilterString(FileFilters[] FileFilters)
        {

            // objects
            List<string> FilterStrings = null;
            string FileFilterString = "";

            FilterStrings = new List<string>();

            foreach (var FileFilter in FileFilters)

                FilterStrings.Add(LoadFileFilterString(FileFilter));

            FileFilterString = string.Join("|", FilterStrings);

            return FileFilterString;
        }
        public static string GetFileName(string File)
        {

            // objects
            string FileName = "";
            System.IO.FileInfo FileInfo = null;

            try
            {
                //var provider = new PhysicalFileProvider(applicationRoot);

                //FileInfo = Computer.FileSystem.GetFileInfo(File);

                //if (FileInfo != null)
                //    FileName = FileInfo.Name;
            }
            catch (Exception ex)
            {
                FileName = "";
            }

            return FileName;
        }
        public static long GetFileSize(System.IO.FileInfo FileInfo)
        {

            // objects
            long FileSize = 0;

            try
            {
                if (FileInfo != null)
                    FileSize = FileInfo.Length;
            }
            catch (Exception ex)
            {
                FileSize = 0;
            }

            return FileSize;
        }
        public static long GetFileSize(string File)
        {

            // objects
            long FileSize = 0;
            System.IO.FileInfo FileInfo = null;

            try
            {
                //FileSize = GetFileSize(My.Computer.FileSystem.GetFileInfo(File));
            }
            catch (Exception ex)
            {
                FileSize = 0;
            }

            return FileSize;
        }
        public static string GetFileSizeWithNotation(double FileSize)
        {
            string[] Notations = new string[10];
            int i = default(int);
            string FileSizeWithNotation = null;


            Notations[0] = "Bytes";
            Notations[1] = "KB"; // Kilobytes
            Notations[2] = "MB"; // Megabytes
            Notations[3] = "GB"; // Gigabytes
            Notations[4] = "TB"; // Terabytes
            Notations[5] = "PB"; // Petabytes
            Notations[6] = "EB"; // Exabytes
            Notations[7] = "ZB"; // Zettabytes
            Notations[8] = "YB"; // Yottabytes

            try
            {
                for (i = Information.UBound(Notations); i >= 0; i += -1)
                {
                    if (FileSize >= (Math.Pow(1024, i)))
                    {
                        if (i >= 2)
                            FileSizeWithNotation = string.Format("{0:N2} {1}", FileSize / (Math.Pow(1024, i)), Notations[i]);
                        else
                            FileSizeWithNotation = string.Format("{0:N0} {1}", FileSize / (Math.Pow(1024, i)), Notations[i]);

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                FileSizeWithNotation = null;
            }

            return FileSizeWithNotation;
        }
        public static AdvantageFramework.Core.FileSystem.FileTypes GetFileType(string FileName, string MIMEType)
        {

            // objects
            AdvantageFramework.Core.FileSystem.FileTypes FileType = default;

            try
            {
                FileType = GetFileTypeByMIMEType(MIMEType);

                if (FileType == FileTypes.Generic)
                    FileType = GetFileTypeByExtension(FileName);
            }
            catch (Exception ex)
            {
                FileType = FileTypes.Generic;
            }

            return FileType;
        }
        public static AdvantageFramework.Core.FileSystem.FileTypes GetFileTypeByMIMEType(string MIMEType)
        {
            AdvantageFramework.Core.FileSystem.FileTypes FileType = default;

            switch (MIMEType)
            {
                case "application/msword":
                case "application/vnd.openxmlformats-officedocument.word":
                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Word;
                        break;
                    }

                case "application/mspowerpoint":
                case "application/vnd.ms-powerpoint":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Powerpoint;
                        break;
                    }

                case "application/msproject":
                case "application/vnd.ms-msproject":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Project;
                        break;
                    }

                case "application/pdf":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.PDF;
                        break;
                    }

                case "application/msexcel":
                case "application/vnd.ms-excel":
                case "application/vnd.openxmlformats-officedocument.spre":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Excel;
                        break;
                    }

                case "image/bmp":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Image;
                        break;
                    }

                case "image/gif":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Image;
                        break;
                    }

                case "image/jpeg":
                case "image/pjpeg":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Image;
                        break;
                    }

                case "image/x-png":
                case "image/png":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Image;
                        break;
                    }

                case "image/tiff":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Image;
                        break;
                    }

                case "text/plain":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Text;
                        break;
                    }

                case "image/x-photoshop":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Photoshop;
                        break;
                    }

                case "application/illustrator":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Illustrator;
                        break;
                    }

                case "URL":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.URL;
                        break;
                    }

                case "application/x-zip-compressed":
                case "application/zip":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Zip;
                        break;
                    }

                case "application/vnd.ms-outlook":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Outlook;
                        break;
                    }

                default:
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Generic;
                        break;
                    }
            }

            return FileType;
        }
        public static AdvantageFramework.Core.FileSystem.FileTypes GetFileTypeByExtension(string FileName)
        {
            AdvantageFramework.Core.FileSystem.FileTypes FileType = default(AdvantageFramework.Core.FileSystem.FileTypes);
            string FileExtension = "";

            try
            {
                FileExtension = new System.IO.FileInfo(FileName).Extension;
            }
            catch (Exception ex)
            {
                FileExtension = "";
            }

            switch (FileExtension)
            {
                case ".doc":
                case ".docx":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Word;
                        break;
                    }

                case ".ppt":
                case ".pptx":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Powerpoint;
                        break;
                    }

                case ".mpg":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Project;
                        break;
                    }

                case ".pdf":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.PDF;
                        break;
                    }

                case ".xls":
                case ".xlsx":
                case ".csv":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Excel;
                        break;
                    }

                case ".bmp":
                case ".gif":
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".tiff":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Image;
                        break;
                    }

                case ".txt":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Text;
                        break;
                    }

                case ".psd":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Photoshop;
                        break;
                    }

                case ".ai":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Illustrator;
                        break;
                    }

                case ".com":
                case ".org":
                case ".net":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.URL;
                        break;
                    }

                case ".zip":
                case "rar":
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Zip;
                        break;
                    }

                default:
                    {
                        FileType = AdvantageFramework.Core.FileSystem.FileTypes.Generic;
                        break;
                    }
            }

            return FileType;
        }
        public static string GetMIMETypeByExtension(string Extension)
        {

            // objects
            string MIMEType = "";
            Microsoft.Win32.RegistryKey RegistryKey = null;

            try
            {
                MIMEType = "application/unknown";

                Extension = Extension.Trim();
                if (Extension.StartsWith(".") == false)
                    Extension = "." + Extension;

                //RegistryKey = Registry.Methods.ClassesRoot.OpenSubKey(Extension.ToLower());

                if (RegistryKey != null)
                {
                    if (RegistryKey.GetValue("Content Type") != null)
                        MIMEType = RegistryKey.GetValue("Content Type").ToString();
                    else
                        MIMEType = "application/unknown";
                }
            }
            catch (Exception ex)
            {
                MIMEType = "application/unknown";
            }

            return MIMEType;
        }
        public static string GetMIMEType(System.IO.FileInfo FileInfo)
        {

            // objects
            string MIMEType = "";

            try
            {
                if (FileInfo != null)
                    MIMEType = GetMIMETypeByExtension(FileInfo.Extension);
            }
            catch (Exception ex)
            {
                MIMEType = "application/unknown";
            }

            return MIMEType;
        }
        public static string GetMIMEType(string File)
        {

            // objects
            string MIMEType = "";

            //TODO fix this
            //try
            //{
            //    MIMEType = GetMIMEType(My.Computer.FileSystem.GetFileInfo(File));
            //}
            //catch (Exception ex)
            //{
            //    MIMEType = "application/unknown";
            //}

            return MIMEType;
        }
        //public static object GetFileImage(AdvantageFramework.Core.FileSystem.FileTypes FileType)
        //{
        //    object FileImage = null;

        //    switch (FileType)
        //    {
        //        case AdvantageFramework.Core.FileSystem.FileTypes.Word:
        //            {
        //                FileImage = AdvantageFramework.My.Resources.WordImage;
        //                break;
        //            }

        //        case  AdvantageFramework.Core.FileSystem.FileTypes.Powerpoint:
        //            {
        //                FileImage = AdvantageFramework.My.Resources.DocumentPowerpoint;
        //                break;
        //            }

        //        case AdvantageFramework.Core.FileSystem.FileTypes.Project:
        //            {
        //                FileImage = AdvantageFramework.My.Resources.DocumentProject;
        //                break;
        //            }

        //        case AdvantageFramework.Core.FileSystem.FileTypes.PDF:
        //            {
        //                FileImage = AdvantageFramework.My.Resources.PDFImage;
        //                break;
        //            }

        //        case AdvantageFramework.Core.FileSystem.FileTypes.Excel:
        //            {
        //                FileImage = AdvantageFramework.My.Resources.ExcelImage;
        //                break;
        //            }

        //        case AdvantageFramework.Core.FileSystem.FileTypes.Image:
        //            {
        //                FileImage = AdvantageFramework.My.Resources.DocumentImage;
        //                break;
        //            }

        //        case AdvantageFramework.Core.FileSystem.FileTypes.Text:
        //            {
        //                FileImage = AdvantageFramework.My.Resources.DocumentText;
        //                break;
        //            }

        //        case AdvantageFramework.Core.FileSystem.FileTypes.Photoshop:
        //            {
        //                FileImage = AdvantageFramework.My.Resources.DocumentPhotoshop;
        //                break;
        //            }

        //        case AdvantageFramework.Core.FileSystem.FileTypes.Illustrator:
        //            {
        //                FileImage = AdvantageFramework.My.Resources.DocumentIllustrator;
        //                break;
        //            }

        //        case AdvantageFramework.Core.FileSystem.FileTypes.Zip:
        //            {
        //                FileImage = AdvantageFramework.My.Resources.DocumentZip;
        //                break;
        //            }

        //        case AdvantageFramework.Core.FileSystem.FileTypes.URL:
        //            {
        //                FileImage = AdvantageFramework.My.Resources.DocumentURL;
        //                break;
        //            }

        //        case AdvantageFramework.Core.FileSystem.FileTypes.Outlook:
        //            {
        //                FileImage = AdvantageFramework.My.Resources.MicrosoftOutlookImage;
        //                break;
        //            }

        //        case AdvantageFramework.Core.FileSystem.FileTypes.Generic:
        //            {
        //                FileImage = AdvantageFramework.My.Resources.DocumentGeneric;
        //                break;
        //            }
        //    }

        //    return FileImage;
        //}
        public static bool Download(AdvantageFramework.Core.Database.Entities.Agency Agency, AdvantageFramework.Core.Database.Entities.Document Document, ref byte[] ByteFile, ref bool FileExists)
        {

            // objects
            bool Downloaded = false;
            System.IO.FileStream FileStream = null;
            string FileSystemFile = null;
            System.IO.BinaryReader BinaryReader = null;
            byte[] _ByteFile = null;
            bool _FileExists = false;

            try
            {
                if (Agency != null && Document != null)
                {
                    AdvantageFramework.Core.Security.Impersonate.RunImpersonated(Agency.DocRepositoryUserName, Agency.DocRepositoryUserDomain,
                        AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.DocRepositoryUserPassword), () =>
                    {
                        try
                        {
                            if (LoadRepositoryFilePath(Agency, Document.RepositoryFilename, ref FileSystemFile))
                            {
                                _FileExists = true;

                                FileStream = new System.IO.FileStream(FileSystemFile, System.IO.FileMode.OpenOrCreate);
                                BinaryReader = new System.IO.BinaryReader(FileStream);
                                _ByteFile = BinaryReader.ReadBytes((int)new FileInfo(FileSystemFile).Length);

                                FileStream.Close();
                                BinaryReader.Close();

                                Downloaded = true;
                            }
                            else {
                                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog("LoadRepositoryFilePath failed", System.Diagnostics.EventLogEntryType.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            Downloaded = false;
                            AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
                        }
                    });

                    FileExists = _FileExists;
                    ByteFile = _ByteFile;

                }
            }
            catch (Exception ex)
            {
                Downloaded = false;
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }

            return Downloaded;
        }
        public static bool DownloadFromExternalLink(AdvantageFramework.Core.Database.Entities.Agency Agency, AdvantageFramework.Core.Database.Entities.Document Document, ref byte[] ByteFile, ref bool FileExists)
        {
            byte[] _ByteFile = null;
            bool Downloaded = false;
            bool _FileExists = false;

            if (Agency != null && Document != null)
            {
                AdvantageFramework.Core.Security.Impersonate.RunImpersonated(Agency.DocRepositoryUserName, Agency.DocRepositoryUserDomain,
                    AdvantageFramework.Core.Security.Encryption.Decrypt(Agency.DocRepositoryUserPassword), () =>
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(Document.RepositoryFilename, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            _ByteFile = new byte[fs.Length];
                            fs.Read(_ByteFile, 0, (int)fs.Length);
                            Downloaded = true;
                            _FileExists = true;
                        }
                    });

                FileExists = _FileExists;
                ByteFile = _ByteFile;
            }

            return Downloaded;
        }
        public static bool Download(AdvantageFramework.Core.Database.Entities.Agency Agency, AdvantageFramework.Core.Database.Entities.Document Document, string SaveLocation, ref string NewFileName, ref bool FileExists)
        {

            // objects
            bool Downloaded = default(Boolean);
            System.IO.FileStream FileStream = null;
            string FileSystemFile = null;
            string File = null;
            System.IO.BinaryReader BinaryReader = null;
            byte[] ByteFile = null;
            System.IO.FileStream FileWriter = null;
            int Counter = 0;
            string FileExtension = null;

            //try
            //{
            //    if (Agency != null && Document != null)
            //    {
            //        AdvantageFramework.Core.Security.Impersonate.BeginImpersonation(Agency.DocRepositoryUserName, Agency.DocRepositoryUserDomain, AdvantageFramework.Core.StringUtilities.Methods.RijndaelSimpleDecrypt(Agency.DocRepositoryUserPassword));

            //        try
            //        {
            //            if (LoadRepositoryFilePath(Agency, Document.RepositoryFilename, FileSystemFile))
            //            {
            //                FileExists = true;

            //                FileStream = new System.IO.FileStream(FileSystemFile, System.IO.FileMode.OpenOrCreate);
            //                BinaryReader = new System.IO.BinaryReader(FileStream);
            //                ByteFile = BinaryReader.ReadBytes(new System.IO.FileInfo(FileSystemFile).Length);

            //                FileStream.Close();
            //                BinaryReader.Close();
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //        }

            //        AdvantageFramework.Core.Security.Impersonate.EndImpersonation();

            //        if (FileExists)
            //        {
            //            if (ByteFile != null)
            //            {
            //                NewFileName = AdvantageFramework.Core.StringUtilities.Methods.AppendTrailingCharacter(SaveLocation, @"\") + Document.Filename;

            //                FileExtension = new System.IO.FileInfo(NewFileName).Extension;

            //                while (System.IO.File.Exists(NewFileName))
            //                {
            //                    Counter = Counter + 1;

            //                    NewFileName = AdvantageFramework.Core.StringUtilities.Methods.AppendTrailingCharacter(SaveLocation, @"\") + Document.Filename.Replace(FileExtension, string.Format("({0})" + FileExtension, Counter.ToString()));
            //                }

            //                try
            //                {
            //                    FileWriter = new System.IO.FileStream(NewFileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            //                    FileWriter.Write(ByteFile, 0, ByteFile.Length);

            //                    Downloaded = true;
            //                }
            //                catch (Exception ex)
            //                {
            //                    Downloaded = false;
            //                }

            //                if (FileWriter != null)
            //                    FileWriter.Close();
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Downloaded = false;
            //}
            return Downloaded;
        }
        public static bool Download(AdvantageFramework.Core.Database.Entities.Agency Agency, AdvantageFramework.Core.Database.Views.AlertAttachmentView AlertAttachmentView, string SaveLocation, ref string NewFileName, ref bool FileExists)
        {

            // objects
            bool Downloaded = default(Boolean);
            System.IO.FileStream FileStream = null;
            string FileSystemFile = null;
            string File = null;
            System.IO.BinaryReader BinaryReader = null;
            byte[] ByteFile = null;
            System.IO.FileStream FileWriter = null;
            int Counter = 0;
            string FileExtension = null;

            try
            {
                if (Agency != null && AlertAttachmentView != null)
                {
                    AdvantageFramework.Core.Security.Impersonate.BeginImpersonation(Agency.DocRepositoryUserName, Agency.DocRepositoryUserDomain, AdvantageFramework.Core.StringUtilities.Methods.RijndaelSimpleDecrypt(Agency.DocRepositoryUserPassword));

                    if (LoadRepositoryFilePath(Agency, AlertAttachmentView.RepositoryFilename, ref FileSystemFile))
                    {
                        FileExists = true;

                        FileStream = new System.IO.FileStream(FileSystemFile, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
                        BinaryReader = new System.IO.BinaryReader(FileStream);
                        ByteFile = BinaryReader.ReadBytes((int)new System.IO.FileInfo(FileSystemFile).Length);
                    }

                    if (FileExists)
                    {
                        if (ByteFile != null)
                        {
                            NewFileName = SaveLocation + @"\" + AlertAttachmentView.RealFileName;

                            FileExtension = new System.IO.FileInfo(NewFileName).Extension;

                            while (System.IO.File.Exists(NewFileName))
                            {
                                Counter = Counter + 1;

                                NewFileName = SaveLocation + @"\" + AlertAttachmentView.RealFileName.Replace(FileExtension, string.Format("({0})" + FileExtension, Counter.ToString()));
                            }

                            FileWriter = new System.IO.FileStream(NewFileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                            FileWriter.Write(ByteFile, 0, ByteFile.Length);
                            FileWriter.Close();

                            Downloaded = true;
                        }
                    }

                    AdvantageFramework.Core.Security.Impersonate.EndImpersonation();
                }
            }
            catch (Exception )
            {
                Downloaded = false;
            }
            return Downloaded;
        }

        //public static bool Add(AdvantageFramework.Core.Security.Session Session, AdvantageFramework.Core.Database.Entities.Agency Agency, System.IO.MemoryStream MemoryStream, string RealFileName, string Description, string Keywords, string UserCodeOrEmployeeName, string FinalLevel = "", string FinalLevelDescription = "", AdvantageFramework.Core.FileSystem.DocumentSource DocumentSource = DocumentSource.Default, ref string FileSystemFile = "", ref string FileName = "", bool AddToDocumentRepository = false, ref int DocumentID = default(Integer))
        //{
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //    {
        //        return Add(DbContext, Agency, MemoryStream, RealFileName, Description, Keywords, UserCodeOrEmployeeName, FinalLevel, FinalLevelDescription, DocumentSource, FileSystemFile, FileName, AddToDocumentRepository, DocumentID);
        //    }
        //}
        public static bool Add(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Agency Agency, System.IO.MemoryStream MemoryStream, string RealFileName, string Description, string Keywords, string UserCodeOrEmployeeName, string FinalLevel, string FinalLevelDescription, AdvantageFramework.Core.FileSystem.DocumentSource DocumentSource, ref string FileSystemFile, ref string FileName, bool AddToDocumentRepository, ref int DocumentID)
        {

            // objects
            bool FileAdded = false;
            System.Text.StringBuilder StringBuilder = null;
            System.Xml.XmlDocument XMLDocument = null;
            byte[] IndexFile = null;
            System.IO.FileStream FileWriter = null;
            bool ImpersonateUser = false;
            string FilePrefix = null;
            System.Byte[] ByteFile = null;
            AdvantageFramework.Core.Database.Entities.Document Document = null;

            try
            {
                if (Agency != null)
                {
                    FilePrefix = LoadDocumentPrefix(DocumentSource);

                    if (FileSystemFile == "")
                        FileName = FilePrefix + Guid.NewGuid().ToString();

                    StringBuilder = new System.Text.StringBuilder();

                    StringBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                    StringBuilder.AppendLine("<documents>");
                    StringBuilder.AppendLine("<document filename=\"\" realfilename=\"\"  description=\"\" keywords=\"\" author=\"\" finallevel=\"\" finalleveldetail=\"\" ></document>");
                    StringBuilder.AppendLine("</documents>");

                    XMLDocument = new System.Xml.XmlDocument();

                    XMLDocument.LoadXml(StringBuilder.ToString());
                    XMLDocument.SelectSingleNode("//documents/document").Attributes["filename"].Value = FileName;
                    XMLDocument.SelectSingleNode("//documents/document").Attributes["realfilename"].Value = RealFileName;
                    XMLDocument.SelectSingleNode("//documents/document").Attributes["description"].Value = Description;
                    XMLDocument.SelectSingleNode("//documents/document").Attributes["author"].Value = UserCodeOrEmployeeName;
                    XMLDocument.SelectSingleNode("//documents/document").Attributes["keywords"].Value = Keywords;
                    XMLDocument.SelectSingleNode("//documents/document").Attributes["finallevel"].Value = FinalLevel;
                    XMLDocument.SelectSingleNode("//documents/document").Attributes["finalleveldetail"].Value = FinalLevelDescription;

                    IndexFile = System.Text.ASCIIEncoding.ASCII.GetBytes(XMLDocument.OuterXml);

                    ByteFile = MemoryStream.ToArray();

                    if (Agency.DocRepositoryUserName != null)
                    {
                        ImpersonateUser = true;

                        AdvantageFramework.Core.Security.Impersonate.BeginImpersonation(Agency.DocRepositoryUserName, Agency.DocRepositoryUserDomain, AdvantageFramework.Core.StringUtilities.Methods.RijndaelSimpleDecrypt(Agency.DocRepositoryUserPassword));
                    }

                    try
                    {
                        FileSystemFile = AdvantageFramework.Core.StringUtilities.Methods.AppendTrailingCharacter(Agency.DocRepositoryPath, @"\") + FileName;

                        FileWriter = new System.IO.FileStream(FileSystemFile, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                        FileWriter.Write(ByteFile, 0, ByteFile.Length);
                        FileWriter.Close();

                        FileWriter = new System.IO.FileStream(FileSystemFile + ".index.xml", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                        FileWriter.Write(IndexFile, 0, IndexFile.Length);
                        FileWriter.Close();

                        FileAdded = true;
                    }
                    catch (Exception ex)
                    {
                        FileAdded = false;
                    }

                    if (ImpersonateUser)
                        AdvantageFramework.Core.Security.Impersonate.EndImpersonation();

                    if (FileAdded)
                    {
                        if (AddToDocumentRepository)
                        {
                            Document = new AdvantageFramework.Core.Database.Entities.Document();
                            Document.RepositoryFilename = FileName;
                            Document.Filename = RealFileName;
                            Document.Description = Description;
                            Document.Keywords = Keywords;
                            Document.MimeType = AdvantageFramework.Core.FileSystem.Methods.GetMIMEType(RealFileName);
                            Document.UploadedDate = System.DateTime.Now;
                            //TODO: Fix this
                            //Document.UserCode = DbContext.UserCode;
                            Document.FileSize = ByteFile.Length;
                            Document.PrivateFlag = null;
                            Document.DocumentTypeId = 2; // File

                            System.Security.Principal.WindowsIdentity CurrentWindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
                            //TODO: Fix this
                            //                            System.Security.Principal.WindowsImpersonationContext ImpersonationContext = null;

                            if (ImpersonateUser == true)
                            {
                                try
                                {
                                    //TODO: Fix this
                                    //                                    CurrentWindowsIdentity = (System.Security.Principal.WindowsIdentity)System.Web.HttpContext.Current.User.Identity;
                                }
                                catch (Exception ex)
                                {
                                    CurrentWindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
                                }

                                //TODO: Fix this
                                //                                ImpersonationContext = CurrentWindowsIdentity.Impersonate();
                            }

                            try
                            {
                                Document.DocumentId = (from Entity in AdvantageFramework.Core.Database.Procedures.Documents.Load(DbContext).AsQueryable()
                                                       select Entity.DocumentId).Max() + 1;
                            }
                            catch (Exception ex)
                            {
                                Document.DocumentId = 1;
                            }

                            if (AdvantageFramework.Core.Database.Procedures.Documents.Insert(DbContext, Document))
                                DocumentID = Document.DocumentId;

                            //TODO: Fix this
                            //                            if (ImpersonateUser)
                            //ImpersonationContext.Undo();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FileAdded = false;
            }

            return FileAdded;
        }
        public static bool Add(AdvantageFramework.Core.Database.Entities.Agency Agency,
            string File, string Description, string Keywords, string UserCodeOrEmployeeName,
            string FinalLevel = "", string FinalLevelDescription = "",
            AdvantageFramework.Core.FileSystem.DocumentSource DocumentSource = DocumentSource.Default,
            string FileSystemFile = "", byte[] byteFile = null, string FileName = ""
            /*System.Diagnostics.EventLog EventLog = null*/)
        {

            // objects
            bool FileAdded = false;
            System.Text.StringBuilder StringBuilder = null;
            System.Xml.XmlDocument XMLDocument = null;
            byte[] IndexFile = null;
            System.IO.FileStream FileWriter = null;
            bool ImpersonateUser = false;
            System.IO.FileStream FileStream = null;
            System.IO.BinaryReader BinaryReader = null;
            string FilePrefix = null;

            try
            {
                if (Agency != null)
                {
                    FilePrefix = LoadDocumentPrefix(DocumentSource);

                    if (FileSystemFile == "")
                        FileName = FilePrefix + Guid.NewGuid().ToString();

                    StringBuilder = new System.Text.StringBuilder();

                    StringBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                    StringBuilder.AppendLine("<documents>");
                    StringBuilder.AppendLine("<document filename=\"\" realfilename=\"\"  description=\"\" keywords=\"\" author=\"\" finallevel=\"\" finalleveldetail=\"\" ></document>");
                    StringBuilder.AppendLine("</documents>");

                    XMLDocument = new System.Xml.XmlDocument();

                    XMLDocument.LoadXml(StringBuilder.ToString());
                    XMLDocument.SelectSingleNode("//documents/document").Attributes["filename"].Value = FileName;
                    XMLDocument.SelectSingleNode("//documents/document").Attributes["realfilename"].Value = new System.IO.FileInfo(File).Name;
                    XMLDocument.SelectSingleNode("//documents/document").Attributes["description"].Value = Description;
                    XMLDocument.SelectSingleNode("//documents/document").Attributes["author"].Value = UserCodeOrEmployeeName;
                    XMLDocument.SelectSingleNode("//documents/document").Attributes["keywords"].Value = Keywords;
                    XMLDocument.SelectSingleNode("//documents/document").Attributes["finallevel"].Value = FinalLevel;
                    XMLDocument.SelectSingleNode("//documents/document").Attributes["finalleveldetail"].Value = FinalLevelDescription;

                    IndexFile = System.Text.ASCIIEncoding.ASCII.GetBytes(XMLDocument.OuterXml);

                    if (byteFile == null)
                    {
                        FileStream = new System.IO.FileStream(File, System.IO.FileMode.OpenOrCreate);
                        BinaryReader = new System.IO.BinaryReader(FileStream);
                        //TODO Fix This
                        //byteFile = BinaryReader.ReadBytes(new System.IO.FileInfo(File).Length);

                        FileStream.Close();
                        FileStream.Dispose();
                        BinaryReader.Close();
                    }

                    if (Agency.DocRepositoryUserName != null)
                    {
                        ImpersonateUser = true;

                        AdvantageFramework.Core.Security.Impersonate.BeginImpersonation(Agency.DocRepositoryUserName, Agency.DocRepositoryUserDomain, AdvantageFramework.Core.StringUtilities.Methods.RijndaelSimpleDecrypt(Agency.DocRepositoryUserPassword));
                    }

                    try
                    {
                        //if (EventLog != null)
                        //    EventLog.WriteEntry("Saving file to document repository --> " + Agency.DocRepositoryPath);

                        FileSystemFile = AdvantageFramework.Core.StringUtilities.Methods.AppendTrailingCharacter(Agency.DocRepositoryPath, @"\") + FileName;

                        FileWriter = new System.IO.FileStream(FileSystemFile, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                        FileWriter.Write(byteFile, 0, byteFile.Length);
                        FileWriter.Close();

                        FileWriter = new System.IO.FileStream(FileSystemFile + ".index.xml", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                        FileWriter.Write(IndexFile, 0, IndexFile.Length);
                        FileWriter.Close();

                        FileAdded = true;
                    }
                    catch (Exception ex)
                    {
                        FileAdded = false;
                    }

                    if (!FileAdded)
                    {
                        //if (EventLog != null)
                        //{
                        //    if (!System.IO.Directory.Exists(Agency.DocRepositoryPath))
                        //        EventLog.WriteEntry("Directory does not exist --> " + Agency.DocRepositoryPath);
                        //    else
                        //        EventLog.WriteEntry("Saving file to document repository failed! Please check document repository settings.");
                        //}
                    }

                    if (ImpersonateUser)
                        AdvantageFramework.Core.Security.Impersonate.EndImpersonation();
                }
            }
            catch (Exception ex)
            {
                FileAdded = false;

                //if (EventLog != null)
                //    EventLog.WriteEntry("Saving file to document repository failed! --> " + ex.Message);
            }

            return FileAdded;
        }
        public static bool Delete(AdvantageFramework.Core.Database.Entities.Agency Agency, string RepositoryFilename)
        {
            string ErrorMessage = string.Empty;
            return Delete(Agency, RepositoryFilename, ref ErrorMessage);
        }
        public static bool Delete(AdvantageFramework.Core.Database.Entities.Agency Agency, string RepositoryFilename, ref string ErrorMessage)
        {

            // objects
            bool Deleted = false;
            bool ImpersonateUser = false;

            try
            {
                if (Agency != null)
                {
                    if (Agency.DocRepositoryUserName != null)
                    {
                        ImpersonateUser = true;

                        AdvantageFramework.Core.Security.Impersonate.BeginImpersonation(Agency.DocRepositoryUserName, Agency.DocRepositoryUserDomain, AdvantageFramework.Core.StringUtilities.Methods.RijndaelSimpleDecrypt(Agency.DocRepositoryUserPassword));
                    }
                    if (System.IO.File.Exists(AdvantageFramework.Core.StringUtilities.Methods.AppendTrailingCharacter(Agency.DocRepositoryPath, @"\") + RepositoryFilename))
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();

                        System.IO.File.Delete(AdvantageFramework.Core.StringUtilities.Methods.AppendTrailingCharacter(Agency.DocRepositoryPath, @"\") + RepositoryFilename);

                        Deleted = true;
                    }
                    else if (System.IO.File.Exists(RepositoryFilename))
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();

                        System.IO.File.Delete(RepositoryFilename);

                        Deleted = true;
                    }
                    if (System.IO.File.Exists(AdvantageFramework.Core.StringUtilities.Methods.AppendTrailingCharacter(Agency.DocRepositoryPath, @"\") + RepositoryFilename + ".index.xml"))
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();

                        System.IO.File.Delete(AdvantageFramework.Core.StringUtilities.Methods.AppendTrailingCharacter(Agency.DocRepositoryPath, @"\") + RepositoryFilename + ".index.xml");
                    }
                    else if (System.IO.File.Exists(RepositoryFilename + ".index.xml"))
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        System.IO.File.Delete(RepositoryFilename + ".index.xml");
                    }
                    if (ImpersonateUser)
                        AdvantageFramework.Core.Security.Impersonate.EndImpersonation();
                }
            }
            catch (Exception ex)
            {
                Deleted = false;
            }

            return Deleted;
        }
        public static long GetDocumentRepositoryFileSizeLimit(AdvantageFramework.Core.Database.DbContext DbContext)
        {

            // objects
            long RepositoryLimit = default(long);

            try
            {
                //TODO Fix This
                //RepositoryLimit = Convert.ToInt64(DbContext.Database.SqlQuery<string>("exec usp_wv_DocumentManager_Limit_Get 1").Single);
            }
            catch (Exception ex)
            {
                RepositoryLimit = default(long);
            }

            return RepositoryLimit;
        }
        public static void GetDocumentRepositoryFileSizeLimit(AdvantageFramework.Core.Database.DbContext DbContext, ref long RespositoryLimit, ref string LimitText)
        {

            // objects
            long MaxFileSize = default(long);

            try
            {
                MaxFileSize = GetDocumentRepositoryFileSizeLimit(DbContext);
            }
            catch (Exception ex)
            {
                MaxFileSize = default(long);
            }

            if (MaxFileSize >= 0)
                LimitText = "Files larger than " + Math.Round((MaxFileSize / (double)1024) / 1024, 0).ToString() + "MB will automatically be excluded.";
            else
                LimitText = "";
        }
        public static void GetDocumentRepositoryMaxFileSizeLimit(AdvantageFramework.Core.Database.DbContext DbContext, ref long MaxFileSize, ref string LimitText)
        {
            try
            {
                MaxFileSize = GetDocumentRepositoryFileSizeLimit(DbContext);
            }
            catch (Exception ex)
            {
                MaxFileSize = -1;
            }
            if (MaxFileSize >= 0)
                LimitText = "Files larger than " + Math.Round((MaxFileSize / (double)1024) / 1024, 0).ToString() + "MB will automatically be excluded.";
            else
                LimitText = "";
        }

        public static long GetDocumentRepositoryLimit(AdvantageFramework.Core.Database.DbContext DbContext)
        {

            // objects
            long RepositoryLimit = default(long);

            try
            {
                //TODO Fix This
                //RepositoryLimit = Convert.ToInt64(DbContext.Database.SqlQuery<string>("exec usp_wv_DocumentManager_Limit_Get 0").Single);
            }
            catch (Exception ex)
            {
                RepositoryLimit = default(long);
            }

            return RepositoryLimit;
        }
        public static long GetDocumentRepositorySize(AdvantageFramework.Core.Database.DbContext DbContext)
        {

            // objects
            Int64 RepositorySize = default(long);

            try
            {

                // RepositorySize = (From Entity In AdvantageFramework.Core.Database.Procedures.Document.Load(DbContext).ToList
                // Select Entity.FileSize).Sum
                //TODO Fix this
                //RepositorySize = DbContext.Database.SqlQuery<Int64>("SELECT SUM(CAST(FILE_SIZE AS BIGINT)) FROM DOCUMENTS WITH(NOLOCK);").SingleOrDefault;
            }
            catch (Exception ex)
            {
                RepositorySize = default(long);
            }

            return RepositorySize;
        }
        public static bool LoadRepositoryFilePath(AdvantageFramework.Core.Database.DbContext DbContext, string FileName, ref string RepositoryFilePath)
        {
            bool FileLoaded = false;
            string FileSystemDirectory = "";

            try
            {
                if (DbContext != null)
                {
                    FileSystemDirectory = AdvantageFramework.Core.Database.Procedures.Agency.LoadFileSystemDirectory(DbContext);

                    FileLoaded = LoadRepositoryFilePath(FileSystemDirectory, FileName, ref RepositoryFilePath);
                }
            }
            catch (Exception ex)
            {
                FileLoaded = false;
            }

            return FileLoaded;
        }
        public static bool LoadRepositoryFilePath(AdvantageFramework.Core.Database.Entities.Agency Agency, string FileName, ref string RepositoryFilePath)
        {
            bool FileLoaded = false;

            try
            {
                //TODO Fix this
                if (Agency != null)
                    FileLoaded = LoadRepositoryFilePath(Agency.DocRepositoryPath, FileName, ref RepositoryFilePath);
            }
            catch (Exception ex)
            {
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
                FileLoaded = false;
            }
            return FileLoaded;
        }
        public static bool LoadRepositoryFilePath(string FileSystemDirectory, string FileName, ref string RepositoryFilePath)
        {
            bool FileLoaded = false;

            try
            {
                RepositoryFilePath = AdvantageFramework.Core.StringUtilities.Methods.AppendTrailingCharacter(FileSystemDirectory, @"\") + FileName;

                if (System.IO.File.Exists(RepositoryFilePath))
                {
                    FileLoaded = true;
                }
                else
                {
                    AdvantageFramework.Core.Security.Methods.AddToProofingEventLog("File repository \"" + RepositoryFilePath + "\" does not exist.", System.Diagnostics.EventLogEntryType.Error);
                }
            }
            catch (Exception ex)
            {
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
                FileLoaded = false;
            }

            return FileLoaded;
        }
        public static void CheckRepositoryConstraints(AdvantageFramework.Core.Database.DbContext DbContext, string FileName, ref bool IsValid, ref string ErrorMessage)
        {

            // objects
            System.IO.FileInfo FileInfo = null;

            try
            {
                FileInfo = new System.IO.FileInfo(FileName);

                CheckFileForRepositoryConstraints(DbContext, FileInfo.Length, ref IsValid, ref ErrorMessage);
            }
            catch (Exception ex)
            {
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public static void CheckFileForRepositoryConstraints(AdvantageFramework.Core.Database.DbContext DbContext, long FileLength, ref bool IsValid, ref string ErrorMessage)
        {

            // objects
            long MaxFileSize = default(long);
            long DocumentRepositoryLimit = -1;

            try
            {
                MaxFileSize = GetDocumentRepositoryFileSizeLimit(DbContext);
                //TODO Fix this
                //DocumentRepositoryLimit = AdvantageFramework.Core.FileSystem.GetDocumentRepositoryLimit(DbContext);

                if ((DocumentRepositoryLimit > 0) && (GetDocumentRepositorySize(DbContext) + FileLength > DocumentRepositoryLimit))
                {
                    ErrorMessage = "The file size exceeds the space left in the repository. File will not be uploaded! Please contact an administrator.";
                    IsValid = false;
                }
                else if (MaxFileSize == 0)
                {
                    ErrorMessage = "*Upload file size is set to 0 MB. File will not be uploaded! Please contact an administrator.";
                    IsValid = false;
                }
                else if ((MaxFileSize > 0) && (FileLength > MaxFileSize))
                {
                    ErrorMessage = "The file size exceeds the max file size limit. File will not be uploaded! Please contact an administrator.";
                    IsValid = false;
                }
            }
            catch (Exception ex)
            {
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public static bool CheckRepositoryLimit(AdvantageFramework.Core.Database.DbContext DbContext, long DocumentRepositoryLimit, ref string ErrorMessage)
        {

            // objects
            bool ValidRepositoryLimit = true;
            long DocumentRepositorySize = 0;

            try
            {
                if (DocumentRepositoryLimit > 0)
                {
                    DocumentRepositorySize = GetDocumentRepositorySize(DbContext);

                    if ((DocumentRepositoryLimit - DocumentRepositorySize) < 1)
                    {
                        ErrorMessage = "There is no more space left in the repository. File(s) will not be uploaded! Please contact an administrator.";
                        ValidRepositoryLimit = false;
                    }
                }
            }
            catch (Exception ex)
            {
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }

            return ValidRepositoryLimit;
        }
        public static bool CheckRepositoryLimit(AdvantageFramework.Core.Database.DbContext DbContext, ref string ErrorMessage)
        {

            // objects
            bool ValidRepositoryLimit = true;
            long DocumentRepositoryLimit = -1;
            long DocumentRepositorySize = 0;

            try
            {
                DocumentRepositoryLimit = GetDocumentRepositoryLimit(DbContext);
                DocumentRepositorySize = GetDocumentRepositorySize(DbContext);

                if (DocumentRepositoryLimit > 0)
                {
                    if ((DocumentRepositoryLimit - DocumentRepositorySize) < 1)
                    {
                        ErrorMessage = "There is no more space left in the repository. File(s) will not be uploaded! Please contact an administrator.";
                        ValidRepositoryLimit = false;
                    }
                }
            }
            catch (Exception ex)
            {
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }

            return ValidRepositoryLimit;
        }
        public static string LoadHostedClientUploadLocation(AdvantageFramework.Core.Database.Entities.Agency Agency)
        {

            // objects
            string UploadLocation = "";

            try
            {
                if (Agency.AspActive.GetValueOrDefault(0) == 1)
                    UploadLocation = AdvantageFramework.Core.StringUtilities.Methods.AppendTrailingCharacter(Agency.ImportPath, @"\") + @"Repository\In\";
            }
            catch (Exception ex)
            {
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
                UploadLocation = "";
            }

            return UploadLocation;
        }
        public static string LoadHostedClientUploadLocation(AdvantageFramework.Core.Database.DbContext DbContext)
        {

            // objects
            AdvantageFramework.Core.Database.Entities.Agency Agency = null;

            Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);

            return LoadHostedClientUploadLocation(Agency);
        }
        public static string LoadHostedClientDownloadLocation(AdvantageFramework.Core.Database.Entities.Agency Agency)
        {

            // objects
            string DownloadLocation = "";

            try
            {
                if (Agency.AspActive.GetValueOrDefault(0) == 1)
                    DownloadLocation = AdvantageFramework.Core.StringUtilities.Methods.AppendTrailingCharacter(Agency.ImportPath, @"\") + @"Repository\Out\";
            }
            catch (Exception ex)
            {
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
                DownloadLocation = "";
            }

            return DownloadLocation;
        }
        public static string LoadHostedClientDownloadLocation(AdvantageFramework.Core.Database.DbContext DbContext)
        {

            // objects
            AdvantageFramework.Core.Database.Entities.Agency Agency = null;

            Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);

            return LoadHostedClientDownloadLocation(Agency);
        }
        public static bool IsValidFileName(string FileName)
        {

            // objects
            bool IsValid = true;

            foreach (var BadChar in System.IO.Path.GetInvalidFileNameChars())
            {
                if (FileName.Contains(BadChar))
                {
                    IsValid = false;
                    break;
                }
            }

            return IsValid;
        }
        public static string CreateValidFileName(string FileName)
        {

            // objects
            string ValidFileName = "";

            ValidFileName = FileName;

            try
            {
                foreach (var BadChar in System.IO.Path.GetInvalidFileNameChars())
                {
                    if (ValidFileName.Contains(BadChar))
                        ValidFileName = ValidFileName.Replace(BadChar.ToString(), string.Empty);
                }
            }
            catch (Exception ex)
            {
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
                ValidFileName = FileName;
            }

            return ValidFileName;
        }
        //public static List<AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute> LoadAvailableDocumentManagerLevels(AdvantageFramework.Security.Session Session)
        //{

        //    // objects
        //    AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute EnumObject = null/* TODO Change to default(_) if this is not a reference type */;
        //    Generic.List<AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute> EnumObjects = null/* TODO Change to default(_) if this is not a reference type */;
        //    Generic.List<AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute> DocumentManagerLevels = null/* TODO Change to default(_) if this is not a reference type */;

        //    DocumentManagerLevels = new Generic.List<AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute>();

        //    EnumObjects = AdvantageFramework.EnumUtilities.LoadEnumObjects(typeof(AdvantageFramework.Database.Entities.DocumentLevel));

        //    using (var SecurityDbContext = new AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //    {
        //        foreach (var UserPermission in AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndUser(SecurityDbContext, Session.Application, Session.User.ID).Where(Entity => Entity.ModuleCode.StartsWith("Desktop_DocumentManagerLevels_")).ToList)
        //        {
        //            if (UserPermission.IsBlocked == false)
        //            {
        //                try
        //                {
        //                    EnumObject = EnumObjects.SingleOrDefault(EO => EO.Description == UserPermission.Module);
        //                }
        //                catch (Exception ex)
        //                {
        //                    EnumObject = null/* TODO Change to default(_) if this is not a reference type */;
        //                }

        //                if (EnumObject != null)
        //                    DocumentManagerLevels.Add(EnumObject);
        //            }
        //        }
        //    }

        //    return DocumentManagerLevels;
        //}
        //public static string AddDateGUID(string File)
        //{
        //    try
        //    {
        //        System.IO.FileInfo FileInfo = null;
        //        string FileName = "";
        //        string FileExtension = "";

        //        FileInfo = My.Computer.FileSystem.GetFileInfo(File);

        //        FileExtension = FileInfo.Extension;
        //        FileName = FileInfo.Name.ToString().Replace(FileExtension, "");

        //        if (!FileName == null && !FileExtension == null)
        //            FileName = FileName + DateGUID(true) + FileExtension;
        //        else
        //            FileName = File;

        //        return FileName;
        //    }
        //    catch (Exception ex)
        //    {
        //        return File;
        //    }
        //}
        public static string DateGUID(bool IncludeSpacer = true, bool IncludeTime = true, bool IncludeSeconds = true, bool IncludeMilliseconds = false)
        {
            try
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                {
                    var withBlock = sb;
                    if (IncludeSpacer == true)
                        withBlock.Append("_");

                    withBlock.Append(DateTime.Now.Year.ToString());
                    withBlock.Append(DateTime.Now.Month.ToString().PadLeft(2, '0'));
                    withBlock.Append(DateTime.Now.Day.ToString().PadLeft(2, '0'));

                    if (IncludeSpacer == true)
                        withBlock.Append("_");

                    if (IncludeTime == true)
                    {
                        withBlock.Append(DateTime.Now.Hour.ToString().PadLeft(2, '0'));
                        withBlock.Append(DateTime.Now.Minute.ToString().PadLeft(2, '0'));

                        if (IncludeSeconds == true)
                            withBlock.Append(DateTime.Now.Second.ToString().PadLeft(2, '0'));

                        if (IncludeMilliseconds == true)
                        {
                            if (IncludeSpacer == true)
                                withBlock.Append("_");

                            withBlock.Append(DateTime.Now.Millisecond.ToString().PadLeft(4));
                        }
                    }
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
                return "";
            }
        }
        //public static string GetDefaultNonHostedDownloadLocation()
        //{

        //    // objects
        //    string DownloadLocation = "";
        //    System.IO.DirectoryInfo DirectoryInfo = null;

        //    if (CheckDirectoryForReadWriteAccess(My.Application.Info.DirectoryPath))
        //    {
        //        DownloadLocation = AdvantageFramework.Core.StringUtilities.Methods.AppendTrailingCharacter(My.Application.Info.DirectoryPath, @"\") + @"Downloads\";

        //        if (My.Computer.FileSystem.DirectoryExists(DownloadLocation) == false)
        //            My.Computer.FileSystem.CreateDirectory(DownloadLocation);

        //        if (My.Computer.FileSystem.DirectoryExists(DownloadLocation) == false || CheckDirectoryForReadWriteAccess(My.Application.Info.DirectoryPath) == false)
        //            DownloadLocation = "";
        //    }

        //    return DownloadLocation;
        //}
        //public static bool CheckDirectoryForReadWriteAccess(string Directory)
        //{

        //    // objects
        //    bool HasReadWriteAccess = false;
        //    System.Security.Permissions.FileIOPermission FileIOPermission = null;

        //    FileIOPermission = new System.Security.Permissions.FileIOPermission(System.Security.Permissions.FileIOPermissionAccess.Write | System.Security.Permissions.FileIOPermissionAccess.Read, Directory);

        //    try
        //    {
        //        FileIOPermission.Demand();

        //        HasReadWriteAccess = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        HasReadWriteAccess = false;
        //    }

        //    return HasReadWriteAccess;
        //}
    }
}
