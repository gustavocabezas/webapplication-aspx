<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="webapplication_aspx.About" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title" class="mb-3 text-center"><%: Title %></h2>

        <h3 class="mb-3">Proyecto #3</h3>

        <p class="mb-3">Con Programación Web escriba una aplicación para solucionar lo siguiente:</p>
        <ol class="list-group list-group-numbered mb-3 ">
            <li class="list-group-item">Funcionalidad para manejar validación de usuarios y registro de nuevos ingresos de usuarios.</li>
            <li class="list-group-item">Con Web services implementar todas las operaciones básicas sobre las tablas de las bases de datos.</li>
            <li class="list-group-item">Con LinQ, implementar una operación agregar, eliminar, consultar y modificar en base de datos.</li>
            <li class="list-group-item">Desarrollar las páginas web necesarias para invocar los webservices de java y C#.</li>
        </ol> 

    </main>
</asp:Content>
