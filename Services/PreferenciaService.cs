using ChallengeLocaweb.Data;
using ChallengeLocaweb.Models;
using ChallengeLocaweb.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class PreferenciaService : IPreferenciaService
{
    private readonly DatabaseContext _contexto;

    public PreferenciaService(DatabaseContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<PreferenciaModel> ObterPreferenciaPorId(int usuarioId)
    {
        return await _contexto.Preferencias
            .Where(p => p.UsuarioID == usuarioId)
            .FirstOrDefaultAsync();
    }

    public async Task<PreferenciaModel> SalvarPreferencia(PreferenciaModel preferencia)
    {
        var preferenciasExistentes = await _contexto.Preferencias
            .Where(p => p.UsuarioID == preferencia.UsuarioID)
            .FirstOrDefaultAsync();

        if (preferenciasExistentes != null)
        {
            preferenciasExistentes.Tema = preferencia.Tema;
            preferenciasExistentes.Cor = preferencia.Cor;
            preferenciasExistentes.Categoria = preferencia.Categoria;
            preferenciasExistentes.Etiqueta = preferencia.Etiqueta;

            _contexto.Preferencias.Update(preferenciasExistentes);
        }
        else
        {
            _contexto.Preferencias.Add(preferencia);
        }

        await _contexto.SaveChangesAsync();
        return preferencia;
    }

    public async Task AtualizarPreferencia(int usuarioId, PreferenciaModel preferencia)
    {
        if (usuarioId != preferencia.UsuarioID)
        {
            throw new ArgumentException("ID do usuário não corresponde");
        }

        _contexto.Entry(preferencia).State = EntityState.Modified;
        await _contexto.SaveChangesAsync();
    }

    public async Task ExcluirPreferencia(int usuarioId)
    {
        var preferencia = await _contexto.Preferencias
            .Where(p => p.UsuarioID == usuarioId)
            .FirstOrDefaultAsync();

        if (preferencia == null)
        {
            throw new KeyNotFoundException("Preferência não encontrada");
        }

        _contexto.Preferencias.Remove(preferencia);
        await _contexto.SaveChangesAsync();
    }

    public Task<PreferenciaModel> ObterPrefenciaPorId(int usuarioId)
    {
        throw new NotImplementedException();
    }
}
