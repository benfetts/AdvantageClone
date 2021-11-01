<%@ Page Title="Chat Test Page" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Chat_Test.aspx.vb" Inherits="Webvantage.Chat_Test" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style type="text/css">
        .chat-container {
            width:670px;
            height: 458px;
            overflow: hidden;
            vertical-align:top;
            border: 0px solid green;
            padding: 0px;
            margin: 0px;
        }
        .left-container {
            width: 470px;
            margin: 0px;
            padding: 8px 10px 0px 0px;
            display: inline-block;
            border: 0px solid red;
            float: left;
      }
        .chat-input-container {
            height: 85px;
            border: 0px solid red;
        }
        .chat-discussion-container {
            border: 1px solid #cecece;
            height:340px;
            overflow-x: hidden;
            overflow-y: auto;
            margin-bottom:7px;
        }
        .right-container {
            vertical-align:top;
            margin: 7px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            display: inline-block;
            width: 180px;
            border: 0px solid red;
            clear: both;
            right: 0;
        }
    </style>
    <telerik:RadScriptBlock ID="RadScriptBlockHead" runat="server">
        <script type="text/javascript">
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="chat-container">
        <div class="left-container">
            <asp:Label ID="LabelTitle" runat="server" Text="My Chat"></asp:Label>
            <div class="chat-discussion-container">
                <ul id="discussion"></ul>
            </div>
            <div class="chat-input-container">
                <input type="text" id="message" style="width: 450px; margin: 0px 5px 0px 0px;" />
                <br />
                <div style="margin: 5px 0px 0px 0px; text-align: right;">
                    <input type="button" id="save" value="Save Room" />
                    <input type="button" id="send" value="Send Message" />
                </div>
            </div>
        </div>
        <div class="right-container">
            <div style="display: block;">
                <div>Who's online:</div>
                <telerik:RadListBox ID="RadListBoxWhoIsOnline" runat="server" Width="170" Height="130" SelectionMode="Multiple">
                </telerik:RadListBox>
            </div>
            <div style="margin-top: 4px; display: block;">
                <div>Available Rooms:</div>
                <telerik:RadListBox ID="RadListBoxChatRooms" runat="server" Width="170" Height="130" SelectionMode="Single">
                </telerik:RadListBox>
                <div style="margin-top: 2px;">
                    <input type="button" id="enterroom" value="Enter Room" style="width: 170px" />
                </div>
            </div>
            <div style="margin-top: 6px; display: block;">
                <div>New Room:</div>
                <input type="text" id="roomname" style="width: 150px;" />
                <div style="margin-top: 5px;">
                    <input type="button" id="newroom" value="Create Room" style="width: 170px" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="Scripts/jquery.signalR-2.4.2.min.js"></script>
    <script src="signalr/hubs"></script>
    <script type="text/javascript">
        $(function () {

            $('#message').focus();

            var chat = $.connection.chatHub;
            var uc = '<%=Session("UserCode")%>';
            var ec = '<%=Session("EmpCode")%>';
            var en = '<%=Session("EmployeeName")%>';
            var guid = '<%=AdvantageFramework.Security.Encryption.ASCIIEncoding(Session("ConnString"))%>';
            var rblWhoIsOnline = $find("<%=RadListBoxWhoIsOnline.ClientID %>");
            var rblChatRooms = $find("<%=RadListBoxChatRooms.ClientID %>");

            //  Returns from server
            chat.client.broadcastMessage = function (fullName, message) {
                window.setTimeout(function () {
                    var encodedName = $('<div />').text(fullName).html();
                    var encodedMsg = $('<div />').text(message).html();
                    $('#discussion').append('<li><strong>' + encodedName + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
                }, 10);
            };
            chat.client.showMessage = function (fullName, message) {
                window.setTimeout(function () {
                    var encodedName;
                    var encodedMsg;
                    var discussionMessage = '';
                    var hasBoth = false;
                    if (fullName && message) {
                        hasBoth = true;
                    }
                    discussionMessage = '<li>';
                    if (fullName) {
                        discussionMessage += '<strong>' + $('<div />').text(fullName).html() + '</strong>';
                    }
                    if (hasBoth){
                        discussionMessage += '<strong>:</strong>&nbsp;&nbsp;';
                    }
                    if (message) {
                        discussionMessage += $('<div />').text(message).html();
                    }
                    discussionMessage += '</li>';
                    $('#discussion').append(discussionMessage);
                }, 10);
            };
            chat.client.showWhoIsOnline = function (ConnectedUsers) {
                window.setTimeout(function () {

                    var parsed = $.parseJSON(ConnectedUsers)

                    if (parsed && rblWhoIsOnline) {

                        var items = rblWhoIsOnline.get_items();
                        items.clear();

                        for (var i in parsed) {

                            //alert(parsed[i].FullName);
                            var item = new Telerik.Web.UI.RadListBoxItem();
                            item.set_text(parsed[i].EmployeeFullName);
                            item.set_value(parsed[i].UserCode);
                            items.add(item);

                        }

                    }

                }, 10);
            };
            chat.client.listRooms = function (rooms) {
                window.setTimeout(function () {

                    var parsed = $.parseJSON(rooms)

                    if (parsed && rblChatRooms) {

                        var items = rblChatRooms.get_items();
                        items.clear();

                        for (var i in parsed) {

                            var item = new Telerik.Web.UI.RadListBoxItem();
                            item.set_value(parsed[i].ID);
                            item.set_text(parsed[i].Name);
                            items.add(item);

                        }

                    }

                }, 10);
            };
            chat.client.enteredRoom = function (roomName, fullName, entered) {
                window.setTimeout(function () {
                    alert(roomName);
                    alert(fullName);
                    alert(entered);
                    if (entered == true) {
                        //alert("You are now in room:  " + roomName);
                        $('#discussion').append(fullName + "&nbsp;entered room&nbsp;" + roomName);
                    }
                    chat.server.listRooms();

                }, 10);
            };

            //  Connection params
            $.connection.hub.qs = {
                'u': "",
                'e': "",
                'n': "",
                'guid': ""
            };

            //  Log to console
            //$.connection.hub.logging = true;

            //  Init
            $.connection.hub
                .start()
                .done(function () {

                    chat.server.refreshWhoIsOnline("");
                    chat.server.listRooms();

                    $('#send').click(function () {

                        var roomId = getRoomId();
                        if (roomId) {
                            if (hasMessage() === true) {
                                chat.server.sendMessageToRoom(roomId, $('#message').val())
                                            .done(function () {
                                                $('#message').val('').focus();
                                            })
                                            .fail(function (error) {
                                                console.log('sendMessageToRoom error: ' + error);
                                            });
                            }
                        } else {
                            if (checkBeforeSend() === true) {
                                var users = [];
                                if (rblWhoIsOnline) {
                                    var items = rblWhoIsOnline.get_items();
                                    if (items) {
                                        items.forEach(function (item) {
                                            if (item.get_selected() == true) {
                                                var user = { UserCode: item.get_value() }
                                                users.push(user);
                                            }
                                        });
                                    }
                                }
                                chat.server.sendMessage($('#message').val(), JSON.stringify(users))
                                            .done(function () {
                                                $('#message').val('').focus();
                                            })
                                            .fail(function (error) {
                                                console.log('sendMessage error: ' + error);
                                            });
                            }
                        }
                    });
                    $('#blast').click(function () {
                        if (hasMessage() === true) {
                            chat.server.blast($('#message').val())
                                        .done(function () {
                                            $('#message').val('').focus();
                                        })
                                        .fail(function (error) {
                                            console.log('blast error: ' + error);
                                        });
                        }
                    });
                    $('#self').click(function () {
                        if (hasMessage() === true) {
                            chat.server.self($('#message').val())
                                        .done(function () {
                                            $('#message').val('').focus();
                                        })
                                        .fail(function (error) {
                                            console.log('self error: ' + error);
                                        });
                        }
                    });
                    $('#others').click(function () {
                        if (checkBeforeSend() === true) {
                            chat.server.others($('#message').val())
                                        .done(function () {
                                            $('#message').val('').focus();
                                        })
                                        .fail(function (error) {
                                            console.log('others error: ' + error);
                                        });
                        }
                    });
                    $('#hello').click(function () {
                        chat.server.sayHello()
                                    .done(function () {
                                        $('#message').val('').focus();
                                    })
                                    .fail(function (error) {
                                        console.log('hello error: ' + error);
                                    });
                    });
                    $('#newroom').click(function () {
                        if ($('#roomname').val() && $('#roomname').val().trim() != '') {
                            chat.server.addRoom($('#roomname').val())
                                        .done(function () {
                                            chat.server.listRooms();
                                            $('#message').val('').focus();
                                        })
                                        .fail(function (error) {
                                            console.log('newroom error: ' + error);
                                        });
                        } else {
                            alert('Enter a room name');
                            $('#roomname').focus();
                        }
                    });
                    $('#enterroom').click(function () {
                        alert("enter room!")
                        //if (rblChatRooms) {
                        //    var items = rblChatRooms.get_items();
                        //    if (items) {
                        //        ////items.forEach(function (item) {
                        //        ////    if (item.get_selected() == true) {
                        //        ////        //alert(item.get_value());
                        //        ////        //chat.server.sendMessageToRoom($('#message').val())
                        //        ////        //            .done(function () {
                        //        ////        //                $('#message').val('').focus();
                        //        ////        //            })
                        //        ////        //            .fail(function (error) {
                        //        ////        //                console.log('sendMessage error: ' + error);
                        //        ////        //            });
                        //        ////    }
                        //        ////});
                        //    }
                        //}
                        var roomId;
                        if (roomId) {
                            chat.server.enterRoom(roomId)
                                        .done(function () {
                                            $('#message').val('').focus();
                                        })
                                        .fail(function (error) {
                                            alert(error)
                                            console.log('sendMessageToRoom error: ' + error);
                                        });
                        }
                    });

                });

            //  Helpers
            function checkBeforeSend() {
                if (hasMessage() === true && hasSelectedUsers() === true) {
                    return true
                } else {
                    return false;
                }
            };
            function hasMessage() {
                if ($('#message').val() && $('#message').val().trim() != '') {
                    return true
                } else {
                    alert('No message to send.\n');
                    return false;
                }
            }
            function hasSelectedUsers() {
                var hasSelectedUsers = false;
                if (rblWhoIsOnline) {
                    var items = rblWhoIsOnline.get_items();
                    if (items) {
                        items.forEach(function (item) {
                            if (item.get_selected() === true) {
                                hasSelectedUsers = true;
                            }
                        });
                    }
                }
                if (hasSelectedUsers === false) {
                    alert('No users selected.\n')
                    return false;
                } else {
                    return true;
                }
            }
            function getRoomId() {
                var roomId;
                if (rblChatRooms) {
                    var items = rblChatRooms.get_items();
                    if (items) {
                        items.forEach(function (item) {
                            if (item.get_selected() == true) {
                                roomId = item.get_value();
                            }
                        });
                    }
                }
                return roomId;
            }

        });
    </script>
</asp:Content>
