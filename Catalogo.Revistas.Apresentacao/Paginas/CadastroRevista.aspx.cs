using Catalogo.Revistas.Biblioteca.Entities;
using Catalogo.Revistas.Biblioteca.Repository.Util;
using Catalogo.Revistas.Biblioteca.Service;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo.Revistas.Apresentacao.Paginas
{
    public partial class CadastroRevista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (ISession session = HibernateUtil.AbrirSession())
                {
                    RevistaService revistaService = new RevistaService(session);
                    RevistasGridView.DataSource = revistaService.ListarTudo();
                    RevistasGridView.DataBind();
                }
            }
        }

        protected void GravarButton_Click(object sender, EventArgs e)
        {
            using (ISession session = HibernateUtil.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        RevistaService revistaService = new RevistaService(session);
                        if (IdHiddenField.Value == null || IdHiddenField.Value.Equals(""))
                        {
                            Revista revista = new Revista()
                            {
                                Titulo = TituloTextBox.Text,
                                SubTitulo = SubTituloTextBox.Text,
                                Arco = ArcoTextBox.Text,
                                Ano = Convert.ToInt32(AnoTextBox.Text),
                                Valor = Convert.ToDouble(ValorTextBox.Text)
                            };
                            revistaService.CadastrarRevista(revista);
                            transacao.Commit();
                        }
                        else
                        {
                            Revista revista = new Revista()
                            {
                                Id = Convert.ToInt32(IdHiddenField.Value),
                                Titulo = TituloTextBox.Text,
                                SubTitulo = SubTituloTextBox.Text,
                                Arco = ArcoTextBox.Text,
                                Ano = Convert.ToInt32(AnoTextBox.Text),
                                Valor = Convert.ToDouble(ValorTextBox.Text)
                            };
                            revistaService.EditarRevista(revista);
                            transacao.Commit();
                            Limpar();
                        }
                        RevistasGridView.DataSource = revistaService.ListarTudo();
                        RevistasGridView.DataBind();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw;
                    }
                }
            }
        }

        protected void RevistasGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            using (ISession session = HibernateUtil.AbrirSession())
            {
                RevistaService revistaService = new RevistaService(session);
                int id = Convert.ToInt32(RevistasGridView.DataKeys[e.NewSelectedIndex].Value.ToString());
                Revista revista = revistaService.BuscatPorId(id);
                IdHiddenField.Value = Convert.ToString(revista.Id);
                TituloTextBox.Text = revista.Titulo;
                SubTituloTextBox.Text = revista.SubTitulo;
                ArcoTextBox.Text = revista.Arco;
                AnoTextBox.Text = Convert.ToString(revista.Ano);
                ValorTextBox.Text = Convert.ToString(revista.Valor);
            }
        }

        protected void RevistasGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (ISession session = HibernateUtil.AbrirSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        RevistaService revistaService = new RevistaService(session);
                        int id = Convert.ToInt32(RevistasGridView.DataKeys[e.RowIndex].Value.ToString());
                        revistaService.DeletarRevista(revistaService.BuscatPorId(id));
                        transaction.Commit();
                        RevistasGridView.DataSource = revistaService.ListarTudo();
                        RevistasGridView.DataBind();
                    }
                    catch (Exception ex)
                    {
                        if (!transaction.WasCommitted)
                        {
                            transaction.Rollback();
                        }
                        throw;
                    }
                }

            }
        }

        private void Limpar()
        {
            IdHiddenField.Value = null;
            TituloTextBox.Text = null;
            SubTituloTextBox.Text = null;
            ArcoTextBox.Text = null;
            AnoTextBox.Text = null;
            ValorTextBox.Text = null;
        }

    }
}