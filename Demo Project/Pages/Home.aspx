<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Demo_Project.Pages.Home" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<!DOCTYPE html>

<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Note App</title>
    <link rel="stylesheet" href="../Styles/bulma.min.css">
    <script src="../Scripts/bulma.modal.js"></script>
</head>

<body>

    <form id="form1" runat="server">

        <div>

            <section class="hero is-primary">
                <div class="hero-body">
                    <p id="formTitle" class="title">
                        Hi, <%= userName %>. Welcome To Note App.
                    </p>
                    <p id="formSubtitle" class="subtitle">
                        <%= noteCount %> note found.
                    </p>

                </div>
                <div class="navbar-end">
                    <div class="navbar-item">
                        <asp:button AutoPostback="false" ID="btnLogOut" class="button is-primary" runat="server" OnClick="btnLogOut_Click" Text="Logout"/>
                    </div>
                </div>
            </section>

            <asp:Button ID="btnAddNote" CssClass="button is-primary ml-20 mt-30" Text="Add Note" OnClick="BtnAddNote_Click" runat="server" />

            <asp:DataList ID="dlNoteList" runat="server" RepeatDirection="Horizontal" DataKeyField="ID" OnDeleteCommand="DlNoteList_DeleteCommand" OnUpdateCommand="dlNoteList_UpdateCommand">
                <ItemTemplate>
                    <div class="tile is-ancestor">
                        <div class="tile is-vertical is-8">
                            <div class="tile">
                                <div class="tile is-child box">
                                    <p class="title"><%# Eval("TITLE") %></p>
                                    <p><%# Eval("DESCRIPTION") %></p>
                                    <div class="columns is-8 mt-4">
                                        <div class="column">
                                            <asp:Button ID="btnUpdateNote" class="button is-primary" Text="Update Note" runat="server" OnClick="btnUpdateNote_Click" CommandName="Update" />
                                        </div>
                                        <div class="column">
                                            <asp:Button ID="btnDeleteNote" CssClass="button is-danger" Text="Delete" runat="server" CommandName="Delete" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>


        </div>


        <div id="deleteNoteModal" class="modal" runat="server">
            <div class="modal-background"></div>
            <div class="modal-card">
                <header class="modal-card-head">
                    <p class="modal-card-title">Warning</p>
                </header>
                <section class="modal-card-body">
                    <p class="subtitle">
                        Do you want to delete the note ?
                    </p>
                </section>
                <footer class="modal-card-foot">
                    <asp:Button AutoPostback="false" ID="deleteNoteModalDelete" CssClass="button is-danger" Text="Delete" runat="server" OnClick="deleteNoteModalDelete_Click" />
                    <asp:Button ID="deleteNoteModalCancel" CssClass="button" Text="Cancel" runat="server" OnClick="DeleteNoteModalCancel_Click" />
                </footer>
            </div>
        </div>


        <div id="addNoteModal" class="modal" runat="server">
            <div class="modal-background"></div>
            <div class="modal-card">
                <header class="modal-card-head">
                    <p class="modal-card-title">Add New Note</p>
                </header>
                <section class="modal-card-body">
                    <input id="addNoteTitle" class="input is-primary mb-3" type="text" placeholder="Enter the title" maxlength="50" runat="server">
                    <textarea id="addNoteDescription" class="textarea is-primary" placeholder="Add new description" maxlength="200" runat="server"></textarea>
                </section>
                <footer class="modal-card-foot">
                    <asp:Button AutoPostback="false" ID="btnAddNoteModal" CssClass="button is-primary" Text="Add" runat="server" OnClick="btnAddNoteModal_Click" />
                    <asp:Button ID="btnAddNoteCancelModal" CssClass="button" Text="Cancel" runat="server" OnClick="btnAddNoteCancelModal_Click" />
                </footer>
            </div>
        </div>

        <div id="updateNoteModal" class="modal" runat="server">
            <div class="modal-background"></div>
            <div class="modal-card">
                <header class="modal-card-head">
                    <p class="modal-card-title">Update Note</p>
                </header>
                <section class="modal-card-body">
                    <input id="updateNoteTitle" class="input is-primary mb-3" type="text" placeholder="Enter the title" maxlength="50" runat="server">
                    <textarea id="updateNoteDescription" class="textarea is-primary" placeholder="Update the description" maxlength="200" runat="server"></textarea>
                </section>
                <footer class="modal-card-foot">
                    <asp:Button AutoPostback="false" ID="btnUpdateNoteModal" CssClass="button is-primary" Text="Update" runat="server" OnClick="btnUpdateNoteModal_Click" />
                    <asp:Button ID="btnUpdateNoteModalCancel" CssClass="button" Text="Cancel" runat="server" OnClick="btnUpdateNoteModalCancel_Click" />
                </footer>
            </div>
        </div>

    </form>



</body>
</html>


