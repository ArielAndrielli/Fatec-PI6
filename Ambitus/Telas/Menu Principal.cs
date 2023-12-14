using Entidades;
using Newtonsoft.Json;
using System.Configuration;
using System.Data;
using System.Net.Http.Headers;

namespace Ambitus.Telas
{
    public partial class MenuPrincipal : Form
    {
        #region Constructor

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        #endregion

        #region Attributes

        Dados_Evento evento = new();
        bool headerFilled = false;
        string urlEventos = "http://ec2-18-223-44-43.us-east-2.compute.amazonaws.com:8082/ambitus-ms/eventos/meuseventos";
        string token = ConfigurationManager.AppSettings["APIToken"];
        HttpClient httpClient = new();

        #endregion

        #region Methods

        public void Formatar_dgvEventos()
        {
            dgvEventos.Columns["titulo"].HeaderText = "Título";
            dgvEventos.Columns["tipo"].HeaderText = "Tipo";
            dgvEventos.Columns["descricao"].HeaderText = "Descrição";
            dgvEventos.Columns["data"].HeaderText = "Data";
            dgvEventos.Columns["titulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEventos.Columns["tipo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEventos.Columns["descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEventos.Columns["descricao"].MinimumWidth = 150;
        }

        private async void Popular_dgvEventos()
        {
            try
            {
                if (!headerFilled)
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", token);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    headerFilled = true;
                }

                var response = await httpClient.GetAsync(urlEventos);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    var eventos = JsonConvert.DeserializeObject<List<Dados_Evento>>(responseContent);

                    dgvEventos.DataSource = eventos.Select(e => new
                    {
                        e.titulo,
                        e.tipo,
                        e.descricao,
                        e.data
                    }).ToList();

                    Formatar_dgvEventos();
                }
                else
                {
                    MessageBox.Show("Erro: " + response.ReasonPhrase, "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Events

        private void btnGerenciarEventos_Click(object sender, EventArgs e)
        {

        }

        private void btnCriarEvento_Click(object sender, EventArgs e)
        {
            Cadastro_de_Eventos cadEventos = new();
            cadEventos.Show();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            Popular_dgvEventos();
        }

        #endregion

        private void btnReload_Click(object sender, EventArgs e)
        {
            Popular_dgvEventos();
        }
    }
}
