using ChallengeLocaweb.Data.Repository;
using ChallengeLocaweb.Models;

namespace ChallengeLocaweb.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _repository;
        public ContatoService(IContatoRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<ContatoModel> ListarContatos() => _repository.GetAll();
        public ContatoModel ObterContatoPorId(int id) => _repository.GetById(id);
        public void CriarContato(ContatoModel contato) => _repository.Add(contato);        
        public void AtualizarContato(ContatoModel contato) => _repository.Update(contato);
        public void DeletarContato(int id)
        {
            var contato = _repository.GetById(id);
            if (contato != null)
            {
                _repository.Delete(contato);
            }
        }
    }
}