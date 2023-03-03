using AutoMapper;
using SistemaVenda.Application.Extensions;
using SistemaVenda.Application.Interfaces;
using SistemaVenda.Domain.Interfaces;
using SistemaVenda.Domain.Models;
using System.Net;

namespace SistemaVenda.Application.Services
{
    public class AccountService : Service, IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository, IMapper mapper) : base(mapper)
        => _accountRepository = accountRepository;

        public async Task<OperationResult> GetUser(string userName)
        {
            var user = await _accountRepository.GetUserName(userName);

            if (user is null)
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            return Success(user);
        }

        public Task<OperationResult> Login(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> Register(User user)
        {
            var entity = await _accountRepository.GetUserName(user.Name);

            if (entity != null)
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            var senhaCriptografada = CalculaHash(user.Password);
            user.Password = senhaCriptografada;

            await _accountRepository.InsertAsync(user);

            return Success();
        }

        public Task<OperationResult> Update(int id)
        {
            throw new NotImplementedException();
        }

        public static string CalculaHash(string Senha)
        {
           
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(Senha);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString(); 
            
        }
    }
}
