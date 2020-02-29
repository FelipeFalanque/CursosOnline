using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.Dominio.Test.Cursos
{
    public class CursoTest
    {
        public const string NomeInvalido = "Nome Inválido";
        public const string CargaHorariaInvalida = "Carga Horaria Inválida";
        public const string ValorInvalido = "Valor Inválido";

        [Fact]
        public void DeveCriarUmCurso()
        {
            var cursoEsperado = new
            {
                Nome = (string)"Informática Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CursoNaoDeveTerNomeInvalido(string nomeInvalido)
        {
            var cursoEsperado = new
            {
                Nome = (string)"Informática Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950
            };

            var message =
                Assert
                .Throws<ArgumentException>(() => new Curso(nomeInvalido, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .Message;

            Assert.Equal(message, NomeInvalido);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.5)]
        [InlineData(-2)]
        [InlineData(double.MinValue)]
        public void CursoNaoDeveTerCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            var cursoEsperado = new
            {
                Nome = (string)"Informática Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950
            };

            var message =
                Assert
                .Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cargaHorariaInvalida, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .Message;

            Assert.Equal(message, CargaHorariaInvalida);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.5)]
        [InlineData(-2)]
        [InlineData(double.MinValue)]
        public void CursoNaoDeveTerValorMenorQue1(double valorInvalido)
        {
            var cursoEsperado = new
            {
                Nome = (string)"Informática Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950
            };

            var message =
                Assert
                .Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, valorInvalido))
                .Message;

            Assert.Equal(message, ValorInvalido);
        }
    }

    public enum PublicoAlvo
    {
        Estudante,
        Universitário,
        Empregado,
        Empreendedor
    }

    public class Curso
    {
        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }

        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException(CursoTest.NomeInvalido);

            if (cargaHoraria < 1)
                throw new ArgumentException(CursoTest.CargaHorariaInvalida);

            if (valor < 1)
                throw new ArgumentException(CursoTest.ValorInvalido);

            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.Valor = valor;
        }
    }
}
