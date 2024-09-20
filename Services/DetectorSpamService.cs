using ChallengeLocaweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeLocaweb.Services
{
    // Detecção de padrões de envio que podem ser considerados Spam.

    public class DetectorSpamService : IDetectorSpamService
    {
        private List<string> _detectorSpam;
        private List<string> _palavrasChaveSpam;
        private Dictionary<string, List<DateTime>> _historicoEnvios; 
        private const int LimiteEnviosPorMinuto = 10;

        public DetectorSpamService()
        {
            _detectorSpam = new List<string>();
            _palavrasChaveSpam = new List<string> { "grátis", "ganhe", "dinheiro", "crédito", "loteria" };
            _historicoEnvios = new Dictionary<string, List<DateTime>>();
        }

        public bool EhSpam(EmailModel mensagem)
        {
            if (_detectorSpam.Contains(mensagem.Remetente.ToLower()))
            {
                return true;
            }

            foreach (var palavra in _palavrasChaveSpam)
            {
                if (mensagem.Assunto.ToLower().Contains(palavra) || mensagem.Texto.ToLower().Contains(palavra))
                {
                    return true;
                }
            }

            if (VerificarEnviosEmMassa(mensagem.Remetente))
            {
                return true;
            }

            return false;
        }
        
        private bool VerificarEnviosEmMassa(string remetente)
        {
            int LimiteEnviosPorMinuto = 10;
            string remetenteLower = remetente.ToLower();

            if (!_historicoEnvios.ContainsKey(remetenteLower))
            {
                _historicoEnvios[remetenteLower] = new List<DateTime>();
            }

            _historicoEnvios[remetenteLower].Add(DateTime.Now);

            _historicoEnvios[remetenteLower] = _historicoEnvios[remetenteLower]
                .Where(envio => (DateTime.Now - envio).TotalMinutes <= 1).ToList();

            if (_historicoEnvios[remetenteLower].Count > LimiteEnviosPorMinuto)
            {
                return true;
            }

            return false;
        }

        public void AddCaixaSpam(string enderecoEmail)
        {
            if (!_detectorSpam.Contains(enderecoEmail.ToLower()))
            {
                _detectorSpam.Add(enderecoEmail.ToLower());
            }
        }

        public void RemoverCaixaSpam(string enderecoEmail)
        {
            if (_detectorSpam.Contains(enderecoEmail.ToLower()))
            {
                _detectorSpam.Remove(enderecoEmail.ToLower());
            }
        }

        public List<string> GetCaixaSpam()
        {
            return _detectorSpam;
        }
    }
}
