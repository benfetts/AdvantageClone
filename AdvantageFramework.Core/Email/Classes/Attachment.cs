using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.Email.Classes
{
    [Serializable()]
    public partial class Attachment
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public enum Properties
        {
            AttachmentName,
            File,
            FileBytes
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private string _AttachmentName = "";
        private string _File = "";
        private byte[] _FileBytes = null;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AttachmentName
        {
            get
            {
                string AttachmentNameRet = default;
                AttachmentNameRet = _AttachmentName;
                return AttachmentNameRet;
            }

            set
            {
                _AttachmentName = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string File
        {
            get
            {
                string FileRet = default;
                FileRet = _File;
                return FileRet;
            }

            set
            {
                _File = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] FileBytes
        {
            get
            {
                byte[] FileBytesRet = default;
                FileBytesRet = _FileBytes;
                return FileBytesRet;
            }

            set
            {
                _FileBytes = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public Attachment(string File)
        {
            _File = File;
        }

        public Attachment(string AttachmentName, string File)
        {
            _AttachmentName = AttachmentName;
            _File = File;
        }

        public Attachment(string AttachmentName, byte[] FileBytes)
        {
            _AttachmentName = AttachmentName;
            _FileBytes = FileBytes;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}
