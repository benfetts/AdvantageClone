<%@ Page Title="Chat Rooms" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Chat_Rooms.aspx.vb" Inherits="Webvantage.Chat_Rooms" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style type="text/css">
        html {
            overflow: hidden;
        }
        .chat-container {
            width:100%;
            /*height: 530px;*/
            overflow: hidden;
            vertical-align:top;
            border: 0px solid green;
            padding: 0px;
            margin: 0px;
        }
        .left-container {
            vertical-align:top;
            margin: 7px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            display: inline-block;
            width:290px;
            border: 0px solid red;
            clear: both;
            right: 0;
         }
        .right-container {
            vertical-align:top;
            margin: 7px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            display: inline-block;
            border: 0px solid red;
            clear: both;
            right: 0;
            width:290px;
       }
    </style>
    <telerik:RadScriptBlock ID="RadScriptBlockHead" runat="server">
        <script type="text/javascript">
            //function radComboBoxDepartmentTeamOnClientSelectedIndexChanged(sender, eventArgs) {
            //    var item = eventArgs.get_item();
            //    sender.set_text("You selected " + item.get_text());
            //}
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="telerik-aqua-body">
        <div class="chat-container">
            <div class="left-container">
                <div class="card" style="height: 514px !important; width: 278px !important;">
                    <div style="padding: 4px;">
                        <div style="padding:0px 0px 4px 0px;">
                            <select id="departmentTeams" style="width:270px;">
                                <option value="null">[Show all departments/teams]</option>
                            </select>
                        </div>
                        <telerik:RadListBox ID="RadListBoxWhoIsOnline" runat="server" Width="270" Height="370" SelectionMode="Multiple">
                        </telerik:RadListBox>
                        <div style="text-align:right;padding: 4px 2px 4px 0px;">
                            <input type="button" id="quickmessage" value="Quick Message" style="width: 265px;" title="Select user(s) and send a message without creating a room." />
                        </div>
                        <div style="display:none !important;">
                            <input type="checkbox" id="showOffLineUsers" title="Check this to show users that are offline">Show offline users
                        </div>
                        <div style="">
                            <input type="checkbox" id="doNotDisturb" title="Check this to appear offline and unavailable to chat">Do not disturb
                        </div>
                    </div>
                    <div class="card-bottom-header card-bottom-header-bg" title="This is a list of users available to chat.">
                        <div style="display: inline-block; padding: 6px 0px 0px 8px; color: #FFFFFF !important;">
                            Who's online
                        </div>
                        <div class="card-action-bar">
                        </div>
                    </div>
                </div>
            </div>
            <div class="right-container">
                <div class="card" style="height: 344px !important; width: 278px !important;">
                    <div style="padding:4px;">
                        <telerik:RadListBox ID="RadListBoxChatRooms" runat="server" Width="270" Height="262" SelectionMode="Single">
                        </telerik:RadListBox>
                    </div>
                    <div style="padding: 0px 5px 0px 4px;text-align:right;">
                        <input type="button" id="inviteroom" value="Invite Users" title="Select users from the 'Who's online' list and select a room to invite them to chat." />
                        <input type="button" id="enterroom" value="Enter" title="Select a room from above and click to enter the room."  />
                    </div>
                    <div class="card-bottom-header card-bottom-header-bg" title="This is a list of rooms available to you">
                        <div style="display: inline-block; padding: 6px 0px 0px 8px;color:#FFFFFF !important;">
                            Available rooms
                        </div>
                        <div class="card-action-bar">
                        </div>
                    </div>
                </div>
                <div class="card" style="height: 160px !important; width:278px !important;">
                    <div style="padding: 0px 4px 0px 4px;">
                        <div>
                            Room Name:
                        </div>
                        <div>
                            <input type="text" id="roomname" style="width: 250px;" title="Enter a name for your room!" maxlength="100" />
                        </div>
                        <div style="margin-left:-3px;">
                            <input type="checkbox" id="isPrivate" checked="checked" title="Only you and those participating in the conversation will see this room in the 'Available rooms' list.">Private
                        </div>
                        <div style="padding: 0px 5px 0px 4px; text-align: right;">
                            <input type="button" id="newroom" value="Create Room" title="Enter a room name and click to create.  You can select users to invite them at the same time!"/>
                            <input type="button" id="viewsaved" value="View Saved" title="View all your saved chat rooms/conversations." />
                        </div>
                    </div>
                    <div class="card-bottom-header card-bottom-header-bg" title="Enter a room name and click 'Create Room' to create a new room.  Click 'View Saved' to view your saved conversations.">
                        <div style="display: inline-block; padding: 6px 0px 0px 8px; color: #FFFFFF !important;">
                            Create a new room
                        </div>
                        <div class="card-action-bar">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="empName" style="display: none !important;"><%=Session("EmployeeName")%></div>
        <script type="text/javascript" src="Scripts/jquery.signalR-2.4.2.min.js"></script>
        <script src="signalr/hubs"></script>
        <script type="text/javascript">
            $(function () {
                var chatActive = '<%=Session("CheckModuleAccessDesktop_Chat").ToString.ToLower%>'
                var chat = $.connection.chatHub;
                var uc = '<%=Session("UserCode")%>';
                var ec = '<%=Session("EmpCode")%>';
                var en = '<%=Session("EmployeeName").ToString.Replace("'", "\'")%>';
                var txtDepartmentTeamShowAll = "[Show all departments/teams]";
                var guid = '<%=AdvantageFramework.Security.Encryption.ASCIIEncoding(Session("ConnString"))%>';
                var rblWhoIsOnline = $find("<%=RadListBoxWhoIsOnline.ClientID %>");
                var rblChatRooms = $find("<%=RadListBoxChatRooms.ClientID %>");
                var selectDepartmentTeam = $("#departmentTeams");
                var inviteUsersButton = $("#inviteroom");
                var enterButton = $("#enterroom");
                var createRoomButton = $("#newroom");
                var viewSavedButton = $("#viewsaved");
                var doNotDisturbCheckBox = $("#doNotDisturb");
                var privateCheckBox = $("#isPrivate");
                var roomNameInput = $("#roomname");

                //  Helpers
                function logMsg(msg) {
                    //console.log("Chat_RoomS.aspx:  " + msg)
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
                function newRoom() {
                    if ($('#roomname').val() && $('#roomname').val().trim() != '') {
                        var users = [];
                        var isPrivate = false;
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
                        isPrivate = $('#isPrivate').is(':checked');
                        chat.server.addRoom($('#roomname').val(), isPrivate, JSON.stringify(users))
                                    .done(function () {
                                        $('#roomname').val('');
                                    })
                                    .fail(function (error) {
                                        console.log('newroom error: ' + error);
                                    });
                    } else {
                        ShowMessage('Enter a room name');
                        $('#roomname').focus();
                    }
                }
                function quickMessage() {
                    var users = [];
                    var isPrivate = true;
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
                    //isPrivate = $('#isPrivate').is(':checked');
                    chat.server.addRoom("", isPrivate, JSON.stringify(users))
                                .done(function () {
                                    $('#roomname').val('');
                                })
                                .fail(function (error) {
                                    console.log('newroom error: ' + error);
                                });
                }
                function enterTheRoom(roomId, inviteOthers) {
                    var users = [];
                    if (inviteOthers == true) {
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
                    }
                    chat.server.enterRoom(roomId, JSON.stringify(users))
                                .done(function () {
                                    //chat.server.listRooms();
                                })
                                .fail(function (error) {
                                    ShowMessage(error);
                                    console.log('sendMessageToRoom error: ' + error);
                                });
                }
                function openTheRoom(roomId, roomName) {
                    window.setTimeout(function () {
                        var url = '';
                        url = 'Chat_Room.aspx?ri=' + roomId;// + '&rn=' + roomName;
                        OpenChatWindow(url);
                    }, 1);
                };
                function restoreTheRoom(roomId, roomName) {
                    window.setTimeout(function () {
                        var url = '';
                        url = 'Chat_Room.aspx?ri=' + roomId;// + '&rn=' + roomName;
                        RestoreChatWindow(url);
                    }, 1);
                };
                function disableControls(disabled) {
                    if (inviteUsersButton) {
                        inviteUsersButton.prop("disabled", disabled);
                    }
                    if (enterButton) {
                        enterButton.prop('disabled', disabled);
                    }
                    if (createRoomButton) {
                        createRoomButton.prop('disabled', disabled);
                    }
                    if (viewSavedButton) {
                        viewSavedButton.prop('disabled', disabled);
                    }
                    if (doNotDisturbCheckBox) {
                        doNotDisturbCheckBox.prop('disabled', disabled);
                    }
                    if (privateCheckBox) {
                        privateCheckBox.prop('disabled', disabled);
                    }
                    if (roomNameInput) {
                        roomNameInput.prop('disabled', disabled);
                    }

                }
                function getSelectedDepartmentTeam() {
                    var deptTeam = "";
                    deptTeam = $("#departmentTeams").val();
                    if (deptTeam == txtDepartmentTeamShowAll) {
                        deptTeam = "";
                    }
                    return deptTeam;
                }
                disableControls(true);
                //  Callbacks from server
                chat.client.refreshWhoIsOnline = function () {
                    window.setTimeout(function () {
                        // get selected dept, pass to who'sonline
                        var deptTeam = ""
                        deptTeam = getSelectedDepartmentTeam();
                        logMsg("deptTeam from refreshWhoIsOnline:  " + deptTeam)
                        chat.server.refreshWhoIsOnline(deptTeam);
                    }, 75);
                }
                chat.client.showWhoIsOnline = function (ConnectedUsers) {
                    window.setTimeout(function () {
                        logMsg("showWhoIsOnline");
                        if (rblWhoIsOnline) {
                            var items = rblWhoIsOnline.get_items();
                            if (items) {
                                items.clear();
                                if (ConnectedUsers) {
                                    var parsed = $.parseJSON(ConnectedUsers)
                                    if (parsed) {
                                        items.clear();
                                        for (var i in parsed) {
                                            var foundItem = rblWhoIsOnline.findItemByValue(parsed[i].UserCode);
                                            if (!foundItem) {
                                                var item = new Telerik.Web.UI.RadListBoxItem();
                                                item.set_text(parsed[i].EmployeeFullName);
                                                item.set_value(parsed[i].UserCode);
                                                if (parsed[i].UserCode == uc) {
                                                    item.set_selected(true);
                                                    item.disable();
                                                }
                                                items.add(item);
                                            }
                                        }
                                    }
                                } else {
                                    //alert("No users to display")
                                }
                            }
                        }
                    }, 75);
                };
                chat.client.loadDepartmentTeam = function (DepartmentTeams) {
                    window.setTimeout(function () {
                        logMsg("loadDepartmentTeam");
                        if (selectDepartmentTeam) {
                            selectDepartmentTeam[0].options.length = 0;
                            selectDepartmentTeam.append($('<option>', {
                                value: null,
                                text: txtDepartmentTeamShowAll,
                                selected: true
                            }));
                            selectDepartmentTeam.val(txtDepartmentTeamShowAll);
                            var parsed = $.parseJSON(DepartmentTeams)
                            if (parsed) {
                                for (var i in parsed) {
                                    selectDepartmentTeam.append($('<option>', {
                                        value: parsed[i].Code,
                                        text: parsed[i].Description
                                    }));
                                }
                            }
                        }
                    }, 75);
                };

                chat.client.listRooms = function (rooms) {
                    window.setTimeout(function () {
                        logMsg("callback listRooms");
                        var parsed = $.parseJSON(rooms)
                        if (parsed && rblChatRooms) {
                            var items = rblChatRooms.get_items();
                            items.clear();
                            for (var i in parsed) {
                                var item = new Telerik.Web.UI.RadListBoxItem();
                                item.set_value(parsed[i].RoomID);
                                item.set_text(parsed[i].Name);
                                item.set_toolTip("Created by:  " + parsed[i].StartedByUserCode + " on " + parsed[i].CreateDate);
                                items.add(item);
                            }
                        }
                    }, 50);
                };
                chat.client.enteredRoom = function (roomId, roomName, userCode, fullName) {
                    window.setTimeout(function () {
                        logMsg("callback enteredRoom");
                        openTheRoom(roomId, roomName);
                        //chat.server.listRooms();
                    }, 50);
                };
                chat.client.openRoom = function (roomId, roomName) {
                    window.setTimeout(function () {
                        openTheRoom(roomId, roomName);
                    }, 50);
                };
                chat.client.restoreRoom = function (roomId, roomName) {
                    window.setTimeout(function () {
                        restoreTheRoom(roomId, roomName);
                    }, 50);
                };
                chat.client.leftRoom = function (roomId, fullName) {
                    window.setTimeout(function () {
                        logMsg("callback leftRoom");
                    }, 50);
                };
                chat.client.inviteToRoom = function(roomId, roomName) {
                    logMsg("callback inviteToRoom");
                    window.setTimeout(function () {
                        if (roomId && roomName) {
                            var url = '';
                            var chatWindow;
                            url = 'Chat_Room.aspx?ri=' + roomId; // + '&rn=' + roomName + '&usr=' + userCode + '&en=' + fullName;
                            chatWindow = FindChatWindow(url);
                            if (!chatWindow) {
                                var msg = 'Chat request for room:\n\n' + roomName + '\n\nAccept?'
                                if (confirm(msg) == true) {
                                    enterTheRoom(roomId);
                                } else {
                                    //chat.server.sendMessageToRoom(roomId, en + ' declined chat invite.')
                                    //           .done(function () {
                                    //               alert('declined message done')
                                    //           })
                                    //           .fail(function (error) {
                                    //               console.log('sendMessageToRoom error: ' + error);
                                    //           });
                                }
                            } else {
                                OpenChatWindow(url);
                            }
                        }
                    }, 1);
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
                if (chatActive && chatActive == true) {
                    if ($.connection.hub && $.connection.hub.state === $.signalR.connectionState.disconnected) {
                        $.connection.hub
                                    .start({ waitForPageLoad: false }, function () {
                                        //console.log("Chat hub starting")
                                    })
                                    .done(function () {

                                        $('#newroom').click(function () {
                                            newRoom();
                                        });
                                        $('#quickmessage').click(function () {
                                            quickMessage();
                                        });
                                        $('#roomname').on("keypress", function (e) {
                                            if (e.keyCode == 13) {
                                                newRoom();
                                                return false;
                                            }
                                        });
                                        $('#enterroom').click(function () {
                                            var roomId = getRoomId();
                                            if (roomId) {
                                                enterTheRoom(roomId, false);
                                            } else {
                                                alert("Please select a room");
                                            }
                                        });
                                        $('#inviteroom').click(function () {
                                            var roomId = getRoomId();
                                            if (roomId) {
                                                enterTheRoom(roomId, true);
                                            } else {
                                                alert("Please select a room");
                                            }
                                        });
                                        $('#viewsaved').click(function () {
                                            OpenRadWindow('Saved Chat Rooms', 'Chat_List.aspx', 500, 750, false);
                                        });
                                        $('#doNotDisturb').click(function () {
                                            var doNotDisturb = false;
                                            doNotDisturb = $('#doNotDisturb').is(':checked');
                                            chat.server.doNotDisturb(doNotDisturb)
                                                        .done(function () {
                                                        })
                                                        .fail(function (error) {
                                                            console.log('doNotDisturb error: ' + error);
                                                        });
                                        });
                                        $("#departmentTeams").on("change", function () {
                                            logMsg("deptTeam from on change:  " + getSelectedDepartmentTeam())
                                            var deptTeam = "";
                                            deptTeam = this.value;
                                            if (deptTeam == txtDepartmentTeamShowAll) {
                                                deptTeam = "";
                                            }
                                            chat.server.refreshWhoIsOnline(deptTeam);
                                        });
                                        chat.server.loadDepartmentTeam();
                                        chat.server.listRooms();
                                        chat.server.refreshWhoIsOnline("");
                                        chat.server.comeOnline();
                                        disableControls(false);
                                    });
                    }
                }
            });
        </script>
    </div>

</asp:Content>
