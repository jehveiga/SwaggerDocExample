﻿using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwaggerDocExample.Dtos.ViewModels;
using SwaggerDocExample.Models;
using SwaggerDocExample.Util;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace SwaggerDocExample.Controllers.V1
{
    [Authorize]
    [ApiController]
    [ApiVersion("1", Deprecated = true)]
    [Route("[controller]/v{version:apiVersion}/")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class AlunosController : ControllerBase
    {
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<AlunoViewModel>))]
        [SwaggerOperation(Summary = "Obter todos os alunos", Description = "Retorna uma lista com todos os alunos")]
        public ActionResult ObterAlunos()
        {
            return Ok();
        }

        [HttpGet("{id:guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Aluno))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Obter aluno por id", Description = "Retorna um aluno conforme id informado no path")]
        public ActionResult ObterAlunoPorId(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(Aluno))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [SwaggerOperation(Summary = "Criar novo aluno", Description = "Valida e cria novo aluno no banco de dados.")]
        public ActionResult CriarNovoAluno(Aluno aluno)
        {
            return Ok();
        }

        [HttpPut("{id:guid}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [SwaggerOperation(Summary = "Atualizar aluno", Description = "Atualiza registro do aluno no banco de daddos.")]
        public ActionResult AtualizarAluno(Guid id, Aluno aluno)
        {
            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [SwaggerOperation(Summary = "Atualizar RA", Description = "Atualiza número do RA do aluno.")]
        public ActionResult AtualizarRa(Guid id, [FromQuery] string ra)
        {
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [SwaggerOperation(Summary = "Deletar aluno por id", Description = "Remove registro do aluno do id informado")]
        public ActionResult DeletarAluno(Guid id)
        {
            return NoContent();
        }
    }
}
