using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;

namespace CSharpAutoMapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Aluno, AlunoViewItem>()
                    .ForMember(av => av.Endereco,
                        m => m.MapFrom(a => a.Endereco.Cidade + ", " + a.Endereco.Rua));
            });

            //Somente para ambiente de desenvolvimento, após remover código
            config.AssertConfigurationIsValid();

            var mapper = config.CreateMapper();

            Aluno aluno = new Aluno();

            aluno.Nome = "João Rafael";
            aluno.Email = "menezes.jrafael@gmail.com";
            aluno.Idade = 30;
            aluno.Genero = "Masculino";
            aluno.Nascimento = DateTime.Now;
            
            Endereco endereco = new Endereco();

            endereco.Rua = "Laudelino Freire";
            endereco.Cidade = "Porto Alegre";
            endereco.Cep = "92120400";
            endereco.Pais = "Brasil";

            aluno.Endereco = endereco;

            AlunoViewItem _alunoViewItem = mapper.Map<Aluno, AlunoViewItem>(aluno);

            listBox1.Items.Add(_alunoViewItem.Nome);
            listBox1.Items.Add(_alunoViewItem.Endereco);
            listBox1.Items.Add(_alunoViewItem.Nascimento);
            listBox1.Items.Add(_alunoViewItem.Email);
            listBox1.Items.Add(_alunoViewItem.Genero);
            listBox1.Items.Add(_alunoViewItem.Idade);
        }
    }
}