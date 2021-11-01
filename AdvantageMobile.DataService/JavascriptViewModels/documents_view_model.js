
(function() {
    AdvantageMobile_UI.DocumentViewModel = function(data) {
				this.ID = ko.observable();
				this.Filename = ko.observable();
				this.RepositoryFilename = ko.observable();
				this.MimeType = ko.observable();
				this.Description = ko.observable();
				this.Keywords = ko.observable();
				this.UploadedDate = ko.observable();
				this.UserCode = ko.observable();
				this.FileSize = ko.observable();
				this.IsPrivate = ko.observable();
				this.DocumentTypeID = ko.observable();
				this.ProofHqUrl = ko.observable();
				this.PROOFHQ_FILEID = ko.observable();
				this.THUMBNAIL = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.DocumentViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			Filename: this.Filename(),
			RepositoryFilename: this.RepositoryFilename(),
			MimeType: this.MimeType(),
			Description: this.Description(),
			Keywords: this.Keywords(),
			UploadedDate: this.UploadedDate(),
			UserCode: this.UserCode(),
			FileSize: this.FileSize(),
			IsPrivate: this.IsPrivate(),
			DocumentTypeID: this.DocumentTypeID(),
			ProofHqUrl: this.ProofHqUrl(),
			PROOFHQ_FILEID: this.PROOFHQ_FILEID(),
			THUMBNAIL: this.THUMBNAIL(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.Filename(data.Filename);
				this.RepositoryFilename(data.RepositoryFilename);
				this.MimeType(data.MimeType);
				this.Description(data.Description);
				this.Keywords(data.Keywords);
				this.UploadedDate(data.UploadedDate);
				this.UserCode(data.UserCode);
				this.FileSize(data.FileSize);
				this.IsPrivate(data.IsPrivate);
				this.DocumentTypeID(data.DocumentTypeID);
				this.ProofHqUrl(data.ProofHqUrl);
				this.PROOFHQ_FILEID(data.PROOFHQ_FILEID);
				this.THUMBNAIL(data.THUMBNAIL);
		
            }
        }
    });
})();