using ExpectedObjects;
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
            var cursoEsperado = new
            {
                Nome = (string)"Informática Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = (string)"Estudantes",
                Valor = (double)950
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
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
