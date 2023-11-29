﻿using Api_Filme.Domain.Model;

namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySala
{
    public interface ISalaAtualizaRepository
    {
        Task<bool> AtualizaSala(SalaModel salaModel, int id);
    }
}