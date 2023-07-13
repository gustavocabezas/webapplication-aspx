﻿<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="webapplication_aspx.Login" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title" class="text-center"><%: Title %></h2>
        <div class="row">
            <div class="form">
                <div class="form-group mb-3">
                    <label for="username" class="form-label">User Name</label>
                    <asp:TextBox ID="TextBoxUsername" type="email" class="form-control" aria-describedby="User Name" runat="server"></asp:TextBox>
                </div>
                <div class="form-group mb-3">
                    <label for="TextBoxPassword" class="form-label">Password</label>
                    <asp:TextBox ID="TextBoxPassword" type="password" class="form-control" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="ButtonLogin" class="btn btn-primary" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
            </div>
        </div>
    </main>
</asp:Content>
