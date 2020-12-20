<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Suscripcion.aspx.cs" Inherits="Suscripciones_Encode.app.pages.Suscripcion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <!-- Custom fonts for this template-->
    <link href="Content/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="Content/css/fontsgoogleapis.css" rel="stylesheet" />

    <!-- Custom styles for this template-->
    <link href="Content/css/sb-admin-2.min.css" rel="stylesheet" />


    <title>Suscripciones</title>
</head>
<body id="page-top">

    <!-- Page Wrapper -->
    <div id="wrapper">

        <!-- Sidebar -->
        <ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">

            <!-- Sidebar - Brand -->
            <a class="sidebar-brand d-flex align-items-center justify-content-center" href="index.html">
                <div class="sidebar-brand-icon rotate-n-15">
                    <i class="fas fa-laugh-wink"></i>
                </div>
                <div class="sidebar-brand-text mx-3">Encode</div>
            </a>

            <!-- Divider -->
            <hr class="sidebar-divider" />

            <!-- Heading -->
            <div class="sidebar-heading">
                Formularios
            </div>

            <!-- Nav Item - Pages Collapse Menu -->
            <li class="nav-item">
                <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseTwo"
                    aria-expanded="true" aria-controls="collapseTwo">
                    <i class="fas fa-fw fa-book"></i>
                    <span>Suscripciones</span>
                </a>
                <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionSidebar">
                    <div class="bg-white py-2 collapse-inner rounded">
                        <a class="collapse-item" href="Suscripcion.aspx">Registrar Suscripcion</a>
                    </div>
                </div>
            </li>

            <!-- Divider -->
            <hr class="sidebar-divider" />
        </ul>
        <!-- End of Sidebar -->


        <!-- Content Wrapper -->
        <div id="content-wrapper" class="d-flex flex-column">

            <!-- Main Content -->
            <div id="content">

                <!-- Topbar -->
                <nav class="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow">

                    <!-- Sidebar Toggle (Topbar) -->
                    <button id="sidebarToggleTop" class="btn btn-link d-md-none rounded-circle mr-3">
                        <i class="fa fa-bars"></i>
                    </button>

                    <!-- Topbar Search -->
                    <form
                        class="d-none d-sm-inline-block form-inline mr-auto ml-md-3 my-2 my-md-0 mw-100 navbar-search">
                        <div class="input-group">
                            <input type="text" class="form-control bg-light border-0 small" placeholder="Search for..."
                                aria-label="Search" aria-describedby="basic-addon2" />
                            <div class="input-group-append">
                                <button class="btn btn-primary" type="button">
                                    <i class="fas fa-search fa-sm"></i>
                                </button>
                            </div>
                        </div>
                    </form>

                    <!-- Topbar Navbar -->
                    <ul class="navbar-nav ml-auto">

                        <!-- Nav Item - Search Dropdown (Visible Only XS) -->
                        <li class="nav-item dropdown no-arrow d-sm-none">
                            <a class="nav-link dropdown-toggle" href="#" id="searchDropdown" role="button"
                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="fas fa-search fa-fw"></i>
                            </a>
                            <!-- Dropdown - Messages -->
                            <div class="dropdown-menu dropdown-menu-right p-3 shadow animated--grow-in"
                                aria-labelledby="searchDropdown">
                                <form class="form-inline mr-auto w-100 navbar-search">
                                    <div class="input-group">
                                        <input type="text" class="form-control bg-light border-0 small"
                                            placeholder="Search for..." aria-label="Search"
                                            aria-describedby="basic-addon2" />
                                        <div class="input-group-append">
                                            <button class="btn btn-primary" type="button">
                                                <i class="fas fa-search fa-sm"></i>
                                            </button>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </li>

                        <div class="topbar-divider d-none d-sm-block"></div>

                        <!-- Nav Item - User Information -->
                        <li class="nav-item dropdown no-arrow">
                            <a class="nav-link dropdown-toggle" href="#" id="userDropdown" role="button"
                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <span class="mr-2 d-none d-lg-inline text-gray-600 small">Erik Martinez</span>
                            </a>
                        </li>

                    </ul>

                </nav>
                <!-- End of Topbar -->

                <!-- Begin Page Content -->
                <div class="container-fluid">

                    <!-- Content Row -->
                    <div class="row">

                        <!-- Content Column -->
                        <div class="jumbotron">

                            <!-- Project Card Example -->
                            <div class="card shadow mb-4">
                                <div class="card-header py-3">
                                    <h6 class="m-0 font-weight-bold text-primary">SUSCRIPCIONES</h6>
                                </div>
                                <div class="card-body">

                                    <form id="formSuscripciones" runat="server">

                                        <div class="form-group">

                                            <div>
                                                <h2>Suscripcion</h2>
                                                <p>Para realizar la suscripcion complete los siguientes datos</p>
                                            </div>
                                            <hr />

                                            <div class="row">
                                                <div class="col">

                                                    <h4>Buscar Suscriptor</h4>

                                                    <div class="form-group">
                                                        <asp:Label ID="lblTipoDocumento" runat="server" Text="Label">TipoDocumento</asp:Label>
                                                        <asp:DropDownList ID="cmbTipoDocumento" class="form-control mt-2 mb-2" runat="server"></asp:DropDownList>

                                                        <asp:Label ID="lblNumeroDocumento" runat="server" Text="Label">Numero de Documento</asp:Label>
                                                        <asp:TextBox ID="txtNumDocumento" class="form-control mt-2 mb-2" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvNumDocumeto" runat="server"
                                                            ControlToValidate="txtNumDocumento"
                                                            ErrorMessage="Campo Obligatorio"
                                                            ForeColor="Red" Display="Dynamic" ToolTip="El campo es obligatorio"></asp:RequiredFieldValidator>


                                                        <asp:TextBox runat="server" ID="bandera" Style="display: none;"></asp:TextBox>

                                                        <div class="text-right">
                                                            <asp:Button ID="btnBuscar" class="btn btn-success mx-3" runat="server" Text="Buscar" OnClick="btnBuscar_Click" causesValidation ="true" ValidationGroup="search"/>
                                                        </div>

                                                        <hr />

                                                        <h4>Datos del Suscriptor</h4>

                                                        <div class="text-center">
                                                            <asp:Button ID="btnModificar" class="btn btn-primary" runat="server" Text="Modificar" OnClick="btnModificar_Click"  causesvalidation="false" />
                                                            <asp:Button ID="btnNuevo" class="btn btn-info" runat="server" Text="Nuevo" OnClick="btnNuevo_Click"  causesvalidation="false" />
                                                        </div>

                                                        <br />

                                                        <asp:Label ID="lblNombre" runat="server" Text="Label">Nombre</asp:Label>
                                                        <asp:TextBox ID="txtNombre" class="form-control mt-2 mb-2" runat="server" PlaceHolder="Name"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                            ControlToValidate="txtNombre"
                                                            ErrorMessage="Campo Obligatorio"
                                                            ForeColor="Red" Display="Dynamic" ToolTip="El campo es obligatorio" ValidationGroup="register"></asp:RequiredFieldValidator><br />

                                                        <asp:Label ID="lblApellido" runat="server" Text="Label">Apellido</asp:Label>
                                                        <asp:TextBox ID="txtApellido" class="form-control mt-2 mb-2" runat="server" PlaceHolder="Surname"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                            ControlToValidate="txtApellido"
                                                            ErrorMessage="Campo Obligatorio"
                                                            ForeColor="Red" Display="Dynamic" ToolTip="El campo es obligatorio" ValidationGroup="register"></asp:RequiredFieldValidator><br />

                                                        <asp:Label ID="lblDireccion" runat="server" Text="Label">Direccion</asp:Label>
                                                        <asp:TextBox ID="txtDireccion" class="form-control mt-2 mb-2" runat="server" PlaceHolder="Address"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                            ControlToValidate="txtDireccion"
                                                            ErrorMessage="Campo Obligatorio"
                                                            ForeColor="Red" Display="Dynamic" ToolTip="El campo es obligatorio" ValidationGroup="register"></asp:RequiredFieldValidator><br />

                                                        <asp:Label ID="lblEmail" runat="server" Text="Label">Email</asp:Label>
                                                        <asp:TextBox ID="txtEmail" class="form-control mt-2 mb-2" runat="server"
                                                            PlaceHolder="example@example.com"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                            ControlToValidate="txtEmail"
                                                            ErrorMessage="Campo Obligatorio"
                                                            ForeColor="Red" Display="Dynamic" ToolTip="El campo es obligatorio" ValidationGroup="register"></asp:RequiredFieldValidator><br />

                                                        <asp:Label ID="lblTelefono" runat="server" Text="Label">Telefono</asp:Label>
                                                        <asp:TextBox ID="txtTelefono" class="form-control mt-2 mb-2" runat="server" PlaceHolder="Phone"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                            ControlToValidate="txtTelefono"
                                                            ErrorMessage="Campo Obligatorio"
                                                            ForeColor="Red" Display="Dynamic" ToolTip="El campo es obligatorio" ValidationGroup="register"></asp:RequiredFieldValidator><br />

                                                        <hr />
                                                        <asp:Label ID="lblNombreUsuario" runat="server" Text="Label">Usuario</asp:Label>
                                                        <asp:TextBox ID="txtNombreUsuario" class="form-control mt-2 mb-2" runat="server" PlaceHolder="User"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                            ControlToValidate="txtNombreUsuario"
                                                            ErrorMessage="Campo Obligatorio"
                                                            ForeColor="Red" Display="Dynamic" ToolTip="El campo es obligatorio" ValidationGroup="register"></asp:RequiredFieldValidator><br />

                                                        <asp:Label ID="lblPassword" runat="server" Text="Label">Password</asp:Label>
                                                        <asp:TextBox ID="txtPassword" class="form-control mt-2 mb-2" type="password" runat="server" PlaceHolder="Password"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                            ControlToValidate="txtPassword"
                                                            ErrorMessage="Campo Obligatorio"
                                                            ForeColor="Red" Display="Dynamic" ToolTip="El campo es obligatorio" ValidationGroup="register"></asp:RequiredFieldValidator>

                                                        <br />
                                                        <br />

                                                        <asp:Button ID="btnAceptar" class="btn btn-success" runat="server" Text="Aceptar" OnClick="btnAceptar_Click"  causesvalidation="true" validationgroup="register"/>
                                                        <asp:Button ID="btnCancelar" class="btn btn-light" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" causesvalidation="false"/>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </form>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <!-- /.container-fluid -->
            </div>
        </div>
        <!-- End of Main Content -->

    </div>
    <!-- End of Page Wrapper -->


    <!-- Bootstrap core JavaScript-->
    <script src="Content/vendor/jquery/jquery.min.js"></script>
    <script src="Content/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="Content/vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="Content/js/sb-admin-2.min.js"></script>

</body>
</html>
