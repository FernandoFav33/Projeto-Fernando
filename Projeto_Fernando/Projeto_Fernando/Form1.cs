using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto_Fernando.Core;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;


namespace Projeto_Fernando {

    public partial class Form1 : Form {

        OracleConnection conn = null;

        public Form1() {
            Form1.getDBConnection("c##fernando", "Fernando1234", "XE");
            InitializeComponent();
        }



        static public void getDBConnection(string Username, string Password, string Datasource) {
            try {
                // String de Conexao
                string connectionString =

                    // Usuario
                    "User Id=" + Username +

                    // Senha
                    ";Password=" + Password +

                    // TNSnames
                    ";Data Source=" + Datasource;

                //Conecta ao datasource usando a conexão Oracle
                OracleConnection conn = new OracleConnection(connectionString);

                //Abre a conexão com o banco de dados
                conn.Open();
                MessageBox.Show("Conexão efetuada com sucesso");

            }
            // Retorna erro
            catch (Exception ex) {
                // Mostra menssagem de erro
                MessageBox.Show(ex.ToString());

            }
        }

        private void teste() {


        }

        private void btnBanco_Click(object sender, EventArgs e) {
            // Cria conexão
            string Banco = "XE";
            getDBConnection("c##fernando", "Fernando1234", Banco);


        }

        private void btnLogin_Click(object sender, EventArgs e) {

            using (var conn = new Oracle.DataAccess.Client.OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User ID=c##fernando;Password=Fernando1234;")) {
                conn.Open();
               // MessageBox.Show("Connected");

                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from re " +
                                    "where nome_usuario = :USUARIO and senha_usuario = :SENHA ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("USUARIO", OracleDbType.Varchar2, 20).Value = txtUser.Text;
                cmd.Parameters.Add("SENHA", OracleDbType.Varchar2, 20).Value = txtPassword.Text;

               

                

                

   
               

            }



        }
    }

}

