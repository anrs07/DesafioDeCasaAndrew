﻿using DesafioDeCasa.Models;
using DesafioDeCasa.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDeCasa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LojasController
    {
        protected LojaService _lojaService;

        public LojasController([FromServices] LojaService lojaService)
        {
            _lojaService = lojaService;
        }

        // GET: Lojas
        [HttpGet("{id}/PagarPessoa/{id}/{valor}")]
        public string PagarPessoa()
        {
            return "Opção não disponível para Lojas";
        }

        // GET: Lojas
        [HttpGet("{id}/PagarLoja/{id}/{valor}")]
        public string PagarLoja()
        {
            return "Opção não disponível para Lojas";
        }

        // GET: Lojas
        [HttpGet("")]
        public IEnumerable<Loja> GetAll()
        {
            return _lojaService.GetAll();
        }

        // GET: Lojas/id 
        [HttpGet("{id}")]
        public ActionResult<Loja> Get(long id)
        {
            return _lojaService.Get(id);
        }

        // POST: Lojas/Remover/id
        [HttpPost("Remover/{id}")]
        public ActionResult<Loja> Remover(long id)
        {
            return _lojaService.Remover(id);
        }

        // GET: Lojas/Atualizar/id
        [HttpPost("Atualizar/{id}")]
        public ActionResult<Loja> Atualizar(long id, [Bind("cnpj,email,nome,senha,saldo")][FromBody] Loja loja)
        {
            return _lojaService.Atualizar(id, loja);
        }

        // POST: Lojas
        // Bind para proteger de 'Overposting Attacks'
        [HttpPost("")]
        public ActionResult<Loja> Post([Bind("cnpj,email,nome,senha,saldo")][FromBody] Loja loja)
        {
            //if (ModelState.IsValid)
            //{

                Loja lojaCadastrada = _lojaService.AdicionarLoja(loja);

                if (lojaCadastrada != null)
                {
                    return lojaCadastrada;
                }

            //Biblioteca não está pegando a versão corretamente
            return null;
                //else
                //{
                //    return BadRequest(ModelState);
                //}

                // TODO: Rever retorno caso não 
            //}
            //else
            //{
            //    return BadRequest(ModelState);
            //}
        }

    }
}
