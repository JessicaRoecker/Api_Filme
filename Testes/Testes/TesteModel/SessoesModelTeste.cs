using System;
using Api_Filme.Domain.Model;
using NUnit;
using Org.BouncyCastle.Security;

public class SessoesModelTests
{
    private SessoesModel sessao;

    public SessoesModelTests()
    {
        
        sessao = new SessoesModel();
    }

    [Test]
    public void SessoesModel_DeveTerTodasPropriedades()
    {
        var sessao = typeof(SessoesModel);
        var propriedadesEsperadas = new List<string> {"Id", "Horario", "Assento", "IdFilme", "IdSala"};
        var propriedades = sessao.GetProperties().Select(p => p.Name).ToList();

        Assert.That(propriedades,Is.EquivalentTo(propriedadesEsperadas));//Verificar se existes todas as propriedades na classe SessoesModel
    }

    [Test]
    public void SessoesModel_DeveTerPropriedadeId()
    {
        // Act
        int id = sessao.Id;

        // Assert
        Assert.AreEqual(0, id);// verificando se inicializa com 0
    }

    [Test]
    public void SessoesModel_DeveTerPropriedadeHorario()
    {
        // Act
        DateTime horario = sessao.Horario;

        // Assert
        Assert.AreEqual(DateTime.MinValue, horario);// verificando se a inicialização padrão é DateTime.MinValue
    }

    [Test]
    public void SessoesModel_DeveTerPropriedadeAssento()
    {
        // Act
        string assento = sessao.Assento;


        // Assert
        Assert.Null(assento);// Verificando se inicializa com valor null
    }

    [Test]
    public void SessoesModel_DeveTerPropriedadeIdFilme()
    {
        // Act
        int idFilme = sessao.IdFilme;

        // Assert
        Assert.AreEqual(0, idFilme);// verificando se inicializa com 0
    }

    [Test]
    public void SessoesModel_DeveTerPropriedadeIdSala()
    {
        // Act
        int idSala = sessao.IdSala;

        // Assert
        Assert.AreEqual(0, idSala);// verificando se inicializa com 0
    }

}
