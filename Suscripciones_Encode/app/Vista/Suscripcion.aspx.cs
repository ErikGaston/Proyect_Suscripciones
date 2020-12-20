using Clases_Negocio;
using System;
using System.Data;
using System.Web.UI;



namespace Suscripciones_Encode.app.pages
{
    public partial class Suscripcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCombo();
                btnModificar.Enabled = false;
                bandera.Text = "suscripcion";
                rfvNumDocumeto.ValidationGroup = "search";
                DisableTextBox();
            }
        }

        public void CargarCombo()
        {
            cmbTipoDocumento.DataSource = Acceso_a_Datos.Suscriptor.obtenerTipoDocumento();
            cmbTipoDocumento.DataTextField = "TipoDocumento";
            cmbTipoDocumento.DataValueField = "TipoDocumento";

            cmbTipoDocumento.DataBind();

            cmbTipoDocumento.SelectedIndex = 0;
        }

        public void EnableTextBox()
        {

            txtNombre.ReadOnly = false;
            txtApellido.ReadOnly = false;
            txtDireccion.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtNombreUsuario.ReadOnly = false;
            txtPassword.ReadOnly = false;

        }
        public void DisableTextBox()
        {
            txtNombre.ReadOnly = true;
            txtApellido.ReadOnly = true;
            txtDireccion.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtNombreUsuario.ReadOnly = true;
            txtPassword.ReadOnly = true;
        }


        public void LimpiarCampos()
        {
            txtNumDocumento.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtNombreUsuario.Text = "";
            txtPassword.Text = "";

            cmbTipoDocumento.Focus();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            DataTable suscriptores = Acceso_a_Datos.Suscriptor.obtenerSuscriptor(Convert.ToString(cmbTipoDocumento.Text), int.Parse(txtNumDocumento.Text));

            if (suscriptores.Rows.Count > 0)
            {
                DisableTextBox();
                txtNombre.Text = suscriptores.Rows[0][1].ToString();
                txtApellido.Text = suscriptores.Rows[0][2].ToString();
                txtDireccion.Text = suscriptores.Rows[0][5].ToString();
                txtEmail.Text = suscriptores.Rows[0][7].ToString();
                txtTelefono.Text = suscriptores.Rows[0][6].ToString();
                txtNombreUsuario.Text = suscriptores.Rows[0][8].ToString();
                txtPassword.Text = suscriptores.Rows[0][9].ToString();

                btnModificar.Enabled = true;
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El suscriptor no existe');", true);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            EnableTextBox();
            cmbTipoDocumento.Enabled = false;
            txtNumDocumento.Enabled = false;
            txtNombreUsuario.ReadOnly = true;

            bandera.Text = "modificar";
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            EnableTextBox();
            cmbTipoDocumento.Enabled = true;
            txtNumDocumento.Enabled = true;
            txtNombreUsuario.ReadOnly = false;
            LimpiarCampos();

            btnModificar.Enabled = false;

            bandera.Text = "nuevo";

            rfvNumDocumeto.ValidationGroup = "register";
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (bandera.Text == "suscripcion")
            {
                Clases_Negocio.Suscriptor eSuscriptor = new Suscriptor();
                DataTable suscriptor = Acceso_a_Datos.Suscriptor.obtenerSuscriptor(Convert.ToString(cmbTipoDocumento.Text), int.Parse(txtNumDocumento.Text));

                if (suscriptor.Rows.Count > 0)
                {
                    eSuscriptor.IdSuscriptor = int.Parse(suscriptor.Rows[0][0].ToString());

                    string vigente = Acceso_a_Datos.Suscripcion.obtenerFechaAlta(eSuscriptor.IdSuscriptor);
                    if (!string.IsNullOrEmpty(vigente))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ya tiene una suscripcion vigente!');", true);
                        btnModificar.Enabled = false;
                    }
                    else
                    {

                        bool resultado = Acceso_a_Datos.Suscripcion.registrarSuscripcion(eSuscriptor.IdSuscriptor);
                        if (resultado)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La suscripcion se ha realizado con éxito');", true);
                            btnModificar.Enabled = false;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La suscripcion no pudo ser realizada!');", true);
                        }
                    }



                }
            }

            if (bandera.Text == "modificar")
            {
                Suscriptor suscriptor = new Suscriptor();
                suscriptor.Nombre = txtNombre.Text;
                suscriptor.Apellido = txtApellido.Text;
                suscriptor.Direccion = txtDireccion.Text;
                suscriptor.Email = txtEmail.Text;
                suscriptor.Telefono = Int64.Parse(txtTelefono.Text);
                suscriptor.Password = txtPassword.Text;

                bool resultado = Acceso_a_Datos.Suscriptor.modificarSuscriptor(suscriptor);
                if (resultado)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Se modifico con exito!');", true);
                    cmbTipoDocumento.Enabled = true;
                    txtNumDocumento.Enabled = true;
                    btnModificar.Enabled = false;
                    bandera.Text = "suscripcion";
                    txtNombreUsuario.ReadOnly = false;
                    DisableTextBox();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No pudo ser modificado');", true);
                }
            }

            if (bandera.Text == "nuevo")
            {
                Suscriptor suscriptor = new Suscriptor();
                suscriptor.Nombre = txtNombre.Text;
                suscriptor.Apellido = txtApellido.Text;
                suscriptor.NumeroDocumento = Int64.Parse(txtNumDocumento.Text);
                suscriptor.TipoDocumento = cmbTipoDocumento.Text;
                suscriptor.Direccion = txtDireccion.Text;
                suscriptor.Telefono = Convert.ToInt64(txtTelefono.Text);
                suscriptor.Email = txtEmail.Text;
                suscriptor.NombreUsuario = txtNombreUsuario.Text;
                suscriptor.Password = txtPassword.Text;

                bool resultado = Acceso_a_Datos.Suscriptor.registrarSuscriptor(suscriptor);
                if (resultado)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Se registro con exito!');", true);
                    cmbTipoDocumento.Enabled = true;
                    txtNumDocumento.Enabled = true;
                    btnModificar.Enabled = false;
                    bandera.Text = "suscripcion";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No pudo ser registrado');", true);
                }
            }

           
            LimpiarCampos();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            cmbTipoDocumento.Enabled = true;
            txtNumDocumento.Enabled = true;
            txtNombreUsuario.ReadOnly = false;
            LimpiarCampos();
            btnModificar.Enabled = false;
        }
    }

}