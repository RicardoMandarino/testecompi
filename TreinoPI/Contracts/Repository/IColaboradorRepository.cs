﻿using TreinoPI.DTO;
using TreinoPI.Entity;

namespace TreinoPI.Contracts.Repository
{
    public interface IColaboradorRepository
    {
        Task Add(ColaboradorDTO colaborador);
        Task Update(ColaboradorDTO colaborador);
        Task Delete(string email);
        Task<IEnumerable<ColaboradorEntity>> Get();
        Task<UserLoginDTO> GetByEmail(string email);

        Task<UserTokenDTO> LogIn(UserLoginDTO user);
    }
}
