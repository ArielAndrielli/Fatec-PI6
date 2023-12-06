﻿using Entidades;
using System.Configuration;
using System.Data;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Ambitus.Telas
{
    public partial class Cadastro_de_Eventos : Form
    {

        #region Constructor

        public Cadastro_de_Eventos()
        {
            InitializeComponent();

            dtpDataEvento.Format = DateTimePickerFormat.Time;
        }

        #endregion

        #region Attributes

        Dados_Evento evento = new();
        bool responseAwnser = false;
        string url = "http://ec2-18-223-44-43.us-east-2.compute.amazonaws.com:8082/ambitus-ms/eventos/cadastro";
        HttpClient httpClient = new();

        #endregion

        #region Load

        private void Cadastro_de_Eventos_Load(object sender, EventArgs e)
        {
            Popular_cbbTipos();

            dtpDataEvento.Format = DateTimePickerFormat.Custom;
            dtpDataEvento.CustomFormat = "dd/MM/yyyy hh:mm";
        }

        #endregion

        #region Methods

        public void Popular_cbbTipos()
        {
            DataTable table = new();
            table.Columns.Add(new DataColumn("Nome", typeof(string)));
            table.Columns.Add(new DataColumn("Valor", typeof(string)));

            table.Rows.Add("Reciclagem", "RECICLAGEM");
            table.Rows.Add("Limpeza de Ambientes", "LIMPEZA_DE_AMBIENTES");
            table.Rows.Add("Reflorestamento", "REFLORESTAMENTO");
            table.Rows.Add("Concientização e Educação", "CONCIENTIZACAO_E_EDUCACAO");
            table.Rows.Add("Conservação", "CONSERVACAO");

            cbbTipos.DataSource = table;

            cbbTipos.DisplayMember = "Nome";
            cbbTipos.ValueMember = "Valor";
        }

        public bool Preencher_Campos()
        {
            evento.titulo = txtNomeEvento.Text;
            evento.descricao = txtDescricaoEvento.Text;
            evento.local = txtEnderecoEvento.Text;
            evento.data = dtpDataEvento.Text.Substring(0, 10);
            evento.hora = dtpDataEvento.Text.Substring(11);
            evento.tipo = cbbTipos.SelectedValue.ToString();

            if (evento.titulo == string.Empty ||
                evento.descricao == string.Empty ||
                evento.local == string.Empty ||
                evento.data == string.Empty ||
                evento.hora == string.Empty ||
                evento.tipo == string.Empty)
            {
                MessageBox.Show("Um ou mais campos não foram preenchidos!", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        public void Preencher_ImagemEvento(string base64)
        {
            evento.imagem = base64;

            if (base64 == string.Empty)
            {
                MessageBox.Show("Houve um problema ao tentar adicionar a imagem!", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public static string ConvertImageToBase64(string caminho)
        {
            try
            {
                byte[] bytes = File.ReadAllBytes(caminho);
                string base64 = Convert.ToBase64String(bytes);

                return base64;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao converter imagem para Base64: " + ex.Message);
                return null;
            }
        }

        #endregion

        private void pbImgEvento_Click(object sender, EventArgs e)
        {
            ofdEvento.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofdEvento.ShowDialog() == DialogResult.OK)
            {
                string caminho = ofdEvento.FileName;
                string base64 = ConvertImageToBase64(caminho);
                byte[] bytes = File.ReadAllBytes(caminho);

                Preencher_ImagemEvento(base64);

                using (MemoryStream ms = new(bytes))
                {
                    Image image = Image.FromStream(ms);
                    pbImgEvento.Image = image;
                    pbImgEvento.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void ckbCupom_CheckedChanged(object sender, EventArgs e)
        {
            pnCupom.Enabled = ckbCupom.Checked;
        }

        private async void btnCriarEvento_Click(object sender, EventArgs e)
        {
            try
            {
                if (Preencher_Campos())
                {
                    using (httpClient)
                    {
                        var data = new
                        {
                            evento.titulo,
                            evento.descricao,
                            evento.local,
                            evento.data,
                            evento.hora,
                            evento.tipo,
                            evento.imagem
                        };

                        var jsonData = JsonSerializer.Serialize(data);

                        string token = ConfigurationManager.AppSettings["APIToken"];

                        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        httpClient.DefaultRequestHeaders.Add("Authorization", token);
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        
                        var response = await httpClient.PostAsync(url, new StringContent(jsonData, Encoding.UTF8, "application/json"));

                        responseAwnser = response.IsSuccessStatusCode;

                    }

                        if (responseAwnser)
                        {
                            MessageBox.Show("Evento cadastrado com sucesso!", "Sucesso", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao criar o evento!", "Erro", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }
    }
}
