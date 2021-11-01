<%@ Page Title="Chat" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Chat_Room.aspx.vb" Inherits="Webvantage.Chat_Room" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style type="text/css">
        html {
            overflow: hidden;
        }
        #chat-container {
            width:100%;
            /*height: 485px;*/
            clear: both;
            overflow: hidden;
            vertical-align:top;
            border: 0px solid green;
            padding: 0px;
            margin: 0px;
        }
        #chat-left-container {
            position:relative;
            margin: 0px;
            padding: 0px 0px 0px 0px;
            border: 0px solid red;
        }
        #chat-discussion-container {
            border: 0px solid #cecece;
            height:383px;
            overflow-x: hidden;
            overflow-y: auto;
            margin-bottom:7px;
            padding: 4px 4px 4px 8px;
        }
        #chat-input-container {
            /*height: 85px;*/
            border: 0px solid aqua;
        }
        #chat-input-buttons-container {
            margin-top:4px;
        }

        #chat-right-container {
            position:relative;
            width: 290px;
            float:right;
            vertical-align:top;
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            top: 0;
            border: 0px solid blue;
      }

        ul.users {
            list-style-type: none;
            list-style: none;
            margin: 0px 0px 0px 0px;
            padding-left: 1em;
            text-indent: -1em;
        }

        .chat-message {
            border: solid 1px #F44336;
            padding: 5px 0px 5px 5px;
            margin: 0px 0px 5px 0px;
        }
        .chat-message-special {
            font-style: italic !important;
            color: #F44336 !important;
            text-align:center !important;
            width: 100% !important;
            display:block;
            clear:both;
        }
        .right {
            text-align: right !important;
            float: right !important;
            right: 0px;
        }
        .emoticon {
            height:24px;
            width:24px;
            margin-bottom: -3px;
        }
   </style>
    <telerik:RadScriptBlock ID="RadScriptBlockHead" runat="server">
        <script type="text/javascript">
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div id="chat-container">
        <div id="chat-right-container">
            <div class="card" style="height: 470px !important;clear: both !important;">
                <div style="padding: 4px;border:0px red solid;height:410px;width:260px;overflow-x:hidden;overflow-y:auto;">
                    <ul id="intheroom" class="users"></ul>
                </div>
                <div class="card-bottom-header card-bottom-header-bg" title="This is a list of users currently in the conversation.  Offline users will not appear here.">
                    <div style="display: inline-block; padding: 6px 0px 0px 8px; color: #FFFFFF !important;">
                        In the room
                    </div>
                    <div class="card-action-bar">
                    </div>
                </div>
            </div>
        </div>
        <div id="chat-left-container">
            <div id="chat-discussion-container"></div>
            <div id="chat-input-container">
                <input type="text" id="message" style="width: 410px; margin: 0px 0px 0px 0px;" />
                <input type="button" id="send" value="Send" title="Click to send message or use the ENTER key on your keyboard." />
                <div id="chat-input-buttons-container" style="">
                    <div style="display: inline-block; float: left;">
                        <input type="button" id="roomactions" value="Room Details" title="Click for room details, actions, and options." />
                        <input type="button" id="leaveroom" value="Leave Room" title="Leave this room.  You will no longer be able to participate or follow the conversation." />
                        <input type="checkbox" id="isPrivate" checked="checked" title="Only you and those participating in the conversation will see this room in the 'Available rooms' list.">Private
                        <input type="checkbox" id="hideSystemMessages" checked="checked" title="Hide system generated messages">Hide system messages
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="empName" style="display: none !important;"><%=Session("EmployeeName")%></div>
    <script type="text/javascript" src="Scripts/jquery.signalR-2.4.2.min.js"></script>
    <script src="signalr/hubs"></script>
    <script type="text/javascript">
        function refreshChat() {
            //alert("Chat Room refreshChat");
        }
        $(function () {

            $('#message').focus();

            var chat = $.connection.chatHub;
            var uc = '<%=Session("UserCode")%>';
            var ec = '<%=Session("EmpCode")%>';
            var en = "";
            var guid = '<%=AdvantageFramework.Security.Encryption.ASCIIEncoding(Session("ConnString"))%>';
            var roomId = '<%=Me.RoomID%>';
            var chatRoomId = <%=Me.ChatRoomID%>;
            var chatActive = '<%=Session("CheckModuleAccessDesktop_Chat").ToString.ToLower%>';

            var messageInput = $("#message");
            var roomActionsButton = $("#roomactions");
            var leaveRoomButton = $("#leaveroom");
            var isPrivateCheckBox = $("#isPrivate");
            var sendButton = $("#send");

            var hideSystemMessagesCheckBox = $("#hideSystemMessages");
            var hideSystemMessages = true;

            hideSystemMessages = $('#hideSystemMessages').is(':checked');

            //  Helpers 
            function logMsg(msg) {
                //console.log("Chat_Room.aspx,   RoomID: " + roomId + ", message:" + msg)
            }
            function scrollToBottom() {
                window.setTimeout(function () {
                    $("#chat-discussion-container").animate({ scrollTop: $('#chat-discussion-container').prop("scrollHeight") }, 1000);
                }, 50);
            }
            function hasMessage() {
                if ($('#message').val() && $('#message').val().trim() != '') {
                    return true
                } else {
                    ShowMessage('No message to send.\n');
                    return false;
                }
            }
            function addMessage(fullName, message, timeStamp, picture, scroll, isSystemMessage) {
                window.setTimeout(function () {
                    var encodedName;
                    var encodedMsg;
                    var discussionMessage = '';
                    var hasBoth = false;
                    var isSpecial = false;
                    hideSystemMessages = $('#hideSystemMessages').is(':checked');
                    // This needs to change to read the IsSystemMessage flag
                    if (isSystemMessage == "true" || isSystemMessage == true) {
                        fullName = null;
                        isSpecial = true;
                    }
                    logMsg(isSpecial);
                    if (hideSystemMessages == true && isSpecial == true) {
                        return;
                    } else {
                        logMsg("Message: " + message)
                        logMsg("isSystemMessage: " + isSystemMessage)
                        logMsg("hideSystemMessages: " + hideSystemMessages)
                        logMsg("isSpecial: " + isSpecial)
                        if ((fullName && fullName != '') && (message && message != '')) {
                            hasBoth = true;
                        }
                        if (isSpecial === true) {
                            discussionMessage += '<div class=\'chat-card chat-message-special\'>';
                        } else {
                            //alert(fullName)
                            //alert(en)
                            if (fullName == en) {

                                discussionMessage += '<div class=\'chat-card chat-card-color-me right\'>';
                            } else {
                                discussionMessage += '<div class=\'chat-card chat-card-color\'>';
                            }
                        }
                        if (picture && isSpecial === false) {
                            discussionMessage += '<div class=\'comment-image-container\'>';
                            if (fullName == en) {
                                discussionMessage += '<img id="ItemPreview" class="wv-employee-img-thumbnail-lg comment-image-right" src="data:image/png;base64,' + picture + '" />';
                            } else {
                                discussionMessage += '<img id="ItemPreview" class="wv-employee-img-thumbnail-lg comment-image-left" src="data:image/png;base64,' + picture + '" />';
                            }
                            discussionMessage += '</div>';
                        }
                        if (fullName == en && isSpecial === false) {
                            discussionMessage += '<div class=\'comment-container-right\'>';
                        } else {
                            discussionMessage += '<div class=\'comment-container\'>';
                        }
                        if (fullName && fullName != '') {
                            discussionMessage += '<div class=\'wv-employee-img-thumbnail\'>';
                            if (fullName == en) {
                                fullName = 'I';
                            }
                            discussionMessage += $('<div />').text(fullName).html();
                            discussionMessage += ' said:</div>';
                        }
                        if (fullName == en && isSpecial === false) {
                            discussionMessage += '<div class=\'comment-right\'>';
                        } else {
                            discussionMessage += '<div class=\'comment-left\'>';
                        }
                        if (message && message != '') {

                            message = $('<div />').text(message).html();
                            message = checkForEmoticon(message);
                            discussionMessage += message;

                        }
                        discussionMessage += '</div>';
                        discussionMessage += '<div class=\'comment-date\'>';
                        discussionMessage += timeStamp;
                        discussionMessage += '</div>';
                        discussionMessage += '</div>';
                        discussionMessage += '</div>';
                        $('#chat-discussion-container').append(discussionMessage);
                        //console.log(discussionMessage);
                        if (scroll == true) {
                            scrollToBottom();
                        }
                    }
                }, 1);
            }
            function send() {
                if (roomId) {
                    if (hasMessage() === true) {
                        disableControls(true);
                        chat.server.sendMessageToRoom(roomId, $('#message').val())
                                    .done(function () {
                                        $('#message').val('').focus();
                                        disableControls(false);
                                    })
                                    .fail(function (error) {
                                        console.log('sendMessageToRoom error: ' + error);
                                    });
                    }
                }
            }
            function listUsers() {
                // list users in room
                chat.server.loadUsersInRoom(roomId)
                            .done(function () {
                            })
                            .fail(function (error) {
                                console.log('loadUsersInRoom error: ' + error);
                            });
            }
            function checkForEmoticon(message) {
                if (message) {
                    if (message.indexOf(":") > -1 || message.indexOf("(") > -1 || message.indexOf(")") > -1) {
                        message = message.replaceAll(":)", "<img src='Images/Icons/White/256/emoticon_smile.png' class='emoticon' />");
                        message = message.replaceAll(":(", "<img src='Images/Icons/White/256/emoticon_frown.png' class='emoticon' />");
                        message = message.replaceAll(":p", "<img src='Images/Icons/White/256/emoticon_tongue.png' class='emoticon' />");
                        message = message.replaceAll(":s", "<img src='Images/Icons/White/256/emoticon_angry.png' class='emoticon' />");
                        message = message.replaceAll("(h)", "<img src='Images/Icons/White/256/emoticon_cool.png' class='emoticon' />");
                        message = message.replaceAll(":d", "<img src='Images/Icons/White/256/emoticon_grin.png' class='emoticon' />");
                        message = message.replaceAll(":'(", "<img src='Images/Icons/White/256/emoticon_cry.png' class='emoticon' />");
                        message = message.replaceAll(";)", "<img src='Images/Icons/White/256/emoticon_blink.png' class='emoticon' />");
                        message = message.replaceAll(":x", "<img src='Images/Icons/White/256/emoticon_kiss.png' class='emoticon' />");
                        message = message.replaceAll("<:o)", "<img src='Images/Icons/White/256/emoticon_clown.png' class='emoticon' />");
                        message = message.replaceAll(":o", "<img src='Images/Icons/White/256/emoticon_surprised.png' class='emoticon' />");
                        message = message.replaceAll(":/", "<img src='Images/Icons/White/256/emoticon_confused.png' class='emoticon' />");
                        message = message.replaceAll(":|", "<img src='Images/Icons/White/256/emoticon_straight_face.png' class='emoticon' />");
                    } 
                }
                return message;
            }
            String.prototype.replaceAll = function (search, replacement) {
                var target = this;
                return target.replace(new RegExp(escapeRegExp(search), 'gi'), replacement);
            };
            function escapeRegExp(str) {
                return str.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1");
            }
            function disableControls(disabled) {
                if (messageInput) {
                    messageInput.prop("disabled", disabled);
                }
                if (roomActionsButton) {
                    roomActionsButton.prop('disabled', disabled);
                }
                if (leaveRoomButton) {
                    leaveRoomButton.prop('disabled', disabled);
                }
                if (isPrivateCheckBox) {
                    isPrivateCheckBox.prop('disabled', disabled);
                }
                if (sendButton) {
                    sendButton.prop('disabled', disabled);
                }
            }

            disableControls(true);

            //  Callbacks from server
            chat.client.roomRenamed = function (RoomID) {
                if (RoomID == roomId) {
                    logMsg("callback roomRenamed");
                    //alert("Room renamed!")
                    location.reload();
                }
            };
            chat.client.showMessage = function (RoomID, fullName, message, timestamp, picture, isSystem) {
                if (RoomID == roomId) {
                    logMsg("callback showMessage");
                    addMessage(fullName, message, timestamp, picture, true, isSystem);
                }
            };
            chat.client.loadUsersInRoom = function (RoomID, ConnectedUsers) {
                if (RoomID == roomId) {
                    logMsg("callback loadUsersInRoom");
                    window.setTimeout(function () {
                        $('#intheroom').empty();
                        var parsed = $.parseJSON(ConnectedUsers)
                        if (parsed) {
                            for (var i in parsed) {
                                //alert(parsed[i].FullName);
                                $('#intheroom').append('<li>' + parsed[i].EmployeeFullName + '</li>');
                            }
                        }
                    }, 1);
                }
            };
            chat.client.loadMessages = function (RoomID, Messages) {
                if (RoomID == roomId) {
                    logMsg("callback loadMessages");
                    window.setTimeout(function () {
                        $('#chat-discussion-container').empty();
                        var parsed = $.parseJSON(Messages)
                        if (parsed) {
                            for (var i in parsed) {
                                addMessage(parsed[i].FullName, parsed[i].Message, parsed[i].TimeStampToLongDateString, parsed[i].EmployeePicture, false, parsed[i].IsSystemMessage);
                            }
                        }
                    }, 1);
                    scrollToBottom();
                }
            };
            chat.client.roomIsPrivate = function (RoomID, isPrivate) {
                if (RoomID == roomId) {
                    logMsg("callback roomIsPrivate");
                    $('#isPrivate').prop('checked', isPrivate);
                }
            }
            chat.client.leftRoom = function (RoomID, leftMessage, leftTimeStamp) {
                if (RoomID == roomId) {
                    logMsg("callback leftRoom");
                    listUsers();
                    addMessage("", leftMessage, leftTimeStamp, null, true, true)
                }
            }
            chat.client.userSignedOut = function (RoomID, leftMessage, leftTimeStamp) {
                if (RoomID == roomId) {
                    logMsg("callback userSignedOut");
                    listUsers();
                    addMessage("", leftMessage, leftTimeStamp, null, true, true)
                }
            }
            chat.client.roomDeleted = function (RoomID) {
                if (RoomID == roomId) {
                    logMsg("callback roomDeleted");
                    ShowMessage("Room no longer available.\n\n It has either been deleted by the room creator or discarded from memory because all users have left the room.");
                    closeWindow();
                }
            }
            try {
                en = $("#empName").text();
            } catch (e) {en = ""}
            //  Connection params
            $.connection.hub.qs = {
                'u': "",
                'e': "",
                'n': "",
                'guid': "",
                'ca' : chatActive
            };
            //  Log to console
            //$.connection.hub.logging = true;
            //  Init
            if ($.connection.hub && $.connection.hub.state === $.signalR.connectionState.disconnected) {
                $.connection.hub
                    .start({ waitForPageLoad: false }, function () {

                    })
                    .done(function () {
                        $('#send').click(function () {
                            send();
                        });
                        $('#message').on("keypress", function (e) {
                            if (e.keyCode == 13) {
                                send();
                                return false; 
                            }
                        });
                        $('#roomactions').click(function () {
                            var roomName = '';
                            var isPrivate = false;
                            roomName = $('#ctl00_ContentPlaceHolderMain_LabelTitle').text();
                            isPrivate = $('#isPrivate').is(':checked');
                            OpenRadWindow('', 'Chat_RoomDetails.aspx?ri=' + roomId + '&rn=' + roomName + '&pvt=' + isPrivate + '&crid=' + chatRoomId, 500, 750, false);

                        });
                        $('#leaveroom').click(function () {
                            chat.server.leaveRoom(roomId)
                                        .done(function () {
                                            closeWindow();
                                        })
                                        .fail(function (error) {
                                            console.log('leaveRoom error: ' + error);
                                        });
                        });
                        $('#isPrivate').click(function () {
                            var isPrivate = false;
                            isPrivate = $('#isPrivate').is(':checked');
                            chat.server.changeRoomPrivacy(roomId, isPrivate)
                                        .done(function () {
                                        })
                                        .fail(function (error) {
                                            console.log('changeRoomPrivacy error: ' + error);
                                        });
                        });
                        $('#hideSystemMessages').click(function () {
                            hideSystemMessages = $('#hideSystemMessages').is(':checked');
                            chat.server.loadMessages(roomId, hideSystemMessages)
                                        .done(function () {
                                        })
                                        .fail(function (error) {
                                            console.log('loadMessages error: ' + error);
                                        });

                        });
                        // check is room private
                        chat.server.isRoomPrivate(roomId)
                                    .done(function (roomIsPrivate) {
                                    })
                                    .fail(function (error) {
                                        console.log('loadMessages error: ' + error);
                                    });
                        // list users in room
                        listUsers();
                        // list messages
                        chat.server.loadMessages(roomId, hideSystemMessages)
                                    .done(function () {
                                    })
                                    .fail(function (error) {
                                        console.log('loadMessages error: ' + error);
                                    });
                        disableControls(false);
                    });
            }
        });


    </script>
</asp:Content>
