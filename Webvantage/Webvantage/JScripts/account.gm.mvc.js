//
function chk() {
    var x = {
        s: $("#TextBoxServerName").val(),
        d: $("#TextBoxDatabaseName").val(),
        u: $("#TextBoxUserCode").val(),
        p: $("#TextBoxPassword").val()
    };
    //x = btoa(x).toString();
    x = arrayBufferToBase64(x);
    //console.log("x", x);
    //$.post({
    //    url: window.appBase + "Account/GM/si",
    //    dataType: "json",
    //    data: x
    //}).always(function (response) {
    //});

}
function bye() {
}
function arrayBufferToBase64(buffer) {
    var binary = '';
    var bytes = new Uint8Array(buffer);

    var len = bytes.byteLength;
    for (var i = 0; i < len; i++) {
        binary += String.fromCharCode(bytes[i]);
    }
    return window.btoa(binary);
}	
