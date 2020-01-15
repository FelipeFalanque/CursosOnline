using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.Dominio.Test.Cursos
{
    public class CursoTest
    {
        [Fact]
        public void DeveCriarUmCurso()
        {
            const string nome = "Informática Básica";
            const double cargaHoraria = 80;
            const string publicoAlvo = "Estudantes";
            const double valor = 950;

            var curso = new Curso(nome, cargaHoraria, publicoAlvo, valor);

            Assert.Equal(nome, curso.Nome);
            Assert.Equal(valor, curso.Valor);
        }
    }

    public class Curso
    {
        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public string PublicoAlvo { get; private set; }
        public double Valor { get; private set; }

        public Curso(string nome, double cargaHoraria, string publicoAlvo, double valor)
        {
            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.Valor = valor;
        }
    }
}
