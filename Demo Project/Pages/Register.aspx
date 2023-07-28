<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Demo_Project.Pages.Register" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Register To Note App</title>
    <link href="../Styles/bulma.min.css" rel="stylesheet" />
</head>

<body>
    <form runat="server">
        <div class="hero is-fullheight">

            <div class="hero-body is-justify-content-center is-align-items-center">
                <div class="columns is-flex is-flex-direction-column box">
                    <div class="column">
                        <p class="title has-text-centered has-text-primary">Register to Note App</p>
                    </div>
                    
                    <div class="column">
                        <label for="email">Name</label>
                        <input id="inputName" class="input is-primary" type="text" placeholder="Name" runat="server">
                    </div>
                    <div class="column">
                        <label for="Name">Surname</label>
                        <input id="inputSurname" class="input is-primary" type="text" placeholder="Surname" runat="server">
                    </div>

                    <div class="column">
                        <label for="email">Email</label>
                        <input id="inputEmail" class="input is-primary" type="text" placeholder="Email address" runat="server">
                    </div>
                    <div class="column">
                        <label for="Name">Password</label>
                        <input id="inputPassword" class="input is-primary" type="password" placeholder="Password" runat="server">
                    </div>

                    <div class="column">
                        <label for="Name">Re-Type Password</label>
                        <input id="inputRetypePassword" class="input is-primary" type="password" placeholder="Retype Password" runat="server">
                    </div>

                    <div class="column">
                        <asp:Button ID="btnRegister" Text="Register" CssClass="button is-primary is-fullwidth" OnClick="btnRegister_Click" runat="server" />
                    </div>

                    <div class="has-text-centered">
                        <p class="is-size-7">
                            Do you have an account? <a href="../MasterForm.aspx" class="has-text-primary">Login</a>
                        </p>
                    </div>

                    <div id="divWarning" class="column" runat="server">
                        <label id="lblWarning" for="email" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>